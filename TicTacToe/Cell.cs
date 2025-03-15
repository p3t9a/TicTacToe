using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe
{
    internal class Cell : Button
    {
        public int Row { get; private set; }
        public int Column { get; private set; }

        public Cell(int row, int column)
        {
            this.Row = row;
            this.Column = column;

            this.Name = $"cell{this.Row}{this.Column}"; // Set the name of the button
            this.Dock = DockStyle.Fill; // Fill the parent container with the button

            float fontSize = Math.Min(this.ClientSize.Width, this.ClientSize.Height) * 1.5f; // Calculate the font size based on the button size
            this.Font = new Font(this.Font.FontFamily, fontSize, FontStyle.Bold); // Set the font size and bold style
            this.TabStop = false; // Remove the focus rectangle around the button
        }

        public void SetClickEvent(EventHandler clickEvent)
        {
            this.Click += clickEvent;
        }
    }
}
