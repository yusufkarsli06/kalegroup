using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Security.Application;
using System;
using System.Linq;
using System.Reflection;
using System.Text.RegularExpressions;

namespace KaleArge.Admin.Filter
{
    public class XssProtectionFilter : ActionFilterAttribute
    {
        // XSS saldırısına neden olabilecek tehlikeli etiketler listesi
        private static readonly string[] DangerousTags = { "script", "iframe", "object", "embed", "form", "img", "svg", "link" ,"select","from","where","update","insert"};

        public override void OnActionExecuting(ActionExecutingContext context)
        {
            foreach (var argument in context.ActionArguments)
            {
                if (argument.Value != null && argument.Value.GetType().IsClass)
                {
                    var properties = argument.Value.GetType().GetProperties(BindingFlags.Public | BindingFlags.Instance)
                        .Where(p => p.PropertyType == typeof(string) && p.CanWrite && p.CanRead);

                    foreach (var property in properties)
                    {
                        if (property.Name == "Description"|| property.Name == "EnDescription" || property.Name== "PageDescription" || 
                            property.Name== "EnPageDescription")
                            continue;


                        var currentValue = property.GetValue(argument.Value) as string;
                        if (!string.IsNullOrEmpty(currentValue))
                        {
                            // Eğer zararlı içerik varsa kaydedilmesini engelle
                            if (ContainsDangerousContent(currentValue))
                            {
                                // JavaScript ile alert mesajı döndür ve sayfayı değiştirme
                                context.Result = new ContentResult
                                {
                                    Content = "<script>alert('Kayıt tehlikeli içerik içeriyor ve engellendi.'); window.history.back();</script>",
                                    ContentType = "text/html; charset=utf-8",
                                    StatusCode = 200
                                };
                                return;
                            }

                            // XSS koruma: HTML encode işlemi
                            var encodedValue = Microsoft.Security.Application.Encoder.HtmlEncode(currentValue);
                            property.SetValue(argument.Value, encodedValue);
                        }
                    }
                }
            }

            base.OnActionExecuting(context);
        }

        // Zararlı içeriği kontrol eden metot
        private bool ContainsDangerousContent(string input)
        {
            foreach (var tag in DangerousTags)
            {
                string pattern = $@"<\s*{tag}\b[^>]*>(.*?)<\s*/\s*{tag}\s*>";
                if (Regex.IsMatch(input, pattern, RegexOptions.IgnoreCase))
                {
                    return true;
                }
            }
            return false;
        }
    }
}
