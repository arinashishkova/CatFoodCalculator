using System.Globalization;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using static System.Net.Mime.MediaTypeNames;

namespace CatFoodCalculator.WpfApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Calculate_Click(object sender, RoutedEventArgs e)
        {
            ResultTextBlock.Text = "";
            ErrorTextBlock.Text = "";

            if (string.IsNullOrWhiteSpace(WeightTextBox.Text) ||
               string.IsNullOrWhiteSpace(CaloriesPerKgTextBox.Text) ||
               string.IsNullOrWhiteSpace(CaloriesPer100gTextBox.Text) ||
               string.IsNullOrWhiteSpace(DaysTextBox.Text))
            {
                ErrorTextBlock.Text = "Palun täitke kõik väljad.";
                return;
            }

            CultureInfo culture = CultureInfo.GetCultureInfo("et-EE");

            if (!decimal.TryParse(WeightTextBox.Text, NumberStyles.Number, culture, out decimal weightKg) ||
                !decimal.TryParse(CaloriesPerKgTextBox.Text, NumberStyles.Number, culture, out decimal caloriesPerKg) ||
                !decimal.TryParse(CaloriesPer100gTextBox.Text, NumberStyles.Number, culture, out decimal caloriesPer100g) ||
                !int.TryParse(DaysTextBox.Text, out int days))
            {
                ErrorTextBlock.Text = "Palun sisestage korrektsed arvud.";
                return;
            }
            if (!CatFoodCalculator.Core.CatFoodCalculator.TryCalculate(
                weightKg,
                caloriesPerKg,
                caloriesPer100g,
                days,
                out decimal dailyFoodGrams,
                out decimal totalFoodKg,
                out string error))
            {
                ErrorTextBlock.Text = error;
                return;
            }

            ResultTextBlock.Text =
                $"Päevane toidukogus: {dailyFoodGrams.ToString("0.0", culture)} g\n" +
                $"{days} päevaks vajalik kogus: {totalFoodKg.ToString("0.00", culture)} kg";
        }

        private void Clear_Click(object sender, RoutedEventArgs e)
        {
            WeightTextBox.Clear();
            CaloriesPerKgTextBox.Clear();
            CaloriesPer100gTextBox.Clear();
            DaysTextBox.Clear();

            ResultTextBlock.Text = "";
            ErrorTextBlock.Text = "";

            WeightTextBox.Focus();
        }
    }
}