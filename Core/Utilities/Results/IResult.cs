using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Results
{
    
    //Temel Voidler için Başlangıç.
    public interface IResult
    {
        //Get yalnız okunabilir. Set yazılabilir.

        bool Success { get; }
        string Messagge { get; }


    }
    

}