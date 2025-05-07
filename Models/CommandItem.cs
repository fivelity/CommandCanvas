using CommunityToolkit.Mvvm.ComponentModel;

namespace Commandeez.Models;

public partial class CommandItem : ObservableObject
{
    private string? _name;
    public string? Name
    {
        get => _name;
        set => SetProperty(ref _name, value);
    }

    private string? _commandText;
    public string? CommandText
    {
        get => _commandText;
        set => SetProperty(ref _commandText, value);
    }

    private string? _description;
    public string? Description
    {
        get => _description;
        set => SetProperty(ref _description, value);
    }

    private CommandStatus _status;
    public CommandStatus Status
    {
        get => _status;
        set => SetProperty(ref _status, value);
    }

    public CommandItem()
    {
        _status = CommandStatus.Pending;
    }

    public CommandItem(string name, string commandText, string? description = null)
    {
        _name = name;
        _commandText = commandText;
        _description = description;
        _status = CommandStatus.Pending;
    }
}
