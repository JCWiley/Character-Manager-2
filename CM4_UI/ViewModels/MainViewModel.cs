using CM4_Core.LogicalGroupInterfaces;
using CM4_Core.Models;
using DynamicData.Binding;
using System.Collections.Generic;

namespace CM4_UI.ViewModels;

public class MainViewModel : ViewModelBase
{
    public List<Character> characters { get; set; }
    public MainViewModel(IPeople people)
    {
        characters = people.GetCharacters();
    }
    public string Greeting => "Welcome to Avalonia!";
}
