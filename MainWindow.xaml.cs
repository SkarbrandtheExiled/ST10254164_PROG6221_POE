using ST10254164_PROG6221_POE.Classes;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ST10254164_PROG6221_POE
{
    /// <summary>
    /// 
    /// </summary>
    public partial class MainWindow : Window
    {
        private ingredientClass recipeData;
        public MainWindow()
        {
            InitializeComponent();
            recipeData = new ingredientClass();
        }
        private void ViewRecipesButton_Click(object sender, RoutedEventArgs e)
        {
            recipeData.DisplayAllRecipes();
        }

        private void AddRecipeButton_Click(object sender, RoutedEventArgs e)
        {
            recipeData.Ingredients();
        }

        private void SearchRecipesButton_Click(object sender, RoutedEventArgs e) 
        {
           recipeChoiceClass searchRecipe = new recipeChoiceClass();
            searchRecipe.RecipeChoice(recipeData);
        }

        private void ClearButton_Click(object sender, RoutedEventArgs e)
        {
                    deleteRecipeClass deleteRecipe = new deleteRecipeClass();
            deleteRecipe.DeleteData(recipeData);
        }

        private void ExitButton_Click(object sender, RoutedEventArgs e)
        {
        Application.Current.Shutdown();
    }

        private void ScaleRecipeButton_Click(object sender, RoutedEventArgs e)
        {
        recipeData.QuantityScaling();
    }

        private void ResetRecipeButton_Click(object sender, RoutedEventArgs e)
        {
recipeData.ResetQuantities();
        }
     public string ShowInputDialog(string prompt)
        {
            addRecipeView dialog = new addRecipeView(prompt);
            if (dialog.ShowDialog() == true)
            {
                return dialog.ResponseText;
            }
            return null;
        }
    }
}
