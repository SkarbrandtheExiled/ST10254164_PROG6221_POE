using System.Windows;

namespace ST10254164_PROG6221_POE.Classes
{
    //********************************************START OF FILE**********************************//
    internal class deleteRecipeClass
    {
        //--------------------deleteData method---------------------------//
        //method must delete the data inputted by the user and loop the application back to the start
        public void DeleteData(ingredientClass recipeData)
        {
            //confirmation dialog to delete data
            MessageBoxResult result = MessageBox.Show("Are you sure you want to delete all your data?", "Delete Confirmation", MessageBoxButton.YesNo, MessageBoxImage.Warning);
            switch (result)
            {
                //switch case based on user response
                case MessageBoxResult.Yes:
                    //clears recipe names and reset ingredient-related arrays
                    recipeData.recipeNames.Clear();
                    recipeData.ingredientNames = null;
                    recipeData.ingredientQuantities = null;
                    recipeData.unitOfMeasurements = null;
                    recipeData.steps = null;
                    MessageBox.Show("Data deleted!", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
                    break;
                //displays all recipes if user chooses not to delete
                case MessageBoxResult.No:
                    recipeData.DisplayAllRecipes();
                    MessageBox.Show("Data still present", "Information", MessageBoxButton.OK, MessageBoxImage.Information);
                    break;
                //informs the user of invalid input
                default:
                    MessageBox.Show("Please enter a valid input", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    break;
            }
            }
        }
}
//*************************************END OF FILE***********************************************//