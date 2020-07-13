
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ProyectoFinal.Models;
using ProyectoFinal.Helpers;
using ProyectoFinal.Request;
using ProyectoFinal.Response;
using AutoMapper;


namespace ProyectoFinal.Repository
{
    public class EntityMapper<TSource, TDestination> where TSource : class where TDestination : class
    {

        public EntityMapper()
        {
            Mapper.CreateMap<RespBase<Product>, RespBase<Product_Resp>>();
            Mapper.CreateMap<RespBase<Product_Resp>, RespBase<Product>>();
            Mapper.CreateMap<RespBase<Product_Req>, RespBase<Product>>();

            Mapper.CreateMap<RespBase<Customer>, RespBase<Customer_Resp>>();
            Mapper.CreateMap<RespBase<Customer_Resp>, RespBase<Customer>>();
            Mapper.CreateMap<RespBase<Customer_Req>, RespBase<Customer>>();

            Mapper.CreateMap<SalesInvoce, SalesInvoce_Resp>();
            Mapper.CreateMap<SalesInvoce_Resp, SalesInvoce>();
            Mapper.CreateMap<SalesInvoce_Req, SalesInvoce>();

            Mapper.CreateMap<SalesInvoceDetail, SalesInvoceDetail_Resp>();
            Mapper.CreateMap<SalesInvoceDetail_Resp, SalesInvoceDetail>();
            Mapper.CreateMap<SalesInvoceDetail_Req, SalesInvoceDetail>();

            Mapper.CreateMap<Seller, Seller_Resp>();
            Mapper.CreateMap<Seller_Resp, Seller>();
            Mapper.CreateMap<Seller_Req, Seller>();

        }

        public TDestination Translate(TSource obj)
        {
            return Mapper.Map<TDestination>(obj);
        }

    }
}