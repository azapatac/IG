namespace IG
{
    using System.Collections.Generic;
    using System.Windows.Input;
    using Prism.Commands;

    public class CountryViewModel : BaseViewModel
    {
        public event CountryDelegate GoTo;

        public string Capital { get; set; }
        public IList<double> Latlng { get; set; }
        public string Name { get; set; }
        public string Region { get; set; }
        public ICommand GoToCountryCommand { get; set; }

        public CountryViewModel()
        {
            GoToCountryCommand = new DelegateCommand(GoToCountry);
        }

        private void GoToCountry()
        {
            GoTo?.Invoke(this);
        }
    }
}