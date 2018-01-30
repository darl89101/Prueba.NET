namespace Prueba
{
    partial class FrmVehicles
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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColUrl = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Transmission = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Price = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColImage = new System.Windows.Forms.DataGridViewImageColumn();
            this.ColEditar = new System.Windows.Forms.DataGridViewButtonColumn();
            this.ColDelete = new System.Windows.Forms.DataGridViewButtonColumn();
            this.panel1 = new System.Windows.Forms.Panel();
            this.BtnNew = new System.Windows.Forms.Button();
            this.TxtFilter = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.name,
            this.ColUrl,
            this.Transmission,
            this.Price,
            this.ColImage,
            this.ColEditar,
            this.ColDelete});
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(0, 48);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowTemplate.Height = 50;
            this.dataGridView1.Size = new System.Drawing.Size(1016, 312);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellClick);
            this.dataGridView1.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dataGridView1_CellFormatting);
            // 
            // name
            // 
            this.name.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.name.DataPropertyName = "Name";
            this.name.HeaderText = "Nombre";
            this.name.Name = "name";
            this.name.ReadOnly = true;
            // 
            // ColUrl
            // 
            this.ColUrl.DataPropertyName = "ImageUrl";
            this.ColUrl.HeaderText = "url";
            this.ColUrl.Name = "ColUrl";
            this.ColUrl.Visible = false;
            // 
            // Transmission
            // 
            this.Transmission.DataPropertyName = "Transmission";
            this.Transmission.HeaderText = "Transmisión";
            this.Transmission.Name = "Transmission";
            this.Transmission.ReadOnly = true;
            // 
            // Price
            // 
            this.Price.DataPropertyName = "Price";
            this.Price.HeaderText = "Precio";
            this.Price.Name = "Price";
            this.Price.ReadOnly = true;
            // 
            // ColImage
            // 
            this.ColImage.DataPropertyName = "Image";
            this.ColImage.HeaderText = "Imagen";
            this.ColImage.ImageLayout = System.Windows.Forms.DataGridViewImageCellLayout.Stretch;
            this.ColImage.Name = "ColImage";
            this.ColImage.ReadOnly = true;
            this.ColImage.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.ColImage.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // ColEditar
            // 
            this.ColEditar.DataPropertyName = "Editar";
            this.ColEditar.HeaderText = "Editar";
            this.ColEditar.Name = "ColEditar";
            this.ColEditar.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.ColEditar.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.ColEditar.Text = "Editar";
            // 
            // ColDelete
            // 
            this.ColDelete.DataPropertyName = "Eliminar";
            this.ColDelete.HeaderText = "Eliminar";
            this.ColDelete.Name = "ColDelete";
            this.ColDelete.Text = "Eliminar";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.BtnNew);
            this.panel1.Controls.Add(this.TxtFilter);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1016, 48);
            this.panel1.TabIndex = 1;
            // 
            // BtnNew
            // 
            this.BtnNew.Location = new System.Drawing.Point(331, 11);
            this.BtnNew.Name = "BtnNew";
            this.BtnNew.Size = new System.Drawing.Size(75, 23);
            this.BtnNew.TabIndex = 2;
            this.BtnNew.Text = "Nuevo";
            this.BtnNew.UseVisualStyleBackColor = true;
            this.BtnNew.Click += new System.EventHandler(this.BtnNew_Click);
            // 
            // TxtFilter
            // 
            this.TxtFilter.Location = new System.Drawing.Point(68, 14);
            this.TxtFilter.Name = "TxtFilter";
            this.TxtFilter.Size = new System.Drawing.Size(244, 20);
            this.TxtFilter.TabIndex = 1;
            this.TxtFilter.TextChanged += new System.EventHandler(this.TxtFilter_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(21, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(32, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Filtrar";
            // 
            // FrmVehicles
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1016, 360);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.panel1);
            this.Name = "FrmVehicles";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Vehículos";
            this.Load += new System.EventHandler(this.FrmVehicles_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox TxtFilter;
        private System.Windows.Forms.Button BtnNew;
        private System.Windows.Forms.DataGridViewTextBoxColumn name;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColUrl;
        private System.Windows.Forms.DataGridViewTextBoxColumn Transmission;
        private System.Windows.Forms.DataGridViewTextBoxColumn Price;
        private System.Windows.Forms.DataGridViewImageColumn ColImage;
        private System.Windows.Forms.DataGridViewButtonColumn ColEditar;
        private System.Windows.Forms.DataGridViewButtonColumn ColDelete;
    }
}