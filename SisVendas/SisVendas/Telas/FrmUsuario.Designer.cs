
namespace SisVendas.Telas
{
    partial class FrmUsuario
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
            this.cbbNivel = new System.Windows.Forms.ComboBox();
            this.txbLogin = new System.Windows.Forms.TextBox();
            this.lblFone = new System.Windows.Forms.Label();
            this.lblSexo = new System.Windows.Forms.Label();
            this.txbEmail = new System.Windows.Forms.TextBox();
            this.lblEmail = new System.Windows.Forms.Label();
            this.txbNome = new System.Windows.Forms.TextBox();
            this.lblNome = new System.Windows.Forms.Label();
            this.txbId = new System.Windows.Forms.TextBox();
            this.lblId = new System.Windows.Forms.Label();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripSalvar = new System.Windows.Forms.ToolStripButton();
            this.toolStripAlterar = new System.Windows.Forms.ToolStripButton();
            this.toolStripExcluir = new System.Windows.Forms.ToolStripButton();
            this.toolStripCancelar = new System.Windows.Forms.ToolStripButton();
            this.lblUsuariosDesativados = new System.Windows.Forms.Label();
            this.lblUsuariosAtivos = new System.Windows.Forms.Label();
            this.dgvUsuariosDesativados = new System.Windows.Forms.DataGridView();
            this.dgvUsuarios = new System.Windows.Forms.DataGridView();
            this.gpbCadastro.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvUsuariosDesativados)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvUsuarios)).BeginInit();
            this.SuspendLayout();
            // 
            // gpbCadastro
            // 
            this.gpbCadastro.Controls.Add(this.cbbNivel);
            this.gpbCadastro.Controls.Add(this.txbLogin);
            this.gpbCadastro.Controls.Add(this.lblFone);
            this.gpbCadastro.Controls.Add(this.lblSexo);
            this.gpbCadastro.Controls.Add(this.txbEmail);
            this.gpbCadastro.Controls.Add(this.lblEmail);
            this.gpbCadastro.Controls.Add(this.txbNome);
            this.gpbCadastro.Controls.Add(this.lblNome);
            this.gpbCadastro.Controls.Add(this.txbId);
            this.gpbCadastro.Controls.Add(this.lblId);
            this.gpbCadastro.Location = new System.Drawing.Point(12, 70);
            this.gpbCadastro.Name = "gpbCadastro";
            this.gpbCadastro.Size = new System.Drawing.Size(545, 272);
            this.gpbCadastro.TabIndex = 24;
            this.gpbCadastro.TabStop = false;
            this.gpbCadastro.Text = "Cadastro";
            // 
            // cbbNivel
            // 
            this.cbbNivel.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbbNivel.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbbNivel.FormattingEnabled = true;
            this.cbbNivel.Items.AddRange(new object[] {
            "Administrador",
            "Usuário"});
            this.cbbNivel.Location = new System.Drawing.Point(381, 224);
            this.cbbNivel.Name = "cbbNivel";
            this.cbbNivel.Size = new System.Drawing.Size(148, 28);
            this.cbbNivel.TabIndex = 4;
            // 
            // txbLogin
            // 
            this.txbLogin.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txbLogin.Location = new System.Drawing.Point(19, 222);
            this.txbLogin.MaxLength = 50;
            this.txbLogin.Name = "txbLogin";
            this.txbLogin.Size = new System.Drawing.Size(243, 30);
            this.txbLogin.TabIndex = 3;
            // 
            // lblFone
            // 
            this.lblFone.AutoSize = true;
            this.lblFone.Location = new System.Drawing.Point(16, 206);
            this.lblFone.Name = "lblFone";
            this.lblFone.Size = new System.Drawing.Size(36, 13);
            this.lblFone.TabIndex = 14;
            this.lblFone.Text = "Login:";
            // 
            // lblSexo
            // 
            this.lblSexo.AutoSize = true;
            this.lblSexo.Location = new System.Drawing.Point(379, 206);
            this.lblSexo.Name = "lblSexo";
            this.lblSexo.Size = new System.Drawing.Size(88, 13);
            this.lblSexo.TabIndex = 8;
            this.lblSexo.Text = "Nível de acesso:";
            // 
            // txbEmail
            // 
            this.txbEmail.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txbEmail.Location = new System.Drawing.Point(19, 160);
            this.txbEmail.MaxLength = 50;
            this.txbEmail.Name = "txbEmail";
            this.txbEmail.Size = new System.Drawing.Size(510, 30);
            this.txbEmail.TabIndex = 2;
            // 
            // lblEmail
            // 
            this.lblEmail.AutoSize = true;
            this.lblEmail.Location = new System.Drawing.Point(16, 144);
            this.lblEmail.Name = "lblEmail";
            this.lblEmail.Size = new System.Drawing.Size(38, 13);
            this.lblEmail.TabIndex = 4;
            this.lblEmail.Text = "E-mail:";
            // 
            // txbNome
            // 
            this.txbNome.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txbNome.Location = new System.Drawing.Point(19, 102);
            this.txbNome.MaxLength = 50;
            this.txbNome.Name = "txbNome";
            this.txbNome.Size = new System.Drawing.Size(510, 30);
            this.txbNome.TabIndex = 1;
            // 
            // lblNome
            // 
            this.lblNome.AutoSize = true;
            this.lblNome.Location = new System.Drawing.Point(16, 86);
            this.lblNome.Name = "lblNome";
            this.lblNome.Size = new System.Drawing.Size(38, 13);
            this.lblNome.TabIndex = 2;
            this.lblNome.Text = "Nome:";
            // 
            // txbId
            // 
            this.txbId.Enabled = false;
            this.txbId.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txbId.Location = new System.Drawing.Point(19, 48);
            this.txbId.Name = "txbId";
            this.txbId.Size = new System.Drawing.Size(85, 30);
            this.txbId.TabIndex = 0;
            // 
            // lblId
            // 
            this.lblId.AutoSize = true;
            this.lblId.Location = new System.Drawing.Point(16, 32);
            this.lblId.Name = "lblId";
            this.lblId.Size = new System.Drawing.Size(21, 13);
            this.lblId.TabIndex = 0;
            this.lblId.Text = "ID:";
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripSalvar,
            this.toolStripAlterar,
            this.toolStripExcluir,
            this.toolStripCancelar});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(1056, 54);
            this.toolStrip1.TabIndex = 23;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripSalvar
            // 
            this.toolStripSalvar.Image = global::SisVendas.Properties.Resources.save_32;
            this.toolStripSalvar.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripSalvar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripSalvar.Name = "toolStripSalvar";
            this.toolStripSalvar.Size = new System.Drawing.Size(42, 51);
            this.toolStripSalvar.Text = "Salvar";
            this.toolStripSalvar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.toolStripSalvar.Click += new System.EventHandler(this.toolStripSalvar_Click);
            // 
            // toolStripAlterar
            // 
            this.toolStripAlterar.Enabled = false;
            this.toolStripAlterar.Image = global::SisVendas.Properties.Resources.update_32;
            this.toolStripAlterar.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripAlterar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripAlterar.Name = "toolStripAlterar";
            this.toolStripAlterar.Size = new System.Drawing.Size(46, 51);
            this.toolStripAlterar.Text = "Alterar";
            this.toolStripAlterar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.toolStripAlterar.Click += new System.EventHandler(this.toolStripAlterar_Click);
            // 
            // toolStripExcluir
            // 
            this.toolStripExcluir.Enabled = false;
            this.toolStripExcluir.Image = global::SisVendas.Properties.Resources.delete_32;
            this.toolStripExcluir.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripExcluir.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripExcluir.Name = "toolStripExcluir";
            this.toolStripExcluir.Size = new System.Drawing.Size(46, 51);
            this.toolStripExcluir.Text = "Excluir";
            this.toolStripExcluir.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.toolStripExcluir.Click += new System.EventHandler(this.toolStripExcluir_Click);
            // 
            // toolStripCancelar
            // 
            this.toolStripCancelar.Image = global::SisVendas.Properties.Resources.cancel_32;
            this.toolStripCancelar.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripCancelar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripCancelar.Name = "toolStripCancelar";
            this.toolStripCancelar.Size = new System.Drawing.Size(57, 51);
            this.toolStripCancelar.Text = "Cancelar";
            this.toolStripCancelar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.toolStripCancelar.Visible = false;
            this.toolStripCancelar.Click += new System.EventHandler(this.toolStripCancelar_Click);
            // 
            // lblUsuariosDesativados
            // 
            this.lblUsuariosDesativados.AutoSize = true;
            this.lblUsuariosDesativados.Location = new System.Drawing.Point(573, 223);
            this.lblUsuariosDesativados.Name = "lblUsuariosDesativados";
            this.lblUsuariosDesativados.Size = new System.Drawing.Size(108, 13);
            this.lblUsuariosDesativados.TabIndex = 30;
            this.lblUsuariosDesativados.Text = "Usuários desativados";
            // 
            // lblUsuariosAtivos
            // 
            this.lblUsuariosAtivos.AutoSize = true;
            this.lblUsuariosAtivos.Location = new System.Drawing.Point(573, 76);
            this.lblUsuariosAtivos.Name = "lblUsuariosAtivos";
            this.lblUsuariosAtivos.Size = new System.Drawing.Size(79, 13);
            this.lblUsuariosAtivos.TabIndex = 29;
            this.lblUsuariosAtivos.Text = "Usuários ativos";
            // 
            // dgvUsuariosDesativados
            // 
            this.dgvUsuariosDesativados.AllowUserToAddRows = false;
            this.dgvUsuariosDesativados.AllowUserToDeleteRows = false;
            this.dgvUsuariosDesativados.AllowUserToOrderColumns = true;
            this.dgvUsuariosDesativados.AllowUserToResizeColumns = false;
            this.dgvUsuariosDesativados.AllowUserToResizeRows = false;
            this.dgvUsuariosDesativados.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvUsuariosDesativados.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvUsuariosDesativados.Location = new System.Drawing.Point(576, 243);
            this.dgvUsuariosDesativados.Name = "dgvUsuariosDesativados";
            this.dgvUsuariosDesativados.ReadOnly = true;
            this.dgvUsuariosDesativados.RowHeadersVisible = false;
            this.dgvUsuariosDesativados.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dgvUsuariosDesativados.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvUsuariosDesativados.Size = new System.Drawing.Size(468, 99);
            this.dgvUsuariosDesativados.TabIndex = 28;
            this.dgvUsuariosDesativados.DoubleClick += new System.EventHandler(this.dgvUsuariosDesativados_DoubleClick);
            // 
            // dgvUsuarios
            // 
            this.dgvUsuarios.AllowUserToAddRows = false;
            this.dgvUsuarios.AllowUserToDeleteRows = false;
            this.dgvUsuarios.AllowUserToOrderColumns = true;
            this.dgvUsuarios.AllowUserToResizeColumns = false;
            this.dgvUsuarios.AllowUserToResizeRows = false;
            this.dgvUsuarios.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvUsuarios.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvUsuarios.Location = new System.Drawing.Point(576, 94);
            this.dgvUsuarios.Name = "dgvUsuarios";
            this.dgvUsuarios.ReadOnly = true;
            this.dgvUsuarios.RowHeadersVisible = false;
            this.dgvUsuarios.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dgvUsuarios.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvUsuarios.Size = new System.Drawing.Size(468, 108);
            this.dgvUsuarios.TabIndex = 27;
            this.dgvUsuarios.Click += new System.EventHandler(this.dgvUsuarios_Click);
            // 
            // FrmUsuario
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1056, 359);
            this.Controls.Add(this.lblUsuariosDesativados);
            this.Controls.Add(this.lblUsuariosAtivos);
            this.Controls.Add(this.dgvUsuariosDesativados);
            this.Controls.Add(this.dgvUsuarios);
            this.Controls.Add(this.gpbCadastro);
            this.Controls.Add(this.toolStrip1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmUsuario";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Cadastro de Usuário";
            this.Load += new System.EventHandler(this.FrmUsuario_Load);
            this.gpbCadastro.ResumeLayout(false);
            this.gpbCadastro.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvUsuariosDesativados)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvUsuarios)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.GroupBox gpbCadastro;
        private System.Windows.Forms.Label lblFone;
        private System.Windows.Forms.Label lblSexo;
        private System.Windows.Forms.TextBox txbEmail;
        private System.Windows.Forms.Label lblEmail;
        private System.Windows.Forms.TextBox txbNome;
        private System.Windows.Forms.Label lblNome;
        private System.Windows.Forms.TextBox txbId;
        private System.Windows.Forms.Label lblId;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton toolStripSalvar;
        private System.Windows.Forms.ToolStripButton toolStripAlterar;
        private System.Windows.Forms.ToolStripButton toolStripExcluir;
        private System.Windows.Forms.ToolStripButton toolStripCancelar;
        private System.Windows.Forms.ComboBox cbbNivel;
        private System.Windows.Forms.TextBox txbLogin;
        private System.Windows.Forms.Label lblUsuariosDesativados;
        private System.Windows.Forms.Label lblUsuariosAtivos;
        private System.Windows.Forms.DataGridView dgvUsuariosDesativados;
        private System.Windows.Forms.DataGridView dgvUsuarios;
    }
}