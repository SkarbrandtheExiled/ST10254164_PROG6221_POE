using System.Windows;

namespace ST10254164_PROG6221_POE.Classes
{
    //********************************************START OF FILE**********************************//
    public partial class addRecipeView : Window
    {
        public string ResponseText { get; private set; }

        //method to change the prompt to ask the relevant question about the ingredient
        public addRecipeView(string prompt)
        {
            InitializeComponent();
            PromptText.Text = prompt; 
        }

        //controls the cancel button to stop the function/ action
        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
        }

        //controls the ok button and adds it to the correct list
        private void OkButton_Click(object sender, RoutedEventArgs e)
        {
            ResponseText = InputTextBox.Text;
            DialogResult = true;
        }

    }
}
//*************************************END OF FILE***********************************************//