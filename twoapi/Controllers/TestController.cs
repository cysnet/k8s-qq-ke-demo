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
        private readonly HttpClient _httpclient;
        public TestController(ILogger<TestController> logger, HttpClient httpclient)
        {
            _logger = logger;
            _httpclient = httpclient;
        }

        [HttpGet("calloneapi")]
        public async Task<string> CallOneApiAsync()
        {
            var content = await (await _httpclient.GetAsync("http://localhost:5000/test")).Content.ReadAsStringAsync();
            return "one api response is " + content;
        }
    }
}