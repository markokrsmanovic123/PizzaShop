using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace PizzaShop.TagHelpers
{
    public class UserExceptionFilter : IExceptionFilter
    {
        private readonly IModelMetadataProvider _metadataProvider;

        public UserExceptionFilter (IModelMetadataProvider metadataProvider)
        {
            _metadataProvider = metadataProvider;
        }
        public void OnException(ExceptionContext context)
        {
            LogExceptionToFile(context.Exception);

            var result = new ViewResult { ViewName = "UserError" };

            result.ViewData = new Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary(_metadataProvider, context.ModelState);

            result.ViewData.Add("Caused by", context.Exception);

            context.ExceptionHandled = true;
            context.Result = result;
        }

        private void LogExceptionToFile(Exception exception)
        {
            string? logPath = "C:\\Users\\krsma\\source\\repos\\PizzaShop\\PizzaShop\\wwwroot\\errorlog.txt";

            using (StreamWriter writer = new StreamWriter(logPath, true))
            {
                writer.WriteLine("-------------------------------------------------------------");
                writer.WriteLine($"{DateTime.Now} {exception.GetType().FullName}: {exception.Message}");
                writer.WriteLine($"StackTrace: {exception.StackTrace}");
                writer.WriteLine();
            }
        }

    }
}
