using System;

namespace ProyectoFinal.Request
{
    public class Customer_Req
    {
        public int CustomerID { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public DateTime Birthdate { get; set; }
    }
}