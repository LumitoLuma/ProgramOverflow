using System.IO;
using System.Windows.Forms;

namespace ProgramOverflow
{
    public partial class Form1 : Form
    {
        byte counterRipPc;
        byte counterRunPrograms;
        byte RunPrograms;
        short x;
        int i;
        int ProgressBar1Value;

        public Form1()
        {
            InitializeComponent();
            counterRipPc = 0;
            counterRunPrograms = 0;
            RunPrograms = 0;
        }

        private void Button1_Click(object sender, System.EventArgs e)
        {
            button1.Enabled = false;
            progressBar1.Value = 0;
            string domainupdowntext = numericUpDown1.Text;
            int NumberOfCopies = int.Parse(domainupdowntext);
            if (!Directory.Exists("C:\\ProgramOverflow"))
            {
                Directory.CreateDirectory("C:\\ProgramOverflow");
            }
            progressBar1.Maximum = NumberOfCopies * 100;
            ProgressBar1Value = progressBar1.Maximum / NumberOfCopies;
            for (i = 1; i <= NumberOfCopies; i++)
            {
                progressBar1.Value += ProgressBar1Value;
                string destinationFile = "C:\\ProgramOverflow\\Program" + i + ".exe";
                var process = System.Diagnostics.Process.GetCurrentProcess();
                string fullPath = process.MainModule.FileName;
                if (!File.Exists(destinationFile))
                {
                    File.Copy(fullPath, destinationFile, true);
                }
                if (RunPrograms == 1)
                {
                    System.Diagnostics.Process.Start(destinationFile);
                }
            }
            progressBar1.Value = progressBar1.Maximum;
            button1.Enabled = true;
            label1.Text = "Done!!!";
        }

        private void RadioButton1_CheckedChanged(object sender, System.EventArgs e)
        {
                checkBox1.Enabled = true;
                checkBox2.Enabled = true;
        }

        private void CheckBox1_CheckedChanged(object sender, System.EventArgs e)
        {
            if (counterRipPc == 0)
            {
                numericUpDown1.Maximum = 999999;
                label6.Text = "Nº of copies: (Max 999999)";
                counterRipPc = 1;
            }
            else
            {
                numericUpDown1.Maximum = 9999;
                label6.Text = "Nº of copies: (Max 9999)";
                label10.Text = " ";
                counterRipPc = 0;
            }
        }

        private void CheckBox2_CheckedChanged(object sender, System.EventArgs e)
        {
            if (counterRunPrograms == 0)
            {
                RunPrograms = 1;
                counterRunPrograms = 1;
                button1.Text = "Destroy computer";
            }
            else
            {
                RunPrograms = 0;
                counterRunPrograms = 0;
                button1.Text = "Start";
            }
        }

        private void Label7_Click(object sender, System.EventArgs e)
        {
            if(counterRipPc == 1 && x == 0)
            {
                x = 1;
            }
            else
            {
                x = 0;
            }
        }

        private void Label8_Click(object sender, System.EventArgs e)
        {
            if (x == 1)
            {
                x = 2;
            }
            else
            {
                x = 0;
            }
        }

        private void Label9_Click(object sender, System.EventArgs e)
        {
            if (x == 2)
            {
                x = 3;
            }
            else
            {
                x = 0;
            }
        }

        private void Label10_Click(object sender, System.EventArgs e)
        {
            if (x == 3)
            {
                x = 0;
                numericUpDown1.Maximum = 9999999;
                label6.Text = "Nº of copies: (Max 9999999)";
                label10.Text = "Enjoy!";
            }
            else
            {
                x = 0;
            }
        }
    }
}