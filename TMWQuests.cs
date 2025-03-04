using Terraria;
using Terraria.ModLoader;
using TMWQuests.Systems;

namespace TMWQuests
{
    public class TMWQuests : Mod
    {
        public override void Load()
        {
            if (!Main.dedServ)
            {
                ModContent.GetInstance<TMWQuestsSystem>();
                ModContent.GetInstance<QuestsHoyKey>();
            }
        }

        public override void Unload()
        {
            TMWQuestsSystem._ui = null;
        }
    }
}