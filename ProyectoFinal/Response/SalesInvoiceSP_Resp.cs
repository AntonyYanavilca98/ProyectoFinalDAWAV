﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProyectoFinal.Response
{
    public class SalesInvoiceSP_Resp
    {
        public int SalesInvoceID { get; set; }

        public string Number { get; set; }
        public DateTime CreateAt { get; set; }
        public string Seller { get; set; }
        public string Customer { get; set; }
        public decimal SubTotal { get; set; }
        public int Discount { get; set; }
        public decimal Total { get; set; }
        public bool Payed { get; set; }
    }
}