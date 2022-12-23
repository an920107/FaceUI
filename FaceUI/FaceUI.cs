using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FaceUI
{
    public partial class FaceUI : Form
    {
        public FaceUI()
        {
            InitializeComponent();
        }

        private void FaceUI_Load(object sender, EventArgs e)
        {
            
        }

        private void imageButton_Click(object sender, EventArgs e)
        {
            string url = this.imageUrlTextBox.Text;

        }
    }
}
