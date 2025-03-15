using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe
{
    internal class PlayerInfo : FlowLayoutPanel
    {
        private Label playerLabel = new Label();
        private Label playerScore = new Label();

        private Player player;

        public PlayerInfo(Player player)
        {
            this.player = player;
            player.PropertyChanged += (sender, e) => UpdateOnModelChange(e.PropertyName);

            playerLabel.Text = $"{player.Name} ({player.Symbol})";
            playerLabel.AutoSize = true;
            playerLabel.Font = new System.Drawing.Font(playerLabel.Font.FontFamily, 14, System.Drawing.FontStyle.Bold);

            playerScore.Text = $"Score: {player.Score}";
            playerScore.AutoSize = true;
            playerScore.Font = new System.Drawing.Font(playerScore.Font.FontFamily, 12);

            Controls.Add(playerLabel);
            Controls.Add(playerScore);

            this.Dock = DockStyle.Fill;

        }

        public void UpdateOnModelChange(string propertyName)
        {
            switch (propertyName)
            {
                case nameof(Player.IsTurn):
                    playersTurn();
                    break;
                case nameof(Player.Name):
                    playerLabel.Text = $"{player.Name} ({player.Symbol})";
                    break;
                case nameof(Player.Score):
                    playerScore.Text = $"Score: {player.Score}";
                    break;
            }

        }

        public void playersTurn()
        {
            if (player.IsTurn)
            {
                this.BackColor = System.Drawing.Color.LightGreen;
            }
            else
            {
                this.BackColor = System.Drawing.Color.White;
            }
        }
    }
}
