using System.Configuration;

namespace ProyectoFinal.Helpers
{
    public static class URLConstant
    {
        public static string UrlBase = ConfigurationManager.AppSettings["UrlBase"];
        public static string Prefix = ConfigurationManager.AppSettings["Prefix"];
        public static string Login = ConfigurationManager.AppSettings["Login"];
        public static string Customer = ConfigurationManager.AppSettings["Customer"];
        public static string Product = ConfigurationManager.AppSettings["Product"];
        public static string Seller = ConfigurationManager.AppSettings["Seller"];
        public static string SalesInvoice = ConfigurationManager.AppSettings["SalesInvoice"];
        public static string SalesInvoiceDetail = ConfigurationManager.AppSettings["SalesInvoiceDetail"];
    }
}