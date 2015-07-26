using Innoventory.Lotus.Business.Abstract;
using Innoventory.Lotus.Core.Common;
using Innoventory.Lotus.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Innoventory.Lotus.WebClient.Controllers.Api
{
    [Export]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    [RoutePrefix("api/productAttribute")]
    public class ProductAttributeController : ApiControllerBase
    {

        IProductAttributeRepository _productAttributeRepository;

        [ImportingConstructor]
        public ProductAttributeController(IProductAttributeRepository productAttributeRepository)
        {
            _productAttributeRepository = productAttributeRepository;
        }

        [HttpGet]
        [Route("ProductAttributes")]
        public HttpResponseMessage GetProductAttributes(HttpRequestMessage request)
        {

            return GetHttpResponse(request, () =>
            {
                HttpResponseMessage response = null;

                List<ProductAttributeViewModel> retProductAttributes = new List<ProductAttributeViewModel>();

                FindResult<ProductAttributeViewModel> result = _productAttributeRepository.GetAll();

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

                UpdateResult<ProductAttributeViewModel> updateResult = _productAttributeRepository.Update(productAttributeModel);


                response = GetUpdateResultResponse(request, updateResult);

                return response;
            });
        }

        [HttpDelete]
        [Route("Delete/{id}")]
        public HttpResponseMessage DeleteProductAttribute(HttpRequestMessage request,
                Guid id)
        {
                        
            GetEntityResult<ProductAttributeViewModel> productAttributeResult = _productAttributeRepository.FindById(id);

            ProductAttributeViewModel productAttribute = null;

            if (productAttributeResult.Success && productAttributeResult.Entity != null)
            {
                productAttribute = productAttributeResult.Entity;
            }

            return GetHttpResponse(request, () =>
            {
                HttpResponseMessage response = null;

                DeleteResult<ProductAttributeViewModel> deleteResult = new DeleteResult<ProductAttributeViewModel>();
                deleteResult.Entity = productAttribute;
              

                if (productAttribute == null)
                {
                    response = new HttpResponseMessage(HttpStatusCode.BadRequest);

                    deleteResult.ErrorMessage = "Product Attribute is null";
                    deleteResult.Success = false;

                    response.Content = new ObjectContent<DeleteResult<ProductAttributeViewModel>>(deleteResult, Configuration.Formatters.JsonFormatter);
                    return response;
                }

                EntityOperationResultBase result = _productAttributeRepository.Delete(productAttribute.ProductAttributeId);

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
