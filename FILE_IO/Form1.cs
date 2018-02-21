using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace FILE_IO
{
    public partial class Form1 : Form
    {
        Stream currStream = null;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            MessageBox.Show("Alex Ramirez" + "\n" + "Assignment: FILE IO " + "\n" + "CPW 212 Advanved .NET");
        }

        private void btnImport_Click(object sender, EventArgs e)
        {
            FilleToTrack.GetFilePath();
            FilleToTrack.GetTextFileText(FilleToTrack.Path);
        }

        private void btnEncrypt_Click(object sender, EventArgs e)
        {
            if (FilleToTrack.Path != null)
            {
                FilleToTrack.ClearTextFile(FilleToTrack.Path);
                StreamWriter writer = new StreamWriter(FilleToTrack.Path);
                foreach (var VARIABLE in FilleToTrack.FileText)
                {
                    string currLine = Encryption__.Encrypt(VARIABLE);


                        writer.WriteLine(currLine);

                }
                writer.Close();
                FilleToTrack.GetTextFileText(FilleToTrack.Path);
            }
            else
            {
                MessageBox.Show("Please import a file first jack ass.");
            }
            
        }
        private void btnDecrypt_Click(object sender, EventArgs e)
        {
            if (FilleToTrack.Path != null)
            {
                FilleToTrack.ClearTextFile(FilleToTrack.Path);
                StreamWriter writer = new StreamWriter(FilleToTrack.Path);
                foreach (var VARIABLE in FilleToTrack.FileText)
                {
                    string currLine = Encryption__.Decrypt(VARIABLE);
        
                        writer.WriteLine(currLine);
                }
                writer.Close();
            }
            else
            {
                MessageBox.Show("Please import a file first jack ass.");
            }
        }

        private void btnExport_Click(object sender, EventArgs e)
        {

            FilleToTrack.GetTextFileText(FilleToTrack.Path);
            
            
        }
    }
}
