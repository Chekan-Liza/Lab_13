using System;
using System.IO;

namespace Lab_13
{
    class FileInfo_CES_
    {   static string path = @"D:\Study\ООП\Проекты C#\Lab_13\bin\Debug\logfile(ces).txt";
        //Предоставл. св-ва и методы экземпляра для созд., копир., удал., перемещ. и откр. файлов, а также позволяет создавать объекты FileStream.
        FileInfo fileInf = new FileInfo(path);

        public void DisplayInfo()
        {
            if (fileInf.Exists)
            {
                Console.WriteLine("Имя файла: {0}", fileInf.Name);
                Console.WriteLine("Время создания: {0}", fileInf.CreationTime);
                Console.WriteLine("Размер: {0} byte", fileInf.Length);
            }
            Console.WriteLine();
        }
    }
}
