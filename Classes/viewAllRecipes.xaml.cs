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
        public List<string> RecipeNames { get; private set; }
        public string SelectedRecipe { get; private set; }

        public viewAllRecipes(List<string> recipeNames)
        {
            InitializeComponent();
            RecipeNames = recipeNames;
            RecipeListBox.ItemsSource = RecipeNames;
        }

        private void SelectButton_Click(object sender, RoutedEventArgs e)
        {
            if (RecipeListBox.SelectedItem != null)
            {
                SelectedRecipe = RecipeListBox.SelectedItem.ToString();
                DialogResult = true; // Close the dialog and return true
            }
            else
            {
                MessageBox.Show("Please select a recipe.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
//*************************************END OF FILE***********************************************//
