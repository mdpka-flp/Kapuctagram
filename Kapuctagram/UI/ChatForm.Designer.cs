namespace Kapuctagram.UI
{
    partial class ChatForm
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
            this.MessageTB = new System.Windows.Forms.TextBox();
            this.ChatBox = new System.Windows.Forms.TextBox();
            this.SendB = new System.Windows.Forms.Button();
            this.SendFileB = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // MessageTB
            // 
            this.MessageTB.AcceptsReturn = true;
            this.MessageTB.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(46)))), ((int)(((byte)(46)))));
            this.MessageTB.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.MessageTB.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.MessageTB.ForeColor = System.Drawing.Color.White;
            this.MessageTB.Location = new System.Drawing.Point(54, 373);
            this.MessageTB.Multiline = true;
            this.MessageTB.Name = "MessageTB";
            this.MessageTB.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.MessageTB.Size = new System.Drawing.Size(653, 24);
            this.MessageTB.TabIndex = 0;
            // 
            // ChatBox
            // 
            this.ChatBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(46)))), ((int)(((byte)(46)))));
            this.ChatBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ChatBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ChatBox.ForeColor = System.Drawing.Color.White;
            this.ChatBox.Location = new System.Drawing.Point(12, 12);
            this.ChatBox.Multiline = true;
            this.ChatBox.Name = "ChatBox";
            this.ChatBox.ReadOnly = true;
            this.ChatBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.ChatBox.Size = new System.Drawing.Size(776, 355);
            this.ChatBox.TabIndex = 2;
            // 
            // SendB
            // 
            this.SendB.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.SendB.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.SendB.FlatAppearance.BorderSize = 0;
            this.SendB.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.SendB.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.SendB.ForeColor = System.Drawing.Color.White;
            this.SendB.Location = new System.Drawing.Point(713, 373);
            this.SendB.Name = "SendB";
            this.SendB.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.SendB.Size = new System.Drawing.Size(75, 23);
            this.SendB.TabIndex = 1;
            this.SendB.Text = "Send";
            this.SendB.UseVisualStyleBackColor = false;
            // 
            // SendFileB
            // 
            this.SendFileB.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.SendFileB.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.SendFileB.ForeColor = System.Drawing.Color.White;
            this.SendFileB.Location = new System.Drawing.Point(13, 372);
            this.SendFileB.Name = "SendFileB";
            this.SendFileB.Size = new System.Drawing.Size(35, 23);
            this.SendFileB.TabIndex = 3;
            this.SendFileB.Text = "file";
            this.SendFileB.UseVisualStyleBackColor = true;
            this.SendFileB.Click += new System.EventHandler(this.SendFileButton_Click);
            // 
            // ChatForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.SendFileB);
            this.Controls.Add(this.MessageTB);
            this.Controls.Add(this.ChatBox);
            this.Controls.Add(this.SendB);
            this.Name = "ChatForm";
            this.Text = "KAPUCTAgram";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox MessageTB;
        private System.Windows.Forms.Button SendB;
        private System.Windows.Forms.TextBox ChatBox;
        private System.Windows.Forms.Button SendFileB;
    }
}