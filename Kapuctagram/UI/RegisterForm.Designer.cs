namespace Kapuctagram
{
    partial class RegisterForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.RegisterB = new System.Windows.Forms.Button();
            this.PasswordTB = new System.Windows.Forms.TextBox();
            this.RegisterInfoL = new System.Windows.Forms.Label();
            this.Diff_of_PasswordL = new System.Windows.Forms.Label();
            this.AutoLoginB = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // RegisterB
            // 
            this.RegisterB.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.RegisterB.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.RegisterB.Location = new System.Drawing.Point(0, 203);
            this.RegisterB.Name = "RegisterB";
            this.RegisterB.Size = new System.Drawing.Size(284, 58);
            this.RegisterB.TabIndex = 0;
            this.RegisterB.Text = "Зарегестрироваться / войти";
            this.RegisterB.UseVisualStyleBackColor = true;
            this.RegisterB.Click += new System.EventHandler(this.RegisterB_Click);
            // 
            // PasswordTB
            // 
            this.PasswordTB.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.PasswordTB.Location = new System.Drawing.Point(6, 27);
            this.PasswordTB.MaxLength = 40;
            this.PasswordTB.Name = "PasswordTB";
            this.PasswordTB.Size = new System.Drawing.Size(266, 24);
            this.PasswordTB.TabIndex = 1;
            this.PasswordTB.TextChanged += new System.EventHandler(this.PasswordTB_TextChanged);
            // 
            // RegisterInfoL
            // 
            this.RegisterInfoL.AutoSize = true;
            this.RegisterInfoL.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.RegisterInfoL.Location = new System.Drawing.Point(3, 54);
            this.RegisterInfoL.Name = "RegisterInfoL";
            this.RegisterInfoL.Size = new System.Drawing.Size(241, 68);
            this.RegisterInfoL.TabIndex = 2;
            this.RegisterInfoL.Text = "・минимум 20 символов\r\n・минимум 5 заглавных букв\r\n・минимум 5 специальных символов\r" +
    "\n・минимум 5 цифр";
            // 
            // Diff_of_PasswordL
            // 
            this.Diff_of_PasswordL.AutoSize = true;
            this.Diff_of_PasswordL.BackColor = System.Drawing.SystemColors.Control;
            this.Diff_of_PasswordL.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Diff_of_PasswordL.ForeColor = System.Drawing.SystemColors.GrayText;
            this.Diff_of_PasswordL.Location = new System.Drawing.Point(3, 9);
            this.Diff_of_PasswordL.Name = "Diff_of_PasswordL";
            this.Diff_of_PasswordL.Size = new System.Drawing.Size(102, 15);
            this.Diff_of_PasswordL.TabIndex = 3;
            this.Diff_of_PasswordL.Text = "Введите пароль";
            // 
            // AutoLoginB
            // 
            this.AutoLoginB.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.AutoLoginB.Location = new System.Drawing.Point(172, 167);
            this.AutoLoginB.Name = "AutoLoginB";
            this.AutoLoginB.Size = new System.Drawing.Size(100, 30);
            this.AutoLoginB.TabIndex = 4;
            this.AutoLoginB.Text = "AutoLogin";
            this.AutoLoginB.UseVisualStyleBackColor = true;
            // 
            // RegisterForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Controls.Add(this.AutoLoginB);
            this.Controls.Add(this.Diff_of_PasswordL);
            this.Controls.Add(this.RegisterInfoL);
            this.Controls.Add(this.PasswordTB);
            this.Controls.Add(this.RegisterB);
            this.MaximumSize = new System.Drawing.Size(300, 300);
            this.MinimumSize = new System.Drawing.Size(300, 300);
            this.Name = "RegisterForm";
            this.Text = "KAPUCTAgram Reg";
            this.Load += new System.EventHandler(this.RegisterForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button RegisterB;
        private System.Windows.Forms.TextBox PasswordTB;
        private System.Windows.Forms.Label RegisterInfoL;
        private System.Windows.Forms.Label Diff_of_PasswordL;
        private System.Windows.Forms.Button AutoLoginB;
    }
}

