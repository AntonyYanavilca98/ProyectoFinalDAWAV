using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProyectoFinal.Request
{
    public class SalesInvoceDetail_Req
    {
        public int SalesInvoceDetailID { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public float Quantity { get; set; }
        public int SalesInvoceID { get; set; }
        public int ProductID { get; set; }
    }
}