using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace ST10254164_PROG6221_POE.Classes
{
    /// <summary>
    /// Interaction logic for viewAllRecipes.xaml
    /// </summary>
    public partial class viewAllRecipes : Window
    {
        public viewAllRecipes()
        {
            InitializeComponent();
            RecipeListBox.ItemsSource = recipes;
        }

        private void SelectButton_Click(object sender, RoutedEventArgs e)
        {
            if (RecipeListBox.SelectedItem != null)
            {
                SelectedRecipe = RecipeListBox.SelectedItem.ToString();
                DialogResult = true;
            }
            else
            {
                MessageBox.Show("Please select a recipe", "choice required", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }
        private void RecipeListBox_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            // Additional logic for selection change can be added here if needed
        }
    }
}
