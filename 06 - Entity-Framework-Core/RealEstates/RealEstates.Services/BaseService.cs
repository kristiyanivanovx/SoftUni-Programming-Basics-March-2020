using AutoMapper;
using RealEstates.ConsoleApplication.Profiler;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealEstates.Services
{
    public abstract class BaseService
    {
        public BaseService()
        {
            InitializeAutoMapper();
        }

        public IMapper Mapper { get; private set; }

        private void InitializeAutoMapper()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<RealEstatesProfiler>();
            });

            this.Mapper = config.CreateMapper();
        }
    }
}
