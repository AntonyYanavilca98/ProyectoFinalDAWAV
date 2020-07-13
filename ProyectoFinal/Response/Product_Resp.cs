using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProyectoFinal.Response
{
    public class Product_Resp
    {
        public int ProductID { get; set; }
        public string Name { get; set; }
        public int Stock { get; set; }
        public Decimal Price { get; set; }
        public string Remarks { get; set; }
        public DateTime CreateAt { get; set; }
        public bool State { get; set; }
        public virtual ICollection<SalesInvoceDetail_Resp> SalesInvoceDetails { get; set; }
    }
}