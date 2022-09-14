namespace CriptoFile
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
            this.lblResultado = new System.Windows.Forms.Label();
            this.txtKey = new System.Windows.Forms.TextBox();
            this.btnCryptoFile = new System.Windows.Forms.Button();
            this.btnDescryptoFile = new System.Windows.Forms.Button();
            this.btnCreateAsmKeys = new System.Windows.Forms.Button();
            this.btnExportPublicKey = new System.Windows.Forms.Button();
            this.btnImporPublicKey = new System.Windows.Forms.Button();
            this.btnGetPrivateKey = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblResultado
            // 
            this.lblResultado.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblResultado.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblResultado.Location = new System.Drawing.Point(13, 13);
            this.lblResultado.Name = "lblResultado";
            this.lblResultado.Size = new System.Drawing.Size(659, 115);
            this.lblResultado.TabIndex = 0;
            this.lblResultado.Text = "Chave não definida";
            this.lblResultado.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtKey
            // 
            this.txtKey.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtKey.Location = new System.Drawing.Point(217, 154);
            this.txtKey.Name = "txtKey";
            this.txtKey.Size = new System.Drawing.Size(250, 29);
            this.txtKey.TabIndex = 1;
            // 
            // btnCryptoFile
            // 
            this.btnCryptoFile.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCryptoFile.Location = new System.Drawing.Point(27, 206);
            this.btnCryptoFile.Name = "btnCryptoFile";
            this.btnCryptoFile.Size = new System.Drawing.Size(206, 72);
            this.btnCryptoFile.TabIndex = 2;
            this.btnCryptoFile.Text = "Criptografar arquivo";
            this.btnCryptoFile.UseVisualStyleBackColor = true;
            this.btnCryptoFile.Click += new System.EventHandler(this.btnCryptoFile_Click);
            // 
            // btnDescryptoFile
            // 
            this.btnDescryptoFile.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDescryptoFile.Location = new System.Drawing.Point(239, 206);
            this.btnDescryptoFile.Name = "btnDescryptoFile";
            this.btnDescryptoFile.Size = new System.Drawing.Size(206, 72);
            this.btnDescryptoFile.TabIndex = 3;
            this.btnDescryptoFile.Text = "Descriptografar arquivo";
            this.btnDescryptoFile.UseVisualStyleBackColor = true;
            this.btnDescryptoFile.Click += new System.EventHandler(this.btnDescryptoFile_Click);
            // 
            // btnCreateAsmKeys
            // 
            this.btnCreateAsmKeys.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCreateAsmKeys.Location = new System.Drawing.Point(451, 206);
            this.btnCreateAsmKeys.Name = "btnCreateAsmKeys";
            this.btnCreateAsmKeys.Size = new System.Drawing.Size(206, 72);
            this.btnCreateAsmKeys.TabIndex = 4;
            this.btnCreateAsmKeys.Text = "Criar chaves";
            this.btnCreateAsmKeys.UseVisualStyleBackColor = true;
            this.btnCreateAsmKeys.Click += new System.EventHandler(this.btnCreateAsmKeys_Click);
            // 
            // btnExportPublicKey
            // 
            this.btnExportPublicKey.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExportPublicKey.Location = new System.Drawing.Point(27, 284);
            this.btnExportPublicKey.Name = "btnExportPublicKey";
            this.btnExportPublicKey.Size = new System.Drawing.Size(206, 72);
            this.btnExportPublicKey.TabIndex = 5;
            this.btnExportPublicKey.Text = "Exportar chave pública";
            this.btnExportPublicKey.UseVisualStyleBackColor = true;
            this.btnExportPublicKey.Click += new System.EventHandler(this.btnExportPublicKey_Click);
            // 
            // btnImporPublicKey
            // 
            this.btnImporPublicKey.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnImporPublicKey.Location = new System.Drawing.Point(239, 284);
            this.btnImporPublicKey.Name = "btnImporPublicKey";
            this.btnImporPublicKey.Size = new System.Drawing.Size(206, 72);
            this.btnImporPublicKey.TabIndex = 6;
            this.btnImporPublicKey.Text = "Importar chave pública";
            this.btnImporPublicKey.UseVisualStyleBackColor = true;
            this.btnImporPublicKey.Click += new System.EventHandler(this.btnImporPublicKey_Click);
            // 
            // btnGetPrivateKey
            // 
            this.btnGetPrivateKey.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGetPrivateKey.Location = new System.Drawing.Point(451, 284);
            this.btnGetPrivateKey.Name = "btnGetPrivateKey";
            this.btnGetPrivateKey.Size = new System.Drawing.Size(206, 72);
            this.btnGetPrivateKey.TabIndex = 7;
            this.btnGetPrivateKey.Text = "Obter chave privada";
            this.btnGetPrivateKey.UseVisualStyleBackColor = true;
            this.btnGetPrivateKey.Click += new System.EventHandler(this.btnGetPrivateKey_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(684, 376);
            this.Controls.Add(this.btnGetPrivateKey);
            this.Controls.Add(this.btnImporPublicKey);
            this.Controls.Add(this.btnExportPublicKey);
            this.Controls.Add(this.btnCreateAsmKeys);
            this.Controls.Add(this.btnDescryptoFile);
            this.Controls.Add(this.btnCryptoFile);
            this.Controls.Add(this.txtKey);
            this.Controls.Add(this.lblResultado);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Criptografar Arquivos";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblResultado;
        private System.Windows.Forms.TextBox txtKey;
        private System.Windows.Forms.Button btnCryptoFile;
        private System.Windows.Forms.Button btnDescryptoFile;
        private System.Windows.Forms.Button btnCreateAsmKeys;
        private System.Windows.Forms.Button btnExportPublicKey;
        private System.Windows.Forms.Button btnImporPublicKey;
        private System.Windows.Forms.Button btnGetPrivateKey;
    }
}

