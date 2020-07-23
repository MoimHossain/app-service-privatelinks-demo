using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Backend.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class InfoController : ControllerBase
    {
        private readonly IHttpContextAccessor _contextAccessor;

        public InfoController(IHttpContextAccessor contextAccessor)
        {
            _contextAccessor = contextAccessor;
        }

        private string GetClientIPAddress()
        {
            try
            {
                var remoteIpAddress = _contextAccessor.HttpContext.Connection.RemoteIpAddress.ToString();
                return remoteIpAddress;
            }
            catch
            {

            }
            return string.Empty;
        }

        private string GetServerIPAddress()
        {
            try
            {
                var httpConnectionFeature = _contextAccessor.HttpContext.Features.Get<IHttpConnectionFeature>();
                return httpConnectionFeature?.LocalIpAddress.ToString();
            }
            catch
            {

            }
            return string.Empty;
        }

        private string GetHostname()
        {
            
            try
            {
                return Environment.GetEnvironmentVariable("CUMPUTERNAME") ?? Environment.GetEnvironmentVariable("HOSTNAME");
            }
            catch
            {

            }
            return string.Empty;
        }

        [HttpGet]
        public ServerInfoResponse Get()
        {
            return new ServerInfoResponse 
            {
                Timestamp = DateTime.Now,
                Hostname = GetHostname(),
                ServerIPAddress = GetServerIPAddress(),
                ClientIPAddress = GetClientIPAddress(),
            };
        }
    }
}
