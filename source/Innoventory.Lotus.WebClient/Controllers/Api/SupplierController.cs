using Innoventory.Lotus.Repository.Abstract;
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
    [RoutePrefix("api/supplier")]
    public class SupplierController : ApiControllerBase
    {

        ISupplierRepository supplierRepository;

        [ImportingConstructor]
        public SupplierController(ISupplierRepository supplierRepository)
        {
            this.supplierRepository = supplierRepository;
        }

        [HttpGet]
        [Route("getSupplier/{id}")]
        public HttpResponseMessage GetSupplier(HttpRequestMessage request, Guid id)
        {

            return GetHttpResponse(request, () =>
            {
                HttpResponseMessage response = null;

                GetEntityResult<SupplierViewModel> entityResult = supplierRepository.FindById(id);

                response = GetEntityResultResponse<SupplierViewModel>(request, entityResult);

                return response;

            });
        }

        [HttpGet]
        [Route("search")]
        public HttpResponseMessage GetSuppliers(HttpRequestMessage request)
        {
            return GetHttpResponse(request, () =>
            {
                HttpResponseMessage response = null;

                FindResult<SupplierViewModel> findSupplierResult = supplierRepository.GetAll();

                response = GetFindResultResponse<SupplierViewModel>(request, findSupplierResult);

                return response;

            });
        }

        [HttpGet]
        [Route("search/{searchString}")]
        public HttpResponseMessage GetSuppliers(HttpRequestMessage request, string searchString = null)
        {
            return GetHttpResponse(request, () =>
            {
                HttpResponseMessage response = null;

                FindResult<SupplierViewModel> findSupplierResult = supplierRepository.SearchSupplier(searchString);

                response = GetFindResultResponse<SupplierViewModel>(request, findSupplierResult);

                return response;

            });
        }

        [HttpPost]
        [Route("save")]
        public HttpResponseMessage SaveSupplier(HttpRequestMessage request, [FromBody]SupplierViewModel supplier)
        {

            return GetHttpResponse(request, () =>
            {

                HttpResponseMessage response = null;

                UpdateResult<SupplierViewModel> updateResult = supplierRepository.Update(supplier);

                response = GetUpdateResultResponse<SupplierViewModel>(request, updateResult);

                return response;

            });
        }

        [HttpDelete]
        [Route("delete/{id}")]
        public HttpResponseMessage DeleteSupplier(HttpRequestMessage request, Guid id)
        {

            return GetHttpResponse(request, () =>
            {

                HttpResponseMessage response = null;

                EntityOperationResultBase deleteResult = new DeleteResult<SupplierViewModel>() { Success = false };

                GetEntityResult<SupplierViewModel> entityResult = supplierRepository.FindById(id);

                if (!(entityResult.Success && entityResult.Entity != null))
                {
                    response = new HttpResponseMessage(HttpStatusCode.NotFound);

                    deleteResult.ErrorMessage = "Supplier does not exist";

                    response.Content = new ObjectContent<EntityOperationResultBase>(deleteResult, Configuration.Formatters.JsonFormatter);

                    return response;
                }

                 deleteResult = supplierRepository.Delete(id);

                 response = GetOperationBaseResponse(request, deleteResult);

                return response;

            });
        }
    }
}
