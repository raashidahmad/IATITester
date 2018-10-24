using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IATITester.IATILib;
using IATITester.IATILib.IATIVersion1;
using IATITester.IATILib.IATIVersion2;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace IATITester.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        // GET api/values
        [HttpGet]
        public IActionResult Get()
        {
            string activitiesURL;
            IParserIATI parserIATI;
            XMLResultVersion2 returnResult2 = null;
            XMLResultVersion1 returnResult1 = null;

            try
            {
                string country = "BD";
                string org = "CA-3";
                activitiesURL = "http://datastore.iatistandard.org/api/1/access/activity.xml?recipient-country=" + country + "&reporting-org=" + org + "&stream=True";
                //activitiesURL = "http://datastore.iatistandard.org/api/1/access/activity.xml?recipient-country=" + country + "&stream=True";
                //Parser v2.01
                parserIATI = new ParserIATIV2();

                returnResult2 = (XMLResultVersion2)parserIATI.ParseIATIXML(activitiesURL);

                var iatiactivityArray = returnResult2?.iatiactivities?.iatiactivity;
                if (iatiactivityArray != null && iatiactivityArray.n()[0].AnyAttr.n()[0].Value.StartsWith("1.0"))
                {
                    //Parser v1.05
                    parserIATI = new ParserIATIV1();
                    returnResult1 = (XMLResultVersion1)parserIATI.ParseIATIXML(activitiesURL);

                    //Conversion
                    ConvertIATIVersion2 convertIATIv2 = new ConvertIATIVersion2();
                    returnResult2 = convertIATIv2.ConvertIATI105to201XML(returnResult1, returnResult2);
                }
            }
            catch (Exception ex)
            {
                returnResult2.n().Value = ex.Message;
            }
            string jsonStr = JsonConvert.SerializeObject(returnResult2);
            dynamic json = JsonConvert.DeserializeObject(jsonStr);
            return Ok(json);
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
