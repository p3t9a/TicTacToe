using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms.VisualStyles;

namespace TicTacToe
{
    internal class StartMenu : TableLayoutPanel
    {
        private ControlButton StartButton;
        private ControlButton ExitButton;
        private TextBox Player1Name;
        private TextBox Player2Name;

        public StartMenu()
        {
            // Initialize the controls
            StartButton = new ControlButton("Start Game");
            ExitButton = new ControlButton("Exit Game");
            Player1Name = new TextBox();
            Player2Name = new TextBox();

            FlowLayoutPanel leftPanel = new FlowLayoutPanel();
            FlowLayoutPanel middlePanel = new FlowLayoutPanel();
            FlowLayoutPanel rightPanel = new FlowLayoutPanel();

            Label leftLabel = new Label();
            Label rightLabel = new Label();

            // Set the textboxes' properties
            Player1Name.PlaceholderText = "Player 1 Name";
            Player2Name.PlaceholderText = "Player 2 Name";

            int minWidth = 200;
            int minHeight = 50;
            Player1Name.MinimumSize = new System.Drawing.Size(minWidth, minHeight);
            Player2Name.MinimumSize = new System.Drawing.Size(minWidth, minHeight);

            //center the text in the textboxes
            Player1Name.TextAlign = HorizontalAlignment.Center;
            Player2Name.TextAlign = HorizontalAlignment.Center;

            // Set the labels' properties
            leftLabel.Text = "Player 1";
            rightLabel.Text = "Player 2";
            leftLabel.Font = new System.Drawing.Font(leftLabel.Font.FontFamily, 14, System.Drawing.FontStyle.Bold);
            rightLabel.Font = new System.Drawing.Font(rightLabel.Font.FontFamily, 14, System.Drawing.FontStyle.Bold);
            leftLabel.AutoSize = true;
            rightLabel.AutoSize = true;
            leftLabel.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            rightLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;

            // Set the panels' properties and add the controls
            leftPanel.Dock = DockStyle.Fill;
            middlePanel.Dock = DockStyle.Fill;
            rightPanel.Dock = DockStyle.Fill;

            leftPanel.FlowDirection = FlowDirection.TopDown;
            middlePanel.FlowDirection = FlowDirection.TopDown;
            rightPanel.FlowDirection = FlowDirection.TopDown;

            // align the items  in the panel
            leftPanel.Anchor = System.Windows.Forms.AnchorStyles.Right;
            middlePanel.Anchor = System.Windows.Forms.AnchorStyles.None;
            rightPanel.Anchor = System.Windows.Forms.AnchorStyles.Left;


            leftPanel.Controls.Add(leftLabel);
            leftPanel.Controls.Add(Player1Name);

            middlePanel.Controls.Add(StartButton);
            middlePanel.Controls.Add(ExitButton);

            rightPanel.Controls.Add(rightLabel);
            rightPanel.Controls.Add(Player2Name);

            

            // Set own properties and add the controls
            this.Dock = DockStyle.Fill;

            int columnCount = 3;
             
            this.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 1f/columnCount));
            this.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 1f/columnCount));
            this.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 1f/columnCount));
            this.RowStyles.Add(new RowStyle(SizeType.Percent, 1f));

            this.Controls.Add(leftPanel,0,0);
            this.Controls.Add(middlePanel,1,0);
            this.Controls.Add(rightPanel,2,0);
        }

        /// <summary>
        /// Set the click event for the start button
        /// </summary>
        /// <param name="eventHandler"></param>
        public void SetStartButtonClickEvent(EventHandler eventHandler)
        {
            StartButton.Click += eventHandler;
        }

        /// <summary>
        /// Set the click event for the exit button
        /// </summary>
        /// <param name="eventHandler"></param>
        public void SetExitButtonClickEvent(EventHandler eventHandler)
        {
            ExitButton.Click += eventHandler;
        }

        public string GetPlayer1Name()
        {
            return Player1Name.Text;
        }

        public string GetPlayer2Name()
        {
            return Player2Name.Text;
        }
    }
}
