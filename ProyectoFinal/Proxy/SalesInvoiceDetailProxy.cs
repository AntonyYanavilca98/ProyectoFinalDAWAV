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
    public class SalesInvoiceDetailProxy
    {
        static string baseUrl = UrlAPI.Url((int)Numerable.SalesInvoiceDetail);
        public async Task<RespBase<SalesInvoceDetail_Resp>> GetAll()
        {
            try
            {
                var client = new HttpClient();
                client.BaseAddress = new Uri(baseUrl);

                var url = string.Concat(baseUrl);
                var response = client.GetAsync(url).Result;
                if (response.StatusCode == HttpStatusCode.OK)
                {
                    var result = await response.Content.ReadAsStringAsync();
                    return JsonConvert.DeserializeObject<RespBase<SalesInvoceDetail_Resp>>(result);
                }
                else
                {
                    return new RespBase<SalesInvoceDetail_Resp>
                    {
                        Code = (int)response.StatusCode,
                        Message = "Error"
                    };
                }
            }
            catch (Exception ex)
            {
                return new RespBase<SalesInvoceDetail_Resp>
                {
                    Code = 404,
                    Message = ex.Message
                };
            }
        }

        public async Task<RespBase<SalesInvoceDetail_Resp>> Get(int id)
        {
            var client = new HttpClient();
            client.BaseAddress = new Uri(baseUrl);

            var url = string.Concat(baseUrl, id);
            var response = client.GetAsync(url).Result;
            if (response.StatusCode == HttpStatusCode.OK)
            {
                var result = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<RespBase<SalesInvoceDetail_Resp>>(result);
            }
            else
            {
                return new RespBase<SalesInvoceDetail_Resp>
                {
                    Code = (int)response.StatusCode,
                    Message = "Error"
                };
            }
        }


        public async Task<RespBase<SalesInvoceDetail_Resp>> Add(SalesInvoceDetail_Req model)
        {
            var request = JsonConvert.SerializeObject(model);
            var content = new StringContent(request, Encoding.UTF8, "application/json");

            var client = new HttpClient();
            client.BaseAddress = new Uri(baseUrl);
            var url = string.Concat(baseUrl);

            var response = client.PostAsync(url, content).Result;

            if (response.StatusCode == HttpStatusCode.OK)
            {
                var result = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<RespBase<SalesInvoceDetail_Resp>>(result);
            }
            else
            {
                return new RespBase<SalesInvoceDetail_Resp>
                {
                    IsSuccess = false,
                    Code = (int)response.StatusCode,
                    Message = "Error"
                };
            }
        }
        public async Task<RespBase<SalesInvoceDetail_Resp>> Update(SalesInvoceDetail_Req model)
        {
            var request = JsonConvert.SerializeObject(model);
            var content = new StringContent(request, Encoding.UTF8, "application/json");

            var client = new HttpClient();
            client.BaseAddress = new Uri(baseUrl);
            var url = string.Concat(baseUrl, model.SalesInvoceID);

            var response = client.PutAsync(url, content).Result;

            if (response.StatusCode == HttpStatusCode.OK)
            {
                var result = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<RespBase<SalesInvoceDetail_Resp>>(result);
            }
            else
            {
                return new RespBase<SalesInvoceDetail_Resp>
                {
                    IsSuccess = false,
                    Code = (int)response.StatusCode,
                    Message = "Error"
                };
            }
        }
        public async Task<RespBase<SalesInvoceDetail_Resp>> Delete(int id)
        {
            var client = new HttpClient();
            client.BaseAddress = new Uri(baseUrl);
            var url = string.Concat(baseUrl, id);

            var response = client.DeleteAsync(url).Result;

            if (response.StatusCode == HttpStatusCode.OK)
            {
                var result = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<RespBase<SalesInvoceDetail_Resp>>(result);
            }
            else
            {
                return new RespBase<SalesInvoceDetail_Resp>
                {
                    IsSuccess = false,
                    Code = (int)response.StatusCode,
                    Message = "Error"
                };
            }
        }
    }
}