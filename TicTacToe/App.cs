namespace TicTacToe
{
    public partial class App : Form
    {
        private StartMenu startMenu;
        private MainContainer mainContainer;
        public App()
        {
            InitializeComponent();
            startMenu = new StartMenu();

            this.Controls.Add(startMenu);

            startMenu.SetStartButtonClickEvent(start_Click);
            startMenu.SetExitButtonClickEvent(exit_Click);
        }

        private void exit_Click(object? sender, EventArgs e)
        {
            //TODO: Ask the user if they want to exit the game
            Environment.Exit(0);
        }

        private void start_Click(object? sender, EventArgs e)
        {
            string player1Name = startMenu.GetPlayer1Name();
            string player2Name = startMenu.GetPlayer2Name();

            player1Name = player1Name == "" ? "Player 1" : player1Name;
            player2Name = player2Name == "" ? "Player 2" : player2Name;
            
            this.Controls.Remove(startMenu);
            mainContainer = new MainContainer(player1Name:player1Name, player2Name:player2Name);
            this.Controls.Add(mainContainer);
            
        }
    }
}
