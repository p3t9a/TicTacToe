using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe
{
    internal class Player
    {
        public string Name { get; private set; }
        public int Score { get; private set; }
        public char Symbol { get; private set; }

        public bool IsTurn { get; private set; } = false;

        public Player(string name, char symbol)
        {
            this.Name = name;
            this.Symbol = symbol;
            this.Score = 0;
        }

        /// <summary>
        /// Adds a point to the player's score
        /// </summary>
        public void AddScore()
        {
            Score++;
            OnPropertyChanged(nameof(Score));

        }

        /// <summary>
        /// Changes the player's name
        /// </summary>
        /// <param name="name"></param>
        public void ChangeName(string name)
        {
            Name = name;
            OnPropertyChanged(nameof(Name));
        }

        /// <summary>
        /// Changes the player's symbol
        /// </summary>
        /// <param name="symbol"></param>
        public void ChangeSymbol(char symbol)
        {
            Symbol = symbol;
            OnPropertyChanged(nameof(Symbol));
        }

        /// <summary>
        /// Sets whether it's the player's turn
        /// </summary>
        /// <param name="isTurn"></param>
        public void SetTurn(bool isTurn)
        {
            IsTurn = isTurn;
            OnPropertyChanged(nameof(IsTurn));
        }




        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

}
}
