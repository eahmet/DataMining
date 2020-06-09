

namespace DataMiningForm
{
    partial class Form1
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
            this.components = new System.ComponentModel.Container();
            DevExpress.XtraBars.Ribbon.GalleryItemGroup galleryItemGroup1 = new DevExpress.XtraBars.Ribbon.GalleryItemGroup();
            this.diagram1 = new DevExpress.XtraDiagram.DiagramControl();
            this.DataMine = new System.Windows.Forms.Button();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.txtDistance = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtReduce = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.InsertContainerPopupMenu = new DevExpress.XtraBars.Commands.CommandBarGalleryDropDown(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.diagram1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.InsertContainerPopupMenu)).BeginInit();
            this.SuspendLayout();
            // 
            // diagram1
            // 
            this.diagram1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.diagram1.Location = new System.Drawing.Point(0, 0);
            this.diagram1.Name = "diagram1";
            this.diagram1.OptionsBehavior.SelectedStencils = new DevExpress.Diagram.Core.StencilCollection(new string[] {
            "BasicShapes",
            "BasicFlowchartShapes"});
            this.diagram1.OptionsView.PaperKind = System.Drawing.Printing.PaperKind.Letter;
            this.diagram1.Size = new System.Drawing.Size(800, 411);
            this.diagram1.TabIndex = 0;
            this.diagram1.Text = "diagramControl1";
            // 
            // DataMine
            // 
            this.DataMine.Location = new System.Drawing.Point(3, 3);
            this.DataMine.Name = "DataMine";
            this.DataMine.Size = new System.Drawing.Size(75, 23);
            this.DataMine.TabIndex = 1;
            this.DataMine.Text = "DataMine";
            this.DataMine.UseVisualStyleBackColor = true;
            this.DataMine.Click += new System.EventHandler(this.DataMine_Click);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.txtDistance);
            this.splitContainer1.Panel1.Controls.Add(this.label2);
            this.splitContainer1.Panel1.Controls.Add(this.txtReduce);
            this.splitContainer1.Panel1.Controls.Add(this.label1);
            this.splitContainer1.Panel1.Controls.Add(this.DataMine);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.diagram1);
            this.splitContainer1.Size = new System.Drawing.Size(800, 450);
            this.splitContainer1.SplitterDistance = 35;
            this.splitContainer1.TabIndex = 2;
            // 
            // txtDistance
            // 
            this.txtDistance.Location = new System.Drawing.Point(390, 7);
            this.txtDistance.Name = "txtDistance";
            this.txtDistance.Size = new System.Drawing.Size(100, 20);
            this.txtDistance.TabIndex = 5;
            this.txtDistance.Text = "0";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(311, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(74, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Step Distance";
            // 
            // txtReduce
            // 
            this.txtReduce.Location = new System.Drawing.Point(196, 10);
            this.txtReduce.Name = "txtReduce";
            this.txtReduce.Size = new System.Drawing.Size(100, 20);
            this.txtReduce.TabIndex = 3;
            this.txtReduce.Text = "0";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(117, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(75, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Reduce Steps";
            // 
            // InsertContainerPopupMenu
            // 
            // 
            // 
            // 
            this.InsertContainerPopupMenu.Gallery.AllowFilter = false;
            this.InsertContainerPopupMenu.Gallery.ColumnCount = 4;
            this.InsertContainerPopupMenu.Gallery.Groups.AddRange(new DevExpress.XtraBars.Ribbon.GalleryItemGroup[] {
            galleryItemGroup1});
            this.InsertContainerPopupMenu.Gallery.ImageSize = new System.Drawing.Size(65, 46);
            this.InsertContainerPopupMenu.Gallery.ItemCheckMode = DevExpress.XtraBars.Ribbon.Gallery.ItemCheckMode.SingleRadio;
            this.InsertContainerPopupMenu.Gallery.RowCount = 2;
            this.InsertContainerPopupMenu.Gallery.ScaleImages = DevExpress.Utils.DefaultBoolean.True;
            this.InsertContainerPopupMenu.Gallery.ShowGroupCaption = false;
            this.InsertContainerPopupMenu.Manager = null;
            this.InsertContainerPopupMenu.MenuDrawMode = DevExpress.XtraBars.MenuDrawMode.LargeImagesText;
            this.InsertContainerPopupMenu.Name = "InsertContainerPopupMenu";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.splitContainer1);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.diagram1)).EndInit();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.InsertContainerPopupMenu)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraDiagram.DiagramControl diagram1;
        private System.Windows.Forms.Button DataMine;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.TextBox txtReduce;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtDistance;
        private System.Windows.Forms.Label label2;
        private DevExpress.XtraBars.Commands.CommandBarGalleryDropDown InsertContainerPopupMenu;
    }
}

