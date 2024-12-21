using CharacterManager4.Services.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using ReactiveUI;
namespace CharacterManager4.ViewModels;

public class MainViewModel : ViewModelBase
{
    public string Greeting {get; set;}

    public MainViewModel(IDataManager test) {
    }
}

//https://www.reactiveui.net/docs/getting-started/compelling-example.html
//https://docs.avaloniaui.net/docs/reference/controls/textblock