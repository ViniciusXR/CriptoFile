using System;
using System.Drawing;
using System.IO;
using System.Security.Cryptography;
using System.Windows.Forms;

namespace CriptoFile
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            Criptografia.cspp = new CspParameters();
            Criptografia.EncrFolder = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + @"\Encrypt\";
            Criptografia.DecrFolder = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + @"\Decrypt\";
            Criptografia.ScrFolder = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);

        }

        private void btnCryptoFile_Click(object sender, EventArgs e)
        {
            if (Criptografia.rsa == null)
            {
                lblResultado.ForeColor = Color.Red;
                lblResultado.Text = "A chave não foi definida";
            }
            else
            {
                //Mostra uma caixa de diálogo para escolher um arquivo para criptografar
                OpenFileDialog dialog = new OpenFileDialog();
                dialog.InitialDirectory = Criptografia.ScrFolder;
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    string fName = dialog.FileName;
                    FileInfo fInfo = new FileInfo(fName);
                    //Passa o nome do arquivo com o caminho
                    string name = fInfo.FullName;
                    lblResultado.Text =  Criptografia.EncryptFile(name);
                }
            }
        }

        private void btnDescryptoFile_Click(object sender, EventArgs e)
        {
            if (Criptografia.rsa == null)
            {
                lblResultado.ForeColor = Color.Red;
                lblResultado.Text = "A chave não foi definida";
            }
            else
            {
                //Mostra uma caixa de diálogo para escolher um arquivo para criptografar
                OpenFileDialog dialog = new OpenFileDialog();
                dialog.InitialDirectory = Criptografia.EncrFolder;
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    string fName = dialog.FileName;
                    FileInfo fInfo = new FileInfo(fName);
                    //Passa o nome do arquivo com o caminho
                    string name = fInfo.Name;
                    lblResultado.Text = Criptografia.DecryptFile(name);
                }
            }
        }

        private void btnCreateAsmKeys_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtKey.Text))
            {
                lblResultado.ForeColor = Color.Red;
                lblResultado.Text = "Insira um valor para definir a chave pública";
                txtKey.Focus();
                return;
            }

            Criptografia.keyName = txtKey.Text;
            lblResultado.ForeColor = Color.Blue;
            lblResultado.Text =  Criptografia.CreateASMKeys();
        }

        private void btnExportPublicKey_Click(object sender, EventArgs e)
        {
            if (Criptografia.ExportPublicKey())
            {
                lblResultado.ForeColor = Color.Blue;
                lblResultado.Text = "Chave pública exportada";
            }
            else
            {
                lblResultado.ForeColor = Color.Red;
                lblResultado.Text = "Chave pública não exportada";
            }
        }

        private void btnImporPublicKey_Click(object sender, EventArgs e)
        {
            Criptografia.keyName = "Publica";
            lblResultado.ForeColor = Color.Blue;
            lblResultado.Text =  Criptografia.ImportPublicKey();
        }

        private void btnGetPrivateKey_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtKey.Text))
            {
                lblResultado.ForeColor = Color.Red;
                lblResultado.Text = "Insira um valor para definir a chave privada";
                txtKey.Focus();
                return;
            }

            Criptografia.keyName = txtKey.Text;
            lblResultado.ForeColor = Color.Blue;
            lblResultado.Text =  Criptografia.GetPrivateKey();
        }
    }
}
