using ApiSipay.Models;
using ApiSipay.Responses;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace ApiSipay.Requests
{
    public class Sipay3DPaymentRequest
    {

        [JsonPropertyName("PosId")]
        public string PosId {  get; set; }

        [JsonPropertyName("CCHolderName")]
        public string CCHolderName {  get; set; }

        [JsonPropertyName("CCNo")]
        public string CCNo {  get; set; }

        [JsonPropertyName("ExpiryMonth")]
        public string ExpiryMonth {  get; set; }

        [JsonPropertyName("ExpiryYear")]
        public string ExpiryYear {  get; set; }

        [JsonPropertyName("CCV")]
        public string CCV {  get; set; }

        [JsonPropertyName("CurrencyId")]
        public string CurrencyId {  get; set; }

        [JsonPropertyName("CurrencyCode")]
        public string CurrencyCode {  get; set; }

        [JsonPropertyName("CampaignId")]
        public string CampaignId {  get; set; }

        [JsonPropertyName("AllocationId")]
        public string AllocationId {  get; set; }

        [JsonPropertyName("InstallmentsNumber")]
        public int InstallmentsNumber {  get; set; }

        [JsonPropertyName("ReturnUrl")]
        public string ReturnUrl {  get; set; }

        [JsonPropertyName("CancelUrl")]
        public string CancelUrl { get; set; }

        [JsonPropertyName("InvoiceId")]
        public string InvoiceId {  get; set; }

        [JsonPropertyName("InvoiceDescription")]
        public string InvoiceDescription {  get; set; }

        [JsonPropertyName("Total")]
        public decimal Total {  get; set; }

        [JsonPropertyName("PayableAmount")]
        public decimal PayableAmount {  get; set; }

        [JsonPropertyName("PosAmount")]
        public string PosAmount {  get; set; }

        [JsonPropertyName("Name")]
        public string Name {  get; set; }

        [JsonPropertyName("SurName")]
        public string SurName {  get; set; }

        [JsonPropertyName("Discount")]
        public string Discount {  get; set; }

        [JsonPropertyName("Coupon")]
        public string Coupon {  get; set; }

        [JsonPropertyName("Items")]
        public List<Item> Items { get; set; }

        [JsonPropertyName("BillingAddress1")]
        public string BillingAddress1 {  get; set; }

        [JsonPropertyName("BillingAddress2")]
        public string BillingAddress2 {  get; set; }

        [JsonPropertyName("BillingCity")]
        public string BillingCity {  get; set; }

        [JsonPropertyName("BillingPostcode")]
        public string BillingPostcode {  get; set; }

        [JsonPropertyName("BillingState")]
        public string BillingState {  get; set; }

        [JsonPropertyName("BillingCountry")]
        public string BillingCountry {  get; set; }

        [JsonPropertyName("BillingEmail")]
        public string BillingEmail {  get; set; }

        [JsonPropertyName("BillingPhone")]
        public string BillingPhone {  get; set; }

        [JsonPropertyName("IsRecurringPayment")]
        public bool IsRecurringPayment {  get; set; }

        [JsonPropertyName("RecurringPaymentNumber")]
        public int RecurringPaymentNumber {  get; set; }

        [JsonPropertyName("RecurringPaymentCycle")]
        public string RecurringPaymentCycle {  get; set; }

        [JsonPropertyName("RecurringPaymentInterval")]
        public int RecurringPaymentInterval {  get; set; }

        [JsonPropertyName("RecurringWebhookKey")]
        public string RecurringWebhookKey {  get; set; }

        [JsonPropertyName("HashKey")]
        public string HashKey {  get; set; }

        public Settings _settings { get; set; }

        //private string pos_id { get { return this.PosId; } }
        //private string cc_holder_name { get { return this.CCHolderName; } }
        //private string cc_no { get { return this.CCNo; } }
        //private string expiry_month { get { return this.ExpiryMonth; } }
        //private string expiry_year { get { return this.ExpiryYear; } }
        //private string cvv { get { return this.CCV; } }
        //private string currency_id { get { return this.CurrencyId; } }
        //private string currency_code { get { return this.CurrencyCode; } }
        //private string campaign_id { get { return this.CampaignId; } }
        //private string allocation_id { get { return this.AllocationId; } }
        //private string installments_number { get { return this.InstallmentsNumber.ToString(); } }
        //private string return_url { get { return this.ReturnUrl; } }
        //private string cancel_url { get { return this.CancelUrl; } }
        //private string invoice_id { get { return this.InvoiceId; } }
        //private string invoice_description { get { return this.InvoiceDescription; } }
        //private string total { get { return Total.ToString("0.00").Replace(",", "."); } }
        //private string payable_amount { get { return PayableAmount.ToString("0.00").Replace(",", "."); } }
        //private List<Item> items { get { return this.Items; } }
        //private string name { get { return this.Name; } }
        //private string surname { get { return this.SurName; } }
        //public string discount { get { return this.Discount; } }
        //public string coupon { get { return this.Coupon; } }
        //public string bill_address1 { get { return this.BillingAddress1; } }
        //public string bill_address2 { get { return this.BillingAddress2; } }
        //public string bill_city { get { return this.BillingCity; } }
        //public string bill_postcode { get { return this.BillingPostcode; } }
        //public string bill_state { get { return this.BillingState; } }
        //public string bill_country { get { return this.BillingCountry; } }
        //public string bill_email { get { return this.BillingEmail; } }
        //public string bill_phone { get { return this.BillingPhone; } }
        //public int order_type { get { return this.IsRecurringPayment ? 1 : 0; } }
        //public int recurring_payment_number { get { return this.RecurringPaymentNumber; } }
        //public string recurring_payment_cycle { get { return this.RecurringPaymentCycle; } }
        //public int recurring_payment_interval { get { return this.RecurringPaymentInterval; } }
        //public string recurring_web_hook_key { get { return this.RecurringWebhookKey; } }
        //public string hash_key { get { return this.HashKey; } }

        public Sipay3DPaymentRequest(Settings settings, CheckoutModel  model, string baseUrl)
        {
            this._settings = settings;
            this.Items = new List<Item>();
            this.AllocationId = model.SelectedPosData.allocation_id;
            this.CampaignId = model.SelectedPosData.campaign_id;
            this.PosId = model.SelectedPosData.pos_id;
            this.PayableAmount = model.SelectedPosData.amount_to_be_paid;
            this.Total = model.SelectedPosData.amount_to_be_paid;
            this.InstallmentsNumber = model.SelectedPosData.installments_number;
            this.CurrencyCode = model.SelectedPosData.currency_code;
            this.CurrencyId = model.SelectedPosData.currency_id;
            this.HashKey = model.SelectedPosData.hash_key;

            this.CCNo = model.CardNumber.Replace(" ", "");
            this.CCHolderName = model.CardHolderName;
            this.CCV = model.CardCode;
            this.ExpiryYear = model.ExpireYear.ToString();
            this.ExpiryMonth = model.ExpireMonth.ToString();
            this.InvoiceDescription = "";
            Random rnd = new Random();
            int num = rnd.Next();
            this.InvoiceId = num.ToString();
            this.ReturnUrl = baseUrl + "/Checkout/SuccessUrl";
            this.CancelUrl = baseUrl + "/Checkout/CancelUrl";
        }

    }

}
