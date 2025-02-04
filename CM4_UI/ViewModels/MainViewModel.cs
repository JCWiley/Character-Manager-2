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

    public MainViewModel(IPeople people,MenuViewModel menuViewModel, OrgTreeViewModel orgTreeViewModel, TabViewModel tabViewModel)
    {
        _people = people;
        MenuViewModel = menuViewModel;
        OrgTreeViewModel = orgTreeViewModel;
        _tabViewModel = tabViewModel;
        TabViewModel = tabViewModel;
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

    TabViewModel _tabViewModel;
    public TabViewModel TabViewModel
    {
        get => _tabViewModel;
        set => this.RaiseAndSetIfChanged(ref _tabViewModel, value);
    }

    List<Character> _characters;
    public List<Character> Characters
    {
        get => _characters;
        set => this.RaiseAndSetIfChanged(ref _characters, value);
    }
}
