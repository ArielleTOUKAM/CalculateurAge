using System.Collections.ObjectModel;

namespace CalculateurAge.ViewModels;

public class CalculateurViewModel : BaseViewModel
{
    private string _nom = "";
    private DateTime _dateNaissance = DateTime.Today.AddYears(-20);
    private string _resultat = "";
    private bool _resultatVisible;
    private string _statut = "";
    private int _joursAvantAnniversaire;

    public string Nom
    {
        get => _nom;
        set { if (SetField(ref _nom, value)) CalculerCommand.Rafraichir(); }
    }

    public DateTime DateNaissance
    {
        get => _dateNaissance;
        set => SetField(ref _dateNaissance, value);
    }

    public string Resultat
    {
        get => _resultat;
        set => SetField(ref _resultat, value);
    }

    public bool ResultatVisible
    {
        get => _resultatVisible;
        set => SetField(ref _resultatVisible, value);
    }

    // Fonctionnalité 1 : Majeur / Mineur
    public string Statut
    {
        get => _statut;
        set => SetField(ref _statut, value);
    }

    // Fonctionnalité 3 : jours avant le prochain anniversaire
    public int JoursAvantAnniversaire
    {
        get => _joursAvantAnniversaire;
        set => SetField(ref _joursAvantAnniversaire, value);
    }

    // Fonctionnalité 4 : historique des calculs
    public ObservableCollection<string> Historique { get; } = new();

    public RelayCommand CalculerCommand { get; }
    public RelayCommand EffacerCommand { get; } // Fonctionnalité 2 : remets tous les champs à zéro

    public CalculateurViewModel()
    {
        CalculerCommand = new RelayCommand(
            Calculer,
            () => !string.IsNullOrWhiteSpace(Nom));

        EffacerCommand = new RelayCommand(Effacer);
    }

    private void Calculer()
    {
        int age = DateTime.Today.Year - DateNaissance.Year;
        if (DateNaissance.Date > DateTime.Today.AddYears(-age)) age--;

        Resultat = $"{Nom}, vous avez {age} ans";
        ResultatVisible = true;

        // Fonctionnalité 1
        Statut = age >= 18 ? "Majeur" : "Mineur";

        // Fonctionnalité 3
        DateTime prochainAnniversaire = DateNaissance.AddYears(
            DateTime.Today.Year - DateNaissance.Year);
        if (prochainAnniversaire < DateTime.Today)
            prochainAnniversaire = prochainAnniversaire.AddYears(1);
        JoursAvantAnniversaire = (prochainAnniversaire - DateTime.Today).Days;

        // Fonctionnalité 4
        Historique.Insert(0, $"{Nom} — {age} ans — calculé le {DateTime.Now:dd/MM/yyyy HH:mm}");
    }

    // Fonctionnalité 2 : Remettre tous les champs a zéro
    private void Effacer()
    {
        Nom = "";
        DateNaissance = DateTime.Today.AddYears(-20);
        Resultat = "";
        ResultatVisible = false;
        Statut = "";
        JoursAvantAnniversaire = 0;
    }
}