using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace WebApi.Filters
{
	public class CustomExceptionFilterAttribute : ExceptionFilterAttribute
	{
		private readonly IHostingEnvironment _hostingEnvironment;
		private readonly IModelMetadataProvider _modelMetadataProvider;

		public CustomExceptionFilterAttribute(
			IHostingEnvironment hostingEnvironment,
			IModelMetadataProvider modelMetadataProvider)
		{
			_hostingEnvironment = hostingEnvironment;
			_modelMetadataProvider = modelMetadataProvider;
		}

		public override void OnException(ExceptionContext context)
		{
			var actionName = context.ActionDescriptor.DisplayName;
			context.Result = new ContentResult
			{
				Content = $"An error occurred in the {actionName} action",
				ContentType = "text/plain",
				StatusCode = StatusCodes.Status500InternalServerError
			};
		}
	}
}
