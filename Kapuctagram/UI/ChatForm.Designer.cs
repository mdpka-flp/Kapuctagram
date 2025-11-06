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
            this.SuspendLayout();
            // 
            // MessageTB
            // 
            this.MessageTB.AcceptsReturn = true;
            this.MessageTB.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(46)))), ((int)(((byte)(46)))));
            this.MessageTB.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.MessageTB.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.MessageTB.ForeColor = System.Drawing.Color.White;
            this.MessageTB.Location = new System.Drawing.Point(12, 373);
            this.MessageTB.Multiline = true;
            this.MessageTB.Name = "MessageTB";
            this.MessageTB.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.MessageTB.Size = new System.Drawing.Size(695, 24);
            this.MessageTB.TabIndex = 0;
            //this.MessageTB.TextChanged += new System.EventHandler(this.MessageTB_TextChanged);
            //this.MessageTB.KeyDown += new System.Windows.Forms.KeyEventHandler(this.MessageTB_KeyDown);
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
            this.SendB.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.SendB.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.SendB.ForeColor = System.Drawing.Color.White;
            this.SendB.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.SendB.Location = new System.Drawing.Point(713, 373);
            this.SendB.Name = "SendB";
            this.SendB.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.SendB.Size = new System.Drawing.Size(75, 23);
            this.SendB.TabIndex = 1;
            this.SendB.Text = "Send";
            this.SendB.UseVisualStyleBackColor = false;
            // 
            // KAPUCTAgram
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.MessageTB);
            this.Controls.Add(this.ChatBox);
            this.Controls.Add(this.SendB);
            this.Name = "KAPUCTAgram";
            this.Text = "KAPUCTAgram";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox MessageTB;
        private System.Windows.Forms.Button SendB;
        private System.Windows.Forms.TextBox ChatBox;
    }
}