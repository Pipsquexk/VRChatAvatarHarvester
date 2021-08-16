using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MelonLoader;

namespace AvatarHarvester
{
    public static class Utils
    {

        public static List<string> logs = new List<string>();

        public static void Log(string text)
        {
            if (logs.Count == 0)
            {
                File.WriteAllText("Avatars.txt", "{");
            }
            logs.Add(text);
            MelonLogger.Msg(ConsoleColor.Green, text);
            File.WriteAllLines("Avatars.txt", logs.ToArray());
        }

    }
}
