using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Results
{
    public class SuccessDataResult <T>:DataResult<T>
    {
        public SuccessDataResult(T data, string message):base(data, true,message)
        {
            
        }

        public SuccessDataResult(T data) : base(data, true)//data gönder ama Mesajsız versiyonu.
        {

        }

        public SuccessDataResult(string message) : base(default,true,message) // default dön - doğru ve mesajı göster
        {
            
        }

        public SuccessDataResult() : base(default, true) // data yok mesaj yok yalnız true dön
        {

        }

    }
}
