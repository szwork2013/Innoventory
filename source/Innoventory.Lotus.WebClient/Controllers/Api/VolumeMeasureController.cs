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
    [RoutePrefix("api/volumeMeasure")]
    public class VolumeMeasureController : ApiControllerBase
    {

        IVolumeMeasureRepository _volumeMeasureRepository;

        [ImportingConstructor]
        public VolumeMeasureController(IVolumeMeasureRepository volumeMeasureRepository)
        {
            _volumeMeasureRepository = volumeMeasureRepository;
        }

        [HttpGet]
        [Route("VolumeMeasures")]
        public HttpResponseMessage GetVolumeMeasures(HttpRequestMessage request)
        {

            return GetHttpResponse(request, () =>
            {
                HttpResponseMessage response = null;

                List<VolumeMeasureViewModel> retVolumeMeasures = new List<VolumeMeasureViewModel>();

                FindResult<VolumeMeasureViewModel> result = _volumeMeasureRepository.GetAll();

                response = GetFindResultResponse(request, result);

                return response;

            });
        }

        [HttpPost]
        [Route("SaveVolumeMeasure")]
        public HttpResponseMessage SaveVolumeMeasure(HttpRequestMessage request, [FromBody]VolumeMeasureViewModel volumeMeasureModel)
        {

            return GetHttpResponse(request, () =>
            {
                HttpResponseMessage response = null;

                UpdateResult<VolumeMeasureViewModel> updateResult = _volumeMeasureRepository.Update(volumeMeasureModel);



                if (updateResult.Success)
                {
                    response = new HttpResponseMessage(HttpStatusCode.OK);
                    updateResult.SuccessMessage = string.Format("VolumeMeasure: {0} saved successfully.", volumeMeasureModel.VolumeMeasureName);

                }
                else
                {
                    response = new HttpResponseMessage(HttpStatusCode.OK);
                    updateResult.ErrorMessage = ("Error occurred while saving volumeMeasure" + updateResult.ErrorMessage);
                }

                response.Content = new ObjectContent<UpdateResult<VolumeMeasureViewModel>>(updateResult, Configuration.Formatters.JsonFormatter);

                return response;
            });
        }

        [HttpDelete]
        [Route("Delete/{id}")]
        public HttpResponseMessage DeleteVolumeMeasure(HttpRequestMessage request, Guid id)
        {

            //Guid id = Guid.Empty;

            //if(!Guid.TryParse(volumeMeasureId, out id))
            //{
            //    throw new Exception("Id is not in correct formate");
            //}

            GetEntityResult<VolumeMeasureViewModel> volumeMeasureResult = _volumeMeasureRepository.FindById(id);

            VolumeMeasureViewModel volumeMeasure = null;

            if (volumeMeasureResult.Success && volumeMeasureResult.Entity != null)
            {
                volumeMeasure = volumeMeasureResult.Entity;
            }

            return GetHttpResponse(request, () =>
            {
                HttpResponseMessage response = null;

                DeleteResult<VolumeMeasureViewModel> deleteResult = new DeleteResult<VolumeMeasureViewModel>();
                deleteResult.Entity = volumeMeasure;

                
                if (volumeMeasure == null)
                {
                    response = new HttpResponseMessage(HttpStatusCode.BadRequest);

                    deleteResult.ErrorMessage = "VolumeMeasure is null";
                    deleteResult.Success = false;

                    response.Content = new ObjectContent<DeleteResult<VolumeMeasureViewModel>>(deleteResult, Configuration.Formatters.JsonFormatter);
                    return response;
                }

                EntityOperationResultBase result = _volumeMeasureRepository.Delete(volumeMeasure.VolumeMeasureId);

                deleteResult.ErrorMessage = result.ErrorMessage;
                deleteResult.Success = result.Success;
                deleteResult.SuccessMessage = result.SuccessMessage;

                response = new HttpResponseMessage(HttpStatusCode.OK);

                if (deleteResult.Success)
                {

                    deleteResult.SuccessMessage = string.Format("VolumeMeasure: '{0}' has been deleted", volumeMeasure.VolumeMeasureName);

                }
                else
                {

                    deleteResult.SuccessMessage = string.Format("Error occurred while deleting VolumeMeasure: '{0}'", volumeMeasure.VolumeMeasureName);

                }

                response.Content = new ObjectContent<DeleteResult<VolumeMeasureViewModel>>(deleteResult, Configuration.Formatters.JsonFormatter);

                return response;
            });

        }

    }
}
