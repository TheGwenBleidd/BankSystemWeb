using Microsoft.AspNetCore.Mvc.ViewFeatures;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Threading.Tasks;

namespace BankApplication.Expando
{
    /// <summary>
    /// Класс для конвертации анонимного типа
    /// </summary>
    public static class Functions
    {
        public static ExpandoObject ToExpando(this object anonymousObject)
        {
            IDictionary<string, object> anonymousDictionary = HtmlHelper.AnonymousObjectToHtmlAttributes(anonymousObject);
            IDictionary<string, object> expando = new ExpandoObject();
            foreach (var item in anonymousDictionary)
                expando.Add(item);
            return (ExpandoObject)expando;
        }
    }
}
