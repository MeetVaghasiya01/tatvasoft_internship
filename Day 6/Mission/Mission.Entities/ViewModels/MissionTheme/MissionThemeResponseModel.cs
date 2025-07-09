using Mission.Entities.ViewModels.MissionSkill;

namespace Mission.Entities.ViewModels.MissionTheme
{
    public class MissionThemeResponseModel : UpsertMissionThemeRequestModel
    {
        public MissionThemeResponseModel() { }

        public MissionThemeResponseModel(Models.MissionTheme missionTheme)
        {
            Id = missionTheme.Id;
            ThemeName = missionTheme.ThemeName;
            Status = missionTheme.Status;
        }
    }
}
