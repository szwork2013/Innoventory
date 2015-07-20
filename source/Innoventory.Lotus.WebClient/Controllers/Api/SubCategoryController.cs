using Innoventory.Lotus.Business.Abstract;
using Innoventory.Lotus.BusinessTransition;
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
    [RoutePrefix("api/SubCategory")]
    public class SubCategoryController : ApiControllerBase
    {
        //ISubCategoryRepository _subCategoryRepository;
        //[Import]
        ISubCategoryTransition subCategoryTransition = null;

        [ImportingConstructor]
        public SubCategoryController(ISubCategoryTransition subCategoryTransition)
        {

            this.subCategoryTransition = subCategoryTransition;

        }

        [HttpGet]
        [Route("SubCategories")]
        public HttpResponseMessage GetSubCategories(HttpRequestMessage request)
        {
            return GetHttpResponse(request, () =>
            {
                HttpResponseMessage response = null;

                FindResult<SubCategoryCategories> subCategoryCategoriesResult = new FindResult<SubCategoryCategories>();

                FindResult<SubCategoryViewModel> subCategoryResult = subCategoryTransition.GetAllSubcategories();

                response = GetFindResultResponse(request, subCategoryResult);
                return response;
            });
        }

        [HttpPost]
        [Route("SaveSubCategory")]
        public HttpResponseMessage SaveSubCategory(HttpRequestMessage request, [FromBody]SubCategoryViewModel model)
        {
            return GetHttpResponse(request, () =>
            {
                HttpResponseMessage response = null;

                UpdateResult<SubCategoryViewModel> updateResult = subCategoryTransition.UpdateSubCategory(model);

                response = GetUpdateResultResponse(request, updateResult);

                return response;
            });
        }

        [HttpGet]
        [Route("SubCategory/{id}")]
        public HttpResponseMessage GetSubCategory(HttpRequestMessage request, Guid id)
        {
            return GetHttpResponse(request, () =>
            {

                HttpResponseMessage response = null;
                SubCategoryCategories subCategory = subCategoryTransition.GetSubCategoryCategories(id);
                GetEntityResult<SubCategoryCategories> result = new GetEntityResult<SubCategoryCategories>
                {
                    Entity = subCategory,
                    ErrorMessage = string.Empty,
                    Success = true,
                    SuccessMessage = string.Empty
                };

                response = new HttpResponseMessage(HttpStatusCode.OK);

                response.Content = new ObjectContent<GetEntityResult<SubCategoryCategories>>(result, Configuration.Formatters.JsonFormatter);



                return response;

            });
        }
    }
}
