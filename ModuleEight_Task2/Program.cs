namespace ModuleEight_Task2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Введите адрес папки: ");
            string FolderPath = Console.ReadLine();
            Console.WriteLine(FolderSize(FolderPath));
        }

        public static long FolderSize(string path)
        {
            DirectoryInfo directory;
            if (Directory.Exists(path))
            {
                directory = new DirectoryInfo(path);
                
                long size = 0;

                try
                {
                    foreach (var file in directory.GetFiles())
                        size += file.Length;
                }
                catch { }

                try
                {
                    foreach (var direct in directory.GetDirectories())
                        size += FolderSize(direct.FullName);
                }
                catch { }

                return size;
            }
            else
            {
                Console.WriteLine("Папка не найдена!");
                return 0;
            }
        }
    }
}
