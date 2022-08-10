using ApiSipay.Extensions;
using ApiSipay.Models;
using ApiSipay.Requests;
using ApiSipay.Responses;
using ApiSipay.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiSipay.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CheckoutController : ControllerBase
    {
        private readonly ILogger<CheckoutController> _logger;
        private readonly IConfiguration _config;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public CheckoutController(ILogger<CheckoutController> logger, IConfiguration config,
   IHttpContextAccessor httpContextAccessor)
        {
            _logger = logger;
            _config = config;
            _httpContextAccessor = httpContextAccessor;
        } 

        //public IActionResult Index()
        //{
        //    return View();
        //}

        [HttpPost("index")]
        public async Task<IActionResult> Index([FromBody] CheckoutModel model)
        {
            Settings settings = new Settings();

            settings.AppID = _config["SIPAY:AppID"];
            settings.AppSecret = _config["SIPAY:AppSecret"];
            settings.MerchantKey = _config["SIPAY:MerchantKey"];
            settings.BaseUrl = _config["SIPAY:BaseUrl"];


            if (model.Is3D == PaymentType.WhiteLabel3D || model.Is3D == PaymentType.WhiteLabel2DOr3D)
            {
                Sipay3DPaymentRequest paymentRequest = new Sipay3DPaymentRequest(settings, model.SelectedPosData);

                paymentRequest.CCNo = model.CCNo.Replace(" ", "");
                paymentRequest.CCHolderName = model.CCHolderName;
                paymentRequest.CCV = model.CCV;
                paymentRequest.ExpiryYear = model.ExpiryYear.ToString();
                paymentRequest.ExpiryMonth = model.ExpiryMonth.ToString();
                paymentRequest.InvoiceDescription = "";
                Random rnd = new Random();
                int num = rnd.Next();
                paymentRequest.InvoiceId = num.ToString();

                string baseUrl = _httpContextAccessor.HttpContext.Request.Scheme + "://" + _httpContextAccessor.HttpContext.Request.Host.Value;
                paymentRequest.ReturnUrl = baseUrl + "/Checkout/SuccessUrl";
                paymentRequest.CancelUrl = baseUrl + "/Checkout/CancelUrl";

                string requestForm = paymentRequest.GenerateFormHtmlToRedirect(_config["SIPAY:BaseUrl"] + "/api/pay3d");

                var bytes = Encoding.UTF8.GetBytes(requestForm);
                await HttpContext.Response.Body.WriteAsync(bytes, 0, bytes.Length);

                //return View("Request3DSipay", requestForm);
            }

            //return View();
            return Ok();


        }

        [HttpPost("checkBinCode")]

        public ActionResult CheckBinCode([FromBody] string binCode)
        {
            if (binCode.Length >= 6)
            {
                Settings settings = new Settings();

                settings.AppID = _config["SIPAY:AppID"];
                settings.AppSecret = _config["SIPAY:AppSecret"];
                settings.MerchantKey = _config["SIPAY:MerchantKey"];
                settings.BaseUrl = _config["SIPAY:BaseUrl"];

                SipayGetPosRequest posRequest = new SipayGetPosRequest();

                posRequest.CreditCardNo = binCode;
                posRequest.Amount = 1;
                posRequest.CurrencyCode = "TRY";
                posRequest.IsRecurring = false;

                SipayGetPosResponse posResponse = SipayPaymentService.GetPos(posRequest, settings, GetAuthorizationToken(settings).Data.token);



                var data = posResponse.Data[0];
                posResponse.Data.Clear();
                posResponse.Data.Add(data);

                return Ok(new { posResponse = posResponse, is_3d = GetAuthorizationToken(settings).Data.is_3d });

            }

            return Ok();
        }

        [NonAction]
        public SipayTokenResponse GetAuthorizationToken(Settings settings)
        {
            if (HttpContext.Session.Get<SipayTokenResponse>("token") == default)
            {
                SipayTokenResponse tokenResponse = SipayPaymentService.CreateToken(settings);

                HttpContext.Session.Set<SipayTokenResponse>("token", tokenResponse);
            }

            return HttpContext.Session.Get<SipayTokenResponse>("token");
        }

        [HttpPost("successUrl")]
        public IActionResult SuccessUrl()
        {
            string sipay_status = HttpContext.Request.Query["sipay_status"];
            string order_no = HttpContext.Request.Query["order_no"];
            string invoice_id = HttpContext.Request.Query["invoice_id"];
            string status_description = HttpContext.Request.Query["status_description"];
            string sipay_payment_method = HttpContext.Request.Query["sipay_payment_method"];

            string fullQuery = " invoice_id : " + invoice_id
                 + "sipay_status :" + sipay_status + "order_no :" + order_no + "status_description :" + status_description
                 + "sipay_payment_method :" + sipay_payment_method;

            //ViewBag.SuccessMessage = fullQuery;

            //return View();
            return Ok(fullQuery);
        }


        [HttpPost("cancelUrl")]
        public IActionResult CancelUrl()
        {
            string error_code = HttpContext.Request.Query["error-code"];
            string error = HttpContext.Request.Query["error"];
            string invoice_id = HttpContext.Request.Query["invoice_id"];

            string sipay_status = HttpContext.Request.Query["sipay_status"];
            string order_no = HttpContext.Request.Query["order_no"];
            string status_description = HttpContext.Request.Query["status_description"];
            string sipay_payment_method = HttpContext.Request.Query["sipay_payment_method"];

            string fullQuery = "error_code : " + error_code + " invoice_id : " + invoice_id + " error : " + error
                 + "sipay_status :" + sipay_status + "order_no :" + order_no + "status_description :" + status_description
                 + "sipay_payment_method :" + sipay_payment_method;

            //ViewBag.Error = fullQuery;

            //return View();
            return Ok(fullQuery);

        }


    }
}
