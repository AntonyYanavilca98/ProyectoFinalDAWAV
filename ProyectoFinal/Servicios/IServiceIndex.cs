using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ProyectoFinal.Helpers;

namespace ProyectoFinal.Servicios
{
    public interface IServiceIndex
    {

        RespBase<T> GetList();
        RespBase<T> Get(int ID);
        RespBase<T> Add(T model);
        RespBase<T> Update(T model);
        RespBase<T> Delete(int ID);
    }
}