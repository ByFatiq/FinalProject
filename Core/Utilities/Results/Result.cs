using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Results
{
    public class Result: IResult
    {
   

        public Result(bool success, string messagge):this(success)// this(Bu constructura(RESULT) success parametresini de göndererek 2sinide senkron edip bool değerini ve mesajı gönderebiliyoruz..
        {
            Messagge = messagge;
        }

        public Result(bool success)
        {
            
            Success = success;
        }


        public bool Success { get; }
        public string Messagge { get; }
    }
}
