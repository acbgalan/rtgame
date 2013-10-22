namespace RememberTheGame
{
    partial class FrmPrincipal
    {
        /// <summary>
        /// Variable del diseñador requerida.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén utilizando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben eliminar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido del método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.archivoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.salirToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ediciónToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.añadirCategoriaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editarCategoriaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.borrarCategoriaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.ayudaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.acercaDeRememberTheGamToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.tvxPlataformas = new System.Windows.Forms.TreeView();
            this.dgvJuegos = new System.Windows.Forms.DataGridView();
            this.añadirPlataformaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editarPlataformaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.borrarPlataformaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.verToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.herramientasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvJuegos)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.archivoToolStripMenuItem,
            this.ediciónToolStripMenuItem,
            this.verToolStripMenuItem,
            this.herramientasToolStripMenuItem,
            this.ayudaToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1024, 24);
            this.menuStrip1.TabIndex = 2;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // archivoToolStripMenuItem
            // 
            this.archivoToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.salirToolStripMenuItem});
            this.archivoToolStripMenuItem.Name = "archivoToolStripMenuItem";
            this.archivoToolStripMenuItem.Size = new System.Drawing.Size(60, 20);
            this.archivoToolStripMenuItem.Text = "Archivo";
            // 
            // salirToolStripMenuItem
            // 
            this.salirToolStripMenuItem.Name = "salirToolStripMenuItem";
            this.salirToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.salirToolStripMenuItem.Text = "Salir";
            this.salirToolStripMenuItem.Click += new System.EventHandler(this.salirToolStripMenuItem_Click);
            // 
            // ediciónToolStripMenuItem
            // 
            this.ediciónToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.añadirCategoriaToolStripMenuItem,
            this.editarCategoriaToolStripMenuItem,
            this.borrarCategoriaToolStripMenuItem,
            this.toolStripSeparator1,
            this.añadirPlataformaToolStripMenuItem,
            this.editarPlataformaToolStripMenuItem,
            this.borrarPlataformaToolStripMenuItem});
            this.ediciónToolStripMenuItem.Name = "ediciónToolStripMenuItem";
            this.ediciónToolStripMenuItem.Size = new System.Drawing.Size(58, 20);
            this.ediciónToolStripMenuItem.Text = "Edición";
            // 
            // añadirCategoriaToolStripMenuItem
            // 
            this.añadirCategoriaToolStripMenuItem.Name = "añadirCategoriaToolStripMenuItem";
            this.añadirCategoriaToolStripMenuItem.Size = new System.Drawing.Size(170, 22);
            this.añadirCategoriaToolStripMenuItem.Text = "Añadir Genero";
            // 
            // editarCategoriaToolStripMenuItem
            // 
            this.editarCategoriaToolStripMenuItem.Name = "editarCategoriaToolStripMenuItem";
            this.editarCategoriaToolStripMenuItem.Size = new System.Drawing.Size(170, 22);
            this.editarCategoriaToolStripMenuItem.Text = "Editar Genero";
            // 
            // borrarCategoriaToolStripMenuItem
            // 
            this.borrarCategoriaToolStripMenuItem.Name = "borrarCategoriaToolStripMenuItem";
            this.borrarCategoriaToolStripMenuItem.Size = new System.Drawing.Size(170, 22);
            this.borrarCategoriaToolStripMenuItem.Text = "Borrar Genero";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(167, 6);
            // 
            // ayudaToolStripMenuItem
            // 
            this.ayudaToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.acercaDeRememberTheGamToolStripMenuItem});
            this.ayudaToolStripMenuItem.Name = "ayudaToolStripMenuItem";
            this.ayudaToolStripMenuItem.Size = new System.Drawing.Size(53, 20);
            this.ayudaToolStripMenuItem.Text = "Ayuda";
            // 
            // acercaDeRememberTheGamToolStripMenuItem
            // 
            this.acercaDeRememberTheGamToolStripMenuItem.Name = "acercaDeRememberTheGamToolStripMenuItem";
            this.acercaDeRememberTheGamToolStripMenuItem.Size = new System.Drawing.Size(244, 22);
            this.acercaDeRememberTheGamToolStripMenuItem.Text = "Acerca de Remember The Game";
            this.acercaDeRememberTheGamToolStripMenuItem.Click += new System.EventHandler(this.acercaDeRememberTheGamToolStripMenuItem_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Location = new System.Drawing.Point(0, 700);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(1024, 22);
            this.statusStrip1.TabIndex = 3;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 24);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.tvxPlataformas);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.dgvJuegos);
            this.splitContainer1.Size = new System.Drawing.Size(1024, 676);
            this.splitContainer1.SplitterDistance = 339;
            this.splitContainer1.TabIndex = 4;
            // 
            // tvxPlataformas
            // 
            this.tvxPlataformas.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tvxPlataformas.Location = new System.Drawing.Point(0, 0);
            this.tvxPlataformas.Name = "tvxPlataformas";
            this.tvxPlataformas.Size = new System.Drawing.Size(339, 676);
            this.tvxPlataformas.TabIndex = 0;
            this.tvxPlataformas.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.tvxPlataformas_AfterSelect);
            // 
            // dgvJuegos
            // 
            this.dgvJuegos.AllowUserToAddRows = false;
            this.dgvJuegos.AllowUserToDeleteRows = false;
            this.dgvJuegos.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgvJuegos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvJuegos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvJuegos.Location = new System.Drawing.Point(0, 0);
            this.dgvJuegos.Name = "dgvJuegos";
            this.dgvJuegos.ReadOnly = true;
            this.dgvJuegos.Size = new System.Drawing.Size(681, 676);
            this.dgvJuegos.TabIndex = 0;
            // 
            // añadirPlataformaToolStripMenuItem
            // 
            this.añadirPlataformaToolStripMenuItem.Name = "añadirPlataformaToolStripMenuItem";
            this.añadirPlataformaToolStripMenuItem.Size = new System.Drawing.Size(170, 22);
            this.añadirPlataformaToolStripMenuItem.Text = "Añadir Plataforma";
            // 
            // editarPlataformaToolStripMenuItem
            // 
            this.editarPlataformaToolStripMenuItem.Name = "editarPlataformaToolStripMenuItem";
            this.editarPlataformaToolStripMenuItem.Size = new System.Drawing.Size(170, 22);
            this.editarPlataformaToolStripMenuItem.Text = "Editar Plataforma";
            // 
            // borrarPlataformaToolStripMenuItem
            // 
            this.borrarPlataformaToolStripMenuItem.Name = "borrarPlataformaToolStripMenuItem";
            this.borrarPlataformaToolStripMenuItem.Size = new System.Drawing.Size(170, 22);
            this.borrarPlataformaToolStripMenuItem.Text = "Borrar Plataforma";
            // 
            // verToolStripMenuItem
            // 
            this.verToolStripMenuItem.Name = "verToolStripMenuItem";
            this.verToolStripMenuItem.Size = new System.Drawing.Size(36, 20);
            this.verToolStripMenuItem.Text = "Ver";
            // 
            // herramientasToolStripMenuItem
            // 
            this.herramientasToolStripMenuItem.Name = "herramientasToolStripMenuItem";
            this.herramientasToolStripMenuItem.Size = new System.Drawing.Size(90, 20);
            this.herramientasToolStripMenuItem.Text = "Herramientas";
            // 
            // FrmPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1024, 722);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "FrmPrincipal";
            this.Text = "Remember The Game";
            this.Load += new System.EventHandler(this.FrmPrincipal_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvJuegos)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem ayudaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem acercaDeRememberTheGamToolStripMenuItem;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripMenuItem archivoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem salirToolStripMenuItem;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.TreeView tvxPlataformas;
        private System.Windows.Forms.DataGridView dgvJuegos;
        private System.Windows.Forms.ToolStripMenuItem ediciónToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem añadirCategoriaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem editarCategoriaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem borrarCategoriaToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem añadirPlataformaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem editarPlataformaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem borrarPlataformaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem verToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem herramientasToolStripMenuItem;

    }
}

