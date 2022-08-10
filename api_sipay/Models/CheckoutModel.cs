using ApiSipay.Responses;

namespace ApiSipay.Models
{
    public class CheckoutModel
    {
        public string CCHolderName { get; set; }
        public string CCNo {  get; set; }
        public string ExpiryMonth {  get; set; }
        public string ExpiryYear {  get; set; }
        public string CCV {  get; set; }
        public PaymentType Is3D { get; set; }
        public PosData SelectedPosData { get; set; }

    }
}