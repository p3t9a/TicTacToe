namespace TicTacToe
{
    internal class ControlButton : Button
    {
        public ControlButton(string text)
        {
            this.Text = text;
            this.AutoSize = true;
            this.TabStop = false;
        }
    }
}
