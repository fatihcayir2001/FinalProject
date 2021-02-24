using Core.Utilities.Results;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Business
{
    public class BusinessRules
    {
                                 //params yazınca istediğin kadar IResult verebilirsin
        public static IResult Run(params IResult[] logics)
        {
            foreach (var logic in logics)
            {
                //hatalı olan kuralı haber ediyoruz
                if (logic.Success==false)
                {
                    return logic;
                }
            }
            return null;
        }
    }
}
