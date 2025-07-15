using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Mission.Entities;
using Mission.Entities.Models;
using Mission.Entities.ViewModels.MissionTheme;
using Mission.Repositories.IRepository;

namespace Mission.Repositories.Repository
{
    public class MissionThemeRepository(MissionDbContext dbContext) : IMissionThemeRepository
    {
        private readonly MissionDbContext _dbContext = dbContext;

        public async Task AddMissionThemeAsync(UpsertMissionThemeRequestModel model)
        {
            var missionTheme = new MissionTheme()
            {
                ThemeName = model.ThemeName,
                Status = model.Status,
            };

            _dbContext.MissionThemes.Add(missionTheme);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<List<MissionThemeResponseModel>> GetMissionThemeListAsync()
        {
            var query = _dbContext.MissionThemes
                .Select(m => new MissionThemeResponseModel(m))
                .AsQueryable();

            return await query.ToListAsync();
        }

        public async Task<MissionThemeResponseModel?> GetMissionThemeByIdAsync(int missionThemeId)
        {
            var missionTheme = await _dbContext.MissionThemes.FindAsync(missionThemeId);

            if (missionTheme == null)
                return null;

            return new MissionThemeResponseModel(missionTheme);
        }

        public async Task<bool> UpdateMissionThemeAsync(UpsertMissionThemeRequestModel model)
        {
            var missionTheme = await _dbContext.MissionThemes.FindAsync(model.Id);

            if (missionTheme == null)
                return false;

            missionTheme.ThemeName = model.ThemeName;
            missionTheme.Status = model.Status;

            _dbContext.MissionThemes.Update(missionTheme);
            await _dbContext.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteMissionTheme(int id)
        {
            var missionTheme = await _dbContext.MissionThemes.FindAsync(id);

            if (missionTheme == null)
                return false;

            _dbContext.MissionThemes.Remove(missionTheme);
            await _dbContext.SaveChangesAsync();
            return true;
        }
    }
}

