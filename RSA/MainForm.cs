using RSA2;
using System.Numerics;
using System.Security.Cryptography;

namespace RSA
{
    public partial class MainForm : Form
    {
        ExampleRSA rsa = new ExampleRSA();

        public MainForm()
        {
            InitializeComponent();
            radioButtonEncrypt.Checked = true;
            rsa.GenKey();
        }

        private void buttonExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void buttonCopy_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(textBoxOutput.Text);
        }

        private void radioButtonEncrypt_CheckedChanged(object sender, EventArgs e)
        {
            labelInput.Text = "Enter the decrypted message:";
            labelOutput.Text = "Encrypted message:";
            buttonDecrypt.Enabled = false;
            buttonEncrypt.Enabled = true;
            textBoxInput.Text = string.Empty;
            textBoxOutput.Text = string.Empty;
        }

        private void radioButtonDecrypt_CheckedChanged(object sender, EventArgs e)
        {
            labelInput.Text = "Enter the encrypted message:";
            labelOutput.Text = "Decrypted message:";
            buttonDecrypt.Enabled = true;
            buttonEncrypt.Enabled = false;
            textBoxInput.Text = string.Empty;
            textBoxOutput.Text = string.Empty;
        }

        private async void buttonEncrypt_Click(object sender, EventArgs e)
        {
            textBoxOutput.Text = rsa.Encryption(textBoxInput.Text);
        }

        private async void buttonDecrypt_Click(object sender, EventArgs e)
        {
            textBoxOutput.Text = rsa.Decryption(textBoxInput.Text);
        }

        private void textBoxInput_TextChanged(object sender, EventArgs e)
        {

        }
    }
}