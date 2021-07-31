using AutoMapper.QueryableExtensions;
using RealEstates.Data;
using RealEstates.Services.Interfaces;
using RealEstates.Services.Models;
using System.Collections.Generic;
using System.Linq;

namespace RealEstates.Services
{
    public class DistrictService : BaseService, IDistrictsService
    {
        private readonly ApplicationDbContext context;

        public DistrictService(ApplicationDbContext context)
        {
            this.context = context;
        }

        public IEnumerable<DistrictInfoDto> GetMostExpensiveDistricts(int count)
        {
            //var mostExpensive = context.Districts
            //    .Select( x=> x.Properties.pr)

            var districts = context.Districts
                .ProjectTo<DistrictInfoDto>(this.Mapper.ConfigurationProvider)
                //.Select(x => new DistrictInfoDto
                //{
                //    Name = x.Name,
                //    PropertiesCount = x.Properties.Count(),
                //    AveragePricePerSquareMeter =
                //        x.Properties.Where(p => p.Price.HasValue)
                //        .Average(p => p.Price / (decimal)p.Size) ?? 0,
                //})
                .OrderByDescending(x => x.AveragePricePerSquareMeter)
                .Take(count)
                .ToList();

            return districts;
        }
    }
}
