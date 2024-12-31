using CM4_Core.LogicalGroupInterfaces;
using CM4_Core.Models;
using System.Collections.Generic;

namespace CM4_UI.ViewModels;

public class MainViewModel : ViewModelBase
{
    public MainViewModel(IPeople people)
    {
        List<Character> characters = people.GetCharacters();
    }
    public string Greeting => "Welcome to Avalonia!";
}
