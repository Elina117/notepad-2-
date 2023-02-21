using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace notepad_2_
{
    public partial class FontSettings : Form
    {
        public int fontSize = 0;
        public System.Drawing.FontStyle fs = FontStyle.Regular;
        public FontSettings()
        {
            InitializeComponent();
            fontBox.SelectedItem = fontBox.Items[0];
            styleBox.SelectedItem = styleBox.Items[0];
        }

       

       

        private void FontChange(object sender, EventArgs e)
        {
            ExampleLabel.Font = new Font(ExampleLabel.Font.FontFamily, int.Parse(fontBox.SelectedItem.ToString()), ExampleLabel.Font.Style);
            fontSize = int.Parse(fontBox.SelectedItem.ToString());
        }


        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void FontSettings_Load(object sender, EventArgs e)
        {

        }

        private void OnStyle(object sender, EventArgs e)
        {
            switch (styleBox.SelectedItem.ToString())
            {
                case "обычный":
                    {
                        ExampleLabel.Font = new Font(ExampleLabel.Font.FontFamily, int.Parse(fontBox.SelectedItem.ToString()), FontStyle.Regular);
                    }
                    break;
                case "курсив":
                    {
                        ExampleLabel.Font = new Font(ExampleLabel.Font.FontFamily, int.Parse(fontBox.SelectedItem.ToString()), FontStyle.Italic);
                    }
                    break;
                case "полужирный":
                    {
                        ExampleLabel.Font = new Font(ExampleLabel.Font.FontFamily, int.Parse(fontBox.SelectedItem.ToString()), FontStyle.Bold);
                    }
                    break;
                case "подчеркнутый":
                    {
                        ExampleLabel.Font = new Font(ExampleLabel.Font.FontFamily, int.Parse(fontBox.SelectedItem.ToString()), FontStyle.Underline);
                    }
                    break;
                case "зачеркнутый":
                    {
                        ExampleLabel.Font = new Font(ExampleLabel.Font.FontFamily, int.Parse(fontBox.SelectedItem.ToString()), FontStyle.Strikeout);
                    }
                    break;
            }

            fs = ExampleLabel.Font.Style;
               
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }
    }
}
