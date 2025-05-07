using Commandeez.ViewModels;
using Microsoft.UI.Xaml.Controls;

namespace Commandeez.Views;

public sealed partial class CustomCommandDialog : ContentDialog
{
    public CustomCommandViewModel ViewModel { get; }

    public CustomCommandDialog()
    {
        ViewModel = App.GetService<CustomCommandViewModel>(); // Resolve using DI
        this.InitializeComponent();
    }

    // Constructor to pass an existing CommandItem for editing
    public CustomCommandDialog(CustomCommandViewModel viewModel)
    {
        ViewModel = viewModel;
        this.InitializeComponent();
    }
}
