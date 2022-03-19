using Microsoft.AspNetCore.Mvc;

using System.Net;
using System.Net.Sockets;

namespace oneapi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TestController : ControllerBase
    {
        private readonly ILogger<TestController> _logger;

        public TestController(ILogger<TestController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public string Get()
        {
            var ip = System.Net.NetworkInformation.NetworkInterface.GetAllNetworkInterfaces().Select(p => p.GetIPProperties()).SelectMany(p => p.UnicastAddresses)
                .Where(p => p.Address.AddressFamily == System.Net.Sockets.AddressFamily.InterNetwork && !System.Net.IPAddress.IsLoopback(p.Address))
                .FirstOrDefault()?.Address.ToString();
            return "ip is " + ip;
        }


        [HttpGet("highcpu")]
        public string HighCpu(int minutes)
        {
            var now = DateTime.Now;
            while (DateTime.Now - now <= TimeSpan.FromMinutes(minutes))
            {
                _logger.LogInformation(DateTime.Now.ToString());
            }
            return "ok";
        }


    }
}