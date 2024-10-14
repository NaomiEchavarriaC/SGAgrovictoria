using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SGAgrovictoriaWEB.Permisos
{
	public class ValidarSesionAttribute : ActionFilterAttribute
	{
		private readonly IHttpContextAccessor _httpContextAccessor;

		public ValidarSesionAttribute(IHttpContextAccessor httpContextAccessor)
		{
			_httpContextAccessor = httpContextAccessor;
		}

		public override void OnActionExecuting(ActionExecutingContext context)
		{
			var session = _httpContextAccessor.HttpContext.Session;

			if (session.GetString("usuario") == null)
			{
				context.Result = new RedirectResult("~/Acceso/Login");
			}

			base.OnActionExecuting(context);
		}
	}

}
