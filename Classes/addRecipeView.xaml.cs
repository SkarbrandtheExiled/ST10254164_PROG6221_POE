using System.Windows;

namespace ST10254164_PROG6221_POE.Classes
{
    //********************************************START OF FILE**********************************//
    public partial class addRecipeView : Window
    {
        public string ResponseText { get; private set; }
        public addRecipeView(string prompt)
        {
            InitializeComponent();
            PromptText.Text = prompt; 
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
        }

        private void OkButton_Click(object sender, RoutedEventArgs e)
        {
            ResponseText = InputTextBox.Text;
            DialogResult = true;
        }

    }
}
//*************************************END OF FILE***********************************************//