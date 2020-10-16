/**
 * Program Overflow 2.1 coded by Lumito.
 * (C) 2020, Lumito Luma.
 * Please use this tool responsibly.
 * I'm not responsible of any damage this tool can make to your PC.
 * Website: www.lumito.net
 */

using System;
using System.IO;
using System.Windows.Forms;

namespace ProgramOverflow
{
    public partial class Form1 : Form
    {
        byte counterRipPc, counterRunPrograms, ischk, ischk2, RunPrograms;
        short x;
        int i, ProgressBar1Value;

        public void CopyFiles()
        {
            button1.Enabled = false;
            button2.Enabled = false;
            richTextBox1.Clear();
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
                richTextBox1.AppendText("Copying Program" + i + ".exe...");
                try
                {
                    if (!File.Exists(destinationFile))
                    {
                        File.Copy(fullPath, destinationFile, true);
                    }
                    if (RunPrograms == 1)
                    {
                        richTextBox1.AppendText(" Done!\nRunning Program" + i + ".exe...");
                        System.Diagnostics.Process.Start(destinationFile);
                    }
                    richTextBox1.AppendText(" Done!\n");
                }
                catch
                {
                    richTextBox1.AppendText(" Error!\n-- Error while deleting files --");
                }
            }
            progressBar1.Value = progressBar1.Maximum;
            button1.Enabled = true;
            button2.Enabled = true;
            richTextBox1.AppendText("-- " + (i - 1) + " Files successfully copied! --");
        }

        public void CopyArg(int argnumber)
        {
            if (argnumber <= 999999)
            {
                if (!Directory.Exists("C:\\ProgramOverflow"))
                {
                    Directory.CreateDirectory("C:\\ProgramOverflow");
                }
                for (i = 1; i <= argnumber; i++)
                {
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
                MessageBox.Show("Copied " + argnumber.ToString() + " files correctly!", "Program Overflow 2.1");
                Environment.Exit(0);
            }
            else
            {
                MessageBox.Show("Please specify a number between 1 and 999999. 0 yields error", "Program Overflow 2.1");
                Environment.Exit(0);
            }
        }

        public static void Clean()
        {
            if (Directory.Exists("C:\\ProgramOverflow"))
            {
                string msg = "This will delete the whole C:\\ProgramOverflow directory.\nAre you sure that you want to continue?";
                string titlemsg = "Program Overflow 2.1";
                MessageBoxButtons buttons = MessageBoxButtons.YesNo;
                MessageBoxDefaultButton dbutton = MessageBoxDefaultButton.Button2;
                DialogResult result = MessageBox.Show(msg, titlemsg, buttons, MessageBoxIcon.Warning, dbutton);
                if (result == DialogResult.Yes)
                {
                    DirectoryInfo podir = new DirectoryInfo("C:\\ProgramOverflow");

                    int fc = 0;

                    foreach (FileInfo file in podir.EnumerateFiles())
                    {
                        file.Delete(); //Deletes all the files in C:\ProgramOverflow directory
                        fc++;
                    }
                    foreach (DirectoryInfo dir in podir.EnumerateDirectories())
                    {
                        dir.Delete(true); //Deletes all the directories in C:\ProgramOverflow directory
                    }
                    podir.Delete(); //Deletes C:\ProgramOverflow directory
                    if (fc == 1) //Checks if there was only a file in C:\ProgramOverflow directory
                    {
                        MessageBox.Show("1 file successfully cleaned!", "Program Overflow 2.1");
                    }
                    else
                    {
                        MessageBox.Show(fc + " files successfully cleaned!", "Program Overflow 2.1");
                    }
                }
                Environment.Exit(0); //Exits the program
            }
            else
            {
                MessageBox.Show("No need to clean", "Program Overflow 2.1");
                Environment.Exit(0);
            }
        }

        public Form1()
        {
            InitializeComponent();
            counterRipPc = 0;
            counterRunPrograms = 0;
            ischk = 0;
            ischk2 = 0;
            RunPrograms = 0;
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            CopyFiles();
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            int cno = 0;
            button1.Enabled = false;
            button2.Enabled = false;
            richTextBox1.Clear();
            progressBar1.Value = 0;
            if (Directory.Exists("C:\\ProgramOverflow"))
            {
                string msg = "This will delete the whole C:\\ProgramOverflow directory.\nAre you sure that you want to continue?";
                string titlemsg = "Program Overflow 2.1";
                MessageBoxButtons buttons = MessageBoxButtons.YesNo;
                MessageBoxDefaultButton dbutton = MessageBoxDefaultButton.Button2;
                DialogResult result = MessageBox.Show(msg, titlemsg, buttons, MessageBoxIcon.Warning, dbutton);
                if (result == DialogResult.Yes)
                {
                    DirectoryInfo podir = new DirectoryInfo("C:\\ProgramOverflow");
                    int fc = 0;
                    int nfiles = podir.GetFiles().Length;
                    progressBar1.Maximum = nfiles * 100;
                    ProgressBar1Value = progressBar1.Maximum / nfiles;
                    try
                    {
                        foreach (FileInfo file in podir.EnumerateFiles())
                        {
                            progressBar1.Value += ProgressBar1Value;
                            richTextBox1.AppendText("Deleting " + file + "...");
                            file.Delete(); //Deletes all the files in C:\ProgramOverflow directory
                            richTextBox1.AppendText(" Done!\n");
                            fc++;
                        }
                        foreach (DirectoryInfo dir in podir.EnumerateDirectories())
                        {
                            dir.Delete(true); //Deletes all the directories in C:\ProgramOverflow directory
                        }
                        podir.Delete(); //Deletes C:\ProgramOverflow directory
                        if (fc == 1) //Checks if there was only a file in C:\ProgramOverflow directory
                        {
                            richTextBox1.AppendText("-- 1 file successfully cleaned! -- ");
                        }
                        else
                        {
                            richTextBox1.AppendText("-- " + fc + " files successfully cleaned! --");
                        }
                    }
                    catch
                    {
                        richTextBox1.AppendText(" Error!\n-- Error while deleting files --");
                    }
                }
                else
                {
                    cno = 1;
                }
            }
            else
            {
                richTextBox1.AppendText("-- No need to clean --");
            }
            if(cno == 0)
            {
                progressBar1.Value = progressBar1.Maximum;
            }
            button1.Enabled = true;
            button2.Enabled = true;
        }

        private void RadioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (ischk == 0)
            {
                string msg = "Are you sure that you want to enable this feature?";
                string titlemsg = "Program Overflow 2.1";
                MessageBoxButtons buttons = MessageBoxButtons.YesNo;
                MessageBoxDefaultButton dbutton = MessageBoxDefaultButton.Button2;
                DialogResult result = MessageBox.Show(msg, titlemsg, buttons, MessageBoxIcon.Warning, dbutton);
                if (result == DialogResult.Yes)
                {
                    checkBox1.Enabled = true;
                    checkBox2.Enabled = true;
                }
                else
                {
                    ischk = 1;
                    radioButton1.Checked = false;
                }
            }
            else
            {
                ischk = 0;
            }
        }

        private void CheckBox1_CheckedChanged(object sender, EventArgs e)
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

        private void CheckBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (ischk2 == 0)
            {
                if (counterRunPrograms == 0)
                {
                    string msg = "This feature may DESTROY your PC.\nAre you highly sure that you want to enable it?";
                    string titlemsg = "Program Overflow 2.1";
                    MessageBoxButtons buttons = MessageBoxButtons.YesNo;
                    MessageBoxDefaultButton dbutton = MessageBoxDefaultButton.Button2;
                    DialogResult result = MessageBox.Show(msg, titlemsg, buttons, MessageBoxIcon.Stop, dbutton);
                    if (result == DialogResult.Yes)
                    {
                        RunPrograms = 1;
                        counterRunPrograms = 1;
                        button1.Text = "Destroy computer";
                        button1.ForeColor = System.Drawing.Color.Red;
                    }
                    else
                    {
                        ischk2 = 1;
                        checkBox2.Checked = false;
                    }
                }
                else
                {
                    RunPrograms = 0;
                    counterRunPrograms = 0;
                    button1.Text = "Start";
                    button1.ForeColor = System.Drawing.Color.Black;
                }
            }
            else
            {
                ischk2 = 0;
            }
        }

        private void Label7_Click(object sender, EventArgs e)
        {
            if (counterRipPc == 1 && x == 0)
            {
                x = 1;
            }
            else
            {
                x = 0;
            }
        }

        private void Label8_Click(object sender, EventArgs e)
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

        private void Label9_Click(object sender, EventArgs e)
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

        private void Label10_Click(object sender, EventArgs e)
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

        private void Form1_Load(object sender, EventArgs e)
        {
            string[] passedInArgs = Environment.GetCommandLineArgs();
            int argnumber;
            try
            {
                argnumber = int.Parse(passedInArgs[1]);
                try
                {
                    string IsSilent = passedInArgs[2];
                    if (IsSilent == "/S" || IsSilent == "/s" || IsSilent == "-S" || IsSilent == "-s"
                                    || IsSilent == "/Silent" || IsSilent == "/silent" || IsSilent == "/silent" || IsSilent == "-silent"
                                    || IsSilent == "--Silent" || IsSilent == "--silent" || IsSilent == "--S" || IsSilent == "--s")
                    {
                        if (argnumber <= 999999)
                        {
                            if (!Directory.Exists("C:\\ProgramOverflow"))
                            {
                                Directory.CreateDirectory("C:\\ProgramOverflow");
                            }
                            for (i = 1; i <= argnumber; i++)
                            {
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
                            Environment.Exit(0);
                        }
                        else
                        {
                            Environment.Exit(0);
                        }
                    }
                    else
                    {
                        CopyArg(argnumber);
                    }
                }
                catch
                {
                    CopyArg(argnumber);
                }
            }
            catch
            {
                try
                {
                    string argstring = passedInArgs[1];
                    if (argstring == "Clean" || argstring == "clean" || argstring == "/Clean" || argstring == "/clean"
                            || argstring == "-Clean" || argstring == "-clean" || argstring == "--Clean" || argstring == "--clean")
                    {
                        try
                        {
                            string IsSilent = passedInArgs[2];
                            if (IsSilent == "/S" || IsSilent == "/s" || IsSilent == "-S" || IsSilent == "-s"
                                        || IsSilent == "/Silent" || IsSilent == "/silent" || IsSilent == "/silent" || IsSilent == "-silent"
                                        || IsSilent == "--Silent" || IsSilent == "--silent" || IsSilent == "--S" || IsSilent == "--s")
                            {
                                if (Directory.Exists("C:\\ProgramOverflow"))
                                {
                                    DirectoryInfo podir = new DirectoryInfo("C:\\ProgramOverflow");
                                    foreach (FileInfo file in podir.EnumerateFiles())
                                    {
                                        file.Delete(); // Deletes all the files in C:\ProgramOverflow directory
                                    }
                                    foreach (DirectoryInfo dir in podir.EnumerateDirectories())
                                    {
                                        dir.Delete(true); // Deletes all the directories in C:\ProgramOverflow directory
                                    }
                                    podir.Delete(); // Deletes C:\ProgramOverflow directory
                                    Environment.Exit(0); // Exits the program
                                }
                                else
                                {
                                    Environment.Exit(0);
                                }
                            }
                            else
                            {
                                Clean();
                            }
                        }
                        catch
                        {
                            Clean();
                        }
                    }
                    else if (argstring == "Help" || argstring == "help" || argstring == "h" || argstring == "H"
                            || argstring == "/Help" || argstring == "/help" || argstring == "/h" || argstring == "/H"
                            || argstring == "-Help" || argstring == "-help" || argstring == "-h" || argstring == "-H"
                            || argstring == "--Help" || argstring == "--help" || argstring == "--h" || argstring == "--H")
                    {
                        var progname = System.Diagnostics.Process.GetCurrentProcess();
                        string programname = progname.ProcessName;
                        MessageBox.Show("Usage:\n\n" +
                                        "\"" + programname + ".exe [number of copies | /clean | /help] [/S]\"\n\n" +
                                        "Number of copies:\n" +
                                        "  If you don't specify a number of copies, the program will run normally.\n" +
                                        "  If number of copies isn't a number the program will start normally unless it's /help.\n" +
                                        "  The number of copies must be between 1 and 999999. 0 yields error.\n\n" +
                                        "/clean:\n" +
                                        "  Deletes all the files in C:\\ProgramOverflow directory.\n\n" +
                                        "/help:\n" +
                                        "  Shows this message.\n" +
                                        "  /S flag does not work with /help.\n\n" +
                                        "/S:\n" +
                                        "  Use this flag after \"Number of copies\" or \"/clean\".\n" +
                                        "  \"/S\" flag suppress any message that the program will show, so the execution is silent.\n\n" +
                                        "© 2020, Lumito - www.lumito.net", "Program Overflow 2.1");

                        Environment.Exit(0);
                    }
                }
                catch
                {
                    // Starts the app normally
                }  
            }
        }

        private void NumericUpDown1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                CopyFiles();
                e.SuppressKeyPress = true;
            }
        }
    }
}
