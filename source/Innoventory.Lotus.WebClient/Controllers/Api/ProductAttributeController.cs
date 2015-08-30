using Innoventory.Lotus.Repository.Abstract;
using Innoventory.Lotus.Core.Common;
using Innoventory.Lotus.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Innoventory.Lotus.BusinessActivity;

namespace Innoventory.Lotus.WebClient.Controllers.Api
{
    [Export]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    [RoutePrefix("api/productAttribute")]
    public class ProductAttributeController : ApiControllerBase
    {

        //IProductAttributeRepository _productAttributeRepository;

        
        IProductAttributeActivity productAttributeActivity;
             
        [ImportingConstructor]
        public ProductAttributeController(IProductAttributeActivity productAttributeActivity)
        {
            this.productAttributeActivity = productAttributeActivity;
            
        }

        [HttpGet]
        [Route("ProductAttributes")]
        public HttpResponseMessage GetProductAttributes(HttpRequestMessage request)
        {

            return GetHttpResponse(request, () =>
            {
                HttpResponseMessage response = null;

                List<ProductAttributeViewModel> retProductAttributes = new List<ProductAttributeViewModel>();

                FindResult<ProductAttributeViewModel> result = productAttributeActivity.GetProductAttributes();

                response = GetFindResultResponse(request, result);

                return response;

            });
        }

        [HttpPost]
        [Route("SaveProductAttribute")]
        public HttpResponseMessage SaveProductAttribute(HttpRequestMessage request, [FromBody]ProductAttributeViewModel productAttributeModel)
        {

            return GetHttpResponse(request, () =>
            {
                HttpResponseMessage response = null;

                UpdateResult<ProductAttributeViewModel> updateResult = productAttributeActivity.UpdateProductAttribute(productAttributeModel);


                response = GetUpdateResultResponse(request, updateResult);

                return response;
            });
        }

        [HttpGet]
        [Route("getAttributeValues/{categorySubCategoryMapId}")]
        public HttpResponseMessage GetAttirbuteValues(HttpRequestMessage request, Guid categorySubCategoryMapId)
        {
            return GetHttpResponse(request, () =>
            {
                HttpResponseMessage response = null;

                FindResult<CategorySubCategoryAttributeValuesViewModel> findResult = productAttributeActivity
                                                        .GetAllCategorySubCategoryAttributesValueList(categorySubCategoryMapId);


                response = GetFindResultResponse(request, findResult);

                return response;
            });


        }

        [HttpDelete]
        [Route("Delete/{id}")]
        public HttpResponseMessage DeleteProductAttribute(HttpRequestMessage request,
                Guid id)
        {

            

            ProductAttributeViewModel productAttribute = null;

           
            return GetHttpResponse(request, () =>
            {
                HttpResponseMessage response = null;

                DeleteResult<ProductAttributeViewModel> deleteResult = new DeleteResult<ProductAttributeViewModel>();

                deleteResult = productAttributeActivity.Delete(id);
                deleteResult.Entity = productAttribute;
              

                if (productAttribute == null)
                {
                    response = new HttpResponseMessage(HttpStatusCode.BadRequest);

                    deleteResult.ErrorMessage = "Product Attribute is null";
                    deleteResult.Success = false;

                    response.Content = new ObjectContent<DeleteResult<ProductAttributeViewModel>>(deleteResult, Configuration.Formatters.JsonFormatter);
                    return response;
                }

                EntityOperationResultBase result = productAttributeActivity.Delete(productAttribute.ProductAttributeId);

                deleteResult.ErrorMessage = result.ErrorMessage;
                deleteResult.Success = result.Success;
                deleteResult.SuccessMessage = result.SuccessMessage;

                response = new HttpResponseMessage(HttpStatusCode.OK);

                if (deleteResult.Success)
                {

                    deleteResult.SuccessMessage = string.Format("Product Attribute: '{0}' has been deleted", productAttribute.AttributeName);

                }
                else
                {

                    deleteResult.SuccessMessage = string.Format("Error occurred while deleting Product Attribute: '{0}'", productAttribute.AttributeName);

                }

                response.Content = new ObjectContent<DeleteResult<ProductAttributeViewModel>>(deleteResult, Configuration.Formatters.JsonFormatter);

                return response;
            });

        }

    }
}
