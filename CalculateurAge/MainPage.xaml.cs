using CalculateurAge.ViewModels;

namespace CalculateurAge;

public partial class MainPage : ContentPage
{
    public MainPage()
    {
        InitializeComponent();
        //Objet dans lequell tousles {Binding} de la page 
        //vont chercher leurs vraie valeurs
        BindingContext = new CalculateurViewModel();
    }
}