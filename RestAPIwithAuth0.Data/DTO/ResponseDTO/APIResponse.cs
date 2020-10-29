using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace RestAPIwithAuth0.Data.DTO.ResponseDTO
{
    public class APIResponse<T>
    {
        public string message { get; set; }
#nullable enable
        public object? errors { get; set; }
#nullable disable
        [MaybeNull, AllowNull]
        public T data { get; set; }
    }

    public class APIResponse : APIResponse<object> { }
}
