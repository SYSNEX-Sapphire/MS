using SapphireXR_App.Common;
using SapphireXR_App.ViewModels;
using System.Windows.Controls;

namespace SapphireXR_App.Views
{
    public partial class RecipeRunPage : Page
    {
        public RecipeRunPage()
        {
            InitializeComponent();
            RecipeRunViewModel viewModel = (RecipeRunViewModel)(DataContext = App.Current.Services.GetService(typeof(RecipeRunViewModel)))!;
            flowControllerDataGridTextColumnTextBoxValidaterMaxValue = new FlowControllerDataGridTextColumnTextBoxValidaterMaxValue(viewModel, nameof(viewModel.CurrentRecipe));
            flowControllerDataGridTextColumnTextBoxValidaterOnlyNumber = new FlowControllerDataGridTextColumnTextBoxValidaterOnlyNumber(viewModel, nameof(viewModel.CurrentRecipe));
        }

        private void TextBox_TextChangedIntegerMaxNumber(object sender, TextChangedEventArgs e)
        {
            Util.CostraintTextBoxColumnMaxNumber(sender, flowControllerDataGridTextColumnTextBoxValidaterMaxValue, e, FlowControllerTextBoxValidater.NumberType.Integer);
        }

        private void TextBox_TextChangedIntegerOnlyNumber(object sender, TextChangedEventArgs e)
        {
            
             Util.CostraintTextBoxColumnOnlyNumber(sender, flowControllerDataGridTextColumnTextBoxValidaterOnlyNumber, FlowControllerTextBoxValidater.NumberType.Integer);
        }

        private void TextBox_TextChangedFloatingPointMaxNumber(object sender, TextChangedEventArgs e)
        {
            Util.CostraintTextBoxColumnMaxNumber(sender, flowControllerDataGridTextColumnTextBoxValidaterMaxValue, e, FlowControllerTextBoxValidater.NumberType.Float);
        }

        private void TextBox_TextChangedFloatingPointOnlyNumber(object sender, TextChangedEventArgs e)
        {

            Util.CostraintTextBoxColumnOnlyNumber(sender, flowControllerDataGridTextColumnTextBoxValidaterOnlyNumber, FlowControllerTextBoxValidater.NumberType.Float);
        }

        private void DataGrid_CellEditEnding(object sender, DataGridCellEditEndingEventArgs e)
        {
            Util.ConstraintEmptyToZeroOnDataGridCellCommitForRecipeRunEdit(sender, e);
        }

        private void TextBox_LostFocusTrimLastDot(object sender, System.Windows.RoutedEventArgs e)
        {
            Util.TrimLastDotOnLostFocus(sender, e);
        }

        FlowControllerDataGridTextColumnTextBoxValidaterMaxValue flowControllerDataGridTextColumnTextBoxValidaterMaxValue;
        FlowControllerDataGridTextColumnTextBoxValidaterOnlyNumber flowControllerDataGridTextColumnTextBoxValidaterOnlyNumber;
    }
}
