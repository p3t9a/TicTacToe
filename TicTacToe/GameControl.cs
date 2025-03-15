using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe
{
    internal class GameControl
    {
        public const int BOARD_SIZE = 3;
        public const int WINNING_LENGTH = 3;

        private char[,] board;

        private Player player1, player2, currentPlayer;

        private GameBoard gameBoard;

        private ControlButtonContainer controlButtonContainer;

        public Player Player1 { get => player1; }
        public Player Player2 { get => player2; }

        public Player CurrentPlayer { get => currentPlayer; }

        public GameControl(GameBoard gameBoard, 
            ControlButtonContainer controlButtonContainer,
            string player1Name,
            string player2Name)
        {
            this.player1 = new Player(player1Name, 'X');
            this.player2 = new Player(player2Name, 'O');
            
            this.currentPlayer = player1;
            currentPlayer.SetTurn(true);
            this.gameBoard = gameBoard;
            this.controlButtonContainer = controlButtonContainer;

            this.gameBoard?.setCellClickEvent(cell_Click); // Set the click event for each cell
            this.controlButtonContainer?.SetNewGameClickEvent(newGame_Click); // Set the click event for the new game button
            this.controlButtonContainer?.SetExitClickEvent(exit_Click); // Set the click event for the exit button

            resetGame();
        }       


        /// <summary>
        /// Switches the current player.
        /// </summary>
        private void switchPlayer()
        {
            // Old player is no longer the current player
            currentPlayer.SetTurn(false);
            if (currentPlayer == player1)
            {
                currentPlayer = player2;
            }
            else
            {
                currentPlayer = player1;
            }
            // New player is the current player
            currentPlayer.SetTurn(true);
        }

        private void resetGame()
        {
            board = new char[BOARD_SIZE, BOARD_SIZE];
            gameBoard.ClearBoard();
        }



        /// <summary>
        /// Places the given symbol on the board at the given position.
        /// </summary>
        /// <param name="row"></param>
        /// <param name="column"></param>
        /// <param name="symbol"></param>
        /// <exception cref="Exception"></exception>
        private void _makeMove(int row, int column, char symbol)
        {
            if (board[row, column] != default(char))
            {
                throw new Exception($"Invalid move. Cell [{row},{column}] is already occupied.");
            }
            board[row, column] = symbol;
        }

        /// <summary>
        /// Places the current player's symbol on the board at the given position.
        /// </summary>
        /// <param name="row"></param>
        /// <param name="column"></param>
        private void makeMove(int row, int column)
        {
            _makeMove(row, column, currentPlayer.Symbol);
        }

        /// <summary>
        /// Checks whether the given position is a winning move for the given symbol.
        /// Only works if the move was already made.
        /// </summary>
        /// <param name="row"></param>
        /// <param name="column"></param>
        /// <param name="symbol"></param>
        /// <returns></returns>
        private bool _isPositionWinning(int row, int column, char symbol)
        {
            bool win = checkRow(row, symbol) || 
                checkColumn(column, symbol) || 
                checkMainDiagonal(row, column, symbol) || 
                checkSecondaryDiagonal(row, column, symbol);
            return win;
        }

        /// <summary>
        /// Checks whether the given position is a winning move for the current player.
        /// </summary>
        /// <param name="row"></param>
        /// <param name="column"></param>
        /// <returns></returns>
        private bool isPositionWinning(int row, int column)
        {
            return _isPositionWinning(row, column, currentPlayer.Symbol);
        }

        /// <summary>
        /// Checks if the game is a draw by checking if the board is full.
        /// </summary>
        /// <returns></returns>
        private bool isDraw()
        {
            for (int i = 0; i < BOARD_SIZE; i++)
            {
                for (int j = 0; j < BOARD_SIZE; j++)
                {
                    if (board[i, j] == default(char))
                    {
                        return false;
                    }
                }
            }
            return true;
        }

        /// <summary>
        /// Checks if the given row contains a winning combination of the given symbol.
        /// </summary>
        /// <param name="row"></param>
        /// <param name="symbol"></param>
        /// <returns></returns>
        private bool checkRow(int row, char symbol)
        {
            // Tries to find a winning length of consecutive symbols in the given row.
            int i = 0;
            while( i < BOARD_SIZE)
            {
                if (board[row, i] == symbol)
                {
                    int count = 1;
                    ++i;
                    while (i < BOARD_SIZE)
                    {
                        if (board[row, i] == symbol)
                        {
                            ++count;
                        }
                        else
                        {
                            break;
                        }
                        if (count == WINNING_LENGTH)
                        {
                            return true;
                        }
                        ++i;
                    }
                    if (count == WINNING_LENGTH)
                    {
                        return true;
                    }
                } else
                {
                    ++i;
                }
            }
            return false;
        }

        /// <summary>
        /// Checks if the given column contains a winning combination of the given symbol.
        /// </summary>
        /// <param name="column"></param>
        /// <param name="symbol"></param>
        /// <returns></returns>
        private bool checkColumn(int column, char symbol)
        {
            // Tries to find a winning length of consecutive symbols in the given column.
            int i = 0;
            while (i < BOARD_SIZE)
            {
                if (board[i, column] == symbol)
                {
                    int count = 1;
                    ++i;
                    while (i < BOARD_SIZE)
                    {
                        if (board[i, column] == symbol)
                        {
                            ++count;
                        }
                        else
                        {
                            break;
                        }
                        if (count == WINNING_LENGTH)
                        {
                            return true;
                        }
                        ++i;
                    }
                    if (count == WINNING_LENGTH)
                    {
                        return true;
                    }
                }
                else
                {
                    ++i;
                }
            }
            return false;
        }

        /// <summary>
        /// Checks if the main diagonal containing the given position contains a winning combination of the given symbol.
        /// </summary>
        /// <param name="row"></param>
        /// <param name="column"></param>
        /// <param name="symbol"></param>
        /// <returns></returns>
        private bool checkMainDiagonal(int row, int column, char symbol)
        {
            // Tries to find a winning length of consecutive symbols in
            // the main diagonal containing the position given by row, column.
            int min = Math.Min(row, column);
            int i = row - min;
            int j = column - min;
            while (i < BOARD_SIZE && j < BOARD_SIZE)
            {
                if (board[i, j] == symbol)
                {
                    int count = 1;
                    ++i;
                    ++j;
                    while (i < BOARD_SIZE && j < BOARD_SIZE)
                    {
                        if (board[i, j] == symbol)
                        {
                            ++count;
                        }
                        else
                        {
                            break;
                        }
                        if (count == WINNING_LENGTH)
                        {
                            return true;
                        }
                        ++i;
                        ++j;
                    }
                    if (count == WINNING_LENGTH)
                    {
                        return true;
                    }
                }
                else
                {
                    ++i;
                    ++j;
                }
            }
            return false;
        }   

        /// <summary>
        /// Checks if the secondary diagonal containing the given position contains a winning combination of the given symbol.
        /// </summary>
        /// <param name="row"></param>
        /// <param name="column"></param>
        /// <param name="symbol"></param>
        /// <returns></returns>
        private bool checkSecondaryDiagonal(int row, int column, char symbol)
        {
            // Tries to find a winning length of consecutive symbols in
            // the secondary diagonal containing the position given by row, column.
            int min = Math.Min(row, BOARD_SIZE - 1 - column);
            int i = row - min;
            int j = column + min;
            while (i < BOARD_SIZE && j >= 0)
            {
                if (board[i, j] == symbol)
                {
                    int count = 1;
                    ++i;
                    --j;
                    while (i < BOARD_SIZE && j >= 0)
                    {
                        if (board[i, j] == symbol)
                        {
                            ++count;
                        }
                        else
                        {
                            break;
                        }
                        if (count == WINNING_LENGTH)
                        {
                            return true;
                        }
                        ++i;
                        --j;
                    }
                    if (count == WINNING_LENGTH)
                    {
                        return true;
                    }
                }
                else
                {
                    ++i;
                    --j;
                }
            }
            return false;
        }

        /// <summary>
        /// Event handler for when a cell on the board is clicked.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cell_Click(object sender, EventArgs e)
        {
            Cell cell = (Cell)sender;
            cell.Enabled = false;

            // Make move
            makeMove(cell.Row, cell.Column);
            cell.Text = CurrentPlayer.Symbol.ToString();
            bool win = isPositionWinning(cell.Row, cell.Column);
            string message;
            if (win)
            {
                message = $"Player \"{currentPlayer.Name}\" wins!";
                MessageBox.Show(message, "Message");
                CurrentPlayer.AddScore();
                Console.WriteLine(message);

                //TODO: Ask the user if they want to start a new game
                resetGame();
            }
            else
            {
                bool draw = isDraw();
                if (draw)
                {
                    message = "Draw!";
                    MessageBox.Show(message, "Message");
                    Console.WriteLine(message);

                    //TODO: Ask the user if they want to start a new game
                    resetGame();
                }
            }
            switchPlayer();

            message = "Cell clicked: " + cell.Row + ", " + cell.Column;
            Console.WriteLine(message);
        }

        /// <summary>
        /// Event handler for when the exit button is clicked.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void exit_Click(object? sender, EventArgs e)
        {
            //TODO: Ask the user if they want to exit the game
            Environment.Exit(0);
        }

        /// <summary>
        /// Event handler for when the new game button is clicked.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void newGame_Click(object? sender, EventArgs e)
        {
            //TODO: Ask the user if they want to start a new game
            resetGame();
            
        }
    }

    
}
