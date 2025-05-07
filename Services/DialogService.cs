using System.Threading.Tasks;
using Commandeez.Contracts.Services;
using Commandeez.ViewModels;
using Commandeez.Views;
using Microsoft.UI.Xaml.Controls;

namespace Commandeez.Services;

public class DialogService : IDialogService
{
    public async Task<(ContentDialogResult Result, CustomCommandViewModel? ViewModel)> ShowEditCommandDialogAsync(CustomCommandViewModel? viewModel = null)
    {
        CustomCommandDialog dialog;
        if (viewModel != null)
        {
            // Use the provided ViewModel for editing
            dialog = new CustomCommandDialog(viewModel);
        }
        else
        {
            // Create a new ViewModel for adding
            dialog = new CustomCommandDialog(); 
        }

        // IMPORTANT: Set XamlRoot for ContentDialog. 
        // In WinUI 3, ContentDialog needs XamlRoot to be set correctly to display.
        // App.MainWindow is the main window of your application.
        if (App.MainWindow?.Content?.XamlRoot != null)
        {
            dialog.XamlRoot = App.MainWindow.Content.XamlRoot;
        }
        else
        {
            // Fallback or error handling if XamlRoot is not available
            // This might happen if the dialog is shown too early or the window structure is unexpected.
            // Consider logging an error or throwing an exception.
            // For now, we'll let it potentially fail if XamlRoot isn't found, to highlight the issue if it occurs.
        }

        var result = await dialog.ShowAsync();
        return (result, dialog.ViewModel);
    }
}
