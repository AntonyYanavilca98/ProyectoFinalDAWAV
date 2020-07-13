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