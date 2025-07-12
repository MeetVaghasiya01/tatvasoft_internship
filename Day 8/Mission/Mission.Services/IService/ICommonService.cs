using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mission.Entities.ViewModels;

namespace Mission.Services.IService
{
    public interface ICommonService
    {
        List<DropDownResponseModel> CountryList();

        List<DropDownResponseModel> CityList(int countryId);

        List<DropDownResponseModel> MissionThemeListAsync();

        List<DropDownResponseModel> MissionSkillListAsync();

        //List<DropDownResponseModel> MissionCountryList();

        //List<DropDownResponseModel> MissionCityList();

        //List<DropDownResponseModel> MissionTitleList();
    }
}
