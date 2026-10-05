using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace CalculateurAge.ViewModels;

//Classe mère de tous les models
public class BaseViewModel : INotifyPropertyChanged
{
    // L EVENEMENT : le moteur de binding s y abonne
    public event PropertyChangedEventHandler PropertyChanged;

    //previent la vue qu une propriete a change
    // ?. : ne fait rien si PropertyChanged est null (aucun abonne)
    protected void OnPropertyChanged([CallerMemberName] string nom = null)
        => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nom));

    //Affecte une valeur ET notifie, en une seule ligne.
    //Renvoie true si la valeur a reelement changé.
    protected bool SetField<T>(ref T champ, T valeur, [CallerMemberName] string nom = null)
    {
        //Garde-fou : evite les notifications inutiles
        //et les boucles infinies en mode TwoWay
        if (EqualityComparer<T>.Default.Equals(champ, valeur))
            return false;
        champ = valeur;
        OnPropertyChanged(nom);
        return true;
    }
}