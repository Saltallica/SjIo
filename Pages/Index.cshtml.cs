using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Linq;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;

namespace sjio2.Pages
{
    public class IndexModel : PageModel
    {

        public dynamic resume {get; set;}

        private readonly IHostingEnvironment hostEnv;

        public IndexModel(IHostingEnvironment hostingEnvironment) {
            hostEnv = hostingEnvironment;
        }

        public void OnGet()
        {
            resume = GetXML("resume.xml");
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
