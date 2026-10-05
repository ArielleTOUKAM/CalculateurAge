using CalculateurAge.Views;

namespace CalculateurAge
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            //Declare la route : sans cette ligne, GoToAsync
            //lEVE UNE EXCEPTION "ROUTE INCONNUE"
            InitializeComponent();
            Routing.RegisterRoute(nameof(ResultatPage), typeof(ResultatPage));
        }
    }
}
