using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace _101Encryption
{
    public partial class MainFrm : Form
    {
        string[] table = new string[26];
        char[] charInput = new char[] { };

        public MainFrm()
        {
            InitializeComponent();
        }

        private void Encrypt()
        {
            int Key = 0;

            Key = int.Parse(txtKey.Text);

            foreach (char c in charInput)
            {
                if (c == ' ')
                {
                    txtOutput.Text += " ";
                }
                else
                {
                    for (int i = 0; i < 26; i++)
                    {
                        if (c.ToString() == table[i])
                        {
                            if ((i + Key) > 25)
                            {
                                txtOutput.Text += table[Key - 1];
                                break;
                            }
                            else
                            {
                                txtOutput.Text += table[i + Key];
                                break;
                            }
                        }
                    }
                }
            }
        }

        private void Decrypt()
        {
            int Key = 0;
            Key = int.Parse(txtKey.Text);

            foreach (char c in charInput)
            {
                if (c == ' ')
                {
                    txtOutput.Text += " ";
                }
                else
                {
                    for (int i = 0; i < 26; i++)
                    {
                        if (c.ToString() == table[i])
                        {

                            if (i + Key > 25)
                            {
                                int NewKey = Key - i;
                                txtOutput.Text += table[i - NewKey];
                            }
                            else
                            {
                                txtOutput.Text += table[i - Key];
                            }
                        }
                    }
                }
            }
        }

        private void MainFrm_Load(object sender, EventArgs e)
        {
            for (int i = 0; i < 26; i++)
            {
                table[i] = System.Text.Encoding.Default.GetString(new byte[1] { Convert.ToByte(i + 97) });
            }
        }

        private void btnEncrypt_Click(object sender, EventArgs e)
        {
            txtOutput.Text = "";

            charInput = txtInput.Text.ToCharArray();

            if (txtInput.Text == "" || txtKey.Text == "")
            {
                MessageBox.Show("Please enter some data and a Key to Encrypt.", "101Encryption - Error", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
            }
            else
            {
                Encrypt();
            }
        }

        private void btnDecrypt_Click(object sender, EventArgs e)
        {
            txtOutput.Text = "";

            charInput = txtInput.Text.ToCharArray();

            if (txtInput.Text == "" || txtKey.Text == "")
            {
                MessageBox.Show("Please enter some data and a Key to Decrypt.", "101Encryption - Error", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
            }
            else
            {
                Decrypt();
            }
        }

        private void btnCopy_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(txtOutput.Text);
        }
    }
}