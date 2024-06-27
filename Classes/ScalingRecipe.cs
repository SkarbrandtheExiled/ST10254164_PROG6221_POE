using System.Collections.Generic;
using System.Text;
using System.Windows;

namespace ST10254164_PROG6221_POE.Classes
{
    //********************************************START OF FILE**********************************//
    internal class ScalingRecipe
    {
        //fields to store recipe information
        private string[] ingredientNames;
        private double[] ingredientQuantities;
        private string[] unitOfMeasurements;
        private double[] calorieCount;
        private string[] foodGroup;
        private List<string> steps;

        //constructor to initialize recipe data
        public ScalingRecipe(string[] ingredientNames, double[] ingredientQuantities, string[] unitOfMeasurements, double[] calorieCount, string[] foodGroup, List<string> steps)
        {
            //assigning values from parameters to fields
            this.ingredientNames = ingredientNames;
            this.ingredientQuantities = ingredientQuantities;
            this.unitOfMeasurements = unitOfMeasurements;
            this.calorieCount = calorieCount;
            this.foodGroup = foodGroup;
            this.steps = steps;
        }

        //------------DisplayScaling method----------------------//
        //method to display scaled recipe details
        public void DisplayScaling()
        {
            //stringBuilder to build the scaled recipe details
            StringBuilder scaledRecipeDetails = new StringBuilder();

            //title and separator for scaled recipe
            scaledRecipeDetails.AppendLine("Scaled Recipe:");
            scaledRecipeDetails.AppendLine("-----------------------\n");
            //displaying ingredients with quantities, units, calories, and food groups
            scaledRecipeDetails.AppendLine("Ingredients:");
            for (int i = 0; i < ingredientNames.Length; i++)
            {
                scaledRecipeDetails.AppendLine($"{ingredientQuantities[i]} {unitOfMeasurements[i]} of {ingredientNames[i]} (calories: {calorieCount[i]}, food group: {foodGroup[i]})");
            }
            //separator before steps
            scaledRecipeDetails.AppendLine("------------------------\n");
            //displaying steps with numbered list
            scaledRecipeDetails.AppendLine("Steps:");
            for (int i = 0; i < steps.Count; i++)
            {
                scaledRecipeDetails.AppendLine($"{i + 1}: {steps[i]}");
            }
            scaledRecipeDetails.AppendLine("---------------------------\n");
            //showing the scaled recipe details in a message box
            MessageBox.Show(scaledRecipeDetails.ToString(), "Scaled Recipe Details", MessageBoxButton.OK, MessageBoxImage.Information);
        }
    }
}
//*************************************END OF FILE***********************************************//