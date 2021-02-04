using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MiBahia_Estate.Helpers
{
    public class MyFilter : IActionFilter
    {
        private readonly ILogger<MyFilter> logger;

        public MyFilter(ILogger<MyFilter> logger)
        {
            this.logger = logger;
        }

        void IActionFilter.OnActionExecuted(ActionExecutedContext context)
        {
            throw new NotImplementedException();
        }

        void IActionFilter.OnActionExecuting(ActionExecutingContext context)
        {
            throw new NotImplementedException();
        }
    }
}
