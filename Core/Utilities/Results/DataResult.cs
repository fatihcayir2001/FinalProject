using Core.Utilities.Results;
using System.Collections.Generic;

namespace Core.Utilities.Results
{
    public class DataResult<T> : Result, IDataResult<T>
    {
        //diğer resulttan tek farkı T data
                                                                //
        public DataResult(T data,bool success,string message):base(success,message)
        {
            Data = data;
        }

        public DataResult(T data, bool success):base(success)
        {
            Data = data;
        }

        public T Data { get; }
    }
}