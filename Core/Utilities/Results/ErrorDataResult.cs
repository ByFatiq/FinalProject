using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Results
{
    public class ErrorDataResult<T> : DataResult<T>
    {
        public ErrorDataResult(T data, string message) : base(data, false, message)
        {

        }

        public ErrorDataResult(T data) : base(data, false)//data gönder ama Mesajsız versiyonu.
        {

        }

        public ErrorDataResult(string message) : base(default, false, message) // default dön - doğru ve mesajı göster
        {

        }

        public ErrorDataResult() : base(default, false) // data yok mesaj yok yalnız true dön
        {

        }

    }
}
