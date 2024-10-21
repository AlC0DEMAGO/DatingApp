using System.Runtime.InteropServices;
using API.DataEntities;
using API.DTOs;
using API.Entities;
using AutoMapper;

namespace API.Helpers;
public class AutoMapperProfiles : Profile
{
    public AutoMapperProfiles()
    {
        CreateMap<AppUser,MemberResponse>();
        CreateMap<Photo,PhotoResponse>();
    }
}
