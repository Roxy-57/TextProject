namespace testProject2
{
    partial class Form1
    {
        /// <summary>
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 디자이너에서 생성한 코드

        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InitializeComponent()
        {
            this.lblStory = new System.Windows.Forms.Label();
            this.btnChoice1 = new System.Windows.Forms.Button();
            this.btnChoice2 = new System.Windows.Forms.Button();
            this.lblResult = new System.Windows.Forms.Label();
            this.txtName = new System.Windows.Forms.TextBox();
            this.btnStart = new System.Windows.Forms.Button();
            this.lblMonsterStatus = new System.Windows.Forms.Label();
            this.btnChoice3 = new System.Windows.Forms.Button();
            this.pictureBoxMonster = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxMonster)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // lblStory
            // 
            this.lblStory.AutoSize = true;
            this.lblStory.BackColor = System.Drawing.Color.Transparent;
            this.lblStory.Font = new System.Drawing.Font("한컴 말랑말랑 Bold", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblStory.Location = new System.Drawing.Point(246, 279);
            this.lblStory.Name = "lblStory";
            this.lblStory.Size = new System.Drawing.Size(63, 25);
            this.lblStory.TabIndex = 0;
            this.lblStory.Text = "label1";
            // 
            // btnChoice1
            // 
            this.btnChoice1.Location = new System.Drawing.Point(248, 332);
            this.btnChoice1.Name = "btnChoice1";
            this.btnChoice1.Size = new System.Drawing.Size(75, 23);
            this.btnChoice1.TabIndex = 1;
            this.btnChoice1.Text = "button1";
            this.btnChoice1.UseVisualStyleBackColor = true;
            this.btnChoice1.Click += new System.EventHandler(this.btnChoice1_Click);
            // 
            // btnChoice2
            // 
            this.btnChoice2.Location = new System.Drawing.Point(356, 332);
            this.btnChoice2.Name = "btnChoice2";
            this.btnChoice2.Size = new System.Drawing.Size(75, 23);
            this.btnChoice2.TabIndex = 2;
            this.btnChoice2.Text = "button2";
            this.btnChoice2.UseVisualStyleBackColor = true;
            this.btnChoice2.Click += new System.EventHandler(this.btnChoice2_Click);
            // 
            // lblResult
            // 
            this.lblResult.AutoSize = true;
            this.lblResult.Font = new System.Drawing.Font("한컴 말랑말랑 Bold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblResult.Location = new System.Drawing.Point(132, 9);
            this.lblResult.Name = "lblResult";
            this.lblResult.Size = new System.Drawing.Size(85, 21);
            this.lblResult.TabIndex = 3;
            this.lblResult.Text = "주사위 결과";
            this.lblResult.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(292, 305);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(100, 21);
            this.txtName.TabIndex = 4;
            // 
            // btnStart
            // 
            this.btnStart.Location = new System.Drawing.Point(305, 332);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(75, 23);
            this.btnStart.TabIndex = 5;
            this.btnStart.Text = "start";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // lblMonsterStatus
            // 
            this.lblMonsterStatus.AutoSize = true;
            this.lblMonsterStatus.BackColor = System.Drawing.Color.Transparent;
            this.lblMonsterStatus.Font = new System.Drawing.Font("한컴 말랑말랑 Bold", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblMonsterStatus.Location = new System.Drawing.Point(246, 215);
            this.lblMonsterStatus.Name = "lblMonsterStatus";
            this.lblMonsterStatus.Size = new System.Drawing.Size(63, 25);
            this.lblMonsterStatus.TabIndex = 7;
            this.lblMonsterStatus.Text = "label1";
            // 
            // btnChoice3
            // 
            this.btnChoice3.Location = new System.Drawing.Point(305, 361);
            this.btnChoice3.Name = "btnChoice3";
            this.btnChoice3.Size = new System.Drawing.Size(75, 23);
            this.btnChoice3.TabIndex = 8;
            this.btnChoice3.Text = "button1";
            this.btnChoice3.UseVisualStyleBackColor = true;
            this.btnChoice3.Click += new System.EventHandler(this.btnChoice3_Click);
            // 
            // pictureBoxMonster
            // 
            this.pictureBoxMonster.Image = global::testProject2.Properties.Resources.boss;
            this.pictureBoxMonster.Location = new System.Drawing.Point(345, 76);
            this.pictureBoxMonster.Name = "pictureBoxMonster";
            this.pictureBoxMonster.Size = new System.Drawing.Size(260, 228);
            this.pictureBoxMonster.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBoxMonster.TabIndex = 9;
            this.pictureBoxMonster.TabStop = false;
            this.pictureBoxMonster.Visible = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::testProject2.Properties.Resources.room;
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(787, 562);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 6;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Paint += new System.Windows.Forms.PaintEventHandler(this.pictureBox1_Paint);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 561);
            this.Controls.Add(this.btnChoice3);
            this.Controls.Add(this.lblMonsterStatus);
            this.Controls.Add(this.btnStart);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.lblResult);
            this.Controls.Add(this.btnChoice2);
            this.Controls.Add(this.btnChoice1);
            this.Controls.Add(this.lblStory);
            this.Controls.Add(this.pictureBoxMonster);
            this.Controls.Add(this.pictureBox1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxMonster)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblStory;
        private System.Windows.Forms.Button btnChoice1;
        private System.Windows.Forms.Button btnChoice2;
        private System.Windows.Forms.Label lblResult;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label lblMonsterStatus;
        private System.Windows.Forms.Button btnChoice3;
        protected System.Windows.Forms.PictureBox pictureBoxMonster;
    }
}

