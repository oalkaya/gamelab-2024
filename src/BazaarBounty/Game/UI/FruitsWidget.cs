/* Generated by MyraPad at 4/28/2024 6:29:59PM */

using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework.Input;

namespace BazaarBounty
{
    public partial class FruitsWidget : IWidgetBase
    {
        private int currIndex;
        public FruitsWidget(List<Buff> buffs)
        {
            BuildUI(buffs);
            foreach (var button in buttons)
            {
                button.Click += (s, a) =>
                {
                    selectionMaps[button].Apply(BazaarBountyGame.player);
                    var uiManager = BazaarBountyGame.uiManager;
                    uiManager.RemoveWidget(this);
                    // BazaarBountyGame.GetGameInstance().ContinueGame();
                    BazaarBountyGame.GetGameInstance().CurrentGameState = BazaarBountyGame.GameState.Running;
                    BazaarBountyGame.playerController.RegisterControllerInput();
                };
                
                // button.MouseEntered += (s, a) =>
                // {
                //     confirmIconMap[button].Visible = true;
                // };
                //
                // button.MouseLeft += (s, a) =>
                // {
                //     confirmIconMap[button].Visible = false;
                // };
            }
        }

        public void Initialize()
        {
            InputRouter.RegisterInput(Buttons.LeftThumbstickLeft, MoveLeft, true);
            InputRouter.RegisterInput(Buttons.LeftThumbstickRight, MoveRight, true);
            InputRouter.RegisterInput(Buttons.A, Confirm, true);
        }

        public void Deinitialize()
        {
            InputRouter.DeregisterInput(Buttons.LeftThumbstickLeft, MoveLeft, true);
            InputRouter.DeregisterInput(Buttons.LeftThumbstickRight, MoveRight, true);
            InputRouter.DeregisterInput(Buttons.A, Confirm, true);
        }

        private void MoveLeft()
        {
            int nextIndex = currIndex - 1 < 0 ? buttons.Count - 1 : currIndex - 1;
            buttons[currIndex].IsPressed = false;
            buttons[nextIndex].IsPressed = true;
            confirmIconMap[buttons[currIndex]].Visible = false;
            confirmIconMap[buttons[nextIndex]].Visible = true;
            currIndex = nextIndex;
        }

        private void MoveRight()
        {
            int nextIndex = currIndex + 1 >= buttons.Count ? 0 : currIndex + 1;
            buttons[currIndex].IsPressed = false;
            buttons[nextIndex].IsPressed = true;
            confirmIconMap[buttons[currIndex]].Visible = false;
            confirmIconMap[buttons[nextIndex]].Visible = true;
            currIndex = nextIndex;
        }

        private void Confirm()
        {
            selectionMaps[buttons[currIndex]].Apply(BazaarBountyGame.player);
            var uiManager = BazaarBountyGame.uiManager;
            uiManager.RemoveWidget(this);
            BazaarBountyGame.GetGameInstance().ContinueGame();
        }
    }
}