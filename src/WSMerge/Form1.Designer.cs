namespace WSMerge
{
    partial class Form1
    {
        /// <summary>
        /// Variável de designer necessária.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpar os recursos que estão sendo usados.
        /// </summary>
        /// <param name="disposing">true se for necessário descartar os recursos gerenciados; caso contrário, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código gerado pelo Windows Form Designer

        /// <summary>
        /// Método necessário para suporte ao Designer - não modifique 
        /// o conteúdo deste método com o editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.openFileDlgSource = new System.Windows.Forms.OpenFileDialog();
            this.btnSelFiles = new System.Windows.Forms.Button();
            this.listViewSourceFiles = new System.Windows.Forms.ListView();
            this.btnClear = new System.Windows.Forms.Button();
            this.btnMerge = new System.Windows.Forms.Button();
            this.txtBxMergecap = new System.Windows.Forms.TextBox();
            this.lblMergecap = new System.Windows.Forms.Label();
            this.brnSelMergecap = new System.Windows.Forms.Button();
            this.saveFileDialMerged = new System.Windows.Forms.SaveFileDialog();
            this.openFileDialFindWS = new System.Windows.Forms.OpenFileDialog();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // openFileDlgSource
            // 
            this.openFileDlgSource.Filter = "Traffic Capture File|*.cap;*.cap.part|Todos os Arquivos|*.*";
            this.openFileDlgSource.Multiselect = true;
            this.openFileDlgSource.RestoreDirectory = true;
            this.openFileDlgSource.SupportMultiDottedExtensions = true;
            this.openFileDlgSource.FileOk += new System.ComponentModel.CancelEventHandler(this.OpenFileDlgSource_FileOk);
            // 
            // btnSelFiles
            // 
            this.btnSelFiles.Location = new System.Drawing.Point(12, 128);
            this.btnSelFiles.Name = "btnSelFiles";
            this.btnSelFiles.Size = new System.Drawing.Size(114, 23);
            this.btnSelFiles.TabIndex = 0;
            this.btnSelFiles.Text = "Selecionar Arquivos";
            this.btnSelFiles.UseVisualStyleBackColor = true;
            this.btnSelFiles.Click += new System.EventHandler(this.Button1_Click);
            // 
            // listViewSourceFiles
            // 
            this.listViewSourceFiles.AllowDrop = true;
            this.listViewSourceFiles.FullRowSelect = true;
            this.listViewSourceFiles.LabelWrap = false;
            this.listViewSourceFiles.Location = new System.Drawing.Point(12, 25);
            this.listViewSourceFiles.Name = "listViewSourceFiles";
            this.listViewSourceFiles.Size = new System.Drawing.Size(393, 97);
            this.listViewSourceFiles.TabIndex = 1;
            this.listViewSourceFiles.UseCompatibleStateImageBehavior = false;
            this.listViewSourceFiles.View = System.Windows.Forms.View.List;
            // 
            // btnClear
            // 
            this.btnClear.Location = new System.Drawing.Point(132, 128);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(75, 23);
            this.btnClear.TabIndex = 2;
            this.btnClear.Text = "Limpar";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.Btn_clear_Click);
            // 
            // btnMerge
            // 
            this.btnMerge.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMerge.Location = new System.Drawing.Point(12, 172);
            this.btnMerge.Name = "btnMerge";
            this.btnMerge.Size = new System.Drawing.Size(393, 43);
            this.btnMerge.TabIndex = 5;
            this.btnMerge.Text = "MERGE !";
            this.btnMerge.UseVisualStyleBackColor = true;
            this.btnMerge.Click += new System.EventHandler(this.BtnMerge_Click);
            // 
            // txtBxMergecap
            // 
            this.txtBxMergecap.Location = new System.Drawing.Point(12, 288);
            this.txtBxMergecap.Name = "txtBxMergecap";
            this.txtBxMergecap.Size = new System.Drawing.Size(393, 20);
            this.txtBxMergecap.TabIndex = 6;
            // 
            // lblMergecap
            // 
            this.lblMergecap.AutoSize = true;
            this.lblMergecap.Location = new System.Drawing.Point(15, 275);
            this.lblMergecap.Name = "lblMergecap";
            this.lblMergecap.Size = new System.Drawing.Size(324, 13);
            this.lblMergecap.TabIndex = 7;
            this.lblMergecap.Text = "Se necessário, ajuste o caminho do programa Wireshark Mergecap";
            // 
            // brnSelMergecap
            // 
            this.brnSelMergecap.Location = new System.Drawing.Point(12, 314);
            this.brnSelMergecap.Name = "brnSelMergecap";
            this.brnSelMergecap.Size = new System.Drawing.Size(75, 23);
            this.brnSelMergecap.TabIndex = 8;
            this.brnSelMergecap.Text = "Buscar";
            this.brnSelMergecap.UseVisualStyleBackColor = true;
            this.brnSelMergecap.Click += new System.EventHandler(this.BrnSelMergecap_Click);
            // 
            // saveFileDialMerged
            // 
            this.saveFileDialMerged.FileName = "merged.cap";
            this.saveFileDialMerged.Filter = "Traffic Capture File|*.cap";
            this.saveFileDialMerged.Title = "Salvar trace concatenado";
            // 
            // openFileDialFindWS
            // 
            this.openFileDialFindWS.FileName = "mergecap.exe";
            this.openFileDialFindWS.InitialDirectory = "C:\\Program Files\\Wireshark";
            this.openFileDialFindWS.ReadOnlyChecked = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(281, 333);
            this.label1.Name = "label1";
            this.label1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.label1.Size = new System.Drawing.Size(124, 13);
            this.label1.TabIndex = 9;
            this.label1.Text = "copyright @gugabguerra";
            this.label1.TextAlign = System.Drawing.ContentAlignment.BottomRight;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(416, 358);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.brnSelMergecap);
            this.Controls.Add(this.lblMergecap);
            this.Controls.Add(this.txtBxMergecap);
            this.Controls.Add(this.btnMerge);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.listViewSourceFiles);
            this.Controls.Add(this.btnSelFiles);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form1";
            this.Padding = new System.Windows.Forms.Padding(3);
            this.Text = "WSMerge 1.0.1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.OpenFileDialog openFileDlgSource;
        private System.Windows.Forms.Button btnSelFiles;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Button btnMerge;
        private System.Windows.Forms.TextBox txtBxMergecap;
        private System.Windows.Forms.Label lblMergecap;
        private System.Windows.Forms.Button brnSelMergecap;
        private System.Windows.Forms.SaveFileDialog saveFileDialMerged;
        private System.Windows.Forms.OpenFileDialog openFileDialFindWS;
        public System.Windows.Forms.ListView listViewSourceFiles;
        private System.Windows.Forms.Label label1;
    }
}

