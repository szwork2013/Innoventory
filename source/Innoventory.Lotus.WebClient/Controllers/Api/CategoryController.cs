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

                List<Category> categories = _categoryRepository.GetAll().ToList();

                List<CategoryViewModel> retCategories = new List<CategoryViewModel>();

                foreach (var item in categories)
                {
                    retCategories.Add(ConvertToCategoryViewModel(item));
                }


                response.Content = new ObjectContent<List<CategoryViewModel>>(retCategories, Configuration.Formatters.JsonFormatter);

                return response;
            });
        }

        [HttpPost]
        [Route("SaveCategory")]
        public HttpResponseMessage SaveCategory(HttpRequestMessage request, [FromBody]CategoryViewModel categoryModel)
        {
            Category category = null;
            bool isNew = false;

            if(categoryModel .CategoryId != Guid.Empty)
            {
                category = _categoryRepository.FindById(categoryModel.CategoryId);

            }
            else
            {
                category = new Category();
                categoryModel.CategoryId = Guid.NewGuid();
                isNew = true;
            }

            category.CategoryName = categoryModel.CategoryName;
            category.Description = categoryModel.Description;

            if(isNew)
            {
                _categoryRepository.Add(category);
            }
            else
            {
                _categoryRepository.Edit(category);

            }

            _categoryRepository.Save();

            HttpResponseMessage response = new HttpResponseMessage(HttpStatusCode.OK);

            return response;

        }
        private CategoryViewModel ConvertToCategoryViewModel(Category category)
        {
            CategoryViewModel cv = new CategoryViewModel();
            ObjectMapper.PropertyMap<Category, CategoryViewModel>(category, cv);
            return cv;
        }

    }
}
