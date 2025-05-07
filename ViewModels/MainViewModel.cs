using System.Collections.ObjectModel;
using System.Windows.Input;
using Commandeez.Models;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace Commandeez.ViewModels;

public partial class MainViewModel : ObservableObject
{
    public ObservableCollection<CommandItem> CommandQueue { get; }

    [ObservableProperty]
    [NotifyCanExecuteChangedFor(nameof(EditCommandCommand))]
    [NotifyCanExecuteChangedFor(nameof(RemoveCommandCommand))]
    [NotifyCanExecuteChangedFor(nameof(MoveCommandUpCommand))]
    [NotifyCanExecuteChangedFor(nameof(MoveCommandDownCommand))]
    private CommandItem? _selectedCommand;

    public MainViewModel()
    {
        CommandQueue = new ObservableCollection<CommandItem>();
        LoadSampleCommands(); // For testing purposes
    }

    private void LoadSampleCommands()
    {
        CommandQueue.Add(new CommandItem("SFC Scan", "sfc /scannow", "Scans integrity of all protected system files."));
        CommandQueue.Add(new CommandItem("DISM Check Health", "DISM /Online /Cleanup-Image /CheckHealth", "Checks if the component store is corrupted."));
        CommandQueue.Add(new CommandItem("Ping Google", "ping google.com", "Pings google.com to check internet connectivity."));
    }

    [RelayCommand]
    private void AddCommand()
    {
        // Placeholder for Add command logic
        System.Diagnostics.Debug.WriteLine("AddCommand executed");
    }

    [RelayCommand(CanExecute = nameof(CanExecuteEditOrRemoveCommand))]
    private void EditCommand()
    {
        // Placeholder for Edit command logic
        if (SelectedCommand != null)
        {
            System.Diagnostics.Debug.WriteLine($"EditCommand executed for: {SelectedCommand.Name}");
        }
    }

    [RelayCommand(CanExecute = nameof(CanExecuteEditOrRemoveCommand))]
    private void RemoveCommand()
    {
        // Placeholder for Remove command logic
        if (SelectedCommand != null)
        {
            System.Diagnostics.Debug.WriteLine($"RemoveCommand executed for: {SelectedCommand.Name}");
            CommandQueue.Remove(SelectedCommand);
        }
    }

    [RelayCommand(CanExecute = nameof(CanExecuteMoveCommandUp))]
    private void MoveCommandUp()
    {
        // Placeholder for Move Up logic
        if (SelectedCommand != null)
        {
            System.Diagnostics.Debug.WriteLine($"MoveCommandUp executed for: {SelectedCommand.Name}");
            int index = CommandQueue.IndexOf(SelectedCommand);
            if (index > 0)
            {
                CommandQueue.Move(index, index - 1);
            }
        }
    }

    [RelayCommand(CanExecute = nameof(CanExecuteMoveCommandDown))]
    private void MoveCommandDown()
    {
        // Placeholder for Move Down logic
        if (SelectedCommand != null)
        {
            System.Diagnostics.Debug.WriteLine($"MoveCommandDown executed for: {SelectedCommand.Name}");
            int index = CommandQueue.IndexOf(SelectedCommand);
            if (index < CommandQueue.Count - 1)
            {
                CommandQueue.Move(index, index + 1);
            }
        }
    }

    [RelayCommand(CanExecute = nameof(CanExecuteClearQueue))]
    private void ClearQueue()
    {
        // Placeholder for Clear Queue logic
        System.Diagnostics.Debug.WriteLine("ClearQueue executed");
        CommandQueue.Clear();
    }

    [RelayCommand]
    private void SaveQueue()
    {
        // Placeholder for Save Queue logic
        System.Diagnostics.Debug.WriteLine("SaveQueue executed");
    }

    [RelayCommand]
    private void LoadQueue()
    {
        // Placeholder for Load Queue logic
        System.Diagnostics.Debug.WriteLine("LoadQueue executed");
    }

    private bool CanExecuteEditOrRemoveCommand()
    {
        return SelectedCommand != null;
    }

    private bool CanExecuteMoveCommandUp()
    {
        return SelectedCommand != null && CommandQueue.IndexOf(SelectedCommand) > 0;
    }

    private bool CanExecuteMoveCommandDown()
    {
        return SelectedCommand != null && CommandQueue.IndexOf(SelectedCommand) < CommandQueue.Count - 1;
    }

    private bool CanExecuteClearQueue()
    {
        return CommandQueue.Count > 0;
    }
}
