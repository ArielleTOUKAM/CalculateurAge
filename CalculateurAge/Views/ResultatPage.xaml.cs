//Relie le parametre "nom" de l'URL à la propriété Nom 

namespace CalculateurAge.Views;

[QueryProperty(nameof(Nom), "nom")]
[QueryProperty(nameof(Age), "age")]
public partial class ResultatPage : ContentPage
{
    //Ces proprietes sont remplies par la navigation,
    //APRES  le constructeur
    public string Nom { get; set; }
    public string Age { get; set; }

    //Construit l'arbre visuel decrit par le xaml
    public ResultatPage() => InitializeComponent();

    //Appele a chaque affichege de la page
    protected override void OnAppearing()
    {
        base.OnAppearing();
        lblMessage.Text = $"{Nom}, vous avez {Age} ans";
    }

    //".." = revenir a la page precedente   
    private async void OnRetourClicked(object s, EventArgs e)
        => await Shell.Current.GoToAsync("..");
}