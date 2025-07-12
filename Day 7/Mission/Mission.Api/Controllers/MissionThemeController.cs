using Microsoft.AspNetCore.Mvc;
using Mission.Entities.ViewModels;
using Mission.Entities.ViewModels.MissionTheme;
using Mission.Services.IService;

namespace Mission.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MissionThemeController(IMissionThemeService missionThemeService) : ControllerBase
    {
        private readonly IMissionThemeService _missionThemeService = missionThemeService;

        [HttpPost]
        [Route("AddMissionTheme")]
        public async Task<IActionResult> AddMissionTheme(UpsertMissionThemeRequestModel model)
        {
            await _missionThemeService.AddMissionThemeAsync(model);

            var result = new ResponseResult() { Result = ResponseStatus.Success, Message = "New Mission Theme Added Successfully" };

            return Ok(result);
        }

        [HttpGet]
        [Route("GetMissionThemeList")]
        public async Task<IActionResult> GetMissionThemeList()
        {
            var response = await _missionThemeService.GetMissionThemeListAsync();

            var result = new ResponseResult() { Data = response, Result = ResponseStatus.Success };

            return Ok(result);

        }

        [HttpGet]
        [Route("GetMissionThemeById/{id:int}")]
        public async Task<IActionResult> GetMissionThemeById(int id)
        {
            var response = await _missionThemeService.GetMissionThemeByIdAsync(id);

            var result = new ResponseResult();

            if (response == null)
            {
                result.Result = ResponseStatus.Error;
                result.Message = "Mission Theme Record Not Found";
                return NotFound(result);
            }

            result.Result = ResponseStatus.Success;
            result.Data = response;

            return Ok(result);
        }

        [HttpPost]
        [Route("UpdateMissionTheme")]
        public async Task<IActionResult> UpdateMissionTheme(UpsertMissionThemeRequestModel model)
        {
            var response = await _missionThemeService.UpdateMissionThemeAsync(model);

            var result = new ResponseResult();

            if (response)
            {
                result.Result = ResponseStatus.Success;
                return Ok(result);
            }
            else
            {
                result.Result = ResponseStatus.Error;
                result.Message = "Mission Theme Record Not Found";
                return NotFound(result);
            }
        }

        [HttpDelete]
        [Route("DeleteMissionTheme/{id:int}")]
        public async Task<IActionResult> DeleteMissionTheme(int id)
        {
            var response = await _missionThemeService.DeleteMissionTheme(id);

            var result = new ResponseResult();

            if (response)
            {
                result.Result = ResponseStatus.Success;
                return Ok(result);
            }
            else
            {
                result.Result = ResponseStatus.Error;
                result.Message = "Mission Theme Record Not Found";
                return NotFound(result);
            }
        }
    }
}

