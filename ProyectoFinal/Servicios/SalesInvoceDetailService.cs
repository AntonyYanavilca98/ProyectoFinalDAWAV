using ProyectoFinal.Helpers;
using ProyectoFinal.Models;
using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.Linq;
using System.Web;
using System.Threading.Tasks;
using System.Text;
using ProyectoFinal.Data;

namespace ProyectoFinal.Servicios
{
    public class SalesInvoceDetailService : IServiceIndex<SalesInvoceDetail>
    {
        public RespBase<SalesInvoceDetail> Get(int ID)
        {
            RespBase<SalesInvoceDetail> response = new RespBase<SalesInvoceDetail>();
            try
            {
                using (var context = new ProyectoFinalContext())
                {
                    response.List = context.SalesInvoceDetails.Include("Product").Include("SalesInvoce").Where(x => x.SalesInvoceID == ID).ToList();
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

        public RespBase<SalesInvoceDetail> GetList()
        {
            RespBase<SalesInvoceDetail> response = new RespBase<SalesInvoceDetail>();
            try
            {
                using (var context = new ProyectoFinalContext())
                {
                    response.List = context.SalesInvoceDetails.ToList();
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

        public RespBase<SalesInvoceDetail> Add(SalesInvoceDetail model)
        {
            RespBase<SalesInvoceDetail> response = new RespBase<SalesInvoceDetail>();
            try
            {
                using (var context = new ProyectoFinalContext())
                {
                    model.State = true;
                    context.SalesInvoceDetails.Add(model);
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

        public RespBase<SalesInvoceDetail> Update(SalesInvoceDetail model)
        {
            RespBase<SalesInvoceDetail> response = new RespBase<SalesInvoceDetail>();
            try
            {
                using (var context = new ProyectoFinalContext())
                {
                    var item = context.SalesInvoceDetails.Where(x => x.SalesInvoceDetailID == model.SalesInvoceDetailID).FirstOrDefault();
                    item.Price = model.Price;
                    item.Quantity = model.Quantity;
                    item.SalesInvoceID = model.SalesInvoceID;
                    item.ProductID = model.ProductID;
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

        public RespBase<SalesInvoceDetail> Delete(int ID)
        {
            RespBase<SalesInvoceDetail> response = new RespBase<SalesInvoceDetail>();
            try
            {
                using (var context = new ProyectoFinalContext())
                {
                    var item = context.SalesInvoceDetails.Where(x => x.SalesInvoceDetailID == ID).FirstOrDefault();
                    context.SalesInvoceDetails.Remove(item);
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