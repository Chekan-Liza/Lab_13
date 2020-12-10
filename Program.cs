using System.IO;

namespace Lab_13
{
    class Program
    {
        public static void Main()
        {   // Созд. класса FileSystemWatcher - ожид. уведомл-я файл. сист. об изм-х и инициирует события при изм-х каталога или файла в каталоге.
            FileSystemWatcher watcher = new FileSystemWatcher();
            watcher.Path = @"new"; // Задает путь отслеживаемого каталога.
            // След. за изм-и во времени LastAccess и LastWrite, а также за переименованием файлов или каталогов.
            watcher.NotifyFilter = NotifyFilters.LastAccess | NotifyFilters.LastWrite // Получает или задает тип отслеживаемых изменений.
               | NotifyFilters.FileName | NotifyFilters.DirectoryName;
            //Дата последнего открытия файла или папки (или) Дата последней записи в файл или папку (или) Имя файла (или) Имя каталога.
            Log_CES_ log = new Log_CES_();
            // Добав. обраб. событий.
            watcher.Changed += new FileSystemEventHandler(log.OnChanged);
            watcher.Created += new FileSystemEventHandler(log.OnChanged);
            watcher.Deleted += new FileSystemEventHandler(log.OnChanged);
            watcher.Renamed += new RenamedEventHandler(log.OnRenamed);
            watcher.Error += new ErrorEventHandler(log.OnError);
            // 
            watcher.EnableRaisingEvents = true;

            DiskInfo_CES_ disk = new DiskInfo_CES_();
            disk.DisplayInfo();

            FileInfo_CES_ file = new FileInfo_CES_();
            file.DisplayInfo();

            DirInfo_CES_ dir = new DirInfo_CES_();
            dir.DisplayInfo();

            FileManager_CES_ fileManager = new FileManager_CES_();
            fileManager.DisplayInfo();
            fileManager.CreateDir();
            fileManager.CreateFile();
            fileManager.CopyFile();
            fileManager.DisplayInfo();
            fileManager.CreateDir_2();
            fileManager.MoveDir();
            fileManager.Archive();
            fileManager.DisplayInfo();
        }
    }
}