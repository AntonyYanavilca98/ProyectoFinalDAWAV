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
    public class SellerProxy
    {
        private string _urlBase = URLConstant.UrlBase;
        private string _endPoint = $"{URLConstant.Prefix}{URLConstant.Seller}";
        public async Task<RespBase<Seller_Resp>> GetAll()
        {
            try
            {
                var client = new HttpClient();
                client.BaseAddress = new Uri(_urlBase);
                var response = client.GetAsync(_endPoint).Result;
                if (response.StatusCode == HttpStatusCode.OK)
                {
                    var result = await response.Content.ReadAsStringAsync();
                    return JsonConvert.DeserializeObject<RespBase<Seller_Resp>>(result);
                }
                else
                {
                    return new RespBase<Seller_Resp>
                    {
                        Code = (int)response.StatusCode,
                        Message = "Error"
                    };
                }
            }
            catch (Exception ex)
            {
                return new RespBase<Seller_Resp>
                {
                    Code = 404,
                    Message = ex.Message
                };
            }
        }

        public async Task<RespBase<Seller_Resp>> Get(int id)
        {
            var client = new HttpClient();
            client.BaseAddress = new Uri(_urlBase);

            var url = string.Concat(_endPoint, id);
            var response = client.GetAsync(url).Result;
            if (response.StatusCode == HttpStatusCode.OK)
            {
                var result = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<RespBase<Seller_Resp>>(result);
            }
            else
            {
                return new RespBase<Seller_Resp>
                {
                    Code = (int)response.StatusCode,
                    Message = "Error"
                };
            }
        }


        public async Task<RespBase<Seller_Resp>> Add(Seller_Req model)
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
                return JsonConvert.DeserializeObject<RespBase<Seller_Resp>>(result);
            }
            else
            {
                return new RespBase<Seller_Resp>
                {
                    IsSuccess = false,
                    Code = (int)response.StatusCode,
                    Message = "Error"
                };
            }
        }
        public async Task<RespBase<Seller_Resp>> Update(Seller_Req model)
        {
            var request = JsonConvert.SerializeObject(model);
            var content = new StringContent(request, Encoding.UTF8, "application/json");

            var client = new HttpClient();
            client.BaseAddress = new Uri(_urlBase);
            var url = string.Concat(_endPoint, model.SellerID);

            var response = client.PutAsync(url, content).Result;

            if (response.StatusCode == HttpStatusCode.OK)
            {
                var result = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<RespBase<Seller_Resp>>(result);
            }
            else
            {
                return new RespBase<Seller_Resp>
                {
                    IsSuccess = false,
                    Code = (int)response.StatusCode,
                    Message = "Error"
                };
            }
        }
        public async Task<RespBase<Seller_Resp>> Delete(int id)
        {
            var client = new HttpClient();
            client.BaseAddress = new Uri(_urlBase);
            var url = string.Concat(_endPoint, id);

            var response = client.DeleteAsync(url).Result;

            if (response.StatusCode == HttpStatusCode.OK)
            {
                var result = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<RespBase<Seller_Resp>>(result);
            }
            else
            {
                return new RespBase<Seller_Resp>
                {
                    IsSuccess = false,
                    Code = (int)response.StatusCode,
                    Message = "Error"
                };
            }
        }
    }
}