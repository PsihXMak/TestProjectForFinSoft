using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Text;
using System.Collections.Specialized;

namespace WebApplicationFinSoft.Controllers
{
    public class SendController : Controller
    {
        // GET: send
        public string Index(string token, string user, string message)
        {

            var parameters = new NameValueCollection
            {
                { "token", token },
                { "user", user },
                { "message", message }
            };

            using (var client = new WebClient())
            {
                byte[] responsebytes =  client.UploadValues(@"http://api.pushover.net/1/messages.json", parameters);
                string response = Encoding.UTF8.GetString(responsebytes);

                return response;
            }
            
        }

        
    }
}