using System.Threading.Tasks;
using Commandeez.ViewModels;
using Microsoft.UI.Xaml.Controls;

namespace Commandeez.Contracts.Services;

public interface IDialogService
{
    Task<(ContentDialogResult Result, CustomCommandViewModel? ViewModel)> ShowEditCommandDialogAsync(CustomCommandViewModel? viewModel = null);
}
