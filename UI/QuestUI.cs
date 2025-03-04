using Microsoft.Xna.Framework;
using Terraria;
using Terraria.GameContent.UI.Elements;
using Terraria.UI;

namespace TMWQuests.UI;

public class QuestUI : UIState
{
    private UIPanel _panel;
    
    public override void OnInitialize()
    {
    // UI size
        var width = Main.screenWidth;
        var height = Main.screenHeight;
        
        _panel = new UIPanel();
        _panel.SetPadding(10);
        
        // Margin position
        _panel.Left.Set(0f, 0f);
        _panel.Top.Set(0f, 0f);
        
        _panel.Width.Set(width, 0f);
        _panel.Height.Set(height, 0f);
        
        _panel.BackgroundColor = new Color(127 / 255f, 127 / 255f, 127 / 255f, 127 / 255f);
        
        Append(_panel);

        _panel.OnMouseOver += (e, element) =>
        {
            Main.player[Main.myPlayer].mouseInterface = true;
        };
    }

    public override void Update(GameTime gameTime)
    {
        Main.player[Main.myPlayer].mouseInterface = true;
        base.Update(gameTime);
    }

    public override void OnDeactivate()
    {
        Main.player[Main.myPlayer].mouseInterface = false;
        base.OnDeactivate();
    }
}