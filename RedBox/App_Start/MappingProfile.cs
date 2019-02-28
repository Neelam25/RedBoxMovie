using AutoMapper;
using RedBox.Dtos;
using RedBox.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RedBox.App_Start
{
    public class MappingProfile:Profile
    {
        public MappingProfile()
        {
            Mapper.CreateMap<CustomerModel, CustomerDTO>();
            Mapper.CreateMap<CustomerDTO, CustomerModel>();
            Mapper.CreateMap<MovieModel, MovieDTO>();
            Mapper.CreateMap<MovieDTO, MovieModel>().ForMember(m => m.ID, opt => opt.Ignore()); ;
        }
       
    }
}