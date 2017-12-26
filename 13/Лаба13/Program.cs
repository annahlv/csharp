using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.IO.Compression;
using System.Reflection;

namespace Лаба13
{
    public class HAYLog
    {
        public delegate void del(string m, string path);

        public event del EventIO;

        public string path = @"HAYlogfile.txt";

        public void Write(string[] s)
        {
            string buf = "";
            using (StreamWriter sw = new StreamWriter(path, true, System.Text.Encoding.Default))
            {
                foreach (string str in s)
                {
                    sw.WriteLine(str);
                }

                sw.Close();
            }

            Type type = typeof(HAYLog);

            foreach (MethodInfo m in type.GetMethods())
            {
                if (m.Name == "Write")
                {
                    buf = m.Name;
                }
            }

            EventIO(buf, path);
        }


        public void Read(string path)
        {
            string buf = "";

            Type type = typeof(HAYLog);

            foreach (MethodInfo m in type.GetMethods())
            {
                if (m.Name == "Read")
                {
                    buf = m.Name;
                }
            }

            EventIO(buf, path);
            using (StreamReader sr = new StreamReader(path, System.Text.Encoding.Default))
            {
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    Console.WriteLine(line);
                }


                sr.Close();

            }
        }


        public void Search(string search)
        {

            using (StreamReader sr = new StreamReader(path, System.Text.Encoding.Default))
            {
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    if (line == search)
                    {

                        Console.WriteLine("Совпало: " + line);
                        Console.WriteLine(sr.ReadLine());

                    }
                }


                sr.Close();

            }

        }

        public static void OnEvent(string m, string path)
        {
            using (StreamWriter sw = new StreamWriter(path, true, System.Text.Encoding.Default))
            {
                sw.WriteLine("Вызван метод: " + m);
                sw.WriteLine("Время: " + DateTime.Now);
            }
        }
    }
    public class HAYDiskinfo
    {
        DriveInfo[] allDrives;
        public HAYDiskinfo()
        {
            allDrives = DriveInfo.GetDrives();
        }
        public void freespace()
        {
            foreach (DriveInfo d in allDrives)
            {
                Console.WriteLine("Диск " + d.Name);
                if (d.IsReady == true)
                {
                    Console.WriteLine("Свободно на диске:{0, 15} bytes", d.AvailableFreeSpace);
                    Console.WriteLine("Всего места:{0, 15} bytes ", d.TotalSize);
                }
            }
        }
        public void allpls()
        {
            foreach (DriveInfo d in allDrives)
            {
                Console.WriteLine("Диск " + d.Name);
                Console.WriteLine("Тип диска: {0}", d.DriveType);
                if (d.IsReady == true)
                {
                    Console.WriteLine("Файловая система: " + d.DriveFormat);
                    Console.WriteLine("Свободно на диске:{0, 15} bytes", d.AvailableFreeSpace);
                    Console.WriteLine("Всего места:{0, 15} bytes " , d.TotalSize);
                }
            }
        }
        public void filesystem()
        {
            foreach (DriveInfo d in allDrives)
            {
                Console.WriteLine("Диск " + d.Name);
                if (d.IsReady == true)
                {
                    Console.WriteLine("Файловая система: " + d.DriveFormat);
                }
            }
        }
    }
    public class HAYFileinfo
    {
        public void Info(string path)
        {

            FileInfo fileInf = new FileInfo(path);
            if (!fileInf.Exists) return;

            Console.WriteLine("Имя файла: " + fileInf.Name);
            Console.WriteLine("Путь: " + fileInf.FullName);
            Console.WriteLine("Время создания: " + fileInf.CreationTime);
            Console.WriteLine("Размер: " + fileInf.Length);
        }
    }
    public class HAYDirinfo
    {

    }
    public class HAYFilemanager
    {
        public void ListOfFiles()
        {
            string dirName = @"C:\";
            string[] dirs = Directory.GetDirectories(dirName);
            string[] files = Directory.GetFiles(dirName);
            if (!Directory.Exists(dirName)) return;


            Console.WriteLine("Подкаталоги: ");

            foreach (string s in dirs)
            {
                Console.WriteLine(s);
            }
            Console.WriteLine();
            Console.WriteLine("Файлы: ");

            foreach (string s in files)
            {
                Console.WriteLine(s);
            }
        }

        public void qw2()
        {
            string dirName = @"C:\";
            string prefPath = @"";
            string[] dirs = Directory.GetDirectories(dirName);
            string[] files = Directory.GetFiles(dirName);
            DirectoryInfo directory = new DirectoryInfo(prefPath + @"HAYInspect");
            directory.Create();

            string path = prefPath + @"HAYInspect\HAYdirinfo.txt";

            using (StreamWriter sw = new StreamWriter(path, false, System.Text.Encoding.Default))
            {
                sw.WriteLine("Подкаталоги:");

                foreach (string s in dirs)
                {
                    sw.WriteLine(s);
                }
                sw.WriteLine();
                sw.WriteLine("Файлы: ");

                foreach (string s in files)
                {
                    sw.WriteLine(s);
                }

                Console.WriteLine("Зaписали");

            }

            string newPath = prefPath + @"HAYInspect\NEWHAYdirinfo.txt"; ;
            FileInfo fileInf = new FileInfo(path);
            if (fileInf.Exists)
            {
                fileInf.CopyTo(newPath, true);
            }
            //File.Delete(prefPath + @"HAYInspect\HAYdirinfo.txt");


        }

        public void qw3(string dirName, string txt)
        {
            string prefPath = @"";
            DirectoryInfo directory = new DirectoryInfo(prefPath + "HAYFiles");
            directory.Create();

            string[] files = Directory.GetFiles(dirName, "*." + txt);

            foreach (var s in files)
            {

                FileInfo fileInf = new FileInfo(s);

                if (fileInf.ToString() == s)
                {
                    Console.WriteLine(s);

                    fileInf.CopyTo(prefPath + @"HAYFiles\" + fileInf.Name, true);

                }
            }

            /*DirectoryInfo dirInfo = new DirectoryInfo(prefPath + @"HAYInspect");
            dirInfo.Delete(true);

            string sourceDirectory = @"HAYFiles\";
            string destinationDirectory = @"HAYInspect\";

            try
            {
                Directory.Move(sourceDirectory, destinationDirectory);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }*/
            

        }

        public void qw4()
        {
            string prefPath = @"";
            string startPath = prefPath + @"HAYInspect";
            string zipPath = prefPath + @"result.zip";
            string extractPath = prefPath + @"result";

            ZipFile.CreateFromDirectory(startPath, zipPath);
            ZipFile.ExtractToDirectory(zipPath, extractPath);

        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("\n************************************\n");
            string buf = "";
            HAYLog pasLog = new HAYLog();

            pasLog.EventIO += HAYLog.OnEvent;

            HAYDiskinfo t = new HAYDiskinfo();

            Console.WriteLine("Ввели в файл");
            pasLog.Write( new string[] { "Designer", "And", "Proud" });
            Console.WriteLine("\nИз файла: " + pasLog.path + "\n");
            pasLog.Read(pasLog.path);
            Console.WriteLine("Введите строку для поиска: ");
            buf = Console.ReadLine();
            Console.WriteLine("Поиск по строке: ");
            pasLog.Search(buf);


            Console.WriteLine("\n************************************\n");
            t.allpls();
            Console.WriteLine("\n************************************\n");
            t.filesystem();
            Console.WriteLine("\n************************************\n");
            t.freespace();

            Console.WriteLine("\n************************************\n");
            HAYFileinfo s = new HAYFileinfo();
            s.Info("C:\\binom.exe");
            Console.WriteLine("\n************************************\n");
            HAYFilemanager manager = new HAYFilemanager();

            manager.ListOfFiles();
            manager.qw2();
            manager.qw3(@"C:\", "txt");
            manager.qw4();
            Console.WriteLine("\n************************************\n");
        }
    }
}
