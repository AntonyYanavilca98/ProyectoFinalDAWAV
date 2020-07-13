
using System.Collections.Generic;

namespace ProyectoFinal.Helpers
{
    public class RespBase<T>
    {
        public int Code { get; set; }

        public bool IsSuccess { get; set; }

        public string Message { get; set; }

        public IEnumerable<T> List { get; set; }

        public T Object { get; set; }

        public object Clone()
        {
            return this.MemberwiseClone();
        }
        public override string ToString()
        {
            return $"{Code} {Message} {List} {Object}";
        }
    }
}