using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Innoventory.Lotus.BusinessActivity;
using Innoventory.Lotus.ViewModels;

namespace Innoventory.Lotus.WebClient.Controllers.Api
{
    [Export]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    [RoutePrefix("api/product")]
    public class ProductController : ApiControllerBase
    {
        [Import]
        IProductActivity productActivity;

        [HttpPost]
        [Route("searchProduct")]
        public HttpResponseMessage GetProducts(HttpRequestMessage request, [FromBody]ProductFilterOption productFilterOption)
        {

            HttpResponseMessage response = null;

            return GetHttpResponse(request, () =>
            {
                FindResult<ProductListItem> productListItemsResult = productActivity.GetAllProductListItems(productFilterOption);

                response = new HttpResponseMessage(HttpStatusCode.OK);

                response = response = GetFindResultResponse(request, productListItemsResult);

                return response;
            });


        }

        [HttpGet]
        [Route("getProduct/{id}")]
        public HttpResponseMessage GetProduct(HttpRequestMessage request, Guid id)
        {

            HttpResponseMessage response = null;

            return GetHttpResponse(request, () =>
            {

                GetEntityResult<ProductViewModel> productResult = productActivity.GetProduct(id);

                if(productResult.Success)
                {
                    response = new HttpResponseMessage(HttpStatusCode.OK);
                   
                }
                else
                {
                    response = new HttpResponseMessage(HttpStatusCode.InternalServerError);
                }

                response.Content = new ObjectContent<GetEntityResult<ProductViewModel>>(productResult, Configuration.Formatters.JsonFormatter);

                return response;

            });

        }

        [HttpPost]
        [Route("saveProduct")]
        public HttpResponseMessage SaveProduct(HttpRequestMessage request, [FromBody]ProductViewModel product)
        {
            HttpResponseMessage response = null;

            return GetHttpResponse(request, () =>
            {

                UpdateResult<ProductViewModel> updateResult = productActivity.SaveProduct(product);

                if (updateResult.Success)
                {
                    response = new HttpResponseMessage(HttpStatusCode.OK);


                }
                else
                {
                    response = new HttpResponseMessage(HttpStatusCode.InternalServerError);

                }

                response.Content = new ObjectContent<UpdateResult<ProductViewModel>>(updateResult, Configuration.Formatters.JsonFormatter);

                return response;

            });
        }
    }
}
