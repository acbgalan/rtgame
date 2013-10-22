namespace RememberTheGame
{
    partial class FrmPlataforma
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
            this.txbNombre = new System.Windows.Forms.TextBox();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnAceptar = new System.Windows.Forms.Button();
            this.lbNombre = new System.Windows.Forms.Label();
            this.lbIdPlataformaResultado = new System.Windows.Forms.Label();
            this.lbIdPlataforma = new System.Windows.Forms.Label();
            this.picLogo = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.picLogo)).BeginInit();
            this.SuspendLayout();
            // 
            // txbNombre
            // 
            this.txbNombre.Location = new System.Drawing.Point(88, 32);
            this.txbNombre.MaxLength = 50;
            this.txbNombre.Name = "txbNombre";
            this.txbNombre.Size = new System.Drawing.Size(150, 20);
            this.txbNombre.TabIndex = 9;
            // 
            // btnCancelar
            // 
            this.btnCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancelar.Location = new System.Drawing.Point(152, 147);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(75, 23);
            this.btnCancelar.TabIndex = 12;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            // 
            // btnAceptar
            // 
            this.btnAceptar.Location = new System.Drawing.Point(71, 147);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(75, 23);
            this.btnAceptar.TabIndex = 11;
            this.btnAceptar.Text = "Aceptar";
            this.btnAceptar.UseVisualStyleBackColor = true;
            // 
            // lbNombre
            // 
            this.lbNombre.AutoSize = true;
            this.lbNombre.Location = new System.Drawing.Point(11, 32);
            this.lbNombre.Name = "lbNombre";
            this.lbNombre.Size = new System.Drawing.Size(47, 13);
            this.lbNombre.TabIndex = 6;
            this.lbNombre.Text = "Nombre:";
            // 
            // lbIdPlataformaResultado
            // 
            this.lbIdPlataformaResultado.AutoSize = true;
            this.lbIdPlataformaResultado.Location = new System.Drawing.Point(85, 9);
            this.lbIdPlataformaResultado.Name = "lbIdPlataformaResultado";
            this.lbIdPlataformaResultado.Size = new System.Drawing.Size(54, 13);
            this.lbIdPlataformaResultado.TabIndex = 7;
            this.lbIdPlataformaResultado.Text = "Id Genero";
            // 
            // lbIdPlataforma
            // 
            this.lbIdPlataforma.AutoSize = true;
            this.lbIdPlataforma.Location = new System.Drawing.Point(11, 9);
            this.lbIdPlataforma.Name = "lbIdPlataforma";
            this.lbIdPlataforma.Size = new System.Drawing.Size(72, 13);
            this.lbIdPlataforma.TabIndex = 8;
            this.lbIdPlataforma.Text = "Id Plataforma:";
            // 
            // picLogo
            // 
            this.picLogo.Location = new System.Drawing.Point(244, 32);
            this.picLogo.Name = "picLogo";
            this.picLogo.Size = new System.Drawing.Size(100, 138);
            this.picLogo.TabIndex = 13;
            this.picLogo.TabStop = false;
            // 
            // FrmPlataforma
            // 
            this.AcceptButton = this.btnAceptar;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancelar;
            this.ClientSize = new System.Drawing.Size(379, 249);
            this.Controls.Add(this.picLogo);
            this.Controls.Add(this.txbNombre);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnAceptar);
            this.Controls.Add(this.lbNombre);
            this.Controls.Add(this.lbIdPlataformaResultado);
            this.Controls.Add(this.lbIdPlataforma);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmPlataforma";
            this.Text = "FrmPlataforma";
            ((System.ComponentModel.ISupportInitialize)(this.picLogo)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txbNombre;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Button btnAceptar;
        private System.Windows.Forms.Label lbNombre;
        private System.Windows.Forms.Label lbIdPlataformaResultado;
        private System.Windows.Forms.Label lbIdPlataforma;
        private System.Windows.Forms.PictureBox picLogo;
    }
}