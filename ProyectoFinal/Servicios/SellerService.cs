using ProyectoFinal.Helpers;
using ProyectoFinal.Models;
using ProyectoFinal.Data;
using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.Linq;
using System.Web;

namespace ProyectoFinal.Servicios
{
    public class SellerService : IServiceIndex<Seller>
    {
        public RespBase<Seller> Get(int ID)
        {
            RespBase<Seller> response = new RespBase<Seller>();
            try
            {
                using (var context = new ProyectoFinalContext())
                {
                    response.Object = context.Sellers.Where(x => x.SellerID == ID && x.State == true).FirstOrDefault();
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

        public RespBase<Seller> GetList()
        {
            RespBase<Seller> response = new RespBase<Seller>();
            try
            {
                using (var context = new ProyectoFinalContext())
                {
                    response.List = context.Sellers.Where(x => x.State == true).ToList();
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

        public RespBase<Seller> Add(Seller model)
        {
            RespBase<Seller> response = new RespBase<Seller>();
            try
            {
                using (var context = new ProyectoFinalContext())
                {
                    model.CreateAt = DateTime.Now;
                    model.State = true;
                    context.Sellers.Add(model);
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

        public RespBase<Seller> Update(Seller model)
        {
            RespBase<Seller> response = new RespBase<Seller>();
            try
            {
                using (var context = new ProyectoFinalContext())
                {
                    var seller = context.Sellers.Where(x => x.SellerID == model.SellerID).FirstOrDefault();
                    seller.Name = model.Name;
                    seller.LastName = model.LastName;
                    seller.Email = model.Email;
                    seller.Birthdate = model.Birthdate;
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

        public RespBase<Seller> Delete(int ID)
        {
            RespBase<Seller> response = new RespBase<Seller>();
            try
            {
                using (var context = new ProyectoFinalContext())
                {
                    var item = context.Sellers.Where(x => x.SellerID == ID).FirstOrDefault();
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