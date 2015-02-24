namespace AddressbookSample.Pages
{
    using AddressbookSample.ViewModel;
    using Xamarin.Forms;

    public class AddressBookListPage : ContentPage
    {
        private ListView listView;
        private ContactViewModel contactViewModel;

        public AddressBookListPage()
        {
            this.contactViewModel = new ContactViewModel();
            listView = new ListView
            {
                RowHeight = 40
            };

            var layout = new StackLayout()
            {
                // Padding = new Thickness(10, 0, 10, 0),
                VerticalOptions = LayoutOptions.FillAndExpand,
                Children = { this.listView }
            };

            this.Content = layout;
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();

            var cell = new DataTemplate(typeof(TextCell));
            cell.SetBinding(TextCell.TextProperty, "FirstName");
            cell.SetBinding(TextCell.DetailProperty, "LastName");
            listView.ItemTemplate = cell;

            await this.contactViewModel.BindContcts();

            listView.ItemsSource = this.contactViewModel.ContactList;

        }
    }
}
