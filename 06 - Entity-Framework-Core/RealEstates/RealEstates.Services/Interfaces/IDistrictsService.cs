using RealEstates.Services.Models;
using System.Collections.Generic;

namespace RealEstates.Services.Interfaces
{
    public interface IDistrictsService
    {
        IEnumerable<DistrictInfoDto> GetMostExpensiveDistricts(int count);
    }
}
