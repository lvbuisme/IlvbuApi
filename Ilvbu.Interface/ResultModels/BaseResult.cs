using System;
using System.Collections.Generic;
using System.Text;

namespace Ilvbu.Interface.ResultModels
{
    public partial class BaseResult
    {
        /// <summary>失败</summary>
        public const int CODE_FAIL = -1;
        /// <summary>成功</summary>
        public const int CODE_SCCUESS = 1;

        private int _code;
        //返回类型
        public int Code
        {
            get { return _code; }
            set { _code = value; }
        }

        /// <summary>
        /// 是否成功
        /// </summary>
        public bool IsSccuess
        {
            get { return _code >= 0; }
        }

        public bool HasTip
        {
            get { return !string.IsNullOrEmpty(Message); }
        }

        private string _message;
        //说明信息
        public string Message
        {
            get { return _message; }
            set { _message = value; }
        }

        public BaseResult(int code = CODE_SCCUESS, string message = "")
        {
            this.Code = code;
            this.Message = message;
        }

        public BaseResult(string message)
        {
            this.Code = CODE_SCCUESS;
            this.Message = message;
        }
    }

    public partial class BaseResult<T> : BaseResult
    {
        private T _data;
        /// <summary>
        /// 返回数据
        /// </summary>
        public T Data
        {
            get { return _data; }
            set { _data = value; }
        }
        public BaseResult(int code, string message = "", T data = default(T))
            : base(code, message)
        {
            this.Data = data;
        }

        public BaseResult(string message = "", T data = default(T))
            : base(message)
        {
            this.Data = data;
        }

        public BaseResult(T data)
            : base(string.Empty)
        {
            this.Data = data;
        }

        public BaseResult()
        {
            this.Data = default(T);
        }
    }

    public partial class BaseResult
    {
        public static BaseResult From(string message)
        {
            return new BaseResult(message);
        }
        public static BaseResult From(BaseResult source)
        {
            return new BaseResult(source.Code, source.Message);
        }
    }

    public partial class BaseResult<T>
    {
        public static BaseResult<T> From(T data = default(T))
        {
            return new BaseResult<T>(data);
        }

        public static BaseResult<T> From(string message, T data = default(T))
        {
            return new BaseResult<T>(message, data);
        }

        public static BaseResult<T> From<S>(BaseResult source)
        {
            return new BaseResult<T>(source.Code, source.Message);
        }
        public static BaseResult<T> From<S>(BaseResult<S> source)
        {
            T data = default(T);
            if (source.Data is S)
            {
                data = (T)(object)source.Data;
            }
            return new BaseResult<T>(source.Code, source.Message, data);
        }

    }

}
