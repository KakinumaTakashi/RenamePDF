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
        private const string SHOPNAMELISTFILE = @"ShopNameList.txt";
        /// <summary>
        /// コピー元フォルダ
        /// </summary>
        private string SourceDirectory = "";
        /// <summary>
        /// コピー先フォルダ
        /// </summary>
        private string DestinationDirectory = "";
        /// <summary>
        /// 店名リスト
        /// </summary>
        private List<string> ShopNameList = new List<string>();
        /// <summary>
        /// サポートイメージリスト
        /// </summary>
        private List<string> SupportExtensionList = new List<string>()
        {
            ".PDF", ".JPEG", ".JPG"
        };


        /// <summary>
        /// 領収書コピー
        /// </summary>
        public Form1()
        {
            InitializeComponent();

            // 店名リストのロード
            this.LoadShopNameList();
            this.ShopName.Items.AddRange(this.ShopNameList.ToArray());
            // コピー先ファイル名の更新
            this.UpdateDestinationFilePath();
            // 実行ボタンの有効判定
            this.CheckExecuteEnable();
        }

        /// <summary>
        /// 店名リストをロードする
        /// </summary>
        void LoadShopNameList()
        {
            // 店名リストが無い場合は終了
            if (!File.Exists(SHOPNAMELISTFILE))
            {
                return;
            }

            // 店名リストをプルダウンリストに展開
            using (StreamReader reader = new StreamReader(SHOPNAMELISTFILE, Encoding.GetEncoding("shift_jis")))
            {
                while (!reader.EndOfStream)
                {
                    string line = reader.ReadLine();
                    if (String.IsNullOrEmpty(line)) continue;

                    this.ShopNameList.Add(line);
                }

                reader.Close();
            }
        }

        /// <summary>
        /// コピー元イメージ選択のクリックイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SelectSourceImage_Click(object sender, EventArgs e)
        {
            // ファイル選択ダイアログを表示
            using (OpenFileDialog dialog = new OpenFileDialog())
            {
                dialog.Filter = @"PDFファイル|*.pdf|JPEGファイル|*.jpeg;*.jpg";
                dialog.InitialDirectory = this.SourceDirectory;

                if (dialog.ShowDialog(this) == DialogResult.OK)
                {
                    this.SourceDirectory = Path.GetDirectoryName(dialog.FileName);

                    // イメージをロード
                    this.LoadImage(dialog.FileName);
                    // コピー先ファイル名の更新
                    this.UpdateDestinationFilePath();
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
            this.LoadImage(files[0]);
            // コピー先ファイル名の更新
            this.UpdateDestinationFilePath();
        }

        /// <summary>
        /// ファイルドロップ開始イベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form1_DragEnter(object sender, DragEventArgs e)
        {
            string[] files = (string[])e.Data.GetData(DataFormats.FileDrop, false);
            string extension = Path.GetExtension(files[0]).ToUpper();

            // サポートイメージ以外はドロップ無効
            if (!this.SupportExtensionList.Contains(extension))
            {
                e.Effect = DragDropEffects.None;
                return;
            }
            // ファイルのドロップのみ有効
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
        /// イメージをロードする
        /// </summary>
        /// <param name="filePath">イメージファイルパス</param>
        private void LoadImage(string filePath)
        {
            // ファイルパスを設定
            this.SourceImage.Text = filePath;

            string extension = Path.GetExtension(filePath).ToUpper();

            if (extension == ".JPEG" || extension == ".JPG")
            {
                this.ImagePreviewPanel.Visible = true;
                this.PDFPreview.Visible = false;

                // プレビューにイメージをロード
                this.ImagePreview.ImageLocation = filePath;
            }
            else if (extension == ".PDF")
            {
                this.ImagePreviewPanel.Visible = false;
                this.PDFPreview.Visible = true;

                // プレビューにPDFをロード
                this.PDFPreview.LoadFile(filePath);
            }
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
                dialog.InitialDirectory = this.DestinationDirectory;
                dialog.Filter = "Folder |.";
                dialog.ValidateNames = false;
                dialog.CheckFileExists = false;
                dialog.CheckPathExists = true;

                if (dialog.ShowDialog(this) == DialogResult.OK)
                {
                    // コピー先ディレクトリに選択したディレクトリを設定
                    this.DestinationDirectory = Path.GetDirectoryName(dialog.FileName);
                    // コピー先ファイル名の更新
                    this.UpdateDestinationFilePath();
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
            if (File.Exists(this.DestinationImage.Text))
            {
                MessageBox.Show("同名のファイルが既に存在します。", this.Text,
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                // コピー先へファイルをコピー
                File.Copy(this.SourceImage.Text, this.DestinationImage.Text);

                MessageBox.Show("コピーが完了しました。", this.Text,
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                // コピー元ファイルを削除
                if (this.DeleteCopiedFile.Checked)
                {
                    File.Delete(this.SourceImage.Text);
                }

                // 店名を追加
                this.SaveNewShopName();
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message, this.Text,
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// 未登録の店名をリストファイルに追加する
        /// </summary>
        private void SaveNewShopName()
        {
            // 登録チェック
            if (this.ShopNameList.Contains(this.ShopName.Text))
            {
                return;
            }
            // 店名リストに追加
            this.ShopNameList.Add(this.ShopName.Text);
            this.ShopName.Items.Add(this.ShopName.Text);
            // リストファイルへ出力
            File.AppendAllText(
                SHOPNAMELISTFILE,
                this.ShopName.Text + Environment.NewLine,
                Encoding.GetEncoding("shift_jis")
            );
        }

        /// <summary>
        /// 領収書コントロールのフォーカスアウトイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ReceiptControl_Leave(object sender, EventArgs e)
        {
            // コピー先ファイル名の更新
            this.UpdateDestinationFilePath();
        }

        /// <summary>
        /// コピー先ファイル名を更新する
        /// </summary>
        private void UpdateDestinationFilePath()
        {
            // 領収書コントロールからコピー先ファイル名を生成
            string[] fileNameParts = new string[3];
            fileNameParts[0] = this.PurchaseDate.Value.ToString("yyyy-MM-dd");
            fileNameParts[1] = this.ShopName.Text;
            fileNameParts[2] = this.Price.Text;

            string destFileName = String.Join("_", fileNameParts);

            if (!String.IsNullOrEmpty(this.Comment.Text))
            {
                destFileName += "_" + this.Comment.Text;
            }

            if (destFileName.Length > 0 && !String.IsNullOrEmpty(this.SourceImage.Text))
            {
                destFileName += Path.GetExtension(this.SourceImage.Text);
            }

            this.DestinationImage.Text = Path.Combine(this.DestinationDirectory, destFileName);
            // 実行ボタンの有効判定
            this.CheckExecuteEnable();
        }

        /// <summary>
        /// 実行ボタンの有効・無効を判定する
        /// </summary>
        private void CheckExecuteEnable()
        {
            bool enable = true;
            bool receiptGroupEnable = true;

            // コピー元
            if (String.IsNullOrEmpty(this.SourceImage.Text))
            {
                this.SourceImage.BackColor = Color.Pink;
                enable = false;
            }
            else
            {
                this.SourceImage.BackColor = SystemColors.Window;
            }
            // 店名
            if (String.IsNullOrEmpty(this.ShopName.Text))
            {
                this.ShopName.BackColor = Color.Pink;
                enable = false;
                receiptGroupEnable = false;
            }
            else
            {
                this.ShopName.BackColor = SystemColors.Window;
            }
            // 金額
            if (String.IsNullOrEmpty(this.Price.Text))
            {
                this.Price.BackColor = Color.Pink;
                enable = false;
                receiptGroupEnable = false;
            }
            else
            {
                this.Price.BackColor = SystemColors.Window;
            }
            // コピー先
            if (String.IsNullOrEmpty(this.DestinationDirectory) || !receiptGroupEnable)
            {
                this.DestinationImage.BackColor = Color.Pink;
                enable = false;
            }
            else
            {
                this.DestinationImage.BackColor = SystemColors.Window;
            }

            this.CopyExecute.Enabled = enable;
        }
    }
}
