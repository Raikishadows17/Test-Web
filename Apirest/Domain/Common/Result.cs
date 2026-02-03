using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace Domain.Common
{
    public class Result<T>
    {
        [JsonPropertyName("Success")]
        public bool IsSuccess { get; private set; }
        [JsonPropertyName("Data")]
        public T Data { get; private set; }
        [JsonPropertyName("Messages")]
        public string Message { get; private set; }
        [JsonPropertyName("Errors")]
        public List<string> Errors { get; private set; }

        private Result(bool isSuccess, T data, string message, List<string> errors)
        {
            IsSuccess = isSuccess;
            Data = data;
            Message = message;
            Errors = errors;
        }

        public static Result<T> Success(T data, string message = "Operacion Exitosa") 
         => new Result<T>(true, data, message, null);
            
        public static Result<T> Failure(string error)
            => new Result<T>(false, default, null, new List<string> {error} );
        public static Result<T> Failure(List<string> errors)
            => new Result<T>(false, default, null, errors);
    }
}
