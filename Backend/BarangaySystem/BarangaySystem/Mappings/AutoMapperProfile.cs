using AutoMapper;
using BarangaySystem.Model;
using BarangaySystem.Model.DTO;
using BarangaySystem.Model.Entities;

namespace BarangaySystem.Mappings
{
    public class AutoMapperProfile: Profile
    {
        public AutoMapperProfile() 
        {
            CreateMap<EditResidentDTO, Resident>()
                .ForAllMembers(opt => opt.Condition((src, dest, srcMember) => srcMember != null));
        }
    }
}
