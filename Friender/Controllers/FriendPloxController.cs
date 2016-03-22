using System.Net;
using System.Net.Http;
using System.Web.Http;
using com.esendex.sdk.messaging;
using Friender.Models;
using Microsoft.Azure;

namespace Friender.Controllers
{
    public class FriendPloxController : ApiController
    {
        public HttpResponseMessage Post(FriendRequest request)
        {
            var messagingService = new MessagingService(CloudConfigurationManager.GetSetting("esendexUser"), CloudConfigurationManager.GetSetting("esendexPassword"));

            var message = string.Format("Hello, {0} wants to be your friend! Go to Goldfish and enter the friend code: {1} to become friends today!", request.Name, request.Code);
            var sms = new SmsMessage(request.MobileNumber, message, CloudConfigurationManager.GetSetting("esendexReference"));

            messagingService.SendMessage(sms);

            return Request.CreateResponse(HttpStatusCode.OK);
        }
    }
}