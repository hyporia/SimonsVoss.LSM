using AutoMapper;
using SimonsVoss.LSM.Core.Entities;
using SimonsVoss.LSM.Core.Requests.GetLocks;

namespace SimonsVoss.LSM.DB.AutoMapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            Lock();
        }

        private void Lock()
        {
            CreateMap<Lock, GetLocksQueryResponseItem>(MemberList.Destination)
                .ForMember(x => x.Type, x => x.MapFrom(@lock => @lock.LockType!.Value));
        }
    }
}