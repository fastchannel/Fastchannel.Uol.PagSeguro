﻿// Copyright [2011] [PagSeguro Internet Ltda.]
//
//   Licensed under the Apache License, Version 2.0 (the "License");
//   you may not use this file except in compliance with the License.
//   You may obtain a copy of the License at
//
//       http://www.apache.org/licenses/LICENSE-2.0
//
//   Unless required by applicable law or agreed to in writing, software
//   distributed under the License is distributed on an "AS IS" BASIS,
//   WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
//   See the License for the specific language governing permissions and
//   limitations under the License.

using System.Collections.Generic;
using Uol.PagSeguro.Domain;
using Uol.PagSeguro.Util;
using Uol.PagSeguro.Constants.PreApproval;
using Uol.PagSeguro.Constants;

namespace Uol.PagSeguro.Parse
{
    /// <summary>
    /// 
    /// </summary>
    internal static class PaymentParse
    {
        public static IDictionary<string, string> GetData(PaymentRequest payment)
        {
            IDictionary<string, string> data = new Dictionary<string, string>();

            // reference
            if (payment.Reference != null)
                data["reference"] = payment.Reference;

            // sender
            if (payment.Sender != null)
            {
                if (payment.Sender.Name != null)
                    data["senderName"] = payment.Sender.Name;

                if (payment.Sender.Email != null)
                    data["senderEmail"] = payment.Sender.Email;

                // phone
                if (payment.Sender.Phone != null)
                {
                    if (payment.Sender.Phone.AreaCode != null)
                        data["senderAreaCode"] = payment.Sender.Phone.AreaCode;

                    if (payment.Sender.Phone.Number != null)
                        data["senderPhone"] = payment.Sender.Phone.Number;
                }

                // documents
                if (payment.Sender.Documents != null)
                {
                    foreach (var document in payment.Sender.Documents)
                    {
                        if (document == null)
                            continue;

                        if (document.Type.Equals("Cadastro de Pessoa Física"))
                            data["senderCPF"] = document.Value;
                        else
                            data["senderCNPJ"] = document.Value;
                    }
                }
            }

            // currency
            if (payment.Currency != null)
                data["currency"] = payment.Currency;

            // items
            if (payment.Items != null && payment.Items.Count > 0)
            {
                var i = 0;
                foreach (var item in payment.Items)
                {
                    i++;

                    if (item.Id != null)
                        data["itemId" + i] = item.Id;

                    if (item.Description != null)
                        data["itemDescription" + i] = item.Description;

                    data["itemQuantity" + i] = item.Quantity.ToString();
                    data["itemAmount" + i] = PagSeguroUtil.DecimalFormat(item.Amount);

                    if (item.Weight.HasValue)
                        data["itemWeight" + i] = item.Weight.ToString();

                    if (item.ShippingCost.HasValue)
                        data["itemShippingCost" + i] = PagSeguroUtil.DecimalFormat(item.ShippingCost.Value);
                }
            }

            //preApproval
            if (payment.PreApproval != null)
            {
                data["preApprovalCharge"] = payment.PreApproval.Charge;
                data["preApprovalName"] = payment.PreApproval.Name;
                data["preApprovalDetails"] = payment.PreApproval.Details;
                data["preApprovalPeriod"] = payment.PreApproval.Period;
                data["preApprovalFinalDate"] = payment.PreApproval.FinalDate.ToString("yyyy-MM-dd") + "T01:00:00.45-03:00";
                data["preApprovalMaxTotalAmount"] = payment.PreApproval.MaxTotalAmount.ToString("F").Replace(",", ".");
                data["preApprovalAmountPerPayment"] = payment.PreApproval.AmountPerPayment.ToString("F").Replace(",", ".");

                if (payment.PreApproval.Charge == Charge.Manual)
                {
                    data["preApprovalInitialDate"] = payment.PreApproval.InitialDate.ToString("yyyy-MM-dd") + "T01:00:00.45-03:00";
                    data["preApprovalMaxAmountPerPeriod"] = payment.PreApproval.MaxAmountPerPeriod.ToString("F").Replace(",", ".");
                    data["preApprovalMaxPaymentsPerPeriod"] = payment.PreApproval.MaxPaymentsPerPeriod.ToString();

                    if (payment.PreApproval.Period == Period.Yearly)
                        data["preApprovalDayOfYear"] = payment.PreApproval.DayOfYear.ToString();

                    if (payment.PreApproval.Period == Period.Monthly ||
                        payment.PreApproval.Period == Period.Bimonthly ||
                        payment.PreApproval.Period == Period.Trimonthly ||
                        payment.PreApproval.Period == Period.SemiAnnually)
                        data["preApprovalDayOfMonth"] = payment.PreApproval.DayOfMonth.ToString();

                    if (payment.PreApproval.Period == Period.Weekly)
                        data["preApprovalDayOfWeek"] = payment.PreApproval.DayOfWeek.ToString();
                }

                if (payment.ReviewUri != null)
                    data["reviewUrl"] = payment.ReviewUri.ToString();
            }

            //preApproval payment
            if (payment.PreApprovalCode != null)
                data["preApprovalCode"] = payment.PreApprovalCode;

            // extraAmount
            if (payment.ExtraAmount.HasValue)
                data["extraAmount"] = PagSeguroUtil.DecimalFormat(payment.ExtraAmount.Value);

            // shipping
            if (payment.Shipping != null)
            {
                if (payment.Shipping.ShippingType.HasValue)
                    data["shippingType"] = payment.Shipping.ShippingType.Value.ToString();

                if (payment.Shipping.Cost.HasValue)
                    data["shippingCost"] = PagSeguroUtil.DecimalFormat(payment.Shipping.Cost.Value);

                // address
                if (payment.Shipping.Address != null)
                {
                    if (payment.Shipping.Address.Street != null)
                        data["shippingAddressStreet"] = payment.Shipping.Address.Street;

                    if (payment.Shipping.Address.Number != null)
                        data["shippingAddressNumber"] = payment.Shipping.Address.Number;

                    if (payment.Shipping.Address.Complement != null)
                        data["shippingAddressComplement"] = payment.Shipping.Address.Complement;

                    if (payment.Shipping.Address.City != null)
                        data["shippingAddressCity"] = payment.Shipping.Address.City;

                    if (payment.Shipping.Address.State != null)
                        data["shippingAddressState"] = payment.Shipping.Address.State;

                    if (payment.Shipping.Address.District != null)
                        data["shippingAddressDistrict"] = payment.Shipping.Address.District;

                    if (payment.Shipping.Address.PostalCode != null)
                        data["shippingAddressPostalCode"] = payment.Shipping.Address.PostalCode;

                    if (payment.Shipping.Address.Country != null)
                        data["shippingAddressCountry"] = payment.Shipping.Address.Country;
                }
            }

            // maxAge
            if (payment.MaxAge.HasValue)
                data["maxAge"] = payment.MaxAge.ToString();

            // maxUses
            if (payment.MaxUses.HasValue)
                data["maxUses"] = payment.MaxUses.ToString();

            // redirectURL
            if (payment.RedirectUri != null)
                data["redirectURL"] = payment.RedirectUri.ToString();

            // notificationURL
            if (payment.NotificationUrl != null)
                data["notificationURL"] = payment.NotificationUrl;

            // metadata
            if (payment.MetaData != null && payment.MetaData.Items != null)
            {
                var i = 0;
                foreach (var item in payment.MetaData.Items)
                {
                    if (PagSeguroUtil.IsEmpty(item.Key) || PagSeguroUtil.IsEmpty(item.Value))
                        continue;

                    i++;
                    data["metadataItemKey" + i] = item.Key;
                    data["metadataItemValue" + i] = item.Value;

                    if (item.Group.HasValue)
                        data["metadataItemGroup" + i] = item.Group.ToString();
                }
            }

            // parameter
            if (payment.Parameter?.Items != null && payment.Parameter.Items.Count > 0)
            {
                foreach (var item in payment.Parameter.Items)
                {
                    if (PagSeguroUtil.IsEmpty(item.Key) || PagSeguroUtil.IsEmpty(item.Value))
                        continue;

                    if (item.Group.HasValue)
                        data[item.Key + "" + item.Group] = item.Value;
                    else
                        data[item.Key] = item.Value;
                }
            }

            // paymentMethodConfig 
            if (payment.PaymentMethodConfig?.Items != null && payment.PaymentMethodConfig.Items.Count > 0)
            {
                var i = 0;
                foreach (var item in payment.PaymentMethodConfig.Items)
                {
                    if (PagSeguroUtil.IsEmpty(item.Key) || PagSeguroUtil.IsEmpty(item.Group))
                        continue;

                    i++;
                    data["paymentMethodGroup" + i] = item.Group;
                    data["paymentMethodConfigKey" + i + "_1"] = item.Key;

                    if (item.Key.Equals(PaymentMethodConfigKeys.DiscountPercent))
                        data["paymentMethodConfigValue" + i + "_1"] = PagSeguroUtil.DecimalFormat(item.Value);
                    else
                        data["paymentMethodConfigValue" + i + "_1"] = PagSeguroUtil.DoubleToInt(item.Value);
                }
            }

            // acceptedPaymentMethods 
            if (payment.AcceptedPaymentMethods?.Items == null || payment.AcceptedPaymentMethods.Items.Count <= 0)
                return data;

            var acceptGroupList = new List<string>();
            var acceptNameList = new List<string>();
            var excludeGroupList = new List<string>();
            var excludeNameList = new List<string>();
            var config = payment.AcceptedPaymentMethods.Items;

            foreach (var item in config)
            {
                if (item.GetType() == typeof(AcceptPaymentMethod))
                {
                    if (!acceptGroupList.Contains(item.Group))
                        acceptGroupList.Add(item.Group);

                    acceptNameList = item.Name;
                }

                if (item.GetType() == typeof(ExcludePaymentMethod))
                {
                    if (!excludeGroupList.Contains(item.Group))
                        excludeGroupList.Add(item.Group);

                    excludeNameList = item.Name;
                }
            }

            if (acceptGroupList.Count > 0 && acceptNameList.Count > 0)
            {
                data["acceptPaymentMethodGroup"] = string.Join(",", acceptGroupList.ToArray());
                data["acceptPaymentMethodName"] = string.Join(",", acceptNameList.ToArray());
            }

            if (excludeGroupList.Count > 0 && excludeNameList.Count > 0)
            {
                data["excludePaymentMethodGroup"] = string.Join(",", excludeGroupList.ToArray());
                data["excludePaymentMethodName"] = string.Join(",", excludeNameList.ToArray());
            }

            return data;
        }
    }
}
