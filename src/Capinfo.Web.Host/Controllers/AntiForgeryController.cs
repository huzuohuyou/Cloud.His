using Microsoft.AspNetCore.Antiforgery;
using Capinfo.Controllers;

namespace Capinfo.Web.Host.Controllers
{
    public class AntiForgeryController : CapinfoControllerBase
    {
        private readonly IAntiforgery _antiforgery;

        public AntiForgeryController(IAntiforgery antiforgery)
        {
            _antiforgery = antiforgery;
        }

        public void GetToken()
        {
            _antiforgery.SetCookieTokenAndHeader(HttpContext);
        }
    }
}
