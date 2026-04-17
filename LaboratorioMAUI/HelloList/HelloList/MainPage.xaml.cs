using HelloList.models;

namespace HelloList
{
    public partial class MainPage : ContentPage
    {
        List<Frutto> frutti;

        public MainPage()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            throw new NotImplementedException();
        }

        private void ShowGUI()
        {
            frutti = new List<Frutto>();
            frutti.Add(new Frutto("mela", "italia"));
            frutti.Add(new Frutto("Svizzera", "svizzera"));
        }

    }

}
