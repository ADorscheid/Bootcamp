using System;
using System.Collections.Generic;
using System.Text;

namespace Lecture.Aids
{
    public static class SpecialFolders
    {
        static public string GetUserFolder()
        {
            return Environment.GetFolderPath(Environment.SpecialFolder.UserProfile);
        }

        static public string GetDesktopFolder()
        {
            return Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
        }
        static public string GetMyDocumentsFolder()
        {
            return Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
        }
        static public string GetMusicFolder()
        {
            return Environment.GetFolderPath(Environment.SpecialFolder.MyMusic);
        }
        static public string GetSharedMusicFolder()
        {
            return Environment.GetFolderPath(Environment.SpecialFolder.CommonMusic);
        }

        static public void ShowAllSpecialFolders()
        {
            foreach (int val in Enum.GetValues(typeof(Environment.SpecialFolder)))
            {
                string folder = Environment.GetFolderPath((Environment.SpecialFolder)val);
                Console.WriteLine($"{Enum.GetName(typeof(Environment.SpecialFolder), val)}: {folder}");
            }

        }
    }
}
