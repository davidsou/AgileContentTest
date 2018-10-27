using AgileContentTestDomain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;

namespace AgileContentService.Controller
{
    public class BaseController:ApiController
    {
        protected async Task<IHttpActionResult> Fail( List<string> messages)
        {           

            return Ok(new { Success = false, Messages = messages } );
        }

        protected async Task<IHttpActionResult> Success(List<string> message = null)
        {
            return Ok(new { Success = true, Messages = message });
        }

        protected async Task<IHttpActionResult> Success<T>(T data, List<string> message = null)
        {

            return Ok(new { Success = true, Data = data, Messages = message });
        }
    }
}
