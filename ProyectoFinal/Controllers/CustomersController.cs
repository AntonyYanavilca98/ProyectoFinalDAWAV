﻿using ProyectoFinal.Helpers;
using ProyectoFinal.Request;
using ProyectoFinal.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using ProyectoFinal.Proxy;

namespace ProyectoFinal.Controllers
{
    public class CustomerController : Controller
    {
        CustomerProxy proxy = new CustomerProxy();

        // GET: Customer
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public JsonResult GetAll()
        {
            var response = Task.Run(() => proxy.GetAll());
            return Json(response.Result.List, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public JsonResult Get(int id)
        {
            var response = Task.Run(() => proxy.Get(id));
            return Json(response.Result.Object, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult Add(Customer_Req customer)
        {
            if (customer.CustomerID == 0)
            {
                var response = Task.Run(() => proxy.Add(customer));
                return Json(response, JsonRequestBehavior.AllowGet);
            }
            else
            {
                var response = Task.Run(() => proxy.Update(customer));
                return Json(response, JsonRequestBehavior.AllowGet);
            }

        }


        [HttpPost]
        public ActionResult Delete(int id)
        {
            var response = Task.Run(() => proxy.Delete(id));
            string message = response.Result.Message;
            return Json(new { Message = message, JsonRequestBehavior.AllowGet });
        }

    }
}