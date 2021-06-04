using AutoMapper;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DietMealApp.Core.Mappings
{
    public class AutoMapperConfig
    {
        public static IMapper RegisterMappings()
        {
            var config = new MapperConfiguration(cfg => {
                cfg.AddProfile<MappingProfiler>();
            });

            AssertConfigurationInDebug(config);
            var mapper = config.CreateMapper();
            return mapper;
        }

        [Conditional("DEBUG")]
        private static void AssertConfigurationInDebug(IConfigurationProvider config)
        {
            config.AssertConfigurationIsValid();
        }
    }
}
