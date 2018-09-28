using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace Venus.Core
{
    public class Core
    {
        protected string Connstr = string.Empty;

        protected virtual void CheckIsTestorStandard<T>(T type)
        {

            if (type.GetType().Name == "UnitTest1")
            {

            }
        }


        public virtual String CheckIS<T>(Func<T, String> func)
        {
            var type = typeof(T);

            var name = type.GetProperties()[0].Attributes;


            return "";
        }


    }
}
