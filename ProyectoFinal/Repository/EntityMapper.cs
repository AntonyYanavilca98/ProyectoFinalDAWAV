
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ProyectoFinal.Models;
using ProyectoFinal.Helpers;
using AutoMapper;

namespace ProyectoFinal.Repository
{
    public class EntityMapper<TSource, TDestination> where TSource : class where TDestination : class
    {

        public EntityMapper()
        {
            Mapper.CreateMap<RespBase<Product>, RespBase<Product_Response>>();
            Mapper.CreateMap<RespBase<Product_Response>, RespBase<Product>>();
            Mapper.CreateMap<RespBase<Product_Request>, RespBase<Product>>();

            Mapper.CreateMap<RespBase<Customer>, RespBase<Customer_Response>>();
            Mapper.CreateMap<RespBase<Customer_Response>, RespBase<Customer>>();
            Mapper.CreateMap<RespBase<Customer_Request>, RespBase<Customer>>();

            Mapper.CreateMap<SalesInvoce, SalesInvoce_Response>();
            Mapper.CreateMap<SalesInvoce_Response, SalesInvoce>();
            Mapper.CreateMap<SalesInvoce_Request, SalesInvoce>();

            Mapper.CreateMap<SalesInvoceDetail, SalesInvoceDetail_Response>();
            Mapper.CreateMap<SalesInvoceDetail_Response, SalesInvoceDetail>();
            Mapper.CreateMap<SalesInvoceDetail_Request, SalesInvoceDetail>();

            Mapper.CreateMap<Seller, Seller_Response>();
            Mapper.CreateMap<Seller_Response, Seller>();
            Mapper.CreateMap<Seller_Request, Seller>();

        }

        public TDestination Translate(TSource obj)
        {
            return Mapper.Map<TDestination>(obj);
        }

    }
}