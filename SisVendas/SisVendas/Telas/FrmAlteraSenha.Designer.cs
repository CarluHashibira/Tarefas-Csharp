
namespace SisVendas.Telas
{
    partial class FrmAlteraSenha
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
            this.gpbCadastro = new System.Windows.Forms.GroupBox();
            this.txbRepitaSenha = new System.Windows.Forms.TextBox();
            this.lblFone = new System.Windows.Forms.Label();
            this.txbSenha = new System.Windows.Forms.TextBox();
            this.lblEmail = new System.Windows.Forms.Label();
            this.txbSenhaAtual = new System.Windows.Forms.TextBox();
            this.lblNome = new System.Windows.Forms.Label();
            this.lblUsuario = new System.Windows.Forms.Label();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.txbFrase = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.picFoto = new System.Windows.Forms.PictureBox();
            this.toolStripAlterar = new System.Windows.Forms.ToolStripButton();
            this.gpbCadastro.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picFoto)).BeginInit();
            this.SuspendLayout();
            // 
            // gpbCadastro
            // 
            this.gpbCadastro.Controls.Add(this.picFoto);
            this.gpbCadastro.Controls.Add(this.label1);
            this.gpbCadastro.Controls.Add(this.txbFrase);
            this.gpbCadastro.Controls.Add(this.txbRepitaSenha);
            this.gpbCadastro.Controls.Add(this.lblFone);
            this.gpbCadastro.Controls.Add(this.txbSenha);
            this.gpbCadastro.Controls.Add(this.lblEmail);
            this.gpbCadastro.Controls.Add(this.txbSenhaAtual);
            this.gpbCadastro.Controls.Add(this.lblNome);
            this.gpbCadastro.Controls.Add(this.lblUsuario);
            this.gpbCadastro.Location = new System.Drawing.Point(12, 67);
            this.gpbCadastro.Name = "gpbCadastro";
            this.gpbCadastro.Size = new System.Drawing.Size(545, 330);
            this.gpbCadastro.TabIndex = 26;
            this.gpbCadastro.TabStop = false;
            this.gpbCadastro.Text = "Cadastro";
            // 
            // txbRepitaSenha
            // 
            this.txbRepitaSenha.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txbRepitaSenha.Location = new System.Drawing.Point(19, 222);
            this.txbRepitaSenha.MaxLength = 50;
            this.txbRepitaSenha.Name = "txbRepitaSenha";
            this.txbRepitaSenha.PasswordChar = '*';
            this.txbRepitaSenha.Size = new System.Drawing.Size(243, 30);
            this.txbRepitaSenha.TabIndex = 3;
            // 
            // lblFone
            // 
            this.lblFone.AutoSize = true;
            this.lblFone.Location = new System.Drawing.Point(16, 206);
            this.lblFone.Name = "lblFone";
            this.lblFone.Size = new System.Drawing.Size(109, 13);
            this.lblFone.TabIndex = 14;
            this.lblFone.Text = "Repita a nova senha:";
            // 
            // txbSenha
            // 
            this.txbSenha.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txbSenha.Location = new System.Drawing.Point(19, 160);
            this.txbSenha.MaxLength = 50;
            this.txbSenha.Name = "txbSenha";
            this.txbSenha.PasswordChar = '*';
            this.txbSenha.Size = new System.Drawing.Size(243, 30);
            this.txbSenha.TabIndex = 2;
            // 
            // lblEmail
            // 
            this.lblEmail.AutoSize = true;
            this.lblEmail.Location = new System.Drawing.Point(16, 144);
            this.lblEmail.Name = "lblEmail";
            this.lblEmail.Size = new System.Drawing.Size(105, 13);
            this.lblEmail.TabIndex = 4;
            this.lblEmail.Text = "Digite a nova senha:";
            // 
            // txbSenhaAtual
            // 
            this.txbSenhaAtual.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txbSenhaAtual.Location = new System.Drawing.Point(19, 102);
            this.txbSenhaAtual.MaxLength = 50;
            this.txbSenhaAtual.Name = "txbSenhaAtual";
            this.txbSenhaAtual.PasswordChar = '*';
            this.txbSenhaAtual.Size = new System.Drawing.Size(243, 30);
            this.txbSenhaAtual.TabIndex = 1;
            // 
            // lblNome
            // 
            this.lblNome.AutoSize = true;
            this.lblNome.Location = new System.Drawing.Point(16, 86);
            this.lblNome.Name = "lblNome";
            this.lblNome.Size = new System.Drawing.Size(115, 13);
            this.lblNome.TabIndex = 2;
            this.lblNome.Text = "Digite sua senha atual:";
            // 
            // lblUsuario
            // 
            this.lblUsuario.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUsuario.Location = new System.Drawing.Point(16, 38);
            this.lblUsuario.Name = "lblUsuario";
            this.lblUsuario.Size = new System.Drawing.Size(513, 20);
            this.lblUsuario.TabIndex = 0;
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripAlterar});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(572, 54);
            this.toolStrip1.TabIndex = 25;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // txbFrase
            // 
            this.txbFrase.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txbFrase.Location = new System.Drawing.Point(19, 279);
            this.txbFrase.MaxLength = 50;
            this.txbFrase.Name = "txbFrase";
            this.txbFrase.PasswordChar = '*';
            this.txbFrase.Size = new System.Drawing.Size(510, 30);
            this.txbFrase.TabIndex = 15;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(17, 263);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(151, 13);
            this.label1.TabIndex = 16;
            this.label1.Text = "Digite sua frase de segurança:";
            // 
            // picFoto
            // 
            this.picFoto.Image = global::SisVendas.Properties.Resources.cadeado;
            this.picFoto.Location = new System.Drawing.Point(328, 102);
            this.picFoto.Name = "picFoto";
            this.picFoto.Size = new System.Drawing.Size(201, 167);
            this.picFoto.TabIndex = 17;
            this.picFoto.TabStop = false;
            // 
            // toolStripAlterar
            // 
            this.toolStripAlterar.Image = global::SisVendas.Properties.Resources.update_32;
            this.toolStripAlterar.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripAlterar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripAlterar.Name = "toolStripAlterar";
            this.toolStripAlterar.Size = new System.Drawing.Size(46, 51);
            this.toolStripAlterar.Text = "Alterar";
            this.toolStripAlterar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.toolStripAlterar.Click += new System.EventHandler(this.toolStripAlterar_Click);
            // 
            // FrmAlteraSenha
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(572, 414);
            this.Controls.Add(this.gpbCadastro);
            this.Controls.Add(this.toolStrip1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmAlteraSenha";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Altera Senha";
            this.Load += new System.EventHandler(this.FrmAlteraSenha_Load);
            this.gpbCadastro.ResumeLayout(false);
            this.gpbCadastro.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picFoto)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox gpbCadastro;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txbFrase;
        private System.Windows.Forms.TextBox txbRepitaSenha;
        private System.Windows.Forms.Label lblFone;
        private System.Windows.Forms.TextBox txbSenha;
        private System.Windows.Forms.Label lblEmail;
        private System.Windows.Forms.TextBox txbSenhaAtual;
        private System.Windows.Forms.Label lblNome;
        private System.Windows.Forms.Label lblUsuario;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton toolStripAlterar;
        private System.Windows.Forms.PictureBox picFoto;
    }
}