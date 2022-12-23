using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FaceUI {
    public partial class FaceUI : Form {

        Dictionary<string, List<string>> nameUrlListDict = new Dictionary<string, List<string>>();

        public FaceUI() {
            InitializeComponent();
        }

        private void FaceUI_Load(object sender, EventArgs e) {

        }

        private void ImageButton_Click(object sender, EventArgs e) {
            string imgUrl = this.imageUrlTextBox.Text;
            string[] attr = new string[0];
            if (imgUrl.Equals(""))
                return;
            this.pictureBox.Load(imgUrl);
            attr = Program.GetInputAttr(imgUrl).Result;
            Console.WriteLine(attr[0]);
            string age = attr[0];
            string gender = attr[1];
            string glasses = attr[2];
            this.ageLabel.Text = age;
            this.genderLabel.Text = gender;
            this.glassesLabel.Text = glasses;
        }

        private void FindButton_Click(object sender, EventArgs e) {
            bool isFaceIdExist = true;
            if (isFaceIdExist) {
                string imgUrl = this.imageUrlTextBox.Text;
                this.pictureBox.Load(imgUrl);
                
                string inputresult = Program.GetInputFaceId(imgUrl).Result;
                JObject resultjson = JObject.Parse(inputresult.Substring(1, inputresult.Length - 2));

                string imgid = resultjson["faceId"].ToString();
                string result = Program.FindInLibrary(imgid).Result;
                Console.WriteLine(result);
                JObject parsedresult = JObject.Parse(result.Substring(1, result.Length-2));
                string confidence = parsedresult["candidates"][0]["confidence"].ToString();
                string personid = parsedresult["candidates"][0]["personId"].ToString();
                string name = Program.GetMatchPersonInfo(personid).Result;
                Console.WriteLine("name:" + name, "confidence:" + confidence);

                this.nameLabel.Text = name;
                this.confidenceLabel.Text = confidence;
                this.picturesListBox.Items.Clear();
                foreach (var url in nameUrlListDict[name])
                    this.picturesListBox.Items.Add(url);
            }
            else {
                MessageBox.Show("Cannot find the face in data library.");
            }
        }

        private void AddButton_Click(object sender, EventArgs e) {

            string name = this.nameTextBox.Text;
            string imgUrl = this.imageUrlTextBox.Text;

            bool isFaceIdExist = false;
            if (isFaceIdExist) {
                MessageBox.Show("There has been the face in data library.");
            }
            else {
                Program.CreateLargeGroup();
                string info = "{'name': '"+ name +"', 'userData':'{}'}";
                Console.WriteLine(info);
                string personid = Program.AddPersonInfo(info).Result;
                Program.AddFaceToPerson(personid, this.imageUrlTextBox.Text);
                Program.TrainLibrery();
                MessageBox.Show("Add Success!");
            }

            //this.picturesListBox.Items.Add(imgUrl);
            if (!nameUrlListDict.ContainsKey(name))
                nameUrlListDict.Add(name, new List<string>()); 
            nameUrlListDict[name].Add(imgUrl);
        }

        private void PicturesListBox_SelectedIndexChanged(object sender, EventArgs e) {
            string imgUrl = this.picturesListBox.SelectedItem.ToString();
            this.pictureBox.Load(imgUrl);
            this.imageUrlTextBox.Text = imgUrl;
            this.ImageButton_Click(this, new EventArgs());
        }
    }
}
