using ProyectoFinal.Data;
using ProyectoFinal.Helpers;
using ProyectoFinal.Models;
using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.Linq;
using System.Web;

namespace ProyectoFinal.Servicios
{
    public class SalesInvoceService : IServiceIndex<SalesInvoce>
    {
        public RespBase<SalesInvoce> Get(int ID)
        {
            RespBase<SalesInvoce> response = new RespBase<SalesInvoce>();
            try
            {
                using (var context = new ProyectoFinalContext())
                {
                    response.Object = context.SalesInvoces
                        .Include("Customer")
                        .Include("Seller")
                        .Include("SalesInvoceDetails.Product")
                        .Where(x => x.SalesInvoceID == ID && x.State == true).FirstOrDefault();

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

        public RespBase<SalesInvoceSP> GetList()
        {
            RespBase<SalesInvoceSP> response = new RespBase<SalesInvoceSP>();
            try
            {

                using (var context = new ProyectoFinalContext())
                {
                    response.List = context.Database.SqlQuery<SalesInvoceSP>("pa_listSales").ToList();
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

        public RespBase<SalesInvoce> Add(SalesInvoce model)
        {
            RespBase<SalesInvoce> response = new RespBase<SalesInvoce>();
            try
            {
                using (var context = new ProyectoFinalContext())
                {
                    model.CreateAt = DateTime.Now;
                    model.State = true;
                    response.Object = context.SalesInvoces.Add(model);
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

        public RespBase<SalesInvoce> Update(SalesInvoce model)
        {
            RespBase<SalesInvoce> response = new RespBase<SalesInvoce>();
            try
            {
                using (var context = new ProyectoFinalContext())
                {
                    var item = context.SalesInvoces.Where(x => x.SalesInvoceID == model.SalesInvoceID).FirstOrDefault();
                    item.Reason = model.Reason;
                    item.SellerID = model.SellerID;
                    item.CustomerID = model.CustomerID;
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

        public RespBase<SalesInvoce> Delete(int ID)
        {
            RespBase<SalesInvoce> response = new RespBase<SalesInvoce>();
            try
            {
                using (var context = new ProyectoFinalContext())
                {
                    var item = context.SalesInvoces.Where(x => x.SalesInvoceID == ID).FirstOrDefault();
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

        RespBase<SalesInvoce> IServiceIndex<SalesInvoce>.GetList()
        {
            throw new NotImplementedException();
        }
    }
}