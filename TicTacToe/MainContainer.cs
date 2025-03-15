using System.Diagnostics.CodeAnalysis;

namespace TicTacToe
{
    internal class MainContainer : TableLayoutPanel
    {
        private GameControl gameControl;

        private GameBoard gameBoard;
        private PlayerInfo playerInfo1;
        private PlayerInfo playerInfo2;
        private ControlButtonContainer controlButtonContainer;

        public MainContainer(string player1Name, string player2Name)
        {
            // Initialize the game
            gameBoard = new GameBoard();
            controlButtonContainer = new ControlButtonContainer();
            gameControl = new GameControl(gameBoard, 
                controlButtonContainer, 
                player1Name: player1Name, 
                player2Name: player2Name);
            playerInfo1 = new PlayerInfo(gameControl.Player1);
            playerInfo2 = new PlayerInfo(gameControl.Player2);

            // Set the panels' properties according to the player's 
            playerInfo1.playersTurn();
            playerInfo2.playersTurn();
            

            // Create the middle panel with its controls
            TableLayoutPanel middlePanel = new TableLayoutPanel();
            middlePanel.Dock = DockStyle.Fill;
            middlePanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 1F));
            middlePanel.RowStyles.Add(new RowStyle(SizeType.Percent, 0.1F));
            middlePanel.RowStyles.Add(new RowStyle(SizeType.Percent, 0.9F));



            middlePanel.Controls.Add(controlButtonContainer);
            middlePanel.Controls.Add(gameBoard);

            // Set the main container properties and add the controls
            this.Dock = DockStyle.Fill;
            this.CellBorderStyle = TableLayoutPanelCellBorderStyle.Single;
            this.RowCount = 1;
            this.ColumnCount = 3;
            this.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 0.2F));
            this.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 0.6F));
            this.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 0.2F));
            this.RowStyles.Add(new RowStyle(SizeType.Percent, 1F));

            this.Controls.Add(playerInfo1, 0, 0);
            this.Controls.Add(middlePanel, 1, 0);
            this.Controls.Add(playerInfo2, 2, 0);
        }

    }
}
