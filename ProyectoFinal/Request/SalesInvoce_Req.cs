using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProyectoFinal.Request
{
    public class SalesInvoce_Req
    {
        public int SalesInvoceID { get; set; }
        public string Number { get; set; }
        public bool Payed { get; set; }
        public int Discount { get; set; }
        public string Reason { get; set; }
        public int CustomerID { get; set; }
        public int SellerID { get; set; }
    }
}