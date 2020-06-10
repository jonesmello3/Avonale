using AutoMapper;
using ProvaAvonale.CrossCutting.Mappers.MappingProfiles;
using System.Collections.Generic;

namespace ProvaAvonale.CrossCutting.Mappers
{
    public class AutoMapperConfig
    {
        private static List<Profile> profiles = new List<Profile>();

        public static void RegisterMappings()
        {
            AutoMapper.Mapper.Initialize(map =>
            {
                map.AllowNullCollections = true;
                map.AddProfile<EntitiesToModelMappingProfile>();

                foreach (var profile in profiles)
                {
                    map.AddProfile(profile);
                }
            });
        }

        public static void AddProfile(Profile profile)
        {
            profiles.Add(profile);
        }
    }
}
