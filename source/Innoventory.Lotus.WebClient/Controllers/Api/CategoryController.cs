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
                    retCategories = result.Entities as List<CategoryViewModel>;
                    response.Content = new ObjectContent<List<CategoryViewModel>>(retCategories, Configuration.Formatters.JsonFormatter);
                }

                return response;
            });
        }

        [HttpPost]
        [Route("SaveCategory")]
        public HttpResponseMessage SaveCategory(HttpRequestMessage request, [FromBody]CategoryViewModel categoryModel)
        {


            _categoryRepository.Update(categoryModel);

            HttpResponseMessage response = new HttpResponseMessage(HttpStatusCode.OK);

            return response;

        }

    }
}
