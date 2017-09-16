using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;

namespace Passwort_Generator_Gui_Csharp
{


    public partial class PasswortGeneraturMainWindow : Form
    {
        string password = "";
        string passwort;
        bool encryption;
        string fileName;
        string encrypted_data;
        string data;
        int a = 0;
        string fileName2;
        string text;
        int b;

        public PasswortGeneraturMainWindow()
        {
            InitializeComponent();






        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        public void button1_Click(object sender, EventArgs e)

        {
            label2.Text = "Dein Passwort Lautet";
            toolStripProgressBar1.Value = 0;

            if (textBox1.Text != "")
            {
                toolStripProgressBar1.Value = 10;
                int i = 0;
                i = int.Parse(textBox1.Text);

                passwort = passwortGenerator(i);
                toolStripProgressBar1.Value = 90;
                textBox2.Text = passwort;

                toolStripProgressBar1.Value = 100;
                toolStripStatusLabel1.Text = "Fertig";
            }
            else
            {
                string message = "Du musst eine Länge eingeben";
                string caption = "Error";
                MessageBoxButtons buttons = MessageBoxButtons.OK;
                DialogResult result;

                // Displays the MessageBox.

                result = MessageBox.Show(message, caption, buttons);


            }



        }
        public string passwortGenerator(int length)
        {

            //Variablen Konfiguartion
            Random rnd = new Random();
            int random;
            string pasword_strg;
            int state1 = 0;
            int x = 0;
            string passwort = "";
            int choice;
            StringBuilder password = null;
            char[] alpahbet = { 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z' };
            char[] alphabetGross = { 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M', 'N', 'O', 'P', 'Q', 'R', 'S', 'T', 'U', 'V', 'W', 'X', 'Y', 'Z' };
            char[] sonderzeichen = { '!', '$', '%', '&', '?', '#', '*', '+', '-', '/', '1', '2', '3', '4', '5', '6', '7', '8', '9', '0' };
            char[] zahlen = { '1', '2', '3', '4', '5', '6', '7', '8', '9', '0' };


            password = new StringBuilder(length);
            toolStripProgressBar1.Value = 50;

            //Test Output
            /*Console.WriteLine("String {0}",length);
            Console.WriteLine("Integer {0}" ,length_int);*/

            for (; x <= (length - 1); x++)
            {
                choice = 0;
                string x_strg = Convert.ToString(x);
                toolStripStatusLabel1.Text = "In Arbeit";
                choice = rnd.Next(0, 4);
                if (choice == 0)
                {
                    int randi = 0;
                    randi = rnd.Next(0, 9);
                    password.Append(Convert.ToString(randi));
                }
                else if (choice == 1)
                {

                    string wort = "";
                    int randp = (rnd.Next(alpahbet.Length));
                    wort = Convert.ToString(alpahbet[randp]);

                    password.Append(wort);
                }
                else if (choice == 2)
                {
                    string wort1 = "";
                    int rando = (rnd.Next(alphabetGross.Length));
                    wort1 = Convert.ToString(alphabetGross[rando]);

                    password.Append(wort1);
                }
                else if (choice == 3)
                {
                    string wort2 = "";
                    int randr = (rnd.Next(sonderzeichen.Length));
                    wort2 = Convert.ToString(sonderzeichen[randr]);
                    password.Append(wort2);
                }
                /*else if (choice == 4)
                {
                    string wort3 = "";
                    int randr = (rnd.Next(zahlen.Length));
                    wort3 = Convert.ToString(sonderzeichen[randr]);
                    password.Append(wort3);
                }*/
            }




            pasword_strg = Convert.ToString(password);
            toolStripProgressBar1.Value = 80;
            return pasword_strg;
        }






        private void PasswortGeneraturMainWindow_Load(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void menüToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        public void speichenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (passwort != null)
            {
                SaveFileDialog dlg = new SaveFileDialog();
                Stream myStream = null;
                //dlg.InitialDirectory = "c:\\";
                dlg.Filter = "PasswortGenerator files (*.pwg)|*.pwg|All files (*.*)|*.*";
                dlg.FilterIndex = 1;
                dlg.RestoreDirectory = true;

                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    password = textBox4.Text;
                    fileName = dlg.FileName;
                    string account = textBox3.Text;
                    data = account + " : " + passwort;

                    encrypted_data = StringCipher.Encrypt(passwort, password);

                    //System.IO.StreamWriter filew = new System.IO.StreamWriter(fileName);

                    if (!File.Exists(fileName))
                    {
                        File.WriteAllText(fileName, String.Empty);
                        using (StreamWriter sw = File.AppendText(fileName))
                        {


                            sw.WriteLine(account);
                            sw.WriteLine(encrypted_data);
                        }
                    }
                    else
                    {
                        System.IO.StreamReader file = new System.IO.StreamReader(fileName);
                        string acountline = file.ReadLine();
                        string passwordline = file.ReadLine();
                        file.Close();
                        File.Delete(fileName);



                        using (StreamWriter sw = File.AppendText(fileName))
                        {


                            sw.WriteLine(acountline + ";" + account);
                            sw.WriteLine(passwordline + ";" + encrypted_data);
                        }
                    }
                }
                

            }
            else
            {
                string message = "Du musst ein Passwort eingeben";
                string caption = "Error";
                MessageBoxButtons buttons = MessageBoxButtons.OK;
                DialogResult result;

                // Displays the MessageBox.

                result = MessageBox.Show(message, caption, buttons);


            }
        }




        private void beendenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(passwort);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (passwort != null)
            {
                SaveFileDialog dlg = new SaveFileDialog();
                Stream myStream = null;
                dlg.InitialDirectory = "c:\\";
                dlg.Filter = "PasswortGenerator files (*.pwg)|*.pwg|All files (*.*)|*.*";
                dlg.FilterIndex = 1;
                //dlg.RestoreDirectory = true;

                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    string fileName;
                    password = textBox4.Text;
                    fileName = dlg.FileName;
                    string account = textBox3.Text;
                    data = account + " : " + passwort;

                    encrypted_data = StringCipher.Encrypt(passwort, password);

                    //System.IO.StreamWriter filew = new System.IO.StreamWriter(fileName);

                    if (!File.Exists(fileName))
                    {

                        File.WriteAllText(fileName, String.Empty);
                        using (StreamWriter sw = File.AppendText(fileName))
                        {


                            sw.WriteLine(account);
                            sw.WriteLine(encrypted_data);
                        }
                    }
                    else
                    {
                        System.IO.StreamReader file = new System.IO.StreamReader(fileName);
                        string acountline = file.ReadLine();
                        string passwordline = file.ReadLine();
                        file.Close();

                        File.Delete(fileName);
                        using (StreamWriter sw = File.AppendText(fileName))
                        {


                            sw.WriteLine(acountline + ";" + account);
                            sw.WriteLine(passwordline + ";" + encrypted_data);

                            //sw.WriteLine();
                        }



                    }
                    
                }


            }
            else
            {
                string message = "Du musst ein Passwort eingeben";
                string caption = "Error";
                MessageBoxButtons buttons = MessageBoxButtons.OK;
                DialogResult result;

                // Displays the MessageBox.

                result = MessageBox.Show(message, caption, buttons);


            }

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void domainUpDown1_SelectedItemChanged(object sender, EventArgs e)
        {

        }

        private void toolStripProgressBar1_Click(object sender, EventArgs e)
        {

        }

        private void toolStripStatusLabel1_Click(object sender, EventArgs e)
        {

        }





        private void button5_Click(object sender, EventArgs e)
        {
            password = textBox4.Text;
            if (password.Length != 0)
            {

                try
                {
                    if (text != null)
                    {
                        string decryptedstring = StringCipher.Decrypt(text, password);
                        label2.Text = "Deine Entschlüsselten Daten lauten :";
                        textBox2.Text = decryptedstring;
                    }
                    else
                    {
                        string message = "Du musst ein Account auswählen";
                        string caption = "Error";
                        MessageBoxButtons buttons = MessageBoxButtons.OK;
                        DialogResult result;

                        // Displays the MessageBox.

                        result = MessageBox.Show(message, caption, buttons);
                    }
                }
                catch (Exception b)
                {
                    MessageBoxButtons buttons = MessageBoxButtons.OK;
                    DialogResult result;
                    result = MessageBox.Show("Das Passwort ist Falsch", "Error", buttons);

                }
            }
            else
            {
                string message = "Du musst ein Passwort eingeben";
                string caption = "Error";
                MessageBoxButtons buttons = MessageBoxButtons.OK;
                DialogResult result;

                // Displays the MessageBox.

                result = MessageBox.Show(message, caption, buttons);


            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();
            Stream myStream = null;
            dlg.InitialDirectory = "c:\\";
            dlg.Filter = "PasswortGenerator files (*.pwg)|*.pwg|All files (*.*)|*.*";
            dlg.FilterIndex = 1;
            //dlg.RestoreDirectory = true;

            if (dlg.ShowDialog() == DialogResult.OK)
            {
                fileName2 = dlg.FileName;
                StreamReader readFile = new StreamReader(fileName2);
                string line;
                string[] row1;

                line = readFile.ReadLine();

                row1 = line.Split(';');
                listBox1.Items.AddRange(row1);


                //More code and assignations here...

                readFile.Close();
            }
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            StreamReader readFile = new StreamReader(fileName2);
            string line;
            string[] row;
            readFile.ReadLine();
            //readFile.ReadLine();
            line = readFile.ReadLine();

            row = line.Split(';');
            //listBox1.Items.AddRange(row);
            //More code and assignations here...

            readFile.Close();
            b = listBox1.SelectedIndex;
            text = row[b];

        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
                e.Handled = true;
        }
    }

    public static class StringCipher
    {
        private const int DerivationIterations = 1000;
        private const int Keysize = 256;
        public static string Encrypt(string plainText, string passPhrase)
        {
            // Salt and IV is randomly generated each time, but is preprended to encrypted cipher text
            // so that the same Salt and IV values can be used when decrypting.  
            var saltStringBytes = Generate256BitsOfRandomEntropy();
            var ivStringBytes = Generate256BitsOfRandomEntropy();
            var plainTextBytes = Encoding.UTF8.GetBytes(plainText);
            using (var password = new Rfc2898DeriveBytes(passPhrase, saltStringBytes, DerivationIterations))
            {
                var keyBytes = password.GetBytes(Keysize / 8);
                using (var symmetricKey = new RijndaelManaged())
                {
                    symmetricKey.BlockSize = 256;
                    symmetricKey.Mode = CipherMode.CBC;
                    symmetricKey.Padding = PaddingMode.PKCS7;
                    using (var encryptor = symmetricKey.CreateEncryptor(keyBytes, ivStringBytes))
                    {
                        using (var memoryStream = new MemoryStream())
                        {
                            using (var cryptoStream = new CryptoStream(memoryStream, encryptor, CryptoStreamMode.Write))
                            {
                                cryptoStream.Write(plainTextBytes, 0, plainTextBytes.Length);
                                cryptoStream.FlushFinalBlock();
                                // Create the final bytes as a concatenation of the random salt bytes, the random iv bytes and the cipher bytes.
                                var cipherTextBytes = saltStringBytes;
                                cipherTextBytes = cipherTextBytes.Concat(ivStringBytes).ToArray();
                                cipherTextBytes = cipherTextBytes.Concat(memoryStream.ToArray()).ToArray();
                                memoryStream.Close();
                                cryptoStream.Close();
                                return Convert.ToBase64String(cipherTextBytes);
                            }
                        }
                    }
                }
            }
        }

        public static string Decrypt(string cipherText, string passPhrase)
        {
            // Get the complete stream of bytes that represent:
            // [32 bytes of Salt] + [32 bytes of IV] + [n bytes of CipherText]
            var cipherTextBytesWithSaltAndIv = Convert.FromBase64String(cipherText);
            // Get the saltbytes by extracting the first 32 bytes from the supplied cipherText bytes.
            var saltStringBytes = cipherTextBytesWithSaltAndIv.Take(Keysize / 8).ToArray();
            // Get the IV bytes by extracting the next 32 bytes from the supplied cipherText bytes.
            var ivStringBytes = cipherTextBytesWithSaltAndIv.Skip(Keysize / 8).Take(Keysize / 8).ToArray();
            // Get the actual cipher text bytes by removing the first 64 bytes from the cipherText string.
            var cipherTextBytes = cipherTextBytesWithSaltAndIv.Skip((Keysize / 8) * 2).Take(cipherTextBytesWithSaltAndIv.Length - ((Keysize / 8) * 2)).ToArray();

            using (var password = new Rfc2898DeriveBytes(passPhrase, saltStringBytes, DerivationIterations))
            {
                var keyBytes = password.GetBytes(Keysize / 8);
                using (var symmetricKey = new RijndaelManaged())
                {
                    symmetricKey.BlockSize = 256;
                    symmetricKey.Mode = CipherMode.CBC;
                    symmetricKey.Padding = PaddingMode.PKCS7;
                    using (var decryptor = symmetricKey.CreateDecryptor(keyBytes, ivStringBytes))
                    {
                        using (var memoryStream = new MemoryStream(cipherTextBytes))
                        {
                            using (var cryptoStream = new CryptoStream(memoryStream, decryptor, CryptoStreamMode.Read))
                            {
                                var plainTextBytes = new byte[cipherTextBytes.Length];
                                var decryptedByteCount = cryptoStream.Read(plainTextBytes, 0, plainTextBytes.Length);
                                memoryStream.Close();
                                cryptoStream.Close();
                                return Encoding.UTF8.GetString(plainTextBytes, 0, decryptedByteCount);
                            }
                        }
                    }
                }
            }
        }

        private static byte[] Generate256BitsOfRandomEntropy()
        {
            var randomBytes = new byte[32]; // 32 Bytes will give us 256 bits.
            using (var rngCsp = new RNGCryptoServiceProvider())
            {
                // Fill the array with cryptographically secure random bytes.
                rngCsp.GetBytes(randomBytes);
            }
            return randomBytes;
        }




    }
}




