using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.IO;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Net.Http.Headers;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Newtonsoft.Json.Linq;
using RecommandationApp.Models;
using System.Data.Entity;
using Newtonsoft.Json;

namespace RecommandationApp.Controllers
{
    public class StringTable
    {
        public string[] ColumnNames { get; set; }
        public string[,] Values { get; set; }
    }

    public class RecommendationController : Controller
    {
        static string currentUserId;
        private ApplicationDbContext db = new ApplicationDbContext();

        public RecommendationController()
        {
            //            currentUserId = User.Identity.GetUserId();
            currentUserId= System.Web.HttpContext.Current.User.Identity.GetUserId();

        }
        // GET: Recommendation
        public async Task<ActionResult> Index()
        {
            try
            {
//                var offres = db.Offres.Include(o => o.Representant);

                var result = await InvokeRequestResponseService();
                var obj = JObject.Parse(result);
                var suggestedOffres = obj["Results"]["output1"]["value"]["Values"][0]
                    .Select(i => i.Value<string>())
                    .Select(i => int.Parse(i));

                List<int> termsList = new List<int>();

                //return Content("Context hello...");
                Boolean first = true;
                foreach (var item in obj["Results"]["output1"]["value"]["Values"][0])
                {
                    //int x = Int32.Parse(TextBoxD1.Text);

                    if (!first) termsList.Add(Int32.Parse(item.ToString()));

                    first = false;                    
                }

                String res = "";
                foreach(var it in termsList)
                {
                    res += " " + it;
                }
                var itemEntity = db.Offres.Where(m => termsList.Contains(m.Id));
                return View(itemEntity);

                //                .Select(i => offres.Where(x => x.Id == i));                
                //                return View(suggestedOffres.ToList());
            }
            catch (Exception e)
            {

//                _logger.LogError(string.Format("An error occured:'{0}'", e));
                var offres = db.Offres.Include(o => o.Representant);

                return Content(e.Message);
//                return View(offres.ToList());
            }            
        }

        static async Task<string> InvokeRequestResponseService()
        {

            
            using (var client = new HttpClient())
            {
                var scoreRequest = new
                {

                    Inputs = new Dictionary<string, StringTable>() {
                        {
                            "input1",
                            new StringTable()
                            {
                                ColumnNames = new string[] {"Client_Id"},
                                Values = new string[,] {  { currentUserId },  { currentUserId },  }
                            }
                        },
                    },
                    GlobalParameters = new Dictionary<string, string>()
                    {
                    }
                };
                const string apiKey = "IUCJEmwd/0MGqG1d3PLhGO5eplfeFTjjsi5kFohym2C/z/gMwR+wOHYZrJ4e3n9hOFSBFXdFohyzy47UENI/zQ=="; // Replace this with the API key for the web service
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", apiKey);

                client.BaseAddress = new Uri("https://ussouthcentral.services.azureml.net/workspaces/ec164974fe8f458999d7d858d4efa243/services/1e2a1f708a1741aa8406eb2992dfbe19/execute?api-version=2.0&details=true");

                // WARNING: The 'await' statement below can result in a deadlock if you are calling this code from the UI thread of an ASP.Net application.
                // One way to address this would be to call ConfigureAwait(false) so that the execution does not attempt to resume on the original context.
                // For instance, replace code such as:
                //      result = await DoSomeTask()
                // with the following:
                //      result = await DoSomeTask().ConfigureAwait(false)


                HttpResponseMessage response = await client.PostAsJsonAsync("", scoreRequest);

                if (response.IsSuccessStatusCode)
                {
                    string result = await response.Content.ReadAsStringAsync();
                    //                    Console.WriteLine("Result: {0}", result);
                    Console.WriteLine("Result: {0}", result);
                    return result;
                }
                else
                {
                    Console.WriteLine(string.Format("The request failed with status code: {0}", response.StatusCode));
//                    System.Diagnostics.Debug.WriteLine(string.Format("The request failed with status code: {0}",
//                        response.StatusCode));

                    // Print the headers - they include the requert ID and the timestamp, which are useful for debugging the failure
//                    Console.WriteLine(response.Headers.ToString());
                    System.Diagnostics.Debug.WriteLine(response.Headers.ToString());
                    string responseContent = await response.Content.ReadAsStringAsync();
                    Console.WriteLine(responseContent);
//                    System.Diagnostics.Debug.WriteLine(responseContent);
                    return null;
                }
            }
        }
        

    }
}