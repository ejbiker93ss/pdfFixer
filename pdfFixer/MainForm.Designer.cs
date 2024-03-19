namespace pdfFixer
{
    partial class MainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.flp1 = new System.Windows.Forms.FlowLayoutPanel();
            this.btnSaveAsNewPDF = new DevExpress.XtraEditors.SimpleButton();
            this.txtOutputFolderPath = new DevExpress.XtraEditors.TextEdit();
            this.label1 = new DevExpress.XtraEditors.LabelControl();
            this.label2 = new DevExpress.XtraEditors.LabelControl();
            this.txtFileName = new DevExpress.XtraEditors.TextEdit();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.btnChooseFolder = new DevExpress.XtraEditors.SimpleButton();
            this.cbDeleteOriginals = new DevExpress.XtraEditors.CheckEdit();
            ((System.ComponentModel.ISupportInitialize)(this.txtOutputFolderPath.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtFileName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbDeleteOriginals.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // flp1
            // 
            this.flp1.AllowDrop = true;
            this.flp1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.flp1.AutoScroll = true;
            this.flp1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.flp1.Location = new System.Drawing.Point(12, 47);
            this.flp1.Name = "flp1";
            this.flp1.Size = new System.Drawing.Size(1440, 820);
            this.flp1.TabIndex = 0;
            this.flp1.DragDrop += new System.Windows.Forms.DragEventHandler(this.flp1_DragDrop);
            this.flp1.DragEnter += new System.Windows.Forms.DragEventHandler(this.flp1_DragEnter);
            // 
            // btnSaveAsNewPDF
            // 
            this.btnSaveAsNewPDF.Appearance.Font = new System.Drawing.Font("Arial Rounded MT Bold", 9F);
            this.btnSaveAsNewPDF.Appearance.Options.UseFont = true;
            this.btnSaveAsNewPDF.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnSaveAsNewPDF.ImageOptions.Image")));
            this.btnSaveAsNewPDF.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.MiddleRight;
            this.btnSaveAsNewPDF.Location = new System.Drawing.Point(12, 5);
            this.btnSaveAsNewPDF.Name = "btnSaveAsNewPDF";
            this.btnSaveAsNewPDF.Size = new System.Drawing.Size(147, 36);
            this.btnSaveAsNewPDF.TabIndex = 1;
            this.btnSaveAsNewPDF.Text = "Save As New PDF";
            this.btnSaveAsNewPDF.Click += new System.EventHandler(this.btnSaveAsNewPDF_Click);
            // 
            // txtOutputFolderPath
            // 
            this.txtOutputFolderPath.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtOutputFolderPath.Location = new System.Drawing.Point(558, 9);
            this.txtOutputFolderPath.Name = "txtOutputFolderPath";
            this.txtOutputFolderPath.Properties.Appearance.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtOutputFolderPath.Properties.Appearance.Options.UseFont = true;
            this.txtOutputFolderPath.Size = new System.Drawing.Size(565, 34);
            this.txtOutputFolderPath.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.Appearance.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Appearance.Options.UseFont = true;
            this.label1.Location = new System.Drawing.Point(404, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(145, 18);
            this.label1.TabIndex = 3;
            this.label1.Text = "Output folder path";
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.Appearance.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Appearance.Options.UseFont = true;
            this.label2.Location = new System.Drawing.Point(1185, 16);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(78, 18);
            this.label2.TabIndex = 5;
            this.label2.Text = "File Name";
            // 
            // txtFileName
            // 
            this.txtFileName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtFileName.Location = new System.Drawing.Point(1269, 9);
            this.txtFileName.Name = "txtFileName";
            this.txtFileName.Properties.Appearance.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFileName.Properties.Appearance.Options.UseFont = true;
            this.txtFileName.Size = new System.Drawing.Size(183, 34);
            this.txtFileName.TabIndex = 4;
            // 
            // btnChooseFolder
            // 
            this.btnChooseFolder.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnChooseFolder.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnChooseFolder.ImageOptions.SvgImage")));
            this.btnChooseFolder.ImageOptions.SvgImageSize = new System.Drawing.Size(30, 30);
            this.btnChooseFolder.Location = new System.Drawing.Point(1081, 9);
            this.btnChooseFolder.Name = "btnChooseFolder";
            this.btnChooseFolder.Size = new System.Drawing.Size(42, 33);
            this.btnChooseFolder.TabIndex = 6;
            this.btnChooseFolder.Click += new System.EventHandler(this.btnChooseFolder_Click);
            // 
            // cbDeleteOriginals
            // 
            this.cbDeleteOriginals.Location = new System.Drawing.Point(165, 14);
            this.cbDeleteOriginals.Name = "cbDeleteOriginals";
            this.cbDeleteOriginals.Properties.Appearance.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F);
            this.cbDeleteOriginals.Properties.Appearance.Options.UseFont = true;
            this.cbDeleteOriginals.Properties.Caption = "Delete original files";
            this.cbDeleteOriginals.Properties.ImageOptions.SvgImageGrayed = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("cbDeleteOriginals.Properties.ImageOptions.SvgImageGrayed")));
            this.cbDeleteOriginals.Size = new System.Drawing.Size(190, 22);
            this.cbDeleteOriginals.TabIndex = 7;
            // 
            // MainForm
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1468, 879);
            this.Controls.Add(this.cbDeleteOriginals);
            this.Controls.Add(this.btnChooseFolder);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtFileName);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtOutputFolderPath);
            this.Controls.Add(this.btnSaveAsNewPDF);
            this.Controls.Add(this.flp1);
            this.IconOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("MainForm.IconOptions.SvgImage")));
            this.Name = "MainForm";
            this.Text = "PdfFixer";
            ((System.ComponentModel.ISupportInitialize)(this.txtOutputFolderPath.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtFileName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbDeleteOriginals.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel flp1;
        private DevExpress.XtraEditors.SimpleButton btnSaveAsNewPDF;
        private DevExpress.XtraEditors.TextEdit txtOutputFolderPath;
        private DevExpress.XtraEditors.LabelControl label1;
        private DevExpress.XtraEditors.LabelControl label2;
        private DevExpress.XtraEditors.TextEdit txtFileName;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private DevExpress.XtraEditors.SimpleButton btnChooseFolder;
        private DevExpress.XtraEditors.CheckEdit cbDeleteOriginals;
    }
}

