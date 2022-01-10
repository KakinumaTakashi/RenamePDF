namespace RenamePDF
{
    partial class Form1
    {
        /// <summary>
        /// 必要なデザイナー変数です。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 使用中のリソースをすべてクリーンアップします。
        /// </summary>
        /// <param name="disposing">マネージド リソースを破棄する場合は true を指定し、その他の場合は false を指定します。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows フォーム デザイナーで生成されたコード

        /// <summary>
        /// デザイナー サポートに必要なメソッドです。このメソッドの内容を
        /// コード エディターで変更しないでください。
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.SourceImage = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.SelectSourceImage = new System.Windows.Forms.Button();
            this.ReceiptGroup = new System.Windows.Forms.GroupBox();
            this.Price = new System.Windows.Forms.TextBox();
            this.ShopName = new System.Windows.Forms.ComboBox();
            this.PurchaseDate = new System.Windows.Forms.DateTimePicker();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.DestinationImage = new System.Windows.Forms.TextBox();
            this.SelectDestinationDirectory = new System.Windows.Forms.Button();
            this.PDFPreviewGroup = new System.Windows.Forms.GroupBox();
            this.ImagePreviewPanel = new System.Windows.Forms.Panel();
            this.ImagePreview = new System.Windows.Forms.PictureBox();
            this.PDFPreview = new AxAcroPDFLib.AxAcroPDF();
            this.CopyExecute = new System.Windows.Forms.Button();
            this.DeleteCopiedFile = new System.Windows.Forms.CheckBox();
            this.label6 = new System.Windows.Forms.Label();
            this.Comment = new System.Windows.Forms.TextBox();
            this.ReceiptGroup.SuspendLayout();
            this.PDFPreviewGroup.SuspendLayout();
            this.ImagePreviewPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ImagePreview)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PDFPreview)).BeginInit();
            this.SuspendLayout();
            // 
            // SourceImage
            // 
            this.SourceImage.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.SourceImage.BackColor = System.Drawing.Color.Pink;
            this.SourceImage.Location = new System.Drawing.Point(69, 7);
            this.SourceImage.Name = "SourceImage";
            this.SourceImage.Size = new System.Drawing.Size(614, 19);
            this.SourceImage.TabIndex = 1;
            this.SourceImage.Leave += new System.EventHandler(this.ReceiptControl_Leave);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(50, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "コピー元：";
            // 
            // SelectSourceImage
            // 
            this.SelectSourceImage.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.SelectSourceImage.Location = new System.Drawing.Point(689, 5);
            this.SelectSourceImage.Name = "SelectSourceImage";
            this.SelectSourceImage.Size = new System.Drawing.Size(57, 23);
            this.SelectSourceImage.TabIndex = 2;
            this.SelectSourceImage.Text = "参照...";
            this.SelectSourceImage.UseVisualStyleBackColor = true;
            this.SelectSourceImage.Click += new System.EventHandler(this.SelectSourceImage_Click);
            // 
            // ReceiptGroup
            // 
            this.ReceiptGroup.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ReceiptGroup.Controls.Add(this.Comment);
            this.ReceiptGroup.Controls.Add(this.label6);
            this.ReceiptGroup.Controls.Add(this.Price);
            this.ReceiptGroup.Controls.Add(this.ShopName);
            this.ReceiptGroup.Controls.Add(this.PurchaseDate);
            this.ReceiptGroup.Controls.Add(this.label4);
            this.ReceiptGroup.Controls.Add(this.label3);
            this.ReceiptGroup.Controls.Add(this.label2);
            this.ReceiptGroup.Location = new System.Drawing.Point(12, 79);
            this.ReceiptGroup.Name = "ReceiptGroup";
            this.ReceiptGroup.Size = new System.Drawing.Size(860, 73);
            this.ReceiptGroup.TabIndex = 6;
            this.ReceiptGroup.TabStop = false;
            this.ReceiptGroup.Text = "領収書情報";
            // 
            // Price
            // 
            this.Price.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Price.BackColor = System.Drawing.Color.Pink;
            this.Price.Location = new System.Drawing.Point(691, 19);
            this.Price.Name = "Price";
            this.Price.Size = new System.Drawing.Size(163, 19);
            this.Price.TabIndex = 3;
            this.Price.Leave += new System.EventHandler(this.ReceiptControl_Leave);
            // 
            // ShopName
            // 
            this.ShopName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ShopName.BackColor = System.Drawing.Color.Pink;
            this.ShopName.FormattingEnabled = true;
            this.ShopName.Location = new System.Drawing.Point(224, 18);
            this.ShopName.Name = "ShopName";
            this.ShopName.Size = new System.Drawing.Size(426, 20);
            this.ShopName.TabIndex = 2;
            this.ShopName.Leave += new System.EventHandler(this.ReceiptControl_Leave);
            // 
            // PurchaseDate
            // 
            this.PurchaseDate.Location = new System.Drawing.Point(53, 18);
            this.PurchaseDate.Name = "PurchaseDate";
            this.PurchaseDate.Size = new System.Drawing.Size(130, 19);
            this.PurchaseDate.TabIndex = 1;
            this.PurchaseDate.Leave += new System.EventHandler(this.ReceiptControl_Leave);
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(656, 21);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(29, 12);
            this.label4.TabIndex = 0;
            this.label4.Text = "金額";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(189, 21);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(29, 12);
            this.label3.TabIndex = 0;
            this.label3.Text = "店名";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 23);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 12);
            this.label2.TabIndex = 0;
            this.label2.Text = "購入日";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 35);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(50, 12);
            this.label5.TabIndex = 0;
            this.label5.Text = "コピー先：";
            // 
            // DestinationImage
            // 
            this.DestinationImage.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.DestinationImage.BackColor = System.Drawing.Color.Pink;
            this.DestinationImage.Location = new System.Drawing.Point(69, 32);
            this.DestinationImage.Name = "DestinationImage";
            this.DestinationImage.ReadOnly = true;
            this.DestinationImage.Size = new System.Drawing.Size(614, 19);
            this.DestinationImage.TabIndex = 3;
            // 
            // SelectDestinationDirectory
            // 
            this.SelectDestinationDirectory.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.SelectDestinationDirectory.Location = new System.Drawing.Point(689, 30);
            this.SelectDestinationDirectory.Name = "SelectDestinationDirectory";
            this.SelectDestinationDirectory.Size = new System.Drawing.Size(57, 23);
            this.SelectDestinationDirectory.TabIndex = 4;
            this.SelectDestinationDirectory.Text = "参照...";
            this.SelectDestinationDirectory.UseVisualStyleBackColor = true;
            this.SelectDestinationDirectory.Click += new System.EventHandler(this.SelectDestinationDirectory_Click);
            // 
            // PDFPreviewGroup
            // 
            this.PDFPreviewGroup.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.PDFPreviewGroup.Controls.Add(this.ImagePreviewPanel);
            this.PDFPreviewGroup.Controls.Add(this.PDFPreview);
            this.PDFPreviewGroup.Location = new System.Drawing.Point(12, 158);
            this.PDFPreviewGroup.Name = "PDFPreviewGroup";
            this.PDFPreviewGroup.Size = new System.Drawing.Size(860, 591);
            this.PDFPreviewGroup.TabIndex = 0;
            this.PDFPreviewGroup.TabStop = false;
            this.PDFPreviewGroup.Text = "プレビュー";
            // 
            // ImagePreviewPanel
            // 
            this.ImagePreviewPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ImagePreviewPanel.AutoScroll = true;
            this.ImagePreviewPanel.Controls.Add(this.ImagePreview);
            this.ImagePreviewPanel.Location = new System.Drawing.Point(6, 18);
            this.ImagePreviewPanel.Name = "ImagePreviewPanel";
            this.ImagePreviewPanel.Size = new System.Drawing.Size(848, 567);
            this.ImagePreviewPanel.TabIndex = 0;
            // 
            // ImagePreview
            // 
            this.ImagePreview.Location = new System.Drawing.Point(0, 0);
            this.ImagePreview.Name = "ImagePreview";
            this.ImagePreview.Size = new System.Drawing.Size(509, 392);
            this.ImagePreview.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.ImagePreview.TabIndex = 1;
            this.ImagePreview.TabStop = false;
            // 
            // PDFPreview
            // 
            this.PDFPreview.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.PDFPreview.Enabled = true;
            this.PDFPreview.Location = new System.Drawing.Point(6, 18);
            this.PDFPreview.Name = "PDFPreview";
            this.PDFPreview.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("PDFPreview.OcxState")));
            this.PDFPreview.Size = new System.Drawing.Size(848, 567);
            this.PDFPreview.TabIndex = 0;
            // 
            // CopyExecute
            // 
            this.CopyExecute.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.CopyExecute.BackColor = System.Drawing.SystemColors.Control;
            this.CopyExecute.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.CopyExecute.ForeColor = System.Drawing.SystemColors.ControlText;
            this.CopyExecute.Location = new System.Drawing.Point(752, 5);
            this.CopyExecute.Name = "CopyExecute";
            this.CopyExecute.Size = new System.Drawing.Size(120, 48);
            this.CopyExecute.TabIndex = 7;
            this.CopyExecute.Text = "コピー実行";
            this.CopyExecute.UseVisualStyleBackColor = false;
            this.CopyExecute.Click += new System.EventHandler(this.CopyExecute_Click);
            // 
            // DeleteCopiedFile
            // 
            this.DeleteCopiedFile.AutoSize = true;
            this.DeleteCopiedFile.Location = new System.Drawing.Point(643, 59);
            this.DeleteCopiedFile.Name = "DeleteCopiedFile";
            this.DeleteCopiedFile.Size = new System.Drawing.Size(229, 16);
            this.DeleteCopiedFile.TabIndex = 5;
            this.DeleteCopiedFile.Text = "コピー完了後にコピー元ファイルを削除する。";
            this.DeleteCopiedFile.UseVisualStyleBackColor = true;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 46);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(29, 12);
            this.label6.TabIndex = 0;
            this.label6.Text = "補足";
            // 
            // Comment
            // 
            this.Comment.Location = new System.Drawing.Point(53, 43);
            this.Comment.Name = "Comment";
            this.Comment.Size = new System.Drawing.Size(801, 19);
            this.Comment.TabIndex = 4;
            this.Comment.Leave += new System.EventHandler(this.ReceiptControl_Leave);
            // 
            // Form1
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(884, 761);
            this.Controls.Add(this.DeleteCopiedFile);
            this.Controls.Add(this.CopyExecute);
            this.Controls.Add(this.SelectDestinationDirectory);
            this.Controls.Add(this.DestinationImage);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.ReceiptGroup);
            this.Controls.Add(this.SelectSourceImage);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.SourceImage);
            this.Controls.Add(this.PDFPreviewGroup);
            this.MinimumSize = new System.Drawing.Size(900, 800);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "領収書コピー";
            this.DragDrop += new System.Windows.Forms.DragEventHandler(this.Form1_DragDrop);
            this.DragEnter += new System.Windows.Forms.DragEventHandler(this.Form1_DragEnter);
            this.ReceiptGroup.ResumeLayout(false);
            this.ReceiptGroup.PerformLayout();
            this.PDFPreviewGroup.ResumeLayout(false);
            this.ImagePreviewPanel.ResumeLayout(false);
            this.ImagePreviewPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ImagePreview)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PDFPreview)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox SourceImage;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button SelectSourceImage;
        private System.Windows.Forms.GroupBox ReceiptGroup;
        private System.Windows.Forms.TextBox Price;
        private System.Windows.Forms.ComboBox ShopName;
        private System.Windows.Forms.DateTimePicker PurchaseDate;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox DestinationImage;
        private System.Windows.Forms.Button SelectDestinationDirectory;
        private System.Windows.Forms.GroupBox PDFPreviewGroup;
        private AxAcroPDFLib.AxAcroPDF PDFPreview;
        private System.Windows.Forms.Button CopyExecute;
        private System.Windows.Forms.CheckBox DeleteCopiedFile;
        private System.Windows.Forms.PictureBox ImagePreview;
        private System.Windows.Forms.Panel ImagePreviewPanel;
        private System.Windows.Forms.TextBox Comment;
        private System.Windows.Forms.Label label6;
    }
}

