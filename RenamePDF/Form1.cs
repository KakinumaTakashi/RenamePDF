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
    /// <summary>
    /// 領収書コピー
    /// </summary>
    public partial class Form1 : Form
    {
        /// <summary>
        /// 店名リストファイル名
        /// </summary>
        private const string COMPANYNAMELISTFILE = @"CompanyNameList.txt";
        /// <summary>
        /// コピー先フォルダ
        /// </summary>
        private string DestinationPDFDirectory = "";


        /// <summary>
        /// 領収書コピー
        /// </summary>
        public Form1()
        {
            InitializeComponent();

            // 店名リストのロード
            this.LoadCompanyNameList();
            // コピー先ファイル名の更新
            this.UpdateDestinationPDF();
            // 実行ボタンの有効判定
            this.CheckExecuteEnable();
        }

        /// <summary>
        /// 店名リストをロードする
        /// </summary>
        void LoadCompanyNameList()
        {
            // 店名リストが無い場合は終了
            if (!File.Exists(COMPANYNAMELISTFILE))
            {
                return;
            }

            // 店名リストをプルダウンリストに展開
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

        /// <summary>
        /// コピー元PDF選択のクリックイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SelectSourcePDF_Click(object sender, EventArgs e)
        {
            // ファイル選択ダイアログを表示
            using (OpenFileDialog dialog = new OpenFileDialog())
            {
                dialog.Filter = @"PDFファイル|*.pdf";

                if (dialog.ShowDialog(this) == DialogResult.OK)
                {
                    // PDFをロード
                    this.LoadPDF(dialog.FileName);
                    // 実行ボタンの有効判定
                    this.CheckExecuteEnable();
                }
            }
        }

        /// <summary>
        /// ファイルドロップイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form1_DragDrop(object sender, DragEventArgs e)
        {
            string[] files = (string[])e.Data.GetData(DataFormats.FileDrop, false);

            // PDFをロード
            this.LoadPDF(files[0]);
            // 実行ボタンの有効判定
            this.CheckExecuteEnable();
        }

        /// <summary>
        /// ファイルドロップ開始イベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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

        /// <summary>
        /// PDFをロードする
        /// </summary>
        /// <param name="filePath">PDFファイルパス</param>
        private void LoadPDF(string filePath)
        {
            // ファイルパスを設定
            this.SourcePDF.Text = filePath;
            // プレビューにPDFをロード
            this.PDFPreview.LoadFile(filePath);
        }

        /// <summary>
        /// コピー先ディレクトリ選択のクリックイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SelectDestinationDirectory_Click(object sender, EventArgs e)
        {
            // ファイル選択ダイアログを表示
            using (OpenFileDialog dialog = new OpenFileDialog())
            {
                dialog.FileName = "Select Folder";
                dialog.InitialDirectory = this.DestinationPDFDirectory;
                dialog.Filter = "Folder |.";
                dialog.ValidateNames = false;
                dialog.CheckFileExists = false;
                dialog.CheckPathExists = true;

                if (dialog.ShowDialog(this) == DialogResult.OK)
                {
                    // コピー先ディレクトリに選択したディレクトリを設定
                    this.DestinationPDFDirectory = Path.GetDirectoryName(dialog.FileName);
                    // コピー先ファイル名の更新
                    this.UpdateDestinationPDF();
                }
            }
        }

        /// <summary>
        /// コピー実行のクリックイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CopyExecute_Click(object sender, EventArgs e)
        {
            // 同名ファイルのチェック
            if (File.Exists(this.DestinationPDF.Text))
            {
                MessageBox.Show("同名のファイルが既に存在します。", this.Text,
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                // コピー先へファイルをコピー
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

        /// <summary>
        /// 領収書コントロールのフォーカスアウトイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ReceiptControl_Leave(object sender, EventArgs e)
        {
            //if (String.IsNullOrEmpty(this.SourcePDF.Text))
            //{
            //    this.SourcePDF.BackColor = Color.Pink;
            //}
            //else
            //{
            //    this.SourcePDF.BackColor = SystemColors.Window;
            //}

            //if (String.IsNullOrEmpty(this.ShopName.Text))
            //{
            //    this.ShopName.BackColor = Color.Pink;
            //}
            //else
            //{
            //    this.ShopName.BackColor = SystemColors.Window;
            //}

            //if (String.IsNullOrEmpty(this.Price.Text))
            //{
            //    this.Price.BackColor = Color.Pink;
            //}
            //else
            //{
            //    this.Price.BackColor = SystemColors.Window;
            //}

            // コピー先ファイル名の更新
            this.UpdateDestinationPDF();
        }

        /// <summary>
        /// コピー先ファイル名を更新する
        /// </summary>
        private void UpdateDestinationPDF()
        {
            // 領収書コントロールからコピー先ファイル名を生成
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
            // 実行ボタンの有効判定
            this.CheckExecuteEnable();
        }

        /// <summary>
        /// 実行ボタンの有効・無効を判定する
        /// </summary>
        private void CheckExecuteEnable()
        {
            bool enable = true;

            if (String.IsNullOrEmpty(this.SourcePDF.Text))
            {
                this.SourcePDF.BackColor = Color.Pink;
                enable = false;
            }
            else
            {
                this.SourcePDF.BackColor = SystemColors.Window;
            }

            if (String.IsNullOrEmpty(this.ShopName.Text))
            {
                this.ShopName.BackColor = Color.Pink;
                enable = false;
            }
            else
            {
                this.ShopName.BackColor = SystemColors.Window;
            }

            if (String.IsNullOrEmpty(this.Price.Text))
            {
                this.Price.BackColor = Color.Pink;
                enable = false;
            }
            else
            {
                this.Price.BackColor = SystemColors.Window;
            }

            this.CopyExecute.Enabled = enable;
        }
    }
}
