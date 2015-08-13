using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Innoventory.Lotus.BusinessTransition;
using Innoventory.Lotus.ViewModels;

namespace Innoventory.Lotus.WebClient.Controllers.Api
{
    [Export]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    [RoutePrefix("api/product")]
    public class ProductController : ApiControllerBase
    {
        [Import]
        IProductTransition productTransition;

        [HttpPost]
        [Route("searchProduct")]
        public HttpResponseMessage GetProducts(HttpRequestMessage request, [FromBody]ProductFilterOption productFilterOption)
        {

            HttpResponseMessage response = null;

            return GetHttpResponse(request, () =>
            {
                FindResult<ProductListItem> productListItemsResult = productTransition.GetAllProductListItems(productFilterOption);

                response = new HttpResponseMessage(HttpStatusCode.OK);

                response = response = GetFindResultResponse(request, productListItemsResult);

                return response;
            });


        }
    }
}
