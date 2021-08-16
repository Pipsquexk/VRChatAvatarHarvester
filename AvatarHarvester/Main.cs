using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MelonLoader;

namespace AvatarHarvester
{
    public class Main : MelonMod
    {
        public override void OnApplicationStart()
        {
            base.OnApplicationStart();
            Patches.ApplyPatches();
            foreach (string str in File.ReadAllLines("Avatars.txt"))
            {
                Utils.logs.Add(str);
            }
        }
    }
}
