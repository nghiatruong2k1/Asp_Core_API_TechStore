using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace Application.Helper
{
    public class ConvertObject
    {
        public void merge(Object a,Object b)
        {
            if (a != null && b != null)
            {
                var propsA = a.GetType().GetProperties(BindingFlags.Public | BindingFlags.Instance);
                var typeB = b.GetType();
                foreach (PropertyInfo propa in propsA)
                {
                    var check = typeB.GetProperty(propa.Name);
                    if (check != null)
                    {
                        var value = check.GetValue(b);
                        propa.SetValue(a, value);
                    }
                }
            }
        }
    }
}
