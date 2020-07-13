using ProyectoFinal.Helpers;
using ProyectoFinal.Models;
using ProyectoFinal.Data;
using ProyectoFinal.Servicios;
using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.Linq;
using System.Web;

namespace ProyectoFinal.Servicios
{
    public class ProductService : IServiceIndex<Product>
    {

        public RespBase<Product> Get(int ID)
        {
            RespBase<Product> response = new RespBase<Product>();
            try
            {
                using (var context = new ProyectoFinalContext())
                {
                    response.Object = context.Products.Where(x => x.ProductID == ID && x.State == true).FirstOrDefault();
                }
                response.IsSuccess = true;
                response.Message = "Success";
                return response;
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
                response.IsSuccess = false;
                return response;
            }
        }

        public RespBase<Product> GetList()
        {
            RespBase<Product> response = new RespBase<Product>();
            try
            {
                using (var context = new ProyectoFinalContext())
                {
                    response.List = context.Products.Where(x => x.State == true).ToList();
                }
                response.IsSuccess = true;
                response.Message = "Success";
                return response;
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
                response.IsSuccess = false;
                return response;
            }
        }

        public RespBase<Product> Add(Product model)
        {
            RespBase<Product> response = new RespBase<Product>();
            try
            {
                using (var context = new ProyectoFinalContext())
                {
                    model.CreateAt = DateTime.Now;
                    model.State = true;
                    context.Products.Add(model);
                    context.SaveChanges();
                }
                response.IsSuccess = true;
                response.Message = "Success";
                return response;
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
                response.IsSuccess = false;
                return response;
            }
        }

        public RespBase<Product> Update(Product model)
        {
            RespBase<Product> response = new RespBase<Product>();
            try
            {
                using (var context = new ProyectoFinalContext())
                {
                    var item = context.Products.Where(x => x.ProductID == model.ProductID).FirstOrDefault();
                    item.Name = model.Name;
                    item.Stock = model.Stock;
                    item.Price = model.Price;
                    item.Remarks = model.Remarks;
                    context.SaveChanges();
                }
                response.IsSuccess = true;
                response.Message = "Success";
                return response;
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
                response.IsSuccess = false;
                return response;
            }
        }

        public RespBase<Product> Delete(int ID)
        {
            RespBase<Product> response = new RespBase<Product>();
            try
            {
                using (var context = new ProyectoFinalContext())
                {
                    var item = context.Products.Where(x => x.ProductID == ID).FirstOrDefault();
                    item.State = false;
                    context.SaveChanges();
                }
                response.IsSuccess = true;
                response.Message = "Success";
                return response;
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
                response.IsSuccess = false;
                return response;
            }
        }

    }
}