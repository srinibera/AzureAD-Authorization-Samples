﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ExceptionHandling.API.ExceptionHandlers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace ExceptionHandling.API.Filters
{
    public class ApplicationExceptionFilter:ExceptionFilterAttribute
    {         

        public override Task OnExceptionAsync(ExceptionContext context)
        {
            switch (context.Exception)
            {
                case CommandValidationException validateEx:
                    context.Result = new BadRequestObjectResult(new { Errors = validateEx.Errors.Values });
                    break;
                case DataNotFoundException notFoundEx:
                    context.Result = new NotFoundObjectResult(new { Errors = new string[] { notFoundEx.Message } });
                    break;
            }             
            
            return base.OnExceptionAsync(context);
        }
    }
}
