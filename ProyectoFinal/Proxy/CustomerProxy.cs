using ProyectoFinal.Helpers;
using ProyectoFinal.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Text;
using ProyectoFinal.Request;

namespace ProyectoFinal.Proxy
{
    public class CustomerProxy
    {
        public string _urlBase = URLConstant.UrlBase;
        public string _endPoint = $"{URLConstant.Prefix}{URLConstant.Customer}";

        public async Task<RespBase<Customer_Resp>> GetAll()
        {
            try
            {
                var client = new HttpClient();
                client.BaseAddress = new Uri(_urlBase);

                var response = client.GetAsync(_endPoint).Result;
                if (response.StatusCode == HttpStatusCode.OK)
                {
                    var result = await response.Content.ReadAsStringAsync();
                    return JsonConvert.DeserializeObject<RespBase<Customer_Resp>>(result);
                }
                else
                {
                    return new RespBase<Customer_Resp>
                    {
                        Code = (int)response.StatusCode,
                        Message = "Error"
                    };
                }
            }
            catch (Exception ex)
            {
                return new RespBase<Customer_Resp>
                {
                    Code = 404,
                    Message = ex.Message
                };
            }
        }

        public async Task<RespBase<Customer_Resp>> Get(int id)
        {
            var client = new HttpClient();
            client.BaseAddress = new Uri(_urlBase);

            var url = string.Concat(_endPoint, id);
            var response = client.GetAsync(url).Result;
            if (response.StatusCode == HttpStatusCode.OK)
            {
                var result = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<RespBase<Customer_Resp>>(result);
            }
            else
            {
                return new RespBase<Customer_Resp>
                {
                    Code = (int)response.StatusCode,
                    Message = "Error"
                };
            }
        }


        public async Task<RespBase<Customer_Resp>> Add(Customer_Req model)
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
                return JsonConvert.DeserializeObject<RespBase<Customer_Resp>>(result);
            }

            return new RespBase<Customer_Resp>
            {
                IsSuccess = false,
                Code = (int)response.StatusCode,
                Message = "Error"
            };

        }
        public async Task<RespBase<Customer_Resp>> Update(Customer_Req model)
        {

            var request = JsonConvert.SerializeObject(model);
            var content = new StringContent(request, Encoding.UTF8, "application/json");

            var client = new HttpClient();
            client.BaseAddress = new Uri(_urlBase);

            var url = string.Concat(_endPoint);

            var response = client.PutAsync(url, content).Result;

            if (response.StatusCode == HttpStatusCode.OK)
            {
                var result = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<RespBase<Customer_Resp>>(result);
            }
            return new RespBase<Customer_Resp>
            {
                IsSuccess = false,
                Code = (int)response.StatusCode,
                Message = "Error"
            };
        }
        public async Task<RespBase<Customer_Resp>> Delete(int id)
        {
            var client = new HttpClient();
            client.BaseAddress = new Uri(_urlBase);
            var url = string.Concat(_endPoint, id);

            var response = client.DeleteAsync(url).Result;

            if (response.StatusCode == HttpStatusCode.OK)
            {
                var result = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<RespBase<Customer_Resp>>(result);
            }
            else
            {
                return new RespBase<Customer_Resp>
                {
                    IsSuccess = false,
                    Code = (int)response.StatusCode,
                    Message = "Error"
                };
            }
        }
    }
}