namespace Lab_2_DB.Controllers;

using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Text;

using Newtonsoft.Json;


public class ControllerBase : Controller
{
	public override void OnActionExecuted(ActionExecutedContext context)
	{
		if( context.Exception != null ) {
			ViewData["exception-message"] = context.Exception.Message;
			ViewData["exception-type"] = context.Exception.GetType().Name;
			context.Result = View("_Exception");
			context.ExceptionHandled = true;
		}

		var requestId = (String)context.HttpContext.Items["HttpRequestID"];

		if( Sql.Queries.ContainsKey(requestId) )
		{
			var queries = Sql.Queries[requestId].ToArray();
			var jsonQueries = JsonConvert.SerializeObject(queries);
			var base64JsonQueries = Convert.ToBase64String(Encoding.UTF8.GetBytes(jsonQueries));

			if( context.Result is ViewResult )
				((ViewResult)context.Result).ViewData["sql-queries"] = base64JsonQueries;

			Sql.Queries.Remove(requestId, out _);
		}

		base.OnActionExecuted(context);
	}

	public override void OnActionExecuting(ActionExecutingContext context)
	{
		Sql.LocalInstance.Value = new Sql((String)context.HttpContext.Items["HttpRequestID"]);

		base.OnActionExecuting(context);
	}

	public override Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
	{
		Sql.LocalInstance.Value = new Sql((String)context.HttpContext.Items["HttpRequestID"]);

		return base.OnActionExecutionAsync(context, next);
	}
}



