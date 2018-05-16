namespace ProjetoFinal.Forms
{
    partial class LoginForm
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
            this.lblLogin = new System.Windows.Forms.Label();
            this.lblPass = new System.Windows.Forms.Label();
            this.tbxLogin = new System.Windows.Forms.TextBox();
            this.tbxPass = new System.Windows.Forms.TextBox();
            this.lblSignIn = new System.Windows.Forms.Button();
            this.lblForgot = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblLogin
            // 
            this.lblLogin.AutoSize = true;
            this.lblLogin.Location = new System.Drawing.Point(31, 36);
            this.lblLogin.Name = "lblLogin";
            this.lblLogin.Size = new System.Drawing.Size(36, 13);
            this.lblLogin.TabIndex = 0;
            this.lblLogin.Text = "Login:";
            // 
            // lblPass
            // 
            this.lblPass.AutoSize = true;
            this.lblPass.Location = new System.Drawing.Point(31, 65);
            this.lblPass.Name = "lblPass";
            this.lblPass.Size = new System.Drawing.Size(41, 13);
            this.lblPass.TabIndex = 1;
            this.lblPass.Text = "Senha:";
            // 
            // tbxLogin
            // 
            this.tbxLogin.Location = new System.Drawing.Point(115, 28);
            this.tbxLogin.Name = "tbxLogin";
            this.tbxLogin.Size = new System.Drawing.Size(100, 20);
            this.tbxLogin.TabIndex = 2;
            // 
            // tbxPass
            // 
            this.tbxPass.Location = new System.Drawing.Point(115, 58);
            this.tbxPass.Name = "tbxPass";
            this.tbxPass.Size = new System.Drawing.Size(100, 20);
            this.tbxPass.TabIndex = 3;
            // 
            // lblSignIn
            // 
            this.lblSignIn.Location = new System.Drawing.Point(34, 115);
            this.lblSignIn.Name = "lblSignIn";
            this.lblSignIn.Size = new System.Drawing.Size(75, 38);
            this.lblSignIn.TabIndex = 4;
            this.lblSignIn.Text = "Entrar";
            this.lblSignIn.UseVisualStyleBackColor = true;
            // 
            // lblForgot
            // 
            this.lblForgot.Location = new System.Drawing.Point(140, 115);
            this.lblForgot.Name = "lblForgot";
            this.lblForgot.Size = new System.Drawing.Size(75, 38);
            this.lblForgot.TabIndex = 5;
            this.lblForgot.Text = "Esqueceu senha";
            this.lblForgot.UseVisualStyleBackColor = true;
            // 
            // LoginForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Controls.Add(this.lblForgot);
            this.Controls.Add(this.lblSignIn);
            this.Controls.Add(this.tbxPass);
            this.Controls.Add(this.tbxLogin);
            this.Controls.Add(this.lblPass);
            this.Controls.Add(this.lblLogin);
            this.Name = "LoginForm";
            this.Text = "LoginForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblLogin;
        private System.Windows.Forms.Label lblPass;
        private System.Windows.Forms.TextBox tbxLogin;
        private System.Windows.Forms.TextBox tbxPass;
        private System.Windows.Forms.Button lblSignIn;
        private System.Windows.Forms.Button lblForgot;
    }
}