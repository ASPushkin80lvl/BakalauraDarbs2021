using BenchmarkTest.Models;
using Microsoft.AspNetCore.Mvc;
using RandomNameGen;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BenchmarkTest.Controllers
{
    public struct NumRequest
    {
        public int Num { get; set; }
    }

    [ApiController]
    [Route("[action]")]
    public class TestController : Controller
    {
        private readonly BakalauraDarbsDBContext _dc;

        public TestController(BakalauraDarbsDBContext dc) => _dc = dc;

        #region [FILL DATABASE]

        [HttpGet, ActionName("DatabaseCreate")]
        public void DatabaseCreate()
        {
            var names = new RandomName(new Random(DateTime.Now.Second)).RandomNames(101, 0);
            for (int i = 2; i <= 100; i++)
            {
                _dc.Users.Add(new User { Id = i, Name = names[i] });
            }

            _dc.SaveChanges();
        }

        #endregion

        [HttpGet, ActionName("")]
        public string Get() => "Benchmark test ASP.NET Core";

        [HttpGet, ActionName("Database")]
        public string Database() => GetUserName("ASP.NET CORE");

        [HttpPost, ActionName("Fibonnaci")]
        public string Fibonnaci(NumRequest req) => CreateFibonnaciString(req.Num);

        private string GetUserName(string tech)
        {
            var user = _dc.Users.First(u => u.Name == tech);
            return $"{user.Id} -- {user.Name}";
        }

        private static string CreateFibonnaciString(int num)
        {
            var numbers = new List<string>() { "0", "1" };
            double n1 = 0, n2 = 1, n3;
            for (int i = 2; i < num; i++)
            {
                n3 = n1 + n2;
                numbers.Add(n3.ToString());
                n1 = n2;
                n2 = n3;
            }
            return string.Join(" | ", numbers);
        }
    }
}
