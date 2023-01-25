using System.IO;

namespace EXSM3942_Demo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // We can use Environment to access some information to address the user and their machine.
            Console.WriteLine($"Hello, {Environment.UserName} of {Environment.MachineName} running {Environment.Version}!");
            // We can also access a variety of configured "special" directories so we can store files in a common easy-to-find location.
            Console.WriteLine($"Your system directory is: {Environment.SystemDirectory}");
            Console.WriteLine($"Your temp directory is: {Environment.GetEnvironmentVariable("TEMP")}");
            Console.WriteLine($"Your Documents directory is: {Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)}");

            // We can show all the files in a directory:
            foreach(string filename in Directory.GetFiles(Environment.GetFolderPath(Environment.SpecialFolder.Desktop))) Console.WriteLine(filename);

            string testDir = "C:\\Users\\Jameson\\Desktop\\Demo\\csharp2";
            RecurseFileNames(testDir);
        }

        // Recursion with files.
        static void RecurseFileNames(string path, string tabs = "")
        {
            // Write the tabstop and the current path.
            Console.WriteLine(tabs + path);
            // Write the files in this directory.
            foreach (string file in Directory.GetFiles(path)) Console.WriteLine(tabs + "\t" + file);
            // Get the directories inside the path.
            string[] subdirectories = Directory.GetDirectories(path);
            // For each directory, recurse into it, and bump over a tabstop.
            foreach (string subdir in subdirectories) RecurseFileNames(subdir, tabs+"\t");
            
        }
    }
}