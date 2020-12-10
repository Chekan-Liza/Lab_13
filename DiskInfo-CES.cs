using System;
using System.IO;

namespace Lab_13
{
    class DiskInfo_CES_
    {   DriveInfo[] drives = DriveInfo.GetDrives(); //Возвращает имена всех логических дисков на компьютере (Записывает их в массив).
        public void DisplayInfo()
        {
            foreach (DriveInfo drive in drives)
            {
                Console.WriteLine("Название: {0}", drive.Name);
                Console.WriteLine("Тип: {0}", drive.DriveType);
                Console.WriteLine("Файловая система: {0}", drive.DriveFormat);
                if (drive.IsReady)
                {
                    Console.WriteLine("Объем диска: {0}", drive.TotalSize);
                    Console.WriteLine("Свободное пространство: {0}", drive.TotalFreeSpace);
                    Console.WriteLine("Метка: {0}", drive.VolumeLabel);
                }
                Console.WriteLine();
            }
        }
    }
}
