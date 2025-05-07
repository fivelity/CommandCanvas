using CommunityToolkit.Mvvm.ComponentModel;

namespace Commandeez.ViewModels;

public partial class CustomCommandViewModel : ObservableObject
{
    [ObservableProperty]
    private string? _name;

    [ObservableProperty]
    private string? _commandText;

    [ObservableProperty]
    private string? _description;

    public CustomCommandViewModel()
    {
    }
}
