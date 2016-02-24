using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Mail;
using System.Web.Http;
using System.Web.Script.Serialization;
using WebApiPagingAngularClient.Models;

namespace WebApiPagingAngularClient.Controllers
{
    public class OrderController : ApiController
    {


        // POST: api/Order
        [HttpPost]
        public void Post([FromBody]OrderModels order)
        {
                     order.Date = DateTime.UtcNow.ToString();
                    var json = new JavaScriptSerializer().Serialize(order);

                    string subject = "NewOrder";
                    string body = json.ToString();
                    const string fromPassword = "qwerty12345678";
                    string fromAddress = "testvovnyanko@gmail.com";
                    string toAddress = " test1vovnyanko@gmail.com";

                    var smtp = new SmtpClient
                    {
                        Host = "smtp.gmail.com",
                        Port = 587,
                        EnableSsl = true,
                        DeliveryMethod = SmtpDeliveryMethod.Network,
                        Credentials = new NetworkCredential(fromAddress, fromPassword),
                        Timeout = 20000
                    };
                    using (var message = new MailMessage(fromAddress, toAddress)
                    {
                        Subject = subject,
                        Body = body
                    })
                    {
                        smtp.Send(message);
                    }
                } 
                    
          

       
    }
}
