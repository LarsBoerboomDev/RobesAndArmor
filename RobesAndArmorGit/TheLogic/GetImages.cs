using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace TheLogic
{
    public static class GetImages
    {
        public static List<string> gettheImages(string folder)
        {

            List<string> images = new List<string>();
            string path = Path.Combine(Environment.CurrentDirectory, @"wwwroot\images\" + folder + @"\");
            foreach (string item in Directory.GetFiles(path))
            {
                images.Add(Path.GetFileName(item));
            }


            return images;
        }
    }
}
