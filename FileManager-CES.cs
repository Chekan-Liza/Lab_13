using System;
using System.Linq;
using System.IO;
using System.IO.Compression;

namespace Lab_13
{
    class FileManager_CES_
    {   static string dirName = "new";

        DirectoryInfo dirInfo = new DirectoryInfo(dirName);

        public void DisplayInfo()
        {
            if (Directory.Exists(dirName))
            {
                Console.WriteLine("Подкаталоги:");
                string[] dirs = Directory.GetDirectories(dirName);
                foreach (string s in dirs)
                {
                    Console.WriteLine(s);
                }
                Console.WriteLine();
                Console.WriteLine("Файлы:");
                string[] files = Directory.GetFiles(dirName);
                foreach (string s in files)
                {
                    Console.WriteLine(s);
                }
            }
        }

        public void CreateDir()
        {
            string path = @"D:\Study\ООП\Проекты C#\Lab_13\bin\Debug\new";
            string subpath = @"Inspect(CES)";
            DirectoryInfo dirInfo = new DirectoryInfo(path);
            if (!dirInfo.Exists)
            {
                dirInfo.Create();
            }
            dirInfo.CreateSubdirectory(subpath);
        }

        public void CreateFile()
        {
            string path = @"new\dirinfo(CES).txt";

            FileInfo file = new FileInfo(path);


            string dirName = "new";

            DirectoryInfo dirInfo = new DirectoryInfo(dirName);

            using (StreamWriter w = File.AppendText(path))
            {
                w.WriteLine("Название каталога: {0}", dirInfo.Name);
                w.WriteLine("Полное название каталога: {0}", dirInfo.FullName);
                w.WriteLine("Время создания каталога: {0}", dirInfo.CreationTime);
                w.WriteLine("Корневой каталог: {0}", dirInfo.Root);

                if (Directory.Exists(dirName))
                {
                    w.WriteLine("Количество подкаталогов: " + Directory.GetDirectories(dirName).Count());
                    w.WriteLine("Количество файлов:" + Directory.GetFiles(dirName).Count());
                }

                w.WriteLine();
            }
        }

        public void CopyFile()
        {
            string path = @"new\dirinfo(CES).txt";
            string newPath = @"new\_dirinfo(CES).txt";
            FileInfo fileInf = new FileInfo(path);
            if (fileInf.Exists)
            {
                fileInf.CopyTo(newPath, true);
            }
        }


        public void CreateDir_2()
        {
            string path = @"D:\Study\ООП\Проекты C#\Lab_13\bin\Debug\new";
            string subpath = @"Files(CES)";
            DirectoryInfo dirInfo = new DirectoryInfo(path);
            if (!dirInfo.Exists)
            {
                dirInfo.Create();
            }
            dirInfo.CreateSubdirectory(subpath);

            if (Directory.Exists("new"))
            {
                string[] files = Directory.GetFiles("new");

                foreach (var s in files)
                {
                    FileInfo info = new FileInfo(s);

                    if (info.Exists)
                    {
                        info.CopyTo(@"D:\Study\ООП\Проекты C#\Lab_13\bin\Debug\new\Files(CES)\" + info.Name, true);
                    }
                }
            }
        }

        public void MoveDir()
        {
            string oldPath = @"new\Files(CES)";
            string newPath = @"new\Inspect(CES)\Files(CES)";
            DirectoryInfo dirInfo = new DirectoryInfo(oldPath);
            if (dirInfo.Exists && Directory.Exists(newPath) == false)
            {
                dirInfo.MoveTo(newPath);
            }
        }

        private static string directoryPath = @"D:\Study\ООП\Проекты C#\Lab_13\bin\Debug\new\Files(CES)";

        public void Archive()
        {   string startPath = @"D:\Study\ООП\Проекты C#\Lab_13\bin\Debug\new\Files(CES)";
            string zipPath = @"D:\Study\ООП\Проекты C#\Lab_13\bin\Debug\new\Files(CES).zip";
            string extractPath = @"D:\Study\ООП\Проекты C#\Lab_13\bin\Debug\new\Files(CES)_W";

            File.Delete(zipPath);
            Directory.Delete(extractPath, true);

            ZipFile.CreateFromDirectory(startPath, zipPath);

            ZipFile.ExtractToDirectory(zipPath, extractPath);
        }
    }
}
