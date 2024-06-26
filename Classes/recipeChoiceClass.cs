using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace ST10254164_PROG6221_POE.Classes
{
    internal class recipeChoiceClass
    {

        private MainWindow mainWindow;

        public recipeChoiceClass()
        {
            mainWindow = (MainWindow)Application.Current.MainWindow;
        }

        public void RecipeChoice(ingredientClass recipeData)
        {
            if (recipeData.recipeNames.Count == 0)
            {
                MessageBox.Show("No recipes to display", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            StringBuilder recipeMenu = new StringBuilder("Please choose which recipe you want to view:\n");
            for (int i = 0; i < recipeData.recipeNames.Count; i++)
            {
                recipeMenu.AppendLine($"{i + 1}. {recipeData.recipeNames[i]}");
            }

            string input = mainWindow.ShowInputDialog(recipeMenu.ToString());
            if (int.TryParse(input, out int recipeIndex) &&
                recipeIndex >= 1 && recipeIndex <= recipeData.recipeNames.Count)
            {
                string selectedRecipeName = recipeData.recipeNames[recipeIndex - 1];
                MessageBox.Show($"Selected Recipe: {selectedRecipeName}");
                recipeData.DisplayRecipe();
            }
            else
            {
                MessageBox.Show("The recipe chosen does not exist. Please try again", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
//*************************************END OF FILE***********************************************//
