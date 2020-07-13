using System;

namespace ProyectoFinal.Request
{
    public class Product_Req
    {
        public int ProductID { get; set; }
        public string Name { get; set; }
        public int Stock { get; set; }
        public Decimal Price { get; set; }
        public string Remarks { get; set; }
    }
}