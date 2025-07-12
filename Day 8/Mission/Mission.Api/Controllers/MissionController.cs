using Microsoft.AspNetCore.Mvc;
using Mission.Entities.ViewModels;
using Mission.Entities.ViewModels.Mission;
using Mission.Entities.ViewModels.MissionApplication;
using Mission.Services.IService;
using System.Threading.Tasks;

namespace Mission.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MissionController(IMissionService missionService) : ControllerBase
    {
        private readonly IMissionService _missionService = missionService;

        //[HttpPost]
        //[Route("AddMission")]
        //public async Task<IActionResult> AddMission([FromBody] AddMissionRequestModel model)
        //{
        //    await _missionService.AddMissionRequestAsync(model);
        //    var result = new ResponseResult() { Result = ResponseStatus.Success, Message = "Mission Added Successfully" };
        //    return Ok(result);
        //}

        [HttpPost]
        [Route("AddMission")]
        public async Task<IActionResult> AddMission([FromBody] AddMissionRequestModel model)
        {
            try
            {
                await _missionService.AddMissionRequestAsync(model);
                var result = new ResponseResult() { Result = ResponseStatus.Success, Message = "Mission Added Successfully" };
                return Ok(result);
            }
            catch (Exception ex)
            {
                var errorResult = new ResponseResult() { Result = ResponseStatus.Error, Message = ex.Message };
                return StatusCode(500, errorResult);
            }
        }

        [HttpGet]
        [Route("MissionList")]
        public async Task<IActionResult> GetMissionList()
        {
            var response = await _missionService.GetMissionList();
            var result = new ResponseResult() { Result = ResponseStatus.Success, Data = response };
            return Ok(result);
        }

        [HttpGet]
        [Route("MissionDetailById/{id:int}")]
        public async Task<IActionResult> GetMissionById(int id)
        {
            var response = await _missionService.GetMissionById(id);
            return Ok(new ResponseResult() { Data = response, Result = ResponseStatus.Success, Message = "" });
        }

        [HttpPost]
        [Route("UpdateMission")]
        public async Task<IActionResult> UpdateMission(MissionRequestViewModel model)
        {
            var response = await _missionService.UpdateMission(model);
            return Ok(new ResponseResult() { Data = response, Result = ResponseStatus.Success, Message = "" });
        }

        [HttpDelete]
        [Route("DeleteMission/{missionId:int}")]
        public async Task<IActionResult> DeleteMission(int missionId)
        {
            var response = await _missionService.DeleteMission(missionId);
            return Ok(new ResponseResult() { Data = response, Result = ResponseStatus.Success, Message = "" });
        }

        //[HttpGet]
        //[Route("MissionApplicationList")]
        //public async Task<IActionResult> GetMissionApplicationList()
        //{
        //    var response = await _missionService.GetMissionApplicationList();
        //    return Ok(new ResponseResult() { Data = response, Result = ResponseStatus.Success, Message = "" });
        //}

        [HttpGet]
        [Route("MissionApplicationList")]
        public async Task<IActionResult> GetMissionApplicationList()
        {
            try
            {
                var response = await _missionService.GetMissionApplicationList();

                return Ok(new ResponseResult()
                {
                    Data = response,
                    Result = ResponseStatus.Success,
                    Message = ""
                });
            }
            catch (Exception ex)
            {
                // Optional: log the exception (e.g., using ILogger)

                return StatusCode(StatusCodes.Status500InternalServerError, new ResponseResult()
                {
                    Data = null,
                    Result = ResponseStatus.Error,
                    Message = $"Server Error: {ex.Message}"
                });
            }
        }


        [HttpPost]
        [Route("MissionApplicationApprove")]
        public async Task<IActionResult> MissionApplicationApprove(MissionApplicationResponseModel model)
        {
            var response = await _missionService.MissionApplicationApprove(model);

            if (!response)
            {
                return NotFound(new ResponseResult() { Result = ResponseStatus.Error, Message = "Mission Application Not Found" });
            }
            return Ok(new ResponseResult() { Data = response, Result = ResponseStatus.Success, Message = "" });
        }

        [HttpPost]
        [Route("MissionApplicationDelete")]
        public async Task<IActionResult> MissionApplicationDelete(MissionApplicationResponseModel model)
        {
            var response = await _missionService.MissionApplicationDelete(model);

            if (!response)
            {
                return NotFound(new ResponseResult() { Result = ResponseStatus.Error, Message = "Mission Application Not Found" });
            }
            return Ok(new ResponseResult() { Data = response, Result = ResponseStatus.Success, Message = "" });
        }
    }
}
