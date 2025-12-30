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

            CreateMap<OrdersTbl, OrderMoreInfoDTO>();
            CreateMap<OrdersTbl, CreatOrderDTO>();
            CreateMap<OrdersTbl, OrderDTO>();

            CreateMap<OrderMoreInfoDTO,OrdersTbl >();
            CreateMap<CreatOrderDTO,OrdersTbl >();
            CreateMap<OrderDTO,OrdersTbl >();

            CreateMap<User, UserDTO>();
            CreateMap<UserDTO, User>();
            CreateMap<UserToRegisterDTO, User>();
        }
    }
}
