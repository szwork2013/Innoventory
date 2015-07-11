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

namespace Innoventory.Lotus.WebClient.Api.Controllers
{
    [Export]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    [RoutePrefix("api/category")]
    public class CategoryController : ApiControllerBase
    {

        ICategoryRepository _categoryRepository;

        [ImportingConstructor]
        public CategoryController(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        [HttpGet]
        [Route("Categories")]
        public HttpResponseMessage GetCategories(HttpRequestMessage request)
        {

            return GetHttpResponse(request, () =>
            {
                HttpResponseMessage response = null;

                List<CategoryViewModel> retCategories = new List<CategoryViewModel>();

                FindResult<CategoryViewModel> result = _categoryRepository.GetAll();

                if (result.Success)
                {

                    response = request.CreateResponse(HttpStatusCode.OK);
                    response.Content = new ObjectContent<FindResult<CategoryViewModel>>(result, Configuration.Formatters.JsonFormatter);
                }
                else
                {
                    response = request.CreateErrorResponse(HttpStatusCode.NoContent, "Error occurred");
                }

                return response;

            });
        }

        [HttpPost]
        [Route("SaveCategory")]
        public HttpResponseMessage SaveCategory(HttpRequestMessage request, [FromBody]CategoryViewModel categoryModel)
        {

            return GetHttpResponse(request, () =>
            {
                HttpResponseMessage response = null;

                UpdateResult<CategoryViewModel> updateResult = _categoryRepository.Update(categoryModel);



                if (updateResult.Success)
                {
                    response = new HttpResponseMessage(HttpStatusCode.OK);
                    updateResult.SuccessMessage = string.Format("Category: {0} saved successfully.", categoryModel.CategoryName);
                    
                }
                else
                {
                    response = new HttpResponseMessage(HttpStatusCode.OK);
                    updateResult.ErrorMessage = ("Error occurred while saving category" + updateResult.ErrorMessage);
                }

                response.Content = new ObjectContent<UpdateResult<CategoryViewModel>> (updateResult, Configuration.Formatters.JsonFormatter);

                return response;
            });
        }

    }
}
