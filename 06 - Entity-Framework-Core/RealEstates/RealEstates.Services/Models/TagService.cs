using System;
using System.Linq;
using RealEstates.Data;
using RealEstates.Models;
using RealEstates.Services.Interfaces;

namespace RealEstates.Services.Models
{
	public class TagService : BaseService, ITagService
	{
		private readonly ApplicationDbContext dbContext;
		private readonly IPropertiesService propertiesService;

		public TagService(ApplicationDbContext dbContext, IPropertiesService propertiesService)
		{
			this.dbContext = dbContext;
			this.propertiesService = propertiesService;
		}

		public void Add(string name, int? importance = null)
		{
			var tag = new Tag
			{
				Name = name,
				Importance = importance.Value,
			};

			this.dbContext.Tags.Add(tag);
			this.dbContext.SaveChanges();
		}

		public void BulkTagToPropertiesRelation()
		{
			var allProperties = dbContext.Properties.ToList();

			foreach (var property in allProperties)
			{
				var averagePriceForThisDistrict = this.propertiesService
					.AveragePricePerSquareMeter(property.DistrictId);

				if (property.Price > averagePriceForThisDistrict)
				{
					var tag = dbContext.Tags.FirstOrDefault(x => x.Name == "скъп-имот");
					//property.PropertyTags.Add(tag);
				}

				if (property.Price < averagePriceForThisDistrict)
				{
					var tag = dbContext.Tags.FirstOrDefault(x => x.Name == "евтин-имот");
					//property.PropertyTags.Add(tag);
				}

				var currentDate = DateTime.Now.AddYears(-15);
				if (property.Year.HasValue && property.Year <= currentDate.Year)
				{
					// старо-строителство
					// ново-строителство
					var tag = dbContext.Tags.FirstOrDefault(x => x.Name == "стар-имот");
					//property.PropertyTags.Add(tag);
				}
				else if (property.Year.HasValue && property.Year > currentDate.Year)
				{
					// старо-строителство
					// ново-строителство
					var tag = dbContext.Tags.FirstOrDefault(x => x.Name == "нов-имот");
					//property.PropertyTags.Add(tag);
				}

				var averagePropertySize = this.propertiesService.AverageSize(property.DistrictId);
				if (property.Size >= averagePropertySize)
				{
					var tag = dbContext.Tags.FirstOrDefault(x => x.Name == "голям-имот");
					//property.PropertyTags.Add(tag);
				}
				else if (property.Size < averagePropertySize)
				{
					var tag = dbContext.Tags.FirstOrDefault(x => x.Name == "малък-имот");
					//property.PropertyTags.Add(tag);
				}

				if (property.Floor.HasValue && property.Floor.Value == 1)
				{
					var tag = dbContext.Tags.FirstOrDefault(x => x.Name == "първи-етаж");
					//property.PropertyTags.Add(tag);
				}
				else if (property.Floor.HasValue && property.Floor.Value > 6)
				{
					//хубава-гледка
					var tag = dbContext.Tags.FirstOrDefault(x => x.Name == "последен-етаж");
					//property.PropertyTags.Add(tag);
				}
				else if (property.Floor.HasValue && property.TotalFloors.HasValue &&
					property.Floor.Value == property.TotalFloors.Value)
				{
					var tag = dbContext.Tags.FirstOrDefault(x => x.Name == "последен-етаж");
					//property.PropertyTags.Add(tag);
				}
			}

			dbContext.SaveChanges();
		}
	}
}
