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
        static string LargeGroupId = "111_ncu_iot_test4";
        static bool debug = true;

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

        public static async Task CreateLargeGroup() {
            var client = new HttpClient();
            client.DefaultRequestHeaders.Add("Ocp-Apim-Subscription-Key", apikey);
            var queryString = HttpUtility.ParseQueryString(string.Empty);
            var uri = "https://westcentralus.api.cognitive.microsoft.com/face/v1.0/largepersongroups/" + LargeGroupId + "?" + queryString;
            HttpResponseMessage response;

            // Request body
            byte[] byteData = Encoding.UTF8.GetBytes("{'name': 'faceconfig_test'}");

            string result;
            using (var content = new ByteArrayContent(byteData)) {
                content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
                response = Task.Run(() => client.PutAsync(uri, content)).Result;
                //response = await client.PutAsync(uri, content);
                result = await response.Content.ReadAsStringAsync();
            }
            if (debug)
                Console.WriteLine(result);
        }

        public static async Task<string> AddPersonInfo(String info) {
            var client = new HttpClient();
            client.DefaultRequestHeaders.Add("Ocp-Apim-Subscription-Key", apikey);
            var queryString = HttpUtility.ParseQueryString(string.Empty);

            var uri = "https://westcentralus.api.cognitive.microsoft.com/face/v1.0/largepersongroups/" + LargeGroupId + "/persons";

            //request body
            byte[] byteData = Encoding.UTF8.GetBytes(info);

            HttpResponseMessage response;
            string result;
            using (var content = new ByteArrayContent(byteData)) {
                content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
                response = Task.Run(() => client.PostAsync(uri, content)).Result;
                //response = await client.PostAsync(uri, content);
                result = await response.Content.ReadAsStringAsync();
            }
            if (debug)
                Console.WriteLine(result);
            return (result.Substring(13, result.Length - 15));
        }

        public static async Task AddFaceToPerson(string personid, string img_url) {
            var client = new HttpClient();
            client.DefaultRequestHeaders.Add("Ocp-Apim-Subscription-Key", apikey);
            var queryString = HttpUtility.ParseQueryString(string.Empty);

            var uri = "https://westcentralus.api.cognitive.microsoft.com/face/v1.0/largepersongroups/" + LargeGroupId + "/persons/" + personid + "/persistedfaces?" + queryString;

            //request body
            byte[] byteData = Encoding.UTF8.GetBytes("{'url': '" + img_url + "'}");

            HttpResponseMessage response;
            string result;
            using (var content = new ByteArrayContent(byteData)) {
                content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
                response = Task.Run(() => client.PostAsync(uri, content)).Result;
                //response = await client.PostAsync(uri, content);
                result = await response.Content.ReadAsStringAsync();
            }
            if (debug)
                Console.WriteLine(result);
        }

        public static async Task TrainLibrery() {
            var client = new HttpClient();
            client.DefaultRequestHeaders.Add("Ocp-Apim-Subscription-Key", apikey);

            var uri = "https://westcentralus.api.cognitive.microsoft.com/face/v1.0/largepersongroups/" + LargeGroupId + "/train";

            HttpResponseMessage response;
            string result;
            byte[] byteData = Encoding.UTF8.GetBytes("");
            using (var content = new ByteArrayContent(byteData)) {
                content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
                response = Task.Run(() => client.PostAsync(uri, content)).Result;
                //response = await client.PostAsync(uri, content);
                result = await response.Content.ReadAsStringAsync();
            }
            if (debug)
                Console.WriteLine(result);
        }

        public static async Task<string> GetInputFaceId(string img_url) {
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
            using (var content = new ByteArrayContent(byteData)) {
                content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
                response = Task.Run(() => client.PostAsync(uri, content)).Result;
                //response = await client.PostAsync(uri, content);
                result = await response.Content.ReadAsStringAsync();
            }
            if (debug)
                Console.WriteLine(result);

            return result;
        }

        public static async Task<string> FindInLibrary(string inputid) {
            var client = new HttpClient();
            client.DefaultRequestHeaders.Add("Ocp-Apim-Subscription-Key", apikey);
            var queryString = HttpUtility.ParseQueryString(string.Empty);

            var uri = "https://westcentralus.api.cognitive.microsoft.com/face/v1.0/identify?" + queryString;
            byte[] byteData = Encoding.UTF8.GetBytes("{'largePersonGroupId': \"" + LargeGroupId + "\", 'faceIds':[ \"" + inputid + "\"], 'maxNumOfCandidatesReturned': 1, 'confidenceThreshold': 0.5}");

            HttpResponseMessage response;
            string result;
            using (var content = new ByteArrayContent(byteData)) {
                content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
                response = Task.Run(() => client.PostAsync(uri, content)).Result;
                //response = await client.PostAsync(uri, content);
                result = await response.Content.ReadAsStringAsync();
            }
            if (debug)
                Console.WriteLine(result);

            return result;
            JObject parseresult = JObject.Parse(result.Substring(1, result.Length - 2));


            //return parseresult["candidates"][0].ToString();
        }

        public static async Task<string> GetMatchPersonInfo(string personid) {
            var client = new HttpClient();
            client.DefaultRequestHeaders.Add("Ocp-Apim-Subscription-Key", apikey);

            var uri = "https://westcentralus.api.cognitive.microsoft.com/face/v1.0/largepersongroups/" + LargeGroupId + "/persons/" + personid;
            var response = Task.Run(() => client.GetAsync(uri)).Result;
            //response = await client.PostAsync(uri, content);
            string result = await response.Content.ReadAsStringAsync();

            JObject parseresult = JObject.Parse(result);
            Console.WriteLine(parseresult);
            return parseresult["name"].ToString();
        }
    }
}

