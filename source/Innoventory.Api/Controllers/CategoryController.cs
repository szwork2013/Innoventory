﻿using Innoventory.Lotus.Core.Common;
using Innoventory.Lotus.DataAccess.Abstract;
using Innoventory.Lotus.Domain.DataEntities;
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

                List<CategoryViewModel> categories = _categoryRepository.GetAll().Select(

                    (T) => ConvertToCategoryViewModel(T)).ToList();

                response.Content = new ObjectContent<List<CategoryViewModel>>(categories, Configuration.Formatters.JsonFormatter);

                return response;
            });
        }

        private CategoryViewModel ConvertToCategoryViewModel(Category category)
        {
            CategoryViewModel cv = new CategoryViewModel();
            ObjectMapper.PropertyMap<Category, CategoryViewModel>(category, cv);
            return cv;
        }

    }
}
