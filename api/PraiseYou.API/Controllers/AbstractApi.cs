using Microsoft.AspNetCore.Mvc;
using PraiseYou.Application;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace PraiseYou.API.Controllers
{
    public class AbstractApi : ControllerBase
    {
        protected ActionResult Success(object o)
        {
            return StatusCode(200, o);
        }

        protected ActionResult Success()
        {
            return new StatusCodeResult(200);
        }

        protected ActionResult FromFile(string downloadFilneName, FileInfo file, string mimeType)
        {
            var memory = new MemoryStream();
            using (var stream = file.OpenRead())
            {
                stream.CopyTo(memory);
            }
            memory.Position = 0;

            var result = new FileStreamResult(memory, mimeType);
            result.FileDownloadName = downloadFilneName;
            return result;
        }

        protected ActionResult CustomAppError(object errorObject)
        {
            return StatusCode(422, errorObject);
        }

        protected ActionResult DefaultAppError(string[] errorMessages)
        {
            return StatusCode(422, new CommandResponse().Attr("messages", errorMessages));
        }

        protected ActionResult Error(Exception e)
        {
            if (e is UnauthorizedAccessException) return new StatusCodeResult(401);
            
            if (e is CustomAppException)
            {
                var customAppException = (CustomAppException)e;
                return CustomAppError(customAppException.CustomData);
            }

            if (e is DefaultAppException)
            {
                var defaultAppException = (DefaultAppException)e;
                return DefaultAppError(
                    !defaultAppException.UserFriendlyMessages.Any() ?
                    new string[] { "Operação inválida" } : defaultAppException.UserFriendlyMessages.ToArray());
            }


            return new StatusCodeResult(500);
        }
    }

    public class CommandResponse
    {
        public Dictionary<string, object> Data { get; set; } = new Dictionary<string, object>();
        public CommandResponse Attr(string key, object value)
        {
            this.Data.Add(key, value);
            return this;
        }
    }
}
