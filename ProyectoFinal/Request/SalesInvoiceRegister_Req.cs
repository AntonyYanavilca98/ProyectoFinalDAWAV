
using System.Collections.Generic;

namespace ProyectoFinal.Request
{
    public class SalesInvoiceRegister_Req
    {
        public SalesInvoce_Req SalesInvoice { get; set; }
        public List<SalesInvoceDetail_Req> SalesInvoceDetails { get; set; }
    }
}