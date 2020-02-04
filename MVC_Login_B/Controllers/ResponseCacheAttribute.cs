using System;

namespace MVC_Login_B.Controllers
{
    internal class ResponseCacheAttribute : Attribute
    {
        public int Duration { get; set; }
        public object ResponseCacheLocation { get; set; }
        public object Location { get; set; }
        public bool NoStore { get; set; }
    }
}