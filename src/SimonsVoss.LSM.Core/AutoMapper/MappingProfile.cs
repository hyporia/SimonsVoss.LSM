using AutoMapper;
using SimonsVoss.LSM.Core.Entities;
using SimonsVoss.LSM.Core.Requests.GetBuildings;
using SimonsVoss.LSM.Core.Requests.GetGroups;
using SimonsVoss.LSM.Core.Requests.GetLocks;
using SimonsVoss.LSM.Core.Requests.GetMedia;
using SimonsVoss.LSM.Core.Requests.GetSearchingWeights;

namespace SimonsVoss.LSM.Core.AutoMapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            Lock();
            Building();
            Medium();
            Group();
        }

        private void Lock()
        {
            CreateMap<Lock, GetLocksQueryResponseItem>(MemberList.Destination)
                .ForMember(x => x.Type, x 
                    => x.MapFrom(@lock => @lock.LockType!.Value));
        }

        private void Building()
        {
            CreateMap<Building, GetBuildingsQueryResponseItem>(MemberList.Destination);
        }

        private void Medium()
        {
            CreateMap<Medium, GetMediaQueryResponseItem>(MemberList.Destination)
                .ForMember(x => x.Type, x 
                    => x.MapFrom(medium => medium.MediumType!.Value));
        }

        private void Group()
        {
            CreateMap<Group, GetGroupsQueryResponseItem>(MemberList.Destination);
        }

        private void SearchingWeight()
        {
            CreateMap<SearchingWeight, GetSearchingWeightsQueryResponseItem>(MemberList.Destination);
        }
    }
}