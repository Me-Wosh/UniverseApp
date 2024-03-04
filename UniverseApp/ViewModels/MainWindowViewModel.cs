using System.Reactive;
using ReactiveUI;

namespace UniverseApp.ViewModels;

public class MainWindowViewModel : ViewModelBase
{
    private ViewModelBase _contentViewModel = new ObjectsByCategoryViewModel();
    private bool _areTabsOpened;

    public ReactiveCommand<Unit, Unit> OpenCloseTabs { get; init; }
    public ReactiveCommand<Unit, Unit> GoToObjectsByCategoryView { get; init; }
    
    public ReactiveCommand<Unit, Unit> GoToCompareObjectsView { get; init; }
    
    public MainWindowViewModel()
    {
        OpenCloseTabs = ReactiveCommand.Create(() => { AreTabsOpened = !AreTabsOpened; });
        
        GoToObjectsByCategoryView = 
            ReactiveCommand.Create(() => { ContentViewModel = new ObjectsByCategoryViewModel(); });
        
        GoToCompareObjectsView = 
            ReactiveCommand.Create(() => { ContentViewModel = new CompareObjectsViewModel(); });
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