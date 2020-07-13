using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProyectoFinal.Response
{
    public class SalesInvoceDetail_Resp
    {
        public int SalesInvoceDetailID { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public float Quantity { get; set; }
        public int SalesInvoceID { get; set; }
        public bool State { get; set; }
        public int ProductID { get; set; }
        public virtual Product_Resp Product { get; set; }
        public virtual SalesInvoce_Resp SalesInvoce { get; set; }
    }
}