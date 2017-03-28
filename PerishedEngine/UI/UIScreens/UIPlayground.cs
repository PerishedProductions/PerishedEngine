using Microsoft.Xna.Framework;

namespace PerishedEngine.UI.UIScreens
{
    public class UIPlayground : UIScreen
    {

        UIPanel panel;

        public override void LoadContent()
        {

            CreateUIElement(new UIText(new Vector2(10, 10), "Playground"), UILayer.Middle);
            UIButton testButton = (UIButton)CreateUIElement(new UIButton("This is a button!", new Rectangle(10, 55, 500, 100), this), UILayer.Middle);

            panel = (UIPanel)CreateUIElement(new UIPanel(new Rectangle(10, 160, 500, 500), ColorTheme.Dark), UILayer.Middle);
            panel.CreateUIElement(new UIText(new Vector2(panel.size.X + 10, panel.size.Y + 5), "This is a text inside a panel"));

            testButton.onButtonClicked += TestButton_onButtonClicked;

            panel.CreateUIElement(new UISlider(0, 10, new Vector2(15, 300)));

            base.LoadContent();
        }

        private void TestButton_onButtonClicked()
        {
            panel.visible = !panel.visible;
        }
    }
}
