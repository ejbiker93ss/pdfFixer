using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraPdfViewer.Forms;
using DevExpress.XtraPdfViewer;
using PdfSharp;
using PdfSharp.Pdf;
using PdfSharp.Forms;
using System.IO;
using PdfSharp.Pdf.IO;
using System.Runtime.CompilerServices;
using DevExpress.XtraBars.Controls;
using DevExpress.Emf;
using DevExpress.XtraEditors;
using pdfFixer.Properties;
using System.Resources;
using Microsoft.WindowsAPICodePack.Dialogs;
using DevExpress.Utils.About;
using System.Reflection;
using PdfSharp.Drawing;
using System.Diagnostics;

namespace pdfFixer
{
    public partial class MainForm : XtraForm
    {
        public MainForm()
        {
            InitializeComponent();
            FormClosing += MainForm_FormClosing;
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            while (flp1.Controls.Count > 0)
            {
                Panel panel = (Panel)flp1.Controls[0];
                panel.Dispose();
            }

            foreach (var file in NewFiles)
            {
                File.Delete(file);
            }
        }

        List<string> OriginalFiles { get; set; } = new List<string>();
        List<string> NewFiles { get; set; } = new List<string>();
        private void flp1_DragDrop(object sender, DragEventArgs e)
        {
            var data = e.Data;
            var files = (string[])e.Data.GetData(DataFormats.FileDrop);
            var pdfviewer = e.Data.GetDataPresent(typeof(Panel));

            if (files != null)
                foreach (string file in files)
                {
                    string newPdf = null;
                    if (file.ToLower().EndsWith(".jpg") || file.ToLower().EndsWith(".jpeg") || file.ToLower().EndsWith(".png"))
                    {
                        newPdf = Path.GetDirectoryName(file) + "\\" + Path.GetFileNameWithoutExtension(file) + ".pdf";
                        GeneratePDF(newPdf, file);

                    }

                    if (!file.ToLower().EndsWith(".pdf") && newPdf == null)
                        continue;

                    OriginalFiles.Add(file);
                    var pdf = newPdf == null ? file.ToString() : newPdf;
                    if (newPdf != null)
                        OriginalFiles.Add(newPdf);
                    AddPDF(pdf, sender as FlowLayoutPanel);
                }

            //Get data from MS Outlook
            if (e.Data.GetDataPresent("FileGroupDescriptor"))
            {
                string[] frmts = e.Data.GetFormats();
                object o = e.Data.GetData(frmts[0]);
                //
                // the first step here is to get the filename
                // of the attachment and
                // build a full-path name so we can store it
                // in the temporary folder
                //

                // set up to obtain the FileGroupDescriptor
                // and extract the file name
                Stream theStream = (Stream)e.Data.GetData("FileGroupDescriptor");
                byte[] fileGroupDescriptor = new byte[512];
                theStream.Read(fileGroupDescriptor, 0, 512);
                // used to build the filename from the FileGroupDescriptor block
                StringBuilder fileName = new StringBuilder("");
                // this trick gets the filename of the passed attached file
                for (int i = 76; fileGroupDescriptor[i] != 0; i++)
                    fileName.Append(Convert.ToChar(fileGroupDescriptor[i]));


                string path = Path.GetTempPath();
                // put the zip file into the temp directory
                string theFile = path + fileName.ToString();
                // create the full-path name

                //
                // Second step:  we have the file name.
                // Now we need to get the actual raw
                // data for the attached file and copy it to disk so we work on it.
                //

                // get the actual raw file into memory
                MemoryStream ms = (MemoryStream)e.Data.GetData("FileContents", true);
                if (ms == null)
                {
                    // ms = (MemoryStream)e.Data.GetData("innerData", true);
                    FieldInfo info;
                    object obj;

                    info = e.Data.GetType().GetField("innerData", BindingFlags.NonPublic | BindingFlags.Instance);
                    obj = info.GetValue(e.Data);

                    info = obj.GetType().GetField("innerData", BindingFlags.NonPublic | BindingFlags.Instance);
                    System.Windows.DataObject dataObj = info.GetValue(obj) as System.Windows.DataObject;
                    //ms = dataObj.GetData("FileContents",true) as MemoryStream;

                }

                // allocate enough bytes to hold the raw data
                byte[] fileBytes = new byte[ms.Length];
                // set starting position at first byte and read in the raw data
                ms.Position = 0;
                ms.Read(fileBytes, 0, (int)ms.Length);
                // create a file and save the raw zip file to it
                FileStream fs = new FileStream(theFile, FileMode.Create);
                fs.Write(fileBytes, 0, (int)fileBytes.Length);

                fs.Close();  // close the file
                theStream.Close();
                FileInfo tempFile = new FileInfo(theFile);

                string newPdf = null;
                if (tempFile.FullName.ToLower().EndsWith(".jpg") || tempFile.FullName.ToLower().EndsWith(".jpeg") || tempFile.FullName.ToLower().EndsWith(".png"))
                {
                    newPdf = Path.GetDirectoryName(tempFile.FullName) + "\\" + Path.GetFileNameWithoutExtension(tempFile.FullName) + ".pdf";
                    GeneratePDF(newPdf, tempFile.FullName);
                    NewFiles.Add(tempFile.FullName);
                    NewFiles.Add(newPdf);

                }
                string FinalFile = newPdf ?? tempFile.FullName;
                AddPDF(FinalFile, sender as FlowLayoutPanel);

            }
            AddPageNumbers();
        }
        int pagnum { get; set; } = 1;
        private void AddPDF(string filepath, FlowLayoutPanel pnl)
        {
            PdfDocument pdf = new PdfDocument();
            pdf = PdfReader.Open(filepath, PdfDocumentOpenMode.Import);
            var pages = pdf.Pages;

            foreach (var page in pages)
            {
                PdfDocument pagePdf = new PdfDocument();
                pagePdf.AddPage(page);
                var dir = Path.GetDirectoryName(filepath);
                var file = "pdfFixer_temp_" + pagnum.ToString() + ".pdf";
                var newPath = Path.Combine(dir, file);
                pagePdf.Save(newPath);

                NewFiles.Add(newPath);

                MyPDFviewer myPDFviewer = new MyPDFviewer();
                myPanel panel = new myPanel();
                panel.FilePath = newPath;
                panel.Height = 520;
                panel.Width = 350;
                panel.Margin = new Padding(1);
                panel.SetPage(pagnum);
                myPDFviewer.LoadDocument(newPath);
                myPDFviewer.Top = panel.Top + 15;
                myPDFviewer.Width = 370;
                myPDFviewer.Height = 500;
                myPDFviewer.ZoomMode = PdfZoomMode.FitToVisible;
                myPDFviewer.AllowDrop = true;
                myPDFviewer.MouseDown += MyPDFviewer_MouseDown;
                myPDFviewer.DragEnter += MyPDFviewer_DragEnter;
                myPDFviewer.DragDrop += MyPDFviewer_DragDrop;
                myPDFviewer.Name = "PdfViewer_" + pagnum.ToString();

                panel.Name = "Panel_" + pagnum.ToString();
                panel.MouseEnter += Panel_MouseEnter;
                panel.MouseLeave += Panel_MouseLeave;
                panel.AllowDrop = true;
                panel.Controls.Add(myPDFviewer);
                panel.MouseDown += Panel_MouseDown;
                panel.pDFviewer = myPDFviewer;
                pnl.Controls.Add(panel);
                txtOutputFolderPath.Text = dir;

                var btn = new SimpleButton();
                btn.Location = new Point(150, 476);
                btn.Size = new System.Drawing.Size(85, 22);
                btn.Click += Btn_Click;
                panel.Controls.Add(btn);
                btn.Name = "btn";
                btn.Text = "Remove page";

                btn.BringToFront();
                pagnum++;
            }

            //Pdfd


        }
        private void RemoveNewFile(string filepath)
        {
            NewFiles.Remove(filepath);
            File.Delete(filepath);
        }
        private void Btn_Click(object sender, EventArgs e)
        {
            myPanel pnl = (myPanel)((SimpleButton)sender).Parent;
            flp1.Controls.Remove(pnl);
            pnl.Dispose();
            RemoveNewFile(pnl.FilePath);

            AddPageNumbers();
        }

        private myPanel LeftPanel { get; set; } = new myPanel();
        private void Panel_MouseLeave(object sender, EventArgs e)
        {

            LeftPanel = sender as myPanel;
        }

        private Panel CurrentPanel { get; set; }

        private void Panel_MouseEnter(object sender, EventArgs e)
        {
            var target = sender as Panel;
            CurrentPanel = target;

        }
        public class DragDropInfo
        {
            public myPanel control { get; set; }
            public DragDropInfo(myPanel ctl)
            {
                this.control = ctl;
            }
        }

        private void MyPDFviewer_DragDrop(object sender, DragEventArgs e)
        {
            var target = FindControlAtCursor(this);
            var index = flp1.Controls.GetChildIndex(target);

            DragDropInfo fromdrop = (DragDropInfo)e.Data.GetData(typeof(DragDropInfo));
            var src = fromdrop.control as myPanel;

            //if (LeftPanel.Name == string.Empty)
            //    return;

            //var leftIndex = flp1.Controls.GetChildIndex(LeftPanel);

            if (index > -1)
                flp1.Controls.SetChildIndex(src, index);

            AddPageNumbers();
        }
        private void MyPDFviewer_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.All;
        }

        private void MyPDFviewer_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left)
                return;

            base.OnMouseDown(e);
            var panel = (myPanel)(sender as Control).Parent as myPanel;
            DoDragDrop(new DragDropInfo(panel), DragDropEffects.All);
        }

        private void Panel_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left)
                return;

            base.OnMouseDown(e);
            DoDragDrop(sender, DragDropEffects.All);
        }

        private void flp1_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.All;
        }

        private void flp2_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.Text))
                e.Effect = DragDropEffects.Copy;
            else
                e.Effect = DragDropEffects.None;
        }
        public class MyPDFviewer : PdfViewer
        {
            public MyPDFviewer()
            {
                NavigationPaneInitialVisibility = PdfNavigationPaneVisibility.Hidden;
            }
        }
        public class myPanel : Panel
        {
            public string FilePath { get; set; }
            public int PageNumber { get; set; }
            public Label pageLabel { get; set; } = new Label();
            public MyPDFviewer pDFviewer { get; set; }
            public void SetPage(int page)
            {
                PageNumber = page;

            }
        }
        public static Control FindControlAtPoint(Control container, Point pos)
        {
            Control child;
            foreach (Control c in container.Controls)
            {
                if (!(c is Panel))
                    continue;
                if (c.Visible && c.Bounds.Contains(pos))
                {
                    child = FindControlAtPoint(c, new Point(pos.X - c.Left, pos.Y - c.Top));
                    if (child == null) return c;
                    else return child;
                }
            }
            return null;
        }
        public static Control FindControlAtCursor(Form form)
        {
            Point pos = Cursor.Position;
            if (form.Bounds.Contains(pos))
                return FindControlAtPoint(form, form.PointToClient(pos));
            return null;
        }

        private void btnSaveAsNewPDF_Click(object sender, EventArgs e)
        {
            SaveAsNew();
        }
        private void SaveAsNew()
        {
            if (txtFileName.Text.Trim().Length < 1)
            {
                MessageBox.Show("Choose a new filename first!");
                return;
            }

            PdfDocument outputDoc = new PdfDocument();

            while (flp1.Controls.Count > 0)
            {
                var panel = (Panel)flp1.Controls[0];
                myPanel mp = (myPanel)panel;
                MyPDFviewer myPDFviewer = new MyPDFviewer();
                foreach (Control c in mp.Controls)
                    if (c is MyPDFviewer)
                        myPDFviewer = (MyPDFviewer)c;

                var fp = mp.FilePath;
                PdfDocument input = PdfReader.Open(fp, PdfDocumentOpenMode.Import);
                PdfPage page = input.Pages[0];

                page.Rotate = myPDFviewer.RotationAngle;
                outputDoc.AddPage(page);

                panel.Dispose();

            }
            var dir = txtOutputFolderPath.Text + "\\";
            var filen = txtFileName.Text + ".pdf";
            outputDoc.Save(dir + filen);

            DeleteNewFiles();


            if (cbDeleteOriginals.Checked)
                DeleteOriginals();
        }
        private void DeleteNewFiles()
        {
            foreach (var file in NewFiles)
                File.Delete(file);
            NewFiles.Clear();
        }
        private void DeleteOriginals()
        {
            foreach (var file in OriginalFiles)
            {
                if (File.Exists(file))
                    File.Delete(file);
            }
            OriginalFiles.Clear();
        }
        private void AddPageNumbers()
        {
            foreach (Control ctrl in flp1.Controls)
                if (ctrl is Panel)
                    foreach (Control lbl in ctrl.Controls)
                        if (lbl is LabelControl)
                            flp1.Controls.Remove(lbl);

            var pg = 1;
            foreach (Control c in flp1.Controls)
            {
                if (!(c is Panel))
                    return;
                var mp = (myPanel)c;
                var pageLabel = new LabelControl();
                pageLabel.Text = "Page " + pg.ToString();
                pageLabel.Visible = true;
                pageLabel.BackColor = Color.Black;
                pageLabel.Location = new System.Drawing.Point(150, 20);
                pageLabel.Width = 500;

                mp.Controls.Add(pageLabel);
                pageLabel.BringToFront();
                pg++;
            }
        }

        private void btnChooseFolder_Click(object sender, EventArgs e)
        {
            var dialog = new CommonOpenFileDialog();
            dialog.IsFolderPicker = true;

            if (dialog.ShowDialog() != CommonFileDialogResult.Ok)
                return;

            txtOutputFolderPath.Text = dialog.FileName;
        }
        private void GeneratePDF(string filename, string imageLoc)
        {
            PdfDocument document = new PdfDocument();

            // Create an empty page or load existing
            PdfPage page = document.AddPage();

            // Get an XGraphics object for drawing
            XGraphics gfx = XGraphics.FromPdfPage(page);
            DrawImage(gfx, imageLoc, 5, 5, (int)gfx.PageSize.Width - 5, (int)gfx.PageSize.Height - 5);


            // Save and start View
            document.Save(filename);
            //Process.Start(filename);
        }

        void DrawImage(XGraphics gfx, string picFilePath, int x, int y, int width, int height)
        {
            XImage img = XImage.FromFile(picFilePath);

            double xx = (250 - img.PixelWidth * 72 / img.HorizontalResolution) / 2;
            gfx.DrawImage(img, x, y, width, height);
        }
    }
}
