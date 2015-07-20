using Innoventory.Lotus.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security;
using System.Web;
using System.Web.Http;

namespace Innoventory.Lotus.WebClient
{
    public class ApiControllerBase: ApiController 
    {
        protected HttpResponseMessage GetHttpResponse(HttpRequestMessage request, Func<HttpResponseMessage> codeToExecute)
        {
            HttpResponseMessage response = null;

            try
            {
                response = codeToExecute.Invoke();
            }
            catch(SecurityException ex)
            {
                response = request.CreateResponse(HttpStatusCode.Unauthorized, ex.Message);
            }
            catch(Exception ex)
            {
                response = request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
            }

            return response;
        }

        protected HttpResponseMessage GetFindResultResponse<T>(HttpRequestMessage request, FindResult<T> findResult)
        {
            HttpResponseMessage response = null;

            

            if(findResult.Success)
            {

                response = request.CreateResponse(HttpStatusCode.OK);
                
            }
            else
            {
                response = request.CreateResponse(HttpStatusCode.InternalServerError);
               
            }

            response.Content = new ObjectContent<FindResult<T>>(findResult, Configuration.Formatters.JsonFormatter);

            return response;
        }

        protected HttpResponseMessage GetUpdateResultResponse<T>(HttpRequestMessage request, UpdateResult<T> findResult)
        {
            HttpResponseMessage response = null;

            if (findResult.Success)
            {

                response = request.CreateResponse(HttpStatusCode.OK);

            }
            else
            {
                response = request.CreateResponse(HttpStatusCode.InternalServerError);

            }

            response.Content = new ObjectContent<UpdateResult<T>>(findResult, Configuration.Formatters.JsonFormatter);

            return response;
        }
    }
}