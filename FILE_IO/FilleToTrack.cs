using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FILE_IO
{
    static class FilleToTrack
    {
        public static string Path;
        public static List<string> FileText;

        public static void GetFilePath()
        {
            OpenFileDialog openFile = new OpenFileDialog();
            
            if (openFile.ShowDialog() == DialogResult.OK)
            {
                Path = openFile.FileName;
            }
            else
            {
                throw new InvalidOperationException("Please give me a correct path.");

            }
            
        }

        public static void GetTextFileText(string path)
        {
            List<string> lines = File.ReadAllLines(path).ToList();
            //return lines;
            foreach (var line in lines)
            {
                MessageBox.Show(line);
            }

            FileText = lines;
        }

        public static void ClearTextFile(string path)
        {
            File.Create(path).Close();
        }
    }
}
