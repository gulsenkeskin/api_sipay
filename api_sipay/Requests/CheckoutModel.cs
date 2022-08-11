using ApiSipay.Models;
using ApiSipay.Responses;

namespace ApiSipay.Requests
{
    public class CheckoutModel
    {
        public string CardHolderName { get; set; }
        public string CardNumber { get; set; }
        public string ExpireMonth { get; set; }
        public string ExpireYear { get; set; }
        public string CardCode { get; set; }
        public PaymentType Is3D { get; set; }
        public PosData SelectedPosData { get; set; }

    }
}