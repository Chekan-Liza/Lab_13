using System;
using System.Linq;
using System.IO;

namespace Lab_13
{
    class DirInfo_CES_
    {   static string dirName = "new";

        DirectoryInfo dirInfo = new DirectoryInfo(dirName); //Предоставл. методы экземпляра кл. для созд., перемещ. и перечисл. в каталогах и подкаталогах. 

        public void DisplayInfo()
        {
            Console.WriteLine("Название каталога: {0}", dirInfo.Name);
            Console.WriteLine("Полное название каталога: {0}", dirInfo.FullName);
            Console.WriteLine("Время создания каталога: {0}", dirInfo.CreationTime);
            Console.WriteLine("Корневой каталог: {0}", dirInfo.Root);

            if (Directory.Exists(dirName))
            {
                Console.WriteLine("Количество подкаталогов: " + Directory.GetDirectories(dirName).Count());
                Console.WriteLine("Количество файлов:" + Directory.GetFiles(dirName).Count());
            }
            Console.WriteLine();
        }
    }
}
