using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RenamePDF
{
    public partial class Form1 : Form
    {
        private const string COMPANYNAMELISTFILE = @"CompanyNameList.txt";

        private string DestinationPDFDirectory = "";


        public Form1()
        {
            InitializeComponent();

            this.LoadCompanyNameList();
            this.UpdateDestinationPDF();
            this.CheckExecuteEnable();
        }

        void LoadCompanyNameList()
        {
            if (!File.Exists(COMPANYNAMELISTFILE))
            {
                return;
            }

            using (StreamReader reader = new StreamReader(COMPANYNAMELISTFILE, Encoding.GetEncoding("shift_jis")))
            {
                while (!reader.EndOfStream)
                {
                    string line = reader.ReadLine();
                    if (String.IsNullOrEmpty(line)) continue;

                    this.ShopName.Items.Add(line);
                }

                reader.Close();
            }
        }

        private void SelectSourcePDF_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog dialog = new OpenFileDialog())
            {
                dialog.Filter = @"PDFファイル|*.pdf";

                if (dialog.ShowDialog(this) == DialogResult.OK)
                {
                    this.LoadPDF(dialog.FileName);
                    this.CheckExecuteEnable();
                }
            }
        }

        private void Form1_DragDrop(object sender, DragEventArgs e)
        {
            string[] files = (string[])e.Data.GetData(DataFormats.FileDrop, false);

            this.LoadPDF(files[0]);
            this.CheckExecuteEnable();
        }

        private void Form1_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                e.Effect = DragDropEffects.All;
            }
            else
            {
                e.Effect = DragDropEffects.None;
            }
        }

        private void LoadPDF(string filePath)
        {
            this.SourcePDF.Text = filePath;

            this.PDFPreview.LoadFile(filePath);
        }

        private void SelectDestinationDirectory_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog dialog = new OpenFileDialog())
            {
                dialog.FileName = "Select Folder";
                dialog.Filter = "Folder |.";
                dialog.ValidateNames = false;
                dialog.CheckFileExists = false;
                dialog.CheckPathExists = true;

                if (dialog.ShowDialog(this) == DialogResult.OK)
                {
                    this.DestinationPDFDirectory = Path.GetDirectoryName(dialog.FileName);
                    this.UpdateDestinationPDF();
                }
            }
        }

        private void CopyExecute_Click(object sender, EventArgs e)
        {
            if (File.Exists(this.DestinationPDF.Text))
            {
                MessageBox.Show("同名のファイルが既に存在します。", this.Text,
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                File.Copy(this.SourcePDF.Text, this.DestinationPDF.Text);

                MessageBox.Show("コピーが完了しました。", this.Text,
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message, this.Text,
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ReceiptControl_Leave(object sender, EventArgs e)
        {
            this.UpdateDestinationPDF();
        }


        private void UpdateDestinationPDF()
        {
            string[] fileNameParts = new string[3];
            fileNameParts[0] = this.PurchaseDate.Value.ToString("yyyyMMdd");
            fileNameParts[1] = this.ShopName.Text;
            fileNameParts[2] = this.Price.Text;

            string destFileName = String.Join("_", fileNameParts);
            if (destFileName.Length > 0)
            {
                destFileName = Path.ChangeExtension(destFileName, "pdf");
            }

            this.DestinationPDF.Text = Path.Combine(this.DestinationPDFDirectory, destFileName);
            this.CheckExecuteEnable();
        }

        private void CheckExecuteEnable()
        {
            if (!String.IsNullOrEmpty(this.DestinationPDF.Text) &&
                !String.IsNullOrEmpty(this.SourcePDF.Text))
            {
                this.CopyExecute.Enabled = true;
            }
            else
            {
                this.CopyExecute.Enabled = false;
            }
        }
    }
}
