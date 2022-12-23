
namespace FaceUI
{
    partial class FaceUI
    {
        /// <summary>
        /// 設計工具所需的變數。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清除任何使用中的資源。
        /// </summary>
        /// <param name="disposing">如果應該處置受控資源則為 true，否則為 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 設計工具產生的程式碼

        /// <summary>
        /// 此為設計工具支援所需的方法 - 請勿使用程式碼編輯器修改
        /// 這個方法的內容。
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.imageUrlTextBox = new System.Windows.Forms.TextBox();
            this.imageButton = new System.Windows.Forms.Button();
            this.pictureBox = new System.Windows.Forms.PictureBox();
            this.ageLabel = new System.Windows.Forms.Label();
            this.genderLabel = new System.Windows.Forms.Label();
            this.glassesLabel = new System.Windows.Forms.Label();
            this.findButton = new System.Windows.Forms.Button();
            this.addButton = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.nameLabel = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.confidenceLabel = new System.Windows.Forms.Label();
            this.picturesListBox = new System.Windows.Forms.ListBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(31, 58);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 1;
            this.label1.Text = "選擇圖片";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(31, 201);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 12);
            this.label2.TabIndex = 1;
            this.label2.Text = "眼鏡";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(31, 106);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(29, 12);
            this.label3.TabIndex = 1;
            this.label3.Text = "年齡";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(31, 153);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(29, 12);
            this.label4.TabIndex = 1;
            this.label4.Text = "性別";
            // 
            // imageUrlTextBox
            // 
            this.imageUrlTextBox.Location = new System.Drawing.Point(104, 56);
            this.imageUrlTextBox.Margin = new System.Windows.Forms.Padding(2);
            this.imageUrlTextBox.Name = "imageUrlTextBox";
            this.imageUrlTextBox.Size = new System.Drawing.Size(190, 22);
            this.imageUrlTextBox.TabIndex = 2;
            // 
            // imageButton
            // 
            this.imageButton.Location = new System.Drawing.Point(309, 56);
            this.imageButton.Margin = new System.Windows.Forms.Padding(2);
            this.imageButton.Name = "imageButton";
            this.imageButton.Size = new System.Drawing.Size(75, 23);
            this.imageButton.TabIndex = 3;
            this.imageButton.Text = "偵測";
            this.imageButton.UseVisualStyleBackColor = true;
            this.imageButton.Click += new System.EventHandler(this.ImageButton_Click);
            // 
            // pictureBox
            // 
            this.pictureBox.Location = new System.Drawing.Point(424, 56);
            this.pictureBox.Margin = new System.Windows.Forms.Padding(2);
            this.pictureBox.Name = "pictureBox";
            this.pictureBox.Size = new System.Drawing.Size(374, 330);
            this.pictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox.TabIndex = 4;
            this.pictureBox.TabStop = false;
            // 
            // ageLabel
            // 
            this.ageLabel.AutoSize = true;
            this.ageLabel.Location = new System.Drawing.Point(104, 106);
            this.ageLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.ageLabel.Name = "ageLabel";
            this.ageLabel.Size = new System.Drawing.Size(24, 12);
            this.ageLabel.TabIndex = 5;
            this.ageLabel.Text = "Age";
            // 
            // genderLabel
            // 
            this.genderLabel.AutoSize = true;
            this.genderLabel.Location = new System.Drawing.Point(104, 153);
            this.genderLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.genderLabel.Name = "genderLabel";
            this.genderLabel.Size = new System.Drawing.Size(39, 12);
            this.genderLabel.TabIndex = 5;
            this.genderLabel.Text = "Gender";
            // 
            // glassesLabel
            // 
            this.glassesLabel.AutoSize = true;
            this.glassesLabel.Location = new System.Drawing.Point(104, 201);
            this.glassesLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.glassesLabel.Name = "glassesLabel";
            this.glassesLabel.Size = new System.Drawing.Size(38, 12);
            this.glassesLabel.TabIndex = 5;
            this.glassesLabel.Text = "Glasses";
            // 
            // findButton
            // 
            this.findButton.Location = new System.Drawing.Point(33, 364);
            this.findButton.Name = "findButton";
            this.findButton.Size = new System.Drawing.Size(75, 23);
            this.findButton.TabIndex = 6;
            this.findButton.Text = "檢索";
            this.findButton.UseVisualStyleBackColor = true;
            this.findButton.Click += new System.EventHandler(this.FindButton_Click);
            // 
            // addButton
            // 
            this.addButton.Location = new System.Drawing.Point(123, 364);
            this.addButton.Name = "addButton";
            this.addButton.Size = new System.Drawing.Size(75, 23);
            this.addButton.TabIndex = 6;
            this.addButton.Text = "新增";
            this.addButton.UseVisualStyleBackColor = true;
            this.addButton.Click += new System.EventHandler(this.AddButton_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(31, 250);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(29, 12);
            this.label5.TabIndex = 7;
            this.label5.Text = "姓名";
            // 
            // nameLabel
            // 
            this.nameLabel.AutoSize = true;
            this.nameLabel.Location = new System.Drawing.Point(104, 250);
            this.nameLabel.Name = "nameLabel";
            this.nameLabel.Size = new System.Drawing.Size(32, 12);
            this.nameLabel.TabIndex = 7;
            this.nameLabel.Text = "Name";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(31, 297);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(41, 12);
            this.label7.TabIndex = 7;
            this.label7.Text = "信心值";
            // 
            // confidenceLabel
            // 
            this.confidenceLabel.AutoSize = true;
            this.confidenceLabel.Location = new System.Drawing.Point(102, 297);
            this.confidenceLabel.Name = "confidenceLabel";
            this.confidenceLabel.Size = new System.Drawing.Size(59, 12);
            this.confidenceLabel.TabIndex = 7;
            this.confidenceLabel.Text = "Confidence";
            // 
            // picturesListBox
            // 
            this.picturesListBox.FormattingEnabled = true;
            this.picturesListBox.ItemHeight = 12;
            this.picturesListBox.Location = new System.Drawing.Point(219, 106);
            this.picturesListBox.Name = "picturesListBox";
            this.picturesListBox.Size = new System.Drawing.Size(165, 280);
            this.picturesListBox.TabIndex = 8;
            this.picturesListBox.SelectedIndexChanged += new System.EventHandler(this.PicturesListBox_SelectedIndexChanged);
            // 
            // FaceUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(845, 446);
            this.Controls.Add(this.picturesListBox);
            this.Controls.Add(this.confidenceLabel);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.nameLabel);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.addButton);
            this.Controls.Add(this.findButton);
            this.Controls.Add(this.glassesLabel);
            this.Controls.Add(this.genderLabel);
            this.Controls.Add(this.ageLabel);
            this.Controls.Add(this.pictureBox);
            this.Controls.Add(this.imageButton);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.imageUrlTextBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "FaceUI";
            this.Text = "FaceUI";
            this.Load += new System.EventHandler(this.FaceUI_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox imageUrlTextBox;
        private System.Windows.Forms.Button imageButton;
        private System.Windows.Forms.PictureBox pictureBox;
        private System.Windows.Forms.Label ageLabel;
        private System.Windows.Forms.Label genderLabel;
        private System.Windows.Forms.Label glassesLabel;
        private System.Windows.Forms.Button findButton;
        private System.Windows.Forms.Button addButton;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label nameLabel;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label confidenceLabel;
        private System.Windows.Forms.ListBox picturesListBox;
    }
}

