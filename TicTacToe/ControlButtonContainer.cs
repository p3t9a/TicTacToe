using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe
{

    internal class ControlButtonContainer : FlowLayoutPanel
    {
        private ControlButton newGameButton;
        private ControlButton exitButton;
        public ControlButtonContainer()
        {
            // Set properties of the FlowLayoutPanel
            this.Dock = DockStyle.Fill;

            // Create the buttons and add them to the FlowLayoutPanel
            newGameButton = new ControlButton("New Game");
            Controls.Add(newGameButton);

            exitButton = new ControlButton("Exit Game");
            Controls.Add(exitButton);
        }

        /// <summary>
        /// Set the click event for the new game button
        /// </summary>
        /// <param name="clickEvent"></param>
        public void SetNewGameClickEvent(EventHandler clickEvent)
        {
            newGameButton.Click += clickEvent;
        }

        /// <summary>
        /// Set the click event for the exit button
        /// </summary>
        /// <param name="clickEvent"></param>
        public void SetExitClickEvent(EventHandler clickEvent)
        {
            exitButton.Click += clickEvent;
        }
    }
}
