using System;
using System.Linq;
using DocIO_Test;
using System.IO;
using Rhino.Geometry;
using Rhino.FileIO;
using System.Diagnostics;

namespace DocIO_Example
{
    partial class Example
    {
        public static bool ConvertDwgToRhino(string FileDir, string OutPath)
        {
            //Check the file directory is a dwg file, if not return.
            if (!FileDir.Contains(".dwg"))
            {
                return false;
            }

            //Convert the file with the file directory string.
            var FileDoc = FileDocument.ConvertDWGto3dm(FileDir);

            Debug.WriteLine(FileDoc);

            //The Result shows the conversion process. If it's null or empty, the conversion failed.
            string Result = FileDoc.cmd;
            if (Result == null || Result.Length == 0) 
            {
                return false;
            }

            //Save a file into with an output string, OutPath
            //This is the first method to save rhino3dm file.
            using (FileIO fileIO = new FileIO(FileDoc, OutPath))
            {
                Debug.WriteLine(FileDoc);
                //Set file Name
                fileIO.FileName = "NewName";
                //Save as a new file
                fileIO.Write(FileDocument.FileType.Rhino);
            }

            //This is the second method to save rhino3dm file.
            //if (!FileIO.Write(FileDoc.RHFile))
            //    return false;
            return true;
        }
        [STAThread]
        public static void ConvertDwgToRhino()
        {
            //Set A Path, this program will open a dialog to select a file path
            string _Path = FileIO.OpenFileSelectionDialog();
            Console.WriteLine(_Path);
            // Path Convert to stream
            Stream StreamPath = FileIO.PathToStream(_Path);
            Console.WriteLine(StreamPath);
            //Stream convert to path
            FileIO.StreamToPath(StreamPath, out _Path);
            Console.WriteLine(_Path);

            //Convert file from DWG to Rhino
            var FileDoc = FileDocument.ConvertDWGto3dm(_Path);
            Console.WriteLine(FileDoc.cmd);

            //Save Directory Setting
            string Dir = FileIO.OpenFileSelectDirectory();

            //Save File
            using (FileIO fileIO = new FileIO(FileDoc, Dir))
            {
                //Set file Name
                fileIO.FileName = "NewName";
                //Save as a new file
                fileIO.Write(FileDocument.FileType.Rhino);
            }
            //Or this way Not recommanded
            //FileIO.Write(FileDoc.RHFile);
        }
        public static void Convert3dmTodxf()
        {
            //Set A Path
            string _Path = FileIO.OpenFileSelectionDialog();
            Console.WriteLine(_Path);
            if (!_Path.Contains("3dm")) return;
            //Select a save diretory
            var saveDir = FileIO.OpenFileSelectDirectory();

            //Convert 3dm to dxf
            var fileIO = new FileIO(FileDocument.Convert3dmtoDXF(_Path), saveDir);
            fileIO.Write(FileDocument.FileType.Dxf);
            Console.WriteLine(fileIO.Message);
        }
    }
}
