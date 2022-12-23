using Newtonsoft.Json.Linq;
using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Windows.Forms;

namespace FaceUI
{
    static class Program
    {

        static string apikey = "9afa2810150f48d999afac58761d4773";
        static string LargeGroupId = "111_ncu_iot_test1";
        static bool debug = false;

        /// <summary>
        /// 應用程式的主要進入點。
        /// </summary>
        [STAThread]
       static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new FaceUI());

            Console.ReadLine();
        }

        public static async Task<string[]> GetInputAttr(string img_url)
        {
            var client = new HttpClient();
            client.DefaultRequestHeaders.Add("Ocp-Apim-Subscription-Key", apikey);
            var queryString = HttpUtility.ParseQueryString(string.Empty);

            queryString["returnFaceId"] = "true";
            queryString["returnFaceLandmarks"] = "false";
            queryString["returnFaceAttributes"] = "age, gender, glasses";

            var uri = "https://westcentralus.api.cognitive.microsoft.com/face/v1.0/detect?" + queryString;

            byte[] byteData = Encoding.UTF8.GetBytes("{'url': '" + img_url + "'}");

            HttpResponseMessage response;
            string result;
            using (var content = new ByteArrayContent(byteData))
            {
                content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
                response = Task.Run(() => client.PostAsync(uri, content)).Result;
                //response = await client.PostAsync(uri, content);
                result = await response.Content.ReadAsStringAsync();
            }
            if (debug)
                Console.WriteLine(result);

            JObject resultjson = JObject.Parse(result.Substring(1, result.Length - 2));

            string gender = resultjson["faceAttributes"]["gender"].ToString();
            string age = resultjson["faceAttributes"]["age"].ToString();
            string glasses = resultjson["faceAttributes"]["glasses"].ToString();
            string[] Attributes = { gender, age, (!glasses.StartsWith("No")).ToString().ToLower() };

            return Attributes;
        }
    }
}

