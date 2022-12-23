using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FaceUI {
    public partial class FaceUI : Form {
        public FaceUI() {
            InitializeComponent();
        }

        private void FaceUI_Load(object sender, EventArgs e) {
            
        }

        private void ImageButton_Click(object sender, EventArgs e) {
            string imgUrl = this.imageUrlTextBox.Text;
            this.pictureBox.Load(imgUrl);
            string age = "";
            string gender = "";
            string glasses = "";
            this.ageLabel.Text = age;
            this.genderLabel.Text = gender;
            this.glassesLabel.Text = glasses;
        }

        private void FindButton_Click(object sender, EventArgs e) {
            bool isFaceIdExist = false;
            if (isFaceIdExist) {
                string name = "";
                string confidence = "";
                string imgUrl = "";
                this.nameLabel.Text = name;
                this.confidenceLabel.Text = confidence;
                this.pictureBox.Load(imgUrl);
            }
            else {
                MessageBox.Show("Cannot find the face in data library.");
            }
        }

        private void AddButton_Click(object sender, EventArgs e) {
            bool isFaceIdExist = false;
            if (isFaceIdExist) {
                MessageBox.Show("There has been the face in data library.");
            }
            else {

            }
        }

        private void PicturesListBox_SelectedIndexChanged(object sender, EventArgs e) {
            string selectedImg = this.picturesListBox.SelectedItem.ToString();
        }
    }
}
