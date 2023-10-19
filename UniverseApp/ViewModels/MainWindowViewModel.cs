using System.Reactive;
using ReactiveUI;

namespace UniverseApp.ViewModels;

public class MainWindowViewModel : ViewModelBase
{
    private ViewModelBase _contentViewModel = AllObjectsViewModel.GetViewModel();
    private bool _areTabsOpened;

    public ReactiveCommand<Unit, Unit> OpenCloseTabs { get; init; }
    public ReactiveCommand<Unit, Unit> GoToAllObjectsView { get; init; }
    public ReactiveCommand<Unit, Unit> GoToObjectsByTypeView { get; init; }
    public ReactiveCommand<Unit, Unit> GoToCompareObjectsView;
    

    public MainWindowViewModel()
    {
        OpenCloseTabs = ReactiveCommand.Create(() => { AreTabsOpened = !AreTabsOpened; });
        GoToAllObjectsView = ReactiveCommand.Create(() => { ContentViewModel = AllObjectsViewModel.GetViewModel(); });
        GoToObjectsByTypeView = ReactiveCommand.Create(() => { ContentViewModel = new ObjectsByTypeViewModel(); });
    }
    public ViewModelBase ContentViewModel
    {
        get => _contentViewModel; 
        private set => this.RaiseAndSetIfChanged(ref _contentViewModel, value);
    }

    public bool AreTabsOpened
    {
        get => _areTabsOpened; 
        set => this.RaiseAndSetIfChanged(ref _areTabsOpened, value);
    }
}