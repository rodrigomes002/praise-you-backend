using System;
using System.Collections.Generic;

namespace PraiseYou.Application
{
    public class BaseFacade
    {
    }

    public class CustomAppException : ApplicationException
    {
        public object CustomData { get; set; }
        public CustomAppException() {}
        public CustomAppException(object data) : base()
        {
            this.CustomData = data;
        }
    }

    public class DefaultAppException : ApplicationException
    {
        public List<string> UserFriendlyMessages { get; set; } = new List<string>();
        public DefaultAppException() {}
        public DefaultAppException(string message) : base(message)
        {
            this.UserFriendlyMessages.Add(message);
        }
    }
}
