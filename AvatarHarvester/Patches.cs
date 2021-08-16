using System;
using System.Collections.Generic;
using System.Reflection;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MelonLoader;
using Harmony;
using VRC;
using Newtonsoft.Json;
using System.IO;

namespace AvatarHarvester
{
    public static class Patches
    {
        public static HarmonyMethod GetLocalPatch(string name) { return new HarmonyMethod(typeof(Patches).GetMethod(name, BindingFlags.NonPublic | BindingFlags.Static)); }

        public static HarmonyInstance instance;

        public static void ApplyPatches()
        {
            instance = HarmonyInstance.Create("AvatarHarvesterPatches");

            instance.Patch(typeof(NetworkManager).GetMethod("Method_Public_Void_Player_1"), GetLocalPatch("NewOnPlayerJoin"));
        }

        private static bool NewOnPlayerJoin(Player __0)
        {

            var playerAvatar = __0.prop_ApiAvatar_0;
            if (playerAvatar.releaseStatus.ToLower() == "public")
            {
                if (File.ReadAllText("Avatars.txt").Contains(playerAvatar.id))
                {
                    MelonLogger.Msg(ConsoleColor.Red, "Already Logged " + playerAvatar.id);
                    MelonLogger.Msg(ConsoleColor.Cyan, "Skipping");
                }
                else
                {
                    var avatarInfo = new Avatar() { Name = playerAvatar.name, ID = playerAvatar.id, ImageURL = playerAvatar.imageUrl, AuthorName = playerAvatar.authorName };
                    Utils.Log(JsonConvert.SerializeObject(avatarInfo) + ",");
                }
            }
            else
            {
                MelonLogger.Msg(ConsoleColor.Red, "PRIVATE");
            }
            
            return true;
        }

    }
}
