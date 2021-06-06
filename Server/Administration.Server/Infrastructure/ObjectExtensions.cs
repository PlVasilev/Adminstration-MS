﻿using Microsoft.AspNetCore.Mvc;

namespace Administration.Server.Infrastructure
{
    public static class ObjectExtensions
    {
        public static ActionResult<TModel> OrNotFound<TModel>(this TModel model)
        {
            if (model == null)
            {
                return new NotFoundResult();
            }

            return model;
        }
    }
}
