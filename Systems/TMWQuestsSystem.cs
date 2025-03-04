using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;
using Terraria.UI;
using TMWQuests.UI;

namespace TMWQuests.Systems
{
    public class TMWQuestsSystem : ModSystem
    {
        internal static UserInterface _ui;
        private static QuestUI _questUI;

        public override void Load()
        {
            if (!Main.dedServ)
            {
                _questUI = new QuestUI();
                _questUI.Activate();
                _ui = new UserInterface();
                _ui.SetState(null);
            }
        }

        public override void UpdateUI(GameTime gameTime)
        {
            if (QuestsHoyKey.OpenQuestsUI.JustPressed)
            {
                ToggleUI();
            }

            if (_ui?.CurrentState != null)
            {
                _ui.Update(gameTime);
            }
        }

        public override void ModifyInterfaceLayers(List<GameInterfaceLayer> layers)
        {
            int index = layers.FindIndex(layer => layer.Name.Equals("Vanilla: Inventory"));

            if (index != -1)
            {
                layers.Insert(index, new LegacyGameInterfaceLayer(
                    "TMWQuests: Quests",
                    delegate
                    {
                        if (_ui?.CurrentState != null)
                        {
                            _ui.Draw(Main.spriteBatch, Main._drawInterfaceGameTime);
                        }
                        return true;
                    },
                    InterfaceScaleType.UI)
                );
            }
        }

        public static void ToggleUI()
        {
            if (_ui?.CurrentState == null)
            {
                _ui.SetState(_questUI);
            }
            else
            {
                _ui.SetState(null);
            }
        }
    }
}