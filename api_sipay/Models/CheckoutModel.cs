namespace ApiSipay.Models
{
    public class CheckoutModel
    {
        public string CCHolderName { private get; set; }
        public string CCNo { private get; set; }
        public string ExpiryMonth { private get; set; }
        public string ExpiryYear { private get; set; }
        public string CCV { private get; set; }

    }
}