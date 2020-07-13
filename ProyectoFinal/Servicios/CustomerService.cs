using ProyectoFinal.Data;
using ProyectoFinal.Helpers;
using ProyectoFinal.Models;
using ProyectoFinal.Servicios;
using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.Linq;
using System.Web;

namespace ProyectoFinal.Servicios
{
    public class CustomerService : IServiceIndex<Customer>
    {
        public RespBase<Customer> Get(int ID)
        {
            RespBase<Customer> response = new RespBase<Customer>();
            try
            {
                using (var context = new ProyectoFinalContext())
                {
                    response.Object = context.Customers.Where(x => x.CustomerID == ID && x.State == true).FirstOrDefault();
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

        public RespBase<Customer> GetList()
        {
            RespBase<Customer> response = new RespBase<Customer>();
            try
            {
                using (var context = new ProyectoFinalContext()) 
                {
                    response.List = context.Customers.Where(x => x.State == true).ToList();
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
        public RespBase<Customer> Add(Customer model)
        {
            model.State = true;
            model.CreateAt = DateTime.Now;
            RespBase<Customer> response = new RespBase<Customer>();
            try
            {
                using (var context = new ProyectoFinalContext())
                {
                    context.Customers.Add(model);
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

        public RespBase<Customer> Update(Customer model)
        {
            RespBase<Customer> response = new RespBase<Customer>();
            try
            {
                using (var context = new ProyectoFinalContext())
                {
                    var item = context.Customers.Find(model.CustomerID);
                    item.Name = model.Name;
                    item.LastName = model.LastName;
                    item.Birthdate = model.Birthdate;
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

        public RespBase<Customer> Delete(int ID)
        {
            RespBase<Customer> response = new RespBase<Customer>();
            try
            {
                using (var context = new ProyectoFinalContext())
                {
                    var item = context.Customers.Where(x => x.CustomerID == ID).FirstOrDefault();
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