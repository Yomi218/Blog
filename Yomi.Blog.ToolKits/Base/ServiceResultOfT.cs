using System;
using System.Collections.Generic;
using System.Text;

namespace Yomi.Blog.ToolKits.Base
{
    /// <summary>
    /// 服务层响应实体类（泛型）
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class ServiceResult<T> : ServiceResult where T : class
    {
        /// <summary>
        /// 返回结果
        /// </summary>
        public T Result { get; set; }

        public void IsSuccess(T result = null, string message = "")
        {
            Message = message;
            Code = Enum.ServiceResultCode.Success;
            Result = result;
        }
    }
}
