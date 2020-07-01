namespace IG
{
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Threading.Tasks;
    using System.Windows.Input;
    using Acr.UserDialogs;
    using AutoMapper;
    using IG.Common;
    using Prism.Commands;
    using Prism.Services;
    using PropertyChanged;
    using Xamarin.Essentials;

    public class MainPageViewModel : BaseViewModel
    {
        readonly IUserDialogs dialogs = UserDialogs.Instance;

        readonly ICountriesService countriesService;
        readonly IMapper mapper;
        readonly IPageDialogService pageDialogService;

        public string Country { get; set; }
        public bool IsBusy { get; set; }

        [DoNotNotify]
        public IList<CountryViewModel> AllCountries { get; set; }
        public ObservableCollection<CountryViewModel> Countries { get; set; }

        public ICommand SearchCountryCommand { get; set; }

        public MainPageViewModel(ICountriesService countriesService, IMapper mapper, IPageDialogService pageDialogService)
        {
            this.countriesService = countriesService;
            this.mapper = mapper;
            this.pageDialogService = pageDialogService;

            SearchCountryCommand = new DelegateCommand(async () => await SearchCountry());
        }

        public override void OnAppearing()
        {
            base.OnAppearing();

            _ = LoadCountries();
        }

        private void OnCountryChanged()
        {
            if (string.IsNullOrEmpty(Country))
            {
                _ = LoadCountries();
            }
        }

        private async Task SearchCountry()
        {
            if (IsBusy)
            {
                return;
            }

            try
            {
                if (string.IsNullOrEmpty(Country) == false)
                {
                    using (dialogs.Loading())
                    {
                        IsBusy = true;
                        var response = await countriesService.GetByName(Country);

                        var countries = mapper.Map<List<CountryViewModel>>(response);
                        AddCountries(countries);
                    }
                }
            }
            catch (Exception ex)
            {
                await pageDialogService.DisplayAlertAsync("IG", ex.Message, "OK");
            }
            finally
            {
                IsBusy = false;
            }
        }
       
        private async Task LoadCountries()
        {
            if (IsBusy)
            {
                return;
            }

            try
            {
                using (dialogs.Loading())
                {
                    IsBusy = true;
                    var response = await countriesService.GetAll();
                    var countries = mapper.Map<List<CountryViewModel>>(response);
                    AddCountries(countries);
                }
                    
            }
            catch (Exception ex)
            {
                await pageDialogService.DisplayAlertAsync("IG", ex.Message, "OK");
            }
            finally
            {
                IsBusy = false;
            }
        }

        private void AddCountries(List<CountryViewModel> countries)
        {
            countries.ForEach((country) => { country.GoTo += Country_GoTo; });
            Countries = new ObservableCollection<CountryViewModel>(countries);
        }

        private async Task Country_GoTo(CountryViewModel sender)
        {
            var location = new Location(sender.Latlng[0], sender.Latlng[1]);
            var options = new MapLaunchOptions { Name = sender.Name };

            try
            {
                await Map.OpenAsync(location, options);
            }
            catch (Exception ex)
            {
                await pageDialogService.DisplayAlertAsync("IG", "No map application available to open", "OK");
            }
        }
    }
}