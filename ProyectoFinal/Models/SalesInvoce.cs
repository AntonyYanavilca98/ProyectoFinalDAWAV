using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ProyectoFinal.Models
{
    public class SalesInvoce
    {
        [Key]
        public int SalesInvoceID { get; set; }

        public string Number { get; set; }

        public bool Payed { get; set; }

        public int discount { get; set; }

        public string Reason { get; set; }

        public DateTime CreateAt { get; set; }

        public bool State { get; set; }

        public int CustomerID { get; set; }

        public int SellerID { get; set; }

        public Customer Customer { get; set; }
        public Seller Seller { get; set; }
        public ICollection<SalesInvoceDetail> SalesInvoceDetails { get; set; }
    }
}