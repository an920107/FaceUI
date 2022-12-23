using System;
using System.Net.Http.Headers;
using System.Text;
using System.Net.Http;
using System.Web;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace CSHttpClientSample
{
    static class Program
    {
        static string apikey = "9afa2810150f48d999afac58761d4773";
        static string LargeGroupId = "111_ncu_iot_test1";
        static bool debug = true;
        static void Main()
        {
            Process();
            Console.ReadLine();
        }

        static async void Process()
        {
            await CreateLargeGroup();
            Console.WriteLine("Create Large Group succeess\n");


            string Info = "{'name': 'wayne', 'userData': \"{'gender':'male', 'age': 32, 'hair': 'black'}\"}";
            string personid = await AddPersonInfo(Info);
            Console.WriteLine("GroupPersonAdd success\n");

            string img = "https://i.pinimg.com/originals/d9/86/94/d98694ef5c2f9a02c2f4fb8f6c4e094c.jpg";
            await AddFaceToPerson(personid, img);
            Console.WriteLine("FaceInfo success\n");


            await TrainLibrery();
            Console.WriteLine("Train success\n");

            img = "https://i.pinimg.com/originals/8c/72/c8/8c72c89deb03d0caa88c9a1e0a27bc63.jpg";
            string inputresult = await GetInputFaceId(img);

            JObject resultjson = JObject.Parse(inputresult.Substring(1, inputresult.Length-2));

            string gender = resultjson["faceAttributes"]["gender"].ToString();
            string age = resultjson["faceAttributes"]["age"].ToString();
            string glasses = resultjson["faceAttributes"]["glasses"].ToString();
            string[] Attributes = { gender, age, glasses };
            


            string inputfaceid = resultjson["faceId"].ToString();
            Console.WriteLine("get input face success\n");

            string outputpersonjson = await FindInLibrary(inputfaceid);
            JObject parsedoutput = JObject.Parse(outputpersonjson);

            string outputpersonid = parsedoutput["personId"].ToString();
            string confidence = parsedoutput["confidence"].ToString();
            
            Console.WriteLine("Get Match Person success\n");


            string result = await GetMatchPersonInfo(outputpersonid);
            Console.WriteLine(result);
            Console.WriteLine("Get Match Person Info success\n");
        }

        static async Task CreateLargeGroup()
        {
            var client = new HttpClient();
            client.DefaultRequestHeaders.Add("Ocp-Apim-Subscription-Key", apikey);
            var queryString = HttpUtility.ParseQueryString(string.Empty);
            var uri = "https://westcentralus.api.cognitive.microsoft.com/face/v1.0/largepersongroups/" + LargeGroupId + "?" + queryString;
            HttpResponseMessage response;

            // Request body
            byte[] byteData = Encoding.UTF8.GetBytes("{'name': 'faceconfig_test'}");

            string result;
            using (var content = new ByteArrayContent(byteData))
            {
                content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
                response = await client.PutAsync(uri, content);
                result = await response.Content.ReadAsStringAsync();
            }
            if(debug)
            Console.WriteLine(result);
        }

        static async Task<string> AddPersonInfo(String info)
        {
            var client = new HttpClient();
            client.DefaultRequestHeaders.Add("Ocp-Apim-Subscription-Key", apikey);
            var queryString = HttpUtility.ParseQueryString(string.Empty);

            var uri = "https://westcentralus.api.cognitive.microsoft.com/face/v1.0/largepersongroups/" + LargeGroupId + "/persons";

            //request body
            byte[] byteData = Encoding.UTF8.GetBytes(info);

            HttpResponseMessage response;
            string result;
            using (var content = new ByteArrayContent(byteData))
            {
                content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
                response = await client.PostAsync(uri, content);
                result = await response.Content.ReadAsStringAsync();
            }
            if (debug)
                Console.WriteLine(result);
            return (result.Substring(13, result.Length - 15));
        }
     
        static async Task AddFaceToPerson(string personid, string img_url)
        {
            var client = new HttpClient();
            client.DefaultRequestHeaders.Add("Ocp-Apim-Subscription-Key", apikey);
            var queryString = HttpUtility.ParseQueryString(string.Empty);

            var uri = "https://westcentralus.api.cognitive.microsoft.com/face/v1.0/largepersongroups/" + LargeGroupId + "/persons/"+personid+"/persistedfaces?"+queryString;

            //request body
            byte[] byteData = Encoding.UTF8.GetBytes("{'url': '"+ img_url +"'}");

            HttpResponseMessage response;
            string result;
            using (var content = new ByteArrayContent(byteData))
            {
                content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
                response = await client.PostAsync(uri, content);
                result = await response.Content.ReadAsStringAsync();
            }
            if (debug)
                Console.WriteLine(result);
        }

        static async Task TrainLibrery()
        {
            var client = new HttpClient();
            client.DefaultRequestHeaders.Add("Ocp-Apim-Subscription-Key", apikey);

            var uri = "https://westcentralus.api.cognitive.microsoft.com/face/v1.0/largepersongroups/" + LargeGroupId + "/train";

            HttpResponseMessage response;
            string result;
            byte[] byteData = Encoding.UTF8.GetBytes("");
            using (var content = new ByteArrayContent(byteData))
            {
                content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
                response = await client.PostAsync(uri, content);
                result = await response.Content.ReadAsStringAsync();
            }
            if (debug)
                Console.WriteLine(result);
        }

        static async Task<string> GetInputFaceId(string img_url)
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
                response = await client.PostAsync(uri, content);
                result = await response.Content.ReadAsStringAsync();
            }
            if (debug)
                Console.WriteLine(result);

            return result;
        }

        static async Task<string> FindInLibrary(string inputid)
        {
            var client = new HttpClient();
            client.DefaultRequestHeaders.Add("Ocp-Apim-Subscription-Key", apikey);
            var queryString = HttpUtility.ParseQueryString(string.Empty);

            var uri = "https://westcentralus.api.cognitive.microsoft.com/face/v1.0/identify?" + queryString;
            byte[] byteData = Encoding.UTF8.GetBytes("{'largePersonGroupId': \""+LargeGroupId+"\", 'faceIds':[ \""+ inputid+"\"], 'maxNumOfCandidatesReturned': 1, 'confidenceThreshold': 0.5}");
            
            HttpResponseMessage response;
            string result;
            using (var content = new ByteArrayContent(byteData))
            {
                content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
                response = await client.PostAsync(uri, content);
                result = await response.Content.ReadAsStringAsync();
            }
            if (debug)
                Console.WriteLine(result);

            JObject parseresult = JObject.Parse(result.Substring(1, result.Length-2));
 

            return parseresult["candidates"][0].ToString();
        }

        static async Task<string> GetMatchPersonInfo(string personid)
        {
            var client = new HttpClient();
            client.DefaultRequestHeaders.Add("Ocp-Apim-Subscription-Key", apikey);

            var uri = "https://westcentralus.api.cognitive.microsoft.com/face/v1.0/largepersongroups/" + LargeGroupId + "/persons/" + personid;
            var response = await client.GetAsync(uri);
            string result = await response.Content.ReadAsStringAsync();

            JObject parseresult = JObject.Parse(result);
            Console.WriteLine(parseresult);
            return parseresult["name"].ToString();
        }
    }
}