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

namespace notepad_2_
{
    public partial class Form1 : Form
    {
        public int fontSize = 0;
        public System.Drawing.FontStyle fs = FontStyle.Regular;
        public string filename;
        public bool isFileChanged;

        public FontSettings fontSetts;
        public Form1()
        {
            InitializeComponent();

            Init();
        }

        public void Init()
        {
            filename = "";
            isFileChanged = false;
            UpdateTitle();
             
        }

        public void Create(object sender, EventArgs e)
        {
            SaveUnsavedFile();
            textBox1.Text = "";
            filename = "";
            isFileChanged = false;
            UpdateTitle();

        }

        public void Open(object sender, EventArgs e)
        {
            SaveUnsavedFile(); 
            openFileDialog1.FileName = "";
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    StreamReader sr = new StreamReader(openFileDialog1.FileName);
                    textBox1.Text = sr.ReadToEnd();
                    sr.Close();
                    filename = openFileDialog1.FileName;
                    isFileChanged = false; 
                }
                catch
                {
                    MessageBox.Show("Error");
                }
            }
            UpdateTitle();
        }

        public void SaveFile(string _filename)
        {
            if (_filename == "")
            {
                if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    _filename = saveFileDialog1.FileName;
                }
            }
            try
            {
                StreamWriter sw = new StreamWriter(_filename + ".txt");
                sw.Write(textBox1.Text);
                sw.Close();
                filename = _filename;
                isFileChanged = false;
            }
            catch
            {
                MessageBox.Show("Error!");
            }
            UpdateTitle();
        }

        public void Save(object sender, EventArgs e)
        {
            SaveFile(filename);
        }


        private void OnTextChanged(object sender, EventArgs e)
        {
            if(isFileChanged)
            {
                this.Text = this.Text.Replace("*", " ");
                isFileChanged = true;
                this.Text = "*" + this.Text;
            }
            
        }

        public void UpdateTitle()
        { 
            if(filename != "")
            {
                this.Text = filename + " - Блокнот";
            }
            else
            {
                this.Text = "Безымянный - Блокнот";
            }
            
        }

        public void SaveUnsavedFile()
        {
            if (isFileChanged)
            {
                DialogResult result = MessageBox.Show("Сохранить изменения в файле?", "Сохранение файла", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
                if (result == DialogResult.Yes)
                {
                    SaveFile(filename);
                     
                }
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }





        public void Copy()
        {
            Clipboard.SetText(textBox1.SelectedText);
        }

        public void Cut()
        {
            Clipboard.SetText(textBox1.SelectedText);
            textBox1.Text = textBox1.Text.Remove(textBox1.SelectionStart, textBox1.SelectionLength);
        }

        public void Paste()
        {
            textBox1.Text = textBox1.Text.Substring(0, textBox1.SelectionStart) + Clipboard.GetText() + textBox1.Text.Substring(textBox1.SelectionStart, textBox1.TextLength - textBox1.SelectionStart);
        }

        private void OnCopyText(object sender, EventArgs e)
        {
            Copy();
        }

        private void OnCutText(object sender, EventArgs e)
        {
            Cut();
        }

        private void OnPasteText(object sender, EventArgs e)
        {
            Paste();
        }

        private void ClosingSaved(object sender, FormClosingEventArgs e)
        {
            SaveUnsavedFile();
        }

        private void OnFont(object sender, EventArgs e)
        {
            fontSetts = new FontSettings();
            fontSetts.Show();
        }

        private void OnFocus(object sender, EventArgs e)
        {
            if (fontSetts!=null)
            {
                fontSize = fontSetts.fontSize;
                fs = fontSetts.fs;
                textBox1.Font = new Font(textBox1.Font.FontFamily, fontSize, fs);
                fontSetts.Close();
            }
        }
    }


    
    
}
