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

                response = GetFindResultResponse(request, result);

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

                response.Content = new ObjectContent<UpdateResult<CategoryViewModel>>(updateResult, Configuration.Formatters.JsonFormatter);

                return response;
            });
        }

        [HttpDelete]
        [Route("Delete/{id}")]
        public HttpResponseMessage DeleteCategory(HttpRequestMessage request,
                Guid id)
        {

            //Guid id = Guid.Empty;

            //if(!Guid.TryParse(categoryId, out id))
            //{
            //    throw new Exception("Id is not in correct formate");
            //}

            GetEntityResult<CategoryViewModel> categoryResult = _categoryRepository.FindById(id);

            CategoryViewModel category = null;

            if (categoryResult.Success && categoryResult.Entity != null)
            {
                category = categoryResult.Entity;
            }

            return GetHttpResponse(request, () =>
            {
                HttpResponseMessage response = null;

                DeleteResult<CategoryViewModel> deleteResult = new DeleteResult<CategoryViewModel>();
                deleteResult.Entity = category;

                bool success = false;

                if (category == null)
                {
                    response = new HttpResponseMessage(HttpStatusCode.BadRequest);

                    deleteResult.ErrorMessage = "Category is null";
                    deleteResult.Success = false;

                    response.Content = new ObjectContent<DeleteResult<CategoryViewModel>>(deleteResult, Configuration.Formatters.JsonFormatter);
                    return response;
                }

                EntityOperationResultBase result = _categoryRepository.Delete(category.CategoryId);

                deleteResult.ErrorMessage = result.ErrorMessage;
                deleteResult.Success = result.Success;
                deleteResult.SuccessMessage = result.SuccessMessage;

                response = new HttpResponseMessage(HttpStatusCode.OK);

                if (deleteResult.Success)
                {

                    deleteResult.SuccessMessage = string.Format("Category: '{0}' has been deleted", category.CategoryName);

                }
                else
                {

                    deleteResult.SuccessMessage = string.Format("Error occurred while deleting Category: '{0}'", category.CategoryName);

                }

                response.Content = new ObjectContent<DeleteResult<CategoryViewModel>>(deleteResult, Configuration.Formatters.JsonFormatter);

                return response;
            });

        }

    }
}
