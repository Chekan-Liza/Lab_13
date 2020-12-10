using System;
using System.IO;

namespace Lab_13
{
    class Log_CES_
    {   public static string path = @"D:\Study\ООП\Проекты C#\Lab_13\bin\Debug\logfile(ces).txt";//Путь к текст. файлу, с кот. будет проведена работа

        public void OnChanged(object source, FileSystemEventArgs e)//Предоставляет данные для событий каталога: Changed, Created, Deleted.
        {
            // Указ., что делается при изменении, создании или удалении файла.
            Console.WriteLine("File: " + e.FullPath + " " + e.ChangeType + ": " + DateTime.Now);

            using (StreamWriter w = File.AppendText(path))//Созд. объект S-W, доб. текст с код. UTF-8 в сущ. файл, или в нов. файл, если указ. файл не сущ.
            {   w.WriteLine("File: " + e.FullPath + " " + e.ChangeType + ": " + DateTime.Now);
            }
        }

        public void OnRenamed(object source, RenamedEventArgs e)//Предоставляет данные для события Renamed.
        {
            // Указ., что делается при переименовании файла.
            Console.WriteLine("File: {0} renamed to {1} : {2}", e.OldFullPath, e.FullPath, DateTime.Now);

            using (StreamWriter w = File.AppendText(path))//
            {   w.WriteLine("File: {0} renamed to {1} : {2}", e.OldFullPath, e.FullPath, DateTime.Now);
            }
        }

        //  Метод вызывается, когда FileSystemWatcher обнаруживает ошибку.
        public void OnError(object source, ErrorEventArgs e)//Предоставляет данные для события Error.
        {
            //  Показ., что обнаружена ошибка.
            Console.WriteLine($"The FileSystemWatcher has detected an error : { DateTime.Now }");

            using (StreamWriter w = File.AppendText(path))//
            {
                w.WriteLine($"The FileSystemWatcher has detected an error : { DateTime.Now }");
            }
            // Дополнительная информация, если ошибка вызвана внутренним переполнением буфера.
            if (e.GetException().GetType() == typeof(InternalBufferOverflowException))
            {
                Console.WriteLine("The file system watcher experienced an internal buffer overflow: " + e.GetException().Message + ':' + DateTime.Now);
                using (StreamWriter w = File.AppendText(path))//
                {
                    w.WriteLine("The file system watcher experienced an internal buffer overflow: " + e.GetException().Message + ':' + DateTime.Now);
                }
            }
        }
    }
}
