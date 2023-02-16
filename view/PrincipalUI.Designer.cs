namespace controle_contas_a_pagar_receber
{
    partial class PrincipalUI
    {
        /// <summary>
        /// Variável de designer necessária.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpar os recursos que estão sendo usados.
        /// </summary>
        /// <param name="disposing">true se for necessário descartar os recursos gerenciados; caso contrário, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código gerado pelo Windows Form Designer

        /// <summary>
        /// Método necessário para suporte ao Designer - não modifique 
        /// o conteúdo deste método com o editor de código.
        /// </summary>
        private void InitializeComponent()
        {
      this.menu = new System.Windows.Forms.MenuStrip();
      this.menuItemContasPagar = new System.Windows.Forms.ToolStripMenuItem();
      this.menuItemContasPagarFornecedores = new System.Windows.Forms.ToolStripMenuItem();
      this.menuItemContasPagarPagamentos = new System.Windows.Forms.ToolStripMenuItem();
      this.menuItemContasReceber = new System.Windows.Forms.ToolStripMenuItem();
      this.menuItemContasReceberClientes = new System.Windows.Forms.ToolStripMenuItem();
      this.menuItemContasReceberReceitas = new System.Windows.Forms.ToolStripMenuItem();
      this.menu.SuspendLayout();
      this.SuspendLayout();
      // 
      // menu
      // 
      this.menu.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.menu.GripMargin = new System.Windows.Forms.Padding(2);
      this.menu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuItemContasPagar,
            this.menuItemContasReceber});
      this.menu.Location = new System.Drawing.Point(0, 0);
      this.menu.Name = "menu";
      this.menu.Padding = new System.Windows.Forms.Padding(5);
      this.menu.Size = new System.Drawing.Size(780, 30);
      this.menu.TabIndex = 1;
      this.menu.Text = "menu";
      // 
      // menuItemContasPagar
      // 
      this.menuItemContasPagar.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuItemContasPagarFornecedores,
            this.menuItemContasPagarPagamentos});
      this.menuItemContasPagar.Name = "menuItemContasPagar";
      this.menuItemContasPagar.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
      this.menuItemContasPagar.Size = new System.Drawing.Size(104, 20);
      this.menuItemContasPagar.Text = "Contas a pagar";
      // 
      // menuItemContasPagarFornecedores
      // 
      this.menuItemContasPagarFornecedores.Name = "menuItemContasPagarFornecedores";
      this.menuItemContasPagarFornecedores.Padding = new System.Windows.Forms.Padding(0);
      this.menuItemContasPagarFornecedores.Size = new System.Drawing.Size(153, 20);
      this.menuItemContasPagarFornecedores.Text = "Fornecedores";
      // 
      // menuItemContasPagarPagamentos
      // 
      this.menuItemContasPagarPagamentos.Name = "menuItemContasPagarPagamentos";
      this.menuItemContasPagarPagamentos.Padding = new System.Windows.Forms.Padding(0);
      this.menuItemContasPagarPagamentos.Size = new System.Drawing.Size(153, 20);
      this.menuItemContasPagarPagamentos.Text = "Pagamentos";
      // 
      // menuItemContasReceber
      // 
      this.menuItemContasReceber.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuItemContasReceberClientes,
            this.menuItemContasReceberReceitas});
      this.menuItemContasReceber.Name = "menuItemContasReceber";
      this.menuItemContasReceber.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
      this.menuItemContasReceber.Size = new System.Drawing.Size(120, 20);
      this.menuItemContasReceber.Text = "Contas a Receber";
      // 
      // menuItemContasReceberClientes
      // 
      this.menuItemContasReceberClientes.Name = "menuItemContasReceberClientes";
      this.menuItemContasReceberClientes.Padding = new System.Windows.Forms.Padding(0);
      this.menuItemContasReceberClientes.Size = new System.Drawing.Size(180, 20);
      this.menuItemContasReceberClientes.Text = "Clientes";
      this.menuItemContasReceberClientes.Click += new System.EventHandler(this.menuItemContasReceberClientes_Click);
      // 
      // menuItemContasReceberReceitas
      // 
      this.menuItemContasReceberReceitas.Name = "menuItemContasReceberReceitas";
      this.menuItemContasReceberReceitas.Padding = new System.Windows.Forms.Padding(0);
      this.menuItemContasReceberReceitas.Size = new System.Drawing.Size(180, 20);
      this.menuItemContasReceberReceitas.Text = "Receitas";
      // 
      // PrincipalUI
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
      this.ClientSize = new System.Drawing.Size(780, 557);
      this.Controls.Add(this.menu);
      this.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
      this.IsMdiContainer = true;
      this.MainMenuStrip = this.menu;
      this.Margin = new System.Windows.Forms.Padding(4);
      this.MaximizeBox = false;
      this.MinimizeBox = false;
      this.MinimumSize = new System.Drawing.Size(800, 600);
      this.Name = "PrincipalUI";
      this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
      this.Text = "Controle de contas a Pagar e Receber";
      this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
      this.menu.ResumeLayout(false);
      this.menu.PerformLayout();
      this.ResumeLayout(false);
      this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menu;
        private System.Windows.Forms.ToolStripMenuItem menuItemContasPagar;
        private System.Windows.Forms.ToolStripMenuItem menuItemContasPagarFornecedores;
        private System.Windows.Forms.ToolStripMenuItem menuItemContasPagarPagamentos;
        private System.Windows.Forms.ToolStripMenuItem menuItemContasReceber;
        private System.Windows.Forms.ToolStripMenuItem menuItemContasReceberClientes;
        private System.Windows.Forms.ToolStripMenuItem menuItemContasReceberReceitas;
    }
}

