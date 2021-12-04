using System.Collections.Generic;

namespace Comercio.Domain.Base
{
    public class ResponseBase<T>
    {
        public ResponseBase(T data, List<string> errors)
        {
            Data = data;
            Errors = errors;
        }

        public ResponseBase(T data)
        {
            Data = data;
        }

        public ResponseBase(List<string> errors)
        {
            Errors = errors;
        }

        public ResponseBase(string error)
        {
            Errors.Add(error);
        }

        public T Data { get; private set; }
        public List<string> Errors { get; private set; } = new();
    }
}
