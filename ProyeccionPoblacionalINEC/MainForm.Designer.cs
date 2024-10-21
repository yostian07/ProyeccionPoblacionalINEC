// Forms/MainForm.Designer.cs
namespace ProyeccionPoblacionalINEC.Forms
{
    partial class MainForm
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        // Declaración de los controles
        private System.Windows.Forms.DataGridView dgvEdadesSexo;
        private System.Windows.Forms.DataGridView dgvSexoGrupoEtario;
        private System.Windows.Forms.DataGridView dgvEducacion;
        private MaterialSkin.Controls.MaterialButton btnCargarArchivo;
        private MaterialSkin.Controls.MaterialButton btnSalir;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanelDataGrids;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanelButtons;
        private MaterialSkin.Controls.MaterialLabel materialLabel1;
        private MaterialSkin.Controls.MaterialProgressBar materialProgressBar1;

        // Nuevos Labels para títulos
        private System.Windows.Forms.Label lblTituloEdadesSexo;
        private System.Windows.Forms.Label lblTituloSexoGrupoEtario;
        private System.Windows.Forms.Label lblTituloEducacion;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
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
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            dgvEdadesSexo = new DataGridView();
            dgvSexoGrupoEtario = new DataGridView();
            dgvEducacion = new DataGridView();
            btnCargarArchivo = new MaterialSkin.Controls.MaterialButton();
            btnSalir = new MaterialSkin.Controls.MaterialButton();
            tableLayoutPanelDataGrids = new TableLayoutPanel();
            lblTituloEdadesSexo = new Label();
            lblTituloSexoGrupoEtario = new Label();
            lblTituloEducacion = new Label();
            flowLayoutPanelButtons = new FlowLayoutPanel();
            materialLabel1 = new MaterialSkin.Controls.MaterialLabel();
            materialProgressBar1 = new MaterialSkin.Controls.MaterialProgressBar();
            ((System.ComponentModel.ISupportInitialize)dgvEdadesSexo).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvSexoGrupoEtario).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvEducacion).BeginInit();
            tableLayoutPanelDataGrids.SuspendLayout();
            flowLayoutPanelButtons.SuspendLayout();
            SuspendLayout();
            // 
            // dgvEdadesSexo
            // 
            dgvEdadesSexo.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvEdadesSexo.Dock = DockStyle.Fill;
            dgvEdadesSexo.Location = new Point(3, 24);
            dgvEdadesSexo.Name = "dgvEdadesSexo";
            dgvEdadesSexo.Size = new Size(334, 487);
            dgvEdadesSexo.TabIndex = 0;
            dgvEdadesSexo.DataBindingComplete += dgvEdadesSexo_DataBindingComplete;
            // 
            // dgvSexoGrupoEtario
            // 
            dgvSexoGrupoEtario.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvSexoGrupoEtario.Dock = DockStyle.Fill;
            dgvSexoGrupoEtario.Location = new Point(343, 24);
            dgvSexoGrupoEtario.Name = "dgvSexoGrupoEtario";
            dgvSexoGrupoEtario.Size = new Size(334, 487);
            dgvSexoGrupoEtario.TabIndex = 1;
            dgvSexoGrupoEtario.DataBindingComplete += dgvSexoGrupoEtario_DataBindingComplete;
            // 
            // dgvEducacion
            // 
            dgvEducacion.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvEducacion.Dock = DockStyle.Fill;
            dgvEducacion.Location = new Point(683, 24);
            dgvEducacion.Name = "dgvEducacion";
            dgvEducacion.Size = new Size(336, 487);
            dgvEducacion.TabIndex = 2;
            dgvEducacion.DataBindingComplete += dgvEducacion_DataBindingComplete;
            // 
            // btnCargarArchivo
            // 
            btnCargarArchivo.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            btnCargarArchivo.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            btnCargarArchivo.Depth = 0;
            btnCargarArchivo.HighEmphasis = true;
            btnCargarArchivo.Icon = null;
            btnCargarArchivo.Location = new Point(850, 10);
            btnCargarArchivo.Margin = new Padding(9, 5, 9, 5);
            btnCargarArchivo.MouseState = MaterialSkin.MouseState.HOVER;
            btnCargarArchivo.Name = "btnCargarArchivo";
            btnCargarArchivo.NoAccentTextColor = Color.Empty;
            btnCargarArchivo.Size = new Size(145, 36);
            btnCargarArchivo.TabIndex = 3;
            btnCargarArchivo.Text = "Cargar Archivo";
            btnCargarArchivo.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            btnCargarArchivo.UseAccentColor = false;
            btnCargarArchivo.UseVisualStyleBackColor = true;
            // 
            // btnSalir
            // 
            btnSalir.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            btnSalir.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            btnSalir.Depth = 0;
            btnSalir.HighEmphasis = true;
            btnSalir.Icon = null;
            btnSalir.Location = new Point(768, 10);
            btnSalir.Margin = new Padding(9, 5, 9, 5);
            btnSalir.MouseState = MaterialSkin.MouseState.HOVER;
            btnSalir.Name = "btnSalir";
            btnSalir.NoAccentTextColor = Color.Empty;
            btnSalir.Size = new Size(64, 36);
            btnSalir.TabIndex = 4;
            btnSalir.Text = "Salir";
            btnSalir.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            btnSalir.UseAccentColor = false;
            btnSalir.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanelDataGrids
            // 
            tableLayoutPanelDataGrids.ColumnCount = 3;
            tableLayoutPanelDataGrids.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.33333F));
            tableLayoutPanelDataGrids.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.33334F));
            tableLayoutPanelDataGrids.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.33334F));
            tableLayoutPanelDataGrids.Controls.Add(lblTituloEdadesSexo, 0, 0);
            tableLayoutPanelDataGrids.Controls.Add(lblTituloSexoGrupoEtario, 1, 0);
            tableLayoutPanelDataGrids.Controls.Add(dgvEdadesSexo, 0, 1);
            tableLayoutPanelDataGrids.Controls.Add(dgvSexoGrupoEtario, 1, 1);
            tableLayoutPanelDataGrids.Controls.Add(dgvEducacion, 2, 1);
            tableLayoutPanelDataGrids.Controls.Add(lblTituloEducacion, 2, 0);
            tableLayoutPanelDataGrids.Dock = DockStyle.Fill;
            tableLayoutPanelDataGrids.Location = new Point(3, 60);
            tableLayoutPanelDataGrids.Name = "tableLayoutPanelDataGrids";
            tableLayoutPanelDataGrids.Padding = new Padding(0, 4, 0, 0);
            tableLayoutPanelDataGrids.RowCount = 2;
            tableLayoutPanelDataGrids.RowStyles.Add(new RowStyle(SizeType.Absolute, 21F));
            tableLayoutPanelDataGrids.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanelDataGrids.Size = new Size(1022, 514);
            tableLayoutPanelDataGrids.TabIndex = 5;
            // 
            // lblTituloEdadesSexo
            // 
            lblTituloEdadesSexo.AutoSize = true;
            lblTituloEdadesSexo.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblTituloEdadesSexo.Location = new Point(3, 0);
            lblTituloEdadesSexo.Name = "lblTituloEdadesSexo";
            lblTituloEdadesSexo.Size = new Size(121, 19);
            lblTituloEdadesSexo.TabIndex = 6;
            lblTituloEdadesSexo.Text = "Edades por Sexo";
            lblTituloEdadesSexo.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblTituloSexoGrupoEtario
            // 
            lblTituloSexoGrupoEtario.AutoSize = true;
            lblTituloSexoGrupoEtario.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblTituloSexoGrupoEtario.Location = new Point(343, 0);
            lblTituloSexoGrupoEtario.Name = "lblTituloSexoGrupoEtario";
            lblTituloSexoGrupoEtario.Size = new Size(143, 19);
            lblTituloSexoGrupoEtario.TabIndex = 7;
            lblTituloSexoGrupoEtario.Text = "Sexo y Grupo Etario";
            lblTituloSexoGrupoEtario.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblTituloEducacion
            // 
            lblTituloEducacion.AutoSize = true;
            lblTituloEducacion.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblTituloEducacion.Location = new Point(683, 0);
            lblTituloEducacion.Name = "lblTituloEducacion";
            lblTituloEducacion.Size = new Size(140, 19);
            lblTituloEducacion.TabIndex = 8;
            lblTituloEducacion.Text = "Distribución Escolar";
            lblTituloEducacion.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // flowLayoutPanelButtons
            // 
            flowLayoutPanelButtons.AutoSize = true;
            flowLayoutPanelButtons.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            flowLayoutPanelButtons.Controls.Add(btnCargarArchivo);
            flowLayoutPanelButtons.Controls.Add(btnSalir);
            flowLayoutPanelButtons.Controls.Add(materialLabel1);
            flowLayoutPanelButtons.Controls.Add(materialProgressBar1);
            flowLayoutPanelButtons.Dock = DockStyle.Bottom;
            flowLayoutPanelButtons.FlowDirection = FlowDirection.RightToLeft;
            flowLayoutPanelButtons.Location = new Point(3, 574);
            flowLayoutPanelButtons.Name = "flowLayoutPanelButtons";
            flowLayoutPanelButtons.Padding = new Padding(0, 5, 18, 5);
            flowLayoutPanelButtons.Size = new Size(1022, 56);
            flowLayoutPanelButtons.TabIndex = 6;
            // 
            // materialLabel1
            // 
            materialLabel1.AutoSize = true;
            materialLabel1.Depth = 0;
            materialLabel1.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            materialLabel1.Location = new Point(615, 5);
            materialLabel1.MouseState = MaterialSkin.MouseState.HOVER;
            materialLabel1.Name = "materialLabel1";
            materialLabel1.Size = new Size(141, 19);
            materialLabel1.TabIndex = 6;
            materialLabel1.Text = "Procesando datos...";
            materialLabel1.Visible = false;
            // 
            // materialProgressBar1
            // 
            materialProgressBar1.Depth = 0;
            materialProgressBar1.Location = new Point(217, 8);
            materialProgressBar1.MouseState = MaterialSkin.MouseState.HOVER;
            materialProgressBar1.Name = "materialProgressBar1";
            materialProgressBar1.Size = new Size(392, 5);
            materialProgressBar1.TabIndex = 5;
            materialProgressBar1.Visible = false;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1028, 633);
            Controls.Add(tableLayoutPanelDataGrids);
            Controls.Add(flowLayoutPanelButtons);
            Name = "MainForm";
            Padding = new Padding(3, 60, 3, 3);
            Text = "Proyección Poblacional INEC";
            ((System.ComponentModel.ISupportInitialize)dgvEdadesSexo).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvSexoGrupoEtario).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvEducacion).EndInit();
            tableLayoutPanelDataGrids.ResumeLayout(false);
            tableLayoutPanelDataGrids.PerformLayout();
            flowLayoutPanelButtons.ResumeLayout(false);
            flowLayoutPanelButtons.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
    }
}
