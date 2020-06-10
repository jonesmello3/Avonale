using System;

namespace ProvaAvonale.Domain.Entities.Auxiliar
{
    public class Response
    {
        public bool Success { get; set; }
        public string Message { get; set; }
        public Exception Error { get; set; }
        public Object Data { get; set; }
    }
}
