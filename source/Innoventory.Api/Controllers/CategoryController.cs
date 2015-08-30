using Innoventory.Lotus.Core.Common;
using Innoventory.Lotus.Repository.Abstract;
using Innoventory.Lotus.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Innoventory.Api.Controllers
{
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

                FindResult<CategoryViewModel> categoryResult = _categoryRepository.GetAll();

                if (categoryResult.Success)
                {
                    
                    response.Content = new ObjectContent<FindResult<CategoryViewModel>>(categoryResult, Configuration.Formatters.JsonFormatter);
                    
                }

                return response;

            });
        }

        
    }
}
