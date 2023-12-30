
namespace SisVendas.Telas
{
    partial class FrmProduto
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
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripSalvar = new System.Windows.Forms.ToolStripButton();
            this.toolStripAlterar = new System.Windows.Forms.ToolStripButton();
            this.toolStripMudaFoto = new System.Windows.Forms.ToolStripButton();
            this.toolStripExcluir = new System.Windows.Forms.ToolStripButton();
            this.toolStripDesativar = new System.Windows.Forms.ToolStripButton();
            this.toolStripAtivar = new System.Windows.Forms.ToolStripButton();
            this.toolStripCancelar = new System.Windows.Forms.ToolStripButton();
            this.gpbCadastro = new System.Windows.Forms.GroupBox();
            this.txbQtde = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txbValor = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnFoto = new System.Windows.Forms.Button();
            this.txbFoto = new System.Windows.Forms.TextBox();
            this.lblFoto = new System.Windows.Forms.Label();
            this.txbDescricao = new System.Windows.Forms.TextBox();
            this.lblFone = new System.Windows.Forms.Label();
            this.txbNome = new System.Windows.Forms.TextBox();
            this.lblNome = new System.Windows.Forms.Label();
            this.txbId = new System.Windows.Forms.TextBox();
            this.lblId = new System.Windows.Forms.Label();
            this.dgvProdutos = new System.Windows.Forms.DataGridView();
            this.gpbFoto = new System.Windows.Forms.GroupBox();
            this.picFoto = new System.Windows.Forms.PictureBox();
            this.gpbBusca = new System.Windows.Forms.GroupBox();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.txbBuscar = new System.Windows.Forms.TextBox();
            this.cbbBusca = new System.Windows.Forms.ComboBox();
            this.toolStrip1.SuspendLayout();
            this.gpbCadastro.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProdutos)).BeginInit();
            this.gpbFoto.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picFoto)).BeginInit();
            this.gpbBusca.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripSalvar,
            this.toolStripAlterar,
            this.toolStripMudaFoto,
            this.toolStripExcluir,
            this.toolStripDesativar,
            this.toolStripAtivar,
            this.toolStripCancelar});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(985, 54);
            this.toolStrip1.TabIndex = 24;
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
            // toolStripMudaFoto
            // 
            this.toolStripMudaFoto.Image = global::SisVendas.Properties.Resources.update_32;
            this.toolStripMudaFoto.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripMudaFoto.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripMudaFoto.Name = "toolStripMudaFoto";
            this.toolStripMudaFoto.Size = new System.Drawing.Size(69, 51);
            this.toolStripMudaFoto.Text = "Muda Foto";
            this.toolStripMudaFoto.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.toolStripMudaFoto.Visible = false;
            this.toolStripMudaFoto.Click += new System.EventHandler(this.toolStripMudaFoto_Click);
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
            // toolStripDesativar
            // 
            this.toolStripDesativar.Image = global::SisVendas.Properties.Resources.disable_32;
            this.toolStripDesativar.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripDesativar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripDesativar.Name = "toolStripDesativar";
            this.toolStripDesativar.Size = new System.Drawing.Size(59, 51);
            this.toolStripDesativar.Text = "Desativar";
            this.toolStripDesativar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.toolStripDesativar.Visible = false;
            this.toolStripDesativar.Click += new System.EventHandler(this.toolStripDesativar_Click);
            // 
            // toolStripAtivar
            // 
            this.toolStripAtivar.Image = global::SisVendas.Properties.Resources.enable_32;
            this.toolStripAtivar.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripAtivar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripAtivar.Name = "toolStripAtivar";
            this.toolStripAtivar.Size = new System.Drawing.Size(42, 51);
            this.toolStripAtivar.Text = "Ativar";
            this.toolStripAtivar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.toolStripAtivar.Visible = false;
            this.toolStripAtivar.Click += new System.EventHandler(this.toolStripAtivar_Click);
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
            // gpbCadastro
            // 
            this.gpbCadastro.Controls.Add(this.txbQtde);
            this.gpbCadastro.Controls.Add(this.label2);
            this.gpbCadastro.Controls.Add(this.txbValor);
            this.gpbCadastro.Controls.Add(this.label1);
            this.gpbCadastro.Controls.Add(this.btnFoto);
            this.gpbCadastro.Controls.Add(this.txbFoto);
            this.gpbCadastro.Controls.Add(this.lblFoto);
            this.gpbCadastro.Controls.Add(this.txbDescricao);
            this.gpbCadastro.Controls.Add(this.lblFone);
            this.gpbCadastro.Controls.Add(this.txbNome);
            this.gpbCadastro.Controls.Add(this.lblNome);
            this.gpbCadastro.Controls.Add(this.txbId);
            this.gpbCadastro.Controls.Add(this.lblId);
            this.gpbCadastro.Location = new System.Drawing.Point(12, 70);
            this.gpbCadastro.Name = "gpbCadastro";
            this.gpbCadastro.Size = new System.Drawing.Size(545, 426);
            this.gpbCadastro.TabIndex = 25;
            this.gpbCadastro.TabStop = false;
            this.gpbCadastro.Text = "Cadastro";
            // 
            // txbQtde
            // 
            this.txbQtde.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txbQtde.Location = new System.Drawing.Point(440, 163);
            this.txbQtde.MaxLength = 50;
            this.txbQtde.Name = "txbQtde";
            this.txbQtde.Size = new System.Drawing.Size(88, 30);
            this.txbQtde.TabIndex = 5;
            this.txbQtde.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(437, 148);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(91, 13);
            this.label2.TabIndex = 19;
            this.label2.Text = "Qtde em estoque:";
            // 
            // txbValor
            // 
            this.txbValor.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txbValor.Location = new System.Drawing.Point(415, 102);
            this.txbValor.MaxLength = 50;
            this.txbValor.Name = "txbValor";
            this.txbValor.Size = new System.Drawing.Size(114, 30);
            this.txbValor.TabIndex = 2;
            this.txbValor.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(412, 86);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(34, 13);
            this.label1.TabIndex = 17;
            this.label1.Text = "Valor:";
            // 
            // btnFoto
            // 
            this.btnFoto.Image = global::SisVendas.Properties.Resources.finder_24;
            this.btnFoto.Location = new System.Drawing.Point(398, 160);
            this.btnFoto.Name = "btnFoto";
            this.btnFoto.Size = new System.Drawing.Size(33, 33);
            this.btnFoto.TabIndex = 4;
            this.btnFoto.UseVisualStyleBackColor = true;
            this.btnFoto.Click += new System.EventHandler(this.btnFoto_Click);
            // 
            // txbFoto
            // 
            this.txbFoto.Enabled = false;
            this.txbFoto.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txbFoto.Location = new System.Drawing.Point(19, 162);
            this.txbFoto.Name = "txbFoto";
            this.txbFoto.Size = new System.Drawing.Size(373, 30);
            this.txbFoto.TabIndex = 3;
            // 
            // lblFoto
            // 
            this.lblFoto.AutoSize = true;
            this.lblFoto.Location = new System.Drawing.Point(16, 146);
            this.lblFoto.Name = "lblFoto";
            this.lblFoto.Size = new System.Drawing.Size(87, 13);
            this.lblFoto.TabIndex = 15;
            this.lblFoto.Text = "Selecione a foto:";
            // 
            // txbDescricao
            // 
            this.txbDescricao.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txbDescricao.Location = new System.Drawing.Point(19, 222);
            this.txbDescricao.Multiline = true;
            this.txbDescricao.Name = "txbDescricao";
            this.txbDescricao.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txbDescricao.Size = new System.Drawing.Size(510, 184);
            this.txbDescricao.TabIndex = 6;
            // 
            // lblFone
            // 
            this.lblFone.AutoSize = true;
            this.lblFone.Location = new System.Drawing.Point(16, 206);
            this.lblFone.Name = "lblFone";
            this.lblFone.Size = new System.Drawing.Size(58, 13);
            this.lblFone.TabIndex = 14;
            this.lblFone.Text = "Descrição:";
            // 
            // txbNome
            // 
            this.txbNome.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txbNome.Location = new System.Drawing.Point(19, 102);
            this.txbNome.MaxLength = 50;
            this.txbNome.Name = "txbNome";
            this.txbNome.Size = new System.Drawing.Size(390, 30);
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
            // dgvProdutos
            // 
            this.dgvProdutos.AllowUserToAddRows = false;
            this.dgvProdutos.AllowUserToDeleteRows = false;
            this.dgvProdutos.AllowUserToOrderColumns = true;
            this.dgvProdutos.AllowUserToResizeColumns = false;
            this.dgvProdutos.AllowUserToResizeRows = false;
            this.dgvProdutos.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvProdutos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvProdutos.Location = new System.Drawing.Point(575, 292);
            this.dgvProdutos.Name = "dgvProdutos";
            this.dgvProdutos.ReadOnly = true;
            this.dgvProdutos.RowHeadersVisible = false;
            this.dgvProdutos.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dgvProdutos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvProdutos.Size = new System.Drawing.Size(393, 204);
            this.dgvProdutos.TabIndex = 26;
            this.dgvProdutos.Click += new System.EventHandler(this.dgvProdutos_Click);
            // 
            // gpbFoto
            // 
            this.gpbFoto.Controls.Add(this.picFoto);
            this.gpbFoto.Enabled = false;
            this.gpbFoto.Location = new System.Drawing.Point(821, 76);
            this.gpbFoto.Name = "gpbFoto";
            this.gpbFoto.Size = new System.Drawing.Size(147, 190);
            this.gpbFoto.TabIndex = 28;
            this.gpbFoto.TabStop = false;
            this.gpbFoto.Text = "Foto";
            // 
            // picFoto
            // 
            this.picFoto.Location = new System.Drawing.Point(25, 29);
            this.picFoto.Name = "picFoto";
            this.picFoto.Size = new System.Drawing.Size(100, 133);
            this.picFoto.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picFoto.TabIndex = 0;
            this.picFoto.TabStop = false;
            this.picFoto.DoubleClick += new System.EventHandler(this.picFoto_DoubleClick);
            // 
            // gpbBusca
            // 
            this.gpbBusca.Controls.Add(this.btnBuscar);
            this.gpbBusca.Controls.Add(this.txbBuscar);
            this.gpbBusca.Controls.Add(this.cbbBusca);
            this.gpbBusca.Location = new System.Drawing.Point(575, 70);
            this.gpbBusca.Name = "gpbBusca";
            this.gpbBusca.Size = new System.Drawing.Size(233, 196);
            this.gpbBusca.TabIndex = 27;
            this.gpbBusca.TabStop = false;
            this.gpbBusca.Text = "Busca por:";
            // 
            // btnBuscar
            // 
            this.btnBuscar.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBuscar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnBuscar.Location = new System.Drawing.Point(11, 124);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(210, 44);
            this.btnBuscar.TabIndex = 9;
            this.btnBuscar.Text = "Buscar";
            this.btnBuscar.UseVisualStyleBackColor = true;
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // txbBuscar
            // 
            this.txbBuscar.Enabled = false;
            this.txbBuscar.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txbBuscar.Location = new System.Drawing.Point(11, 73);
            this.txbBuscar.Name = "txbBuscar";
            this.txbBuscar.Size = new System.Drawing.Size(210, 30);
            this.txbBuscar.TabIndex = 8;
            // 
            // cbbBusca
            // 
            this.cbbBusca.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbbBusca.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbbBusca.FormattingEnabled = true;
            this.cbbBusca.Items.AddRange(new object[] {
            "Tudo",
            "ID",
            "Nome",
            "Desativado"});
            this.cbbBusca.Location = new System.Drawing.Point(11, 21);
            this.cbbBusca.Name = "cbbBusca";
            this.cbbBusca.Size = new System.Drawing.Size(210, 33);
            this.cbbBusca.TabIndex = 7;
            this.cbbBusca.DropDownClosed += new System.EventHandler(this.cbbBusca_DropDownClosed);
            // 
            // FrmProduto
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(985, 513);
            this.Controls.Add(this.gpbFoto);
            this.Controls.Add(this.gpbBusca);
            this.Controls.Add(this.dgvProdutos);
            this.Controls.Add(this.gpbCadastro);
            this.Controls.Add(this.toolStrip1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmProduto";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Cadastro de Produto";
            this.Load += new System.EventHandler(this.FrmProduto_Load);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.gpbCadastro.ResumeLayout(false);
            this.gpbCadastro.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProdutos)).EndInit();
            this.gpbFoto.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picFoto)).EndInit();
            this.gpbBusca.ResumeLayout(false);
            this.gpbBusca.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton toolStripSalvar;
        private System.Windows.Forms.ToolStripButton toolStripAlterar;
        private System.Windows.Forms.ToolStripButton toolStripExcluir;
        private System.Windows.Forms.ToolStripButton toolStripCancelar;
        private System.Windows.Forms.GroupBox gpbCadastro;
        private System.Windows.Forms.TextBox txbDescricao;
        private System.Windows.Forms.Label lblFone;
        private System.Windows.Forms.TextBox txbNome;
        private System.Windows.Forms.Label lblNome;
        private System.Windows.Forms.TextBox txbId;
        private System.Windows.Forms.Label lblId;
        private System.Windows.Forms.Button btnFoto;
        private System.Windows.Forms.TextBox txbFoto;
        private System.Windows.Forms.Label lblFoto;
        private System.Windows.Forms.DataGridView dgvProdutos;
        private System.Windows.Forms.GroupBox gpbFoto;
        private System.Windows.Forms.PictureBox picFoto;
        private System.Windows.Forms.GroupBox gpbBusca;
        private System.Windows.Forms.Button btnBuscar;
        private System.Windows.Forms.TextBox txbBuscar;
        private System.Windows.Forms.ComboBox cbbBusca;
        private System.Windows.Forms.TextBox txbValor;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ToolStripButton toolStripMudaFoto;
        private System.Windows.Forms.TextBox txbQtde;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ToolStripButton toolStripDesativar;
        private System.Windows.Forms.ToolStripButton toolStripAtivar;
    }
}