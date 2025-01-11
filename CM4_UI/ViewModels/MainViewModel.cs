using CM4_Core.LogicalGroupInterfaces;
using CM4_Core.LogicalGroups;
using CM4_Core.Models;
using CM4_Core.Service.Interfaces;
using DynamicData.Binding;
using ReactiveUI;
using System.Collections.Generic;
using System.ComponentModel;

namespace CM4_UI.ViewModels;

public class MainViewModel : ViewModelBase
{
    IPeople _people;
    INotifyService _notifyService;
    public event PropertyChangedEventHandler PropertyChanged;

    public MainViewModel(IPeople people,INotifyService notifyService,MenuViewModel menuViewModel, OrgTreeViewModel orgTreeViewModel)
    {
        _notifyService = notifyService;
        _people = people;
        MenuViewModel = menuViewModel;
        OrgTreeViewModel = orgTreeViewModel;

        _notifyService.NotifyDataSourceChanged += HandleDataSourceChanged;
    }

    private void HandleDataSourceChanged()
    {
        Characters = _people.GetCharacters();
    }

    protected virtual void OnPropertyChanged(string propertyName)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }

    //---Commands---//
    public void AddCharacter()
    {
        Character character = new Character();
        character.Name = "tim";
        _people.AddCharacter(character);
        Characters = _people.GetCharacters();
    }

    //---Properties---//
    MenuViewModel _menuViewModel;
    public MenuViewModel MenuViewModel
    {
        get => _menuViewModel;
        set => this.RaiseAndSetIfChanged(ref _menuViewModel, value);
    }

    OrgTreeViewModel _orgTreeViewModel;
    public OrgTreeViewModel OrgTreeViewModel
    {
        get => _orgTreeViewModel;
        set => this.RaiseAndSetIfChanged(ref _orgTreeViewModel, value);
    }

    List<Character> _characters;
    public List<Character> Characters
    {
        get => _characters;
        set => this.RaiseAndSetIfChanged(ref _characters, value);
    }
}
