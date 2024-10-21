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
        private MaterialSkin.Controls.MaterialProgressBar progressBarCarga;

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
            flowLayoutPanelButtons = new FlowLayoutPanel();
            materialLabel1 = new MaterialSkin.Controls.MaterialLabel();
            materialProgressBar1 = new MaterialSkin.Controls.MaterialProgressBar();
            progressBarCarga = new MaterialSkin.Controls.MaterialProgressBar();
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
            dgvEdadesSexo.Location = new Point(3, 3);
            dgvEdadesSexo.Name = "dgvEdadesSexo";
            dgvEdadesSexo.Size = new Size(347, 430);
            dgvEdadesSexo.TabIndex = 0;
            dgvEdadesSexo.DataBindingComplete += dgvEdadesSexo_DataBindingComplete;
            // 
            // dgvSexoGrupoEtario
            // 
            dgvSexoGrupoEtario.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvSexoGrupoEtario.Dock = DockStyle.Fill;
            dgvSexoGrupoEtario.Location = new Point(356, 3);
            dgvSexoGrupoEtario.Name = "dgvSexoGrupoEtario";
            dgvSexoGrupoEtario.Size = new Size(347, 430);
            dgvSexoGrupoEtario.TabIndex = 1;
            dgvSexoGrupoEtario.DataBindingComplete += dgvSexoGrupoEtario_DataBindingComplete;
            // 
            // dgvEducacion
            // 
            dgvEducacion.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvEducacion.Dock = DockStyle.Fill;
            dgvEducacion.Location = new Point(709, 3);
            dgvEducacion.Name = "dgvEducacion";
            dgvEducacion.Size = new Size(348, 430);
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
            btnCargarArchivo.Location = new Point(888, 10);
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
            btnSalir.Location = new Point(806, 10);
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
            tableLayoutPanelDataGrids.Controls.Add(dgvEdadesSexo, 0, 0);
            tableLayoutPanelDataGrids.Controls.Add(dgvSexoGrupoEtario, 1, 0);
            tableLayoutPanelDataGrids.Controls.Add(dgvEducacion, 2, 0);
            tableLayoutPanelDataGrids.Dock = DockStyle.Fill;
            tableLayoutPanelDataGrids.Location = new Point(3, 60);
            tableLayoutPanelDataGrids.Name = "tableLayoutPanelDataGrids";
            tableLayoutPanelDataGrids.RowCount = 1;
            tableLayoutPanelDataGrids.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanelDataGrids.Size = new Size(1060, 436);
            tableLayoutPanelDataGrids.TabIndex = 5;
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
            flowLayoutPanelButtons.Location = new Point(3, 496);
            flowLayoutPanelButtons.Name = "flowLayoutPanelButtons";
            flowLayoutPanelButtons.Padding = new Padding(0, 5, 18, 5);
            flowLayoutPanelButtons.Size = new Size(1060, 67);
            flowLayoutPanelButtons.TabIndex = 6;
            // 
            // materialLabel1
            // 
            materialLabel1.AutoSize = true;
            materialLabel1.Depth = 0;
            materialLabel1.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            materialLabel1.Location = new Point(714, 5);
            materialLabel1.MouseState = MaterialSkin.MouseState.HOVER;
            materialLabel1.Name = "materialLabel1";
            materialLabel1.Size = new Size(80, 19);
            materialLabel1.TabIndex = 6;
            materialLabel1.Text = "Prcesando ";
            materialLabel1.Visible = false;
            // 
            // materialProgressBar1
            // 
            materialProgressBar1.Depth = 0;
            materialProgressBar1.Location = new Point(260, 54);
            materialProgressBar1.MouseState = MaterialSkin.MouseState.HOVER;
            materialProgressBar1.Name = "materialProgressBar1";
            materialProgressBar1.Size = new Size(779, 5);
            materialProgressBar1.TabIndex = 5;
            materialProgressBar1.Visible = false;
            // 
            // progressBarCarga
            // 
            progressBarCarga.Depth = 0;
            progressBarCarga.Location = new Point(0, 0);
            progressBarCarga.MouseState = MaterialSkin.MouseState.HOVER;
            progressBarCarga.Name = "progressBarCarga";
            progressBarCarga.Size = new Size(100, 23);
            progressBarCarga.TabIndex = 7;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1066, 566);
            Controls.Add(tableLayoutPanelDataGrids);
            Controls.Add(flowLayoutPanelButtons);
            Controls.Add(progressBarCarga);
            Name = "MainForm";
            Padding = new Padding(3, 60, 3, 3);
            Text = "Proyección Poblacional INEC";
            ((System.ComponentModel.ISupportInitialize)dgvEdadesSexo).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvSexoGrupoEtario).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvEducacion).EndInit();
            tableLayoutPanelDataGrids.ResumeLayout(false);
            flowLayoutPanelButtons.ResumeLayout(false);
            flowLayoutPanelButtons.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private MaterialSkin.Controls.MaterialProgressBar materialProgressBar1;
        private MaterialSkin.Controls.MaterialLabel materialLabel1;
    }
}
