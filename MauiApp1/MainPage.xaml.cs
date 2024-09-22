using System.ComponentModel;

namespace MauiApp1
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }
        private void Slider_ValueChanged(object sender, ValueChangedEventArgs e)
        {
            var red = sldRed.Value;
            var green = sldGreen.Value;
            var blue = sldBlue.Value;
            Color color = Color.FromRgb(red, green, blue);

            SetColor(color);
        }
        private void SetColor(Color color)
        {
            btnRand.BackgroundColor = color;
            Container.BackgroundColor = color;
            lblHex.Text = color.ToHex();
            HexEntry.Text = color.ToHex();
        }

        private void btnRand_Clicked(object sender, EventArgs e)
        {
            var random = new Random();

            var color = Color.FromRgb(
                random.Next(0, 256),
                random.Next(0, 256),
                random.Next(0, 256));

            SetColor(color);

            sldRed.Value = color.Red;
            sldGreen.Value = color.Green;
            sldBlue.Value = color.Blue;
        }
        
        private void btnSet_Clicked(object sender, EventArgs e)
        {
            string hex = HexEntry.Text;

            // Validate hex input
            if (IsHexColor(hex))
            {
                Color color = Color.FromArgb(hex);
                Container.BackgroundColor = color;
                lblHex.Text = hex; // Update label with the hex value
            }
            else
            {
                // Handle invalid hex code
                DisplayAlert("Invalid Hex Code", "Please enter a valid hex color code (e.g. #FF5733).", "OK");
            }
        }
        private bool IsHexColor(string hex)
        {
            return !string.IsNullOrEmpty(hex) && hex.Length == 7 && hex.StartsWith("#");
        }
    }
}
