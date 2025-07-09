using Mission.Entities.ViewModels.MissionTheme;

namespace Mission.Services.IService
{
    public interface IMissionThemeService
    {
        Task AddMissionThemeAsync(UpsertMissionThemeRequestModel model);

        Task<List<MissionThemeResponseModel>> GetMissionThemeListAsync();

        Task<MissionThemeResponseModel?> GetMissionThemeByIdAsync(int missionThemeId);

        Task<bool> UpdateMissionThemeAsync(UpsertMissionThemeRequestModel model);

        Task<bool> DeleteMissionTheme(int id);
    }
}

