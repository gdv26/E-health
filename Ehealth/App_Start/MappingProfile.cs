using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using Ehealth.Models;
using Ehealth.Dtos;

namespace Ehealth.App_Start
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            //Domain to Dto
            Mapper.CreateMap<User, UserDto>();
            Mapper.CreateMap<Program, ProgramDto>();
            Mapper.CreateMap<MembershipType, MembershipTypeDto>();
            Mapper.CreateMap<ProgramType, ProgramTypeDto>();

            //Dto to Domain
            Mapper.CreateMap<UserDto, User>()
                .ForMember(c => c.Id, opt => opt.Ignore());

            Mapper.CreateMap<ProgramDto, Program>()
                .ForMember(c => c.Id, opt => opt.Ignore());
        }
    }
}