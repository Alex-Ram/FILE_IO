using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FILE_IO
{
    static class FilleToTrack
    {
        public static string Path;
        public static List<string> FileText;
        public static string NewFilePath;

        public static void GetFilePath()
        {
            OpenFileDialog openFile = new OpenFileDialog();
            openFile.Filter = "Text|*.txt||*.*";

            if (openFile.ShowDialog() == DialogResult.OK)
            {
                Path = openFile.FileName;
            }
            else
            {

                MessageBox.Show("Please give me a correct path.");
                //throw new InvalidOperationException("Please give me a correct path.");

            }
            
        }
        public static void GetNewFilePath()
        {
            FolderBrowserDialog openFolder = new FolderBrowserDialog();

            if (openFolder.ShowDialog() == DialogResult.OK)
            {
                NewFilePath = openFolder.SelectedPath;
                MessageBox.Show(NewFilePath);
            }
            else
            {
                MessageBox.Show("Please give me a correct path.");
                //throw new InvalidOperationException("Please give me a correct path.");

            }

        }

        public static void GetTextFileText(string path)
        {
            if (!string.IsNullOrWhiteSpace(path))
            {
                List<string> lines = File.ReadAllLines(path).ToList();
                //return lines;


                FileText = lines;
            }
            else
            {
                MessageBox.Show("Please Select a path");
            }

        }

        public static void ClearTextFile(string path)
        {
            File.Create(path).Close();
        }


        public static void CopyFile(string fileName)
        {
            if (FileText != null && !(String.IsNullOrWhiteSpace(fileName)))
            {
                GetNewFilePath();

                if (!File.Exists(NewFilePath + $"\\{fileName}.txt"))
                {

                    

                    using (StreamWriter writer = File.CreateText(NewFilePath + $"\\{fileName}.txt"))
                    {
                        foreach (var VARIABLE in FileText)
                        {
                            writer.WriteLine(VARIABLE);
                        }
                    }
                }
                else
                {
                    MessageBox.Show("File already exists please select another name");
                }
            }
            else
            {
                MessageBox.Show("Please Import a text file first and give it a name.");
            }

        }


        //end class
    }
}
