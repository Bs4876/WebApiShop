using AutoMapper;
using DTOs;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class AutoMapping : Profile
    { 
        public AutoMapping()
        {
            CreateMap<ProductsTbl, MoreInfoProductDTO>();
            CreateMap<ProductsTbl, LessInfoProductDTO>();

            CreateMap<OrdersTbl, MoreInfoOrderDTO>();
            CreateMap<OrdersTbl, LessInfoOrderDTO>();

            CreateMap<User, MoreInfoUserDTO>();
            CreateMap<User, LessInfoUserDTO>();
        }
    }
}
