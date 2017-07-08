using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using System.Web.Http.Results;

namespace FactFinder.Common.Response
{
    public abstract class CustomResult : ActionResult
    {
        public abstract HttpStatusCode StatusCode();

        protected HttpResponseMessage BuildMessage()
        {
            HttpStatusCode code = this.StatusCode();
            return BuildMessage(code);
        }

        protected virtual HttpResponseMessage BuildMessage(HttpStatusCode code)
        {
            return new HttpResponseMessage(code);
        }

        public IHttpActionResult BuildResult()
        {
            HttpResponseMessage message = BuildMessage();
            return new ResponseMessageResult(message);
        }
    }

    public class NoContent : CustomResult
    {
        public override HttpStatusCode StatusCode()
        {
            return HttpStatusCode.NoContent;
        }

        public static IHttpActionResult Build()
        {
            return new NoContent().BuildResult();
        }
    }
}