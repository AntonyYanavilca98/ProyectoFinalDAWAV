using Newtonsoft.Json;
using ProyectoFinal.Helpers;
using ProyectoFinal.Request;
using ProyectoFinal.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace ProyectoFinal.Proxy
{
    public class SalesInvoiceProxy
    {
        private string _urlBase = URLConstant.UrlBase;
        private string _endPoint = $"{URLConstant.Prefix}{URLConstant.SalesInvoice}";

        public async Task<RespBase<SalesInvoiceSP_Resp>> GetAll()
        {
            try
            {
                var client = new HttpClient();
                client.BaseAddress = new Uri(_urlBase);
                var response = await client.GetAsync(_endPoint);
                var answer = await response.Content.ReadAsStringAsync();
                if (!response.IsSuccessStatusCode)
                {
                    return new RespBase<SalesInvoiceSP_Resp>
                    {
                        Code = 404,
                        Message = "Error"
                    };
                }
                var obj = JsonConvert.DeserializeObject<RespBase<SalesInvoiceSP_Resp>>(answer);
                return obj;
            }
            catch (Exception ex)
            {
                return new RespBase<SalesInvoiceSP_Resp>
                {
                    Code = 404,
                    Message = ex.Message
                };
            }
        }

        public async Task<RespBase<SalesInvoce_Resp>> Get(int id)
        {
            var client = new HttpClient();
            client.BaseAddress = new Uri(_urlBase);

            var url = string.Concat(_endPoint, id);
            var response = client.GetAsync(url).Result;
            if (response.StatusCode == HttpStatusCode.OK)
            {
                var result = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<RespBase<SalesInvoce_Resp>>(result);
            }
            else
            {
                return new RespBase<SalesInvoce_Resp>
                {
                    Code = (int)response.StatusCode,
                    Message = "Error"
                };
            }
        }


        public async Task<RespBase<SalesInvoce_Resp>> Add(SalesInvoce_Req model)
        {
            var request = JsonConvert.SerializeObject(model);
            var content = new StringContent(request, Encoding.UTF8, "application/json");

            var client = new HttpClient();
            client.BaseAddress = new Uri(_urlBase);
            var url = string.Concat(_endPoint);

            var response = client.PostAsync(url, content).Result;

            if (response.StatusCode == HttpStatusCode.OK)
            {
                var result = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<RespBase<SalesInvoce_Resp>>(result);
            }
            else
            {
                return new RespBase<SalesInvoce_Resp>
                {
                    IsSuccess = false,
                    Code = (int)response.StatusCode,
                    Message = "Error"
                };
            }
        }
        public async Task<RespBase<SalesInvoce_Resp>> Add(SalesInvoiceRegister_Req model)
        {
            var request = JsonConvert.SerializeObject(model);
            var content = new StringContent(request, Encoding.UTF8, "application/json");

            var client = new HttpClient();
            client.BaseAddress = new Uri(_urlBase);
            var url = string.Concat(_endPoint);

            var response = await client.PostAsync(url, content);
            var answer = await response.Content.ReadAsStringAsync();
            if (!response.IsSuccessStatusCode)
            {
                return new RespBase<SalesInvoce_Resp>
                {
                    IsSuccess = false,
                    Code = (int)response.StatusCode,
                    Message = "Error"
                };
            }
            return JsonConvert.DeserializeObject<RespBase<SalesInvoce_Resp>>(answer);
        }
        public async Task<RespBase<SalesInvoce_Resp>> Update(SalesInvoce_Req model)
        {
            var request = JsonConvert.SerializeObject(model);
            var content = new StringContent(request, Encoding.UTF8, "application/json");

            var client = new HttpClient();
            client.BaseAddress = new Uri(_urlBase);
            var url = string.Concat(_endPoint, model.SalesInvoceID);

            var response = client.PutAsync(url, content).Result;

            if (response.StatusCode == HttpStatusCode.OK)
            {
                var result = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<RespBase<SalesInvoce_Resp>>(result);
            }
            else
            {
                return new RespBase<SalesInvoce_Resp>
                {
                    IsSuccess = false,
                    Code = (int)response.StatusCode,
                    Message = "Error"
                };
            }
        }
        public async Task<RespBase<SalesInvoce_Resp>> Delete(int id)
        {
            var client = new HttpClient();
            client.BaseAddress = new Uri(_urlBase);
            var url = string.Concat(_endPoint, id);

            var response = client.DeleteAsync(url).Result;

            if (response.StatusCode == HttpStatusCode.OK)
            {
                var result = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<RespBase<SalesInvoce_Resp>>(result);
            }
            else
            {
                return new RespBase<SalesInvoce_Resp>
                {
                    IsSuccess = false,
                    Code = (int)response.StatusCode,
                    Message = "Error"
                };
            }
        }
    }
}