using Terraria.ModLoader;
using Terraria.ModLoader.IO;

namespace TMWQuests.Systems
{
    public class QuestsHoyKey : ModSystem
    {
        public static ModKeybind OpenQuestsUI { get; private set; }

        public override void Load()
        {
            OpenQuestsUI = KeybindLoader.RegisterKeybind(Mod, "Open Quests", Microsoft.Xna.Framework.Input.Keys.P);
        }

        public override void Unload()
        {
            OpenQuestsUI = null;
        }
    }
}