using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TicTacToe
{
    internal class GameBoard : TableLayoutPanel
    {
        private const int BOARD_SIZE = GameControl.BOARD_SIZE;

        private Cell[,] cells;

        public GameBoard()
        {
            this.cells = new Cell[BOARD_SIZE, BOARD_SIZE];

            this.ColumnCount = BOARD_SIZE;
            this.Name = "GameBoard";
            this.RowCount = BOARD_SIZE;

            // Set the game board to fill the parent control
            this.Dock = DockStyle.Fill;
            

            for (int i = 0; i < BOARD_SIZE; i++)
            {
                for (int j = 0; j < BOARD_SIZE; j++)
                {
                    cells[i, j] = new Cell(i, j);
                    this.Controls.Add(cells[i, j], i, j);
                    float percent = 100f / BOARD_SIZE;
                    this.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, percent));
                    this.RowStyles.Add(new RowStyle(SizeType.Percent, percent));
                }
            }
        }

        public void setCellClickEvent(EventHandler clickEvent)
        {
            foreach (Cell cell in cells)
            {
                cell.SetClickEvent(clickEvent);
            }
        }

        public void ClearBoard()
        {
            foreach (Cell cell in cells)
            {
                cell.Text = "";
                cell.Enabled = true;
            }
        }
    }
}
