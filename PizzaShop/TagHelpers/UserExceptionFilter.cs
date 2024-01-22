using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace PizzaShop.TagHelpers
{
    public class UserExceptionFilter : IExceptionFilter
    {
        private IModelMetadataProvider _metadataProvider;

        public UserExceptionFilter (IModelMetadataProvider metadataProvider)
        {
            _metadataProvider = metadataProvider;
        }
        public void OnException(ExceptionContext context)
        {
            var result = new ViewResult { ViewName = "UserError" };

            result.ViewData = new Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary(_metadataProvider, context.ModelState);

            result.ViewData.Add("Caused by", context.Exception);

            context.ExceptionHandled = true;
            context.Result = result;
        }
    }
}
