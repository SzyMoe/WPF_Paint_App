using System.Windows;
using System.Windows.Media;
namespace Grafika_Komputerowa_Projekt
{
    public partial class ColorPickerWindow : Window
    {
        public event Action<Color> ColorSelected;
        
        public ColorPickerWindow()
        {
            InitializeComponent();
        }

        int r;
        int g;
        int b;

        private void onApplyColorButtonPressed(object sender, RoutedEventArgs e)
        {
            // Get the values from the TextBoxes
            if (int.TryParse(R_value.Text, out int r_value) && int.TryParse(G_value.Text, out int g_value) && int.TryParse(B_value.Text, out int b_value))
            {
                // Ensure the values are within the valid range (0-255)
                r = Math.Clamp(r_value, 0, 255);
                g = Math.Clamp(g_value, 0, 255);
                b = Math.Clamp(b_value, 0, 255);

                // Create a Color from the RGB values
                Color color = Color.FromRgb((byte)r, (byte)g, (byte)b);

                // Set the Fill property of the Rectangle to the new color
                colorPreviewBox.Fill = new SolidColorBrush(color);

                // Pass selected color to Main Window
                ColorSelected?.Invoke(color);
            }
            else
            {
                MessageBox.Show("Please enter valid numeric values for R, G, and B.");
            }
        }

        private void onConvertToHsvButtonPressed(object sender, RoutedEventArgs e)
        {

            double R_prim = r / 255.0;
            double G_prim = g / 255.0;
            double B_prim = b / 255.0;
            double C_max = new[] { R_prim, G_prim, B_prim }.Max();
            double C_min = new[] { R_prim, G_prim, B_prim }.Min();
            double delta = C_max - C_min;

            double H = 0;
            if (delta != 0)
            {
                if (C_max == R_prim)
                {
                    H = 60.0 * (((G_prim - B_prim) / delta) % 6);
                }
                else if (C_max == G_prim)
                {
                    H = 60.0 * (((B_prim - R_prim) / delta) + 2);
                }
                else if (C_max == B_prim)
                {
                    H = 60.0 * (((R_prim - G_prim) / delta) + 4);
                }
            }

            if (H < 0)
            {
                H += 360.0;
            }

            double S = (C_max == 0) ? 0 : delta / C_max;
            double V = C_max;

            hsvDisplay.Text = $"HSV: {H:F2}° {S * 100.0:F2}% {V * 100.0:F2}%";
        }
    }
}
