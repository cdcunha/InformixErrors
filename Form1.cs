using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace InformixErrors
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Match match = Regex.Match(InformixErrors.Properties.Resources.erros, @"(\-?\d+)\t");
            int count = 0;
            richTextBox1.Text = "";
            while (match.Success)
            {
                if (match.Groups[1].ToString() == textBox1.Text)
                {
                    int ind1 = InformixErrors.Properties.Resources.erros.IndexOf(match.ToString());
                    int ind2 = InformixErrors.Properties.Resources.erros.IndexOf(match.NextMatch().ToString());
                    if (ind2 < ind1)
                    {
                        ind2 = InformixErrors.Properties.Resources.erros.IndexOf("©") -11;
                    }
                    richTextBox1.Text = InformixErrors.Properties.Resources.erros.Substring(ind1, ind2-ind1);
                    count++;
                    break;
                }
                
                match = match.NextMatch();
            }
            if (count == 0)
                MessageBox.Show("Error code not found!");
        }

        private void textBox1_KeyUp(object sender, KeyEventArgs e)
        {
            if ((e.KeyCode) == Keys.Enter)
            {
                if (textBox1.Text != "")
                    button1_Click(sender, e);
            }
        }
    }
}
