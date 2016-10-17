using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Linq;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace SjIo.Controllers
{
    public class HomeController : Controller
    {

        private readonly IHostingEnvironment hostEnv;

        public HomeController(IHostingEnvironment hostingEnvironment) {
            hostEnv = hostingEnvironment;
        }

        public IActionResult Index()
        {
            var resume = GetXML("resume.xml");
            return View(resume);
        }
 
        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";
            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";
            return View();
        }

        public IActionResult Error()
        {
            return View();
        }


        
        public dynamic GetXML(string path) {
            /// <summary>
            /// Return XML file as a dynamic object
            /// </summary>
            /// <param name="path"></param>
            /// <returns></returns>
            XDocument doc = XDocument.Load(hostEnv.WebRootPath + "/data/" + path);
            string json = JsonConvert.SerializeXNode(doc);
            return JsonConvert.DeserializeObject<ExpandoObject>(json);
        }

    }



}
