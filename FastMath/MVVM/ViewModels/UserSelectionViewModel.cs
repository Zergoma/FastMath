using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using FastMath.Core.Interfaces;
using FastMath.Core.Models.UserConfiguration;
using FastMath.Serialization;

namespace FastMath.MVVM.ViewModels
{
    public partial class UserSelectionViewModel : ObservableObject
    {
        private List<UserSetting> _users = [];
        public List<UserSetting> Users
        {
            get => _users;
            set
            {
                SetProperty(ref _users, value);
            }
        }
        public IDataLayer<UserSettingCollection> UsersConfigsService { get; }
        public required UserSettingCollection AllConfigs {get; set;}
        public ICurrentUser CurrentUser { get; }

        public UserSelectionViewModel( [FromKeyedServices(DataLayerKeys.xml)] IDataLayer<UserSettingCollection> configsDataLayer,
                                       ICurrentUser currentUser)
        {
            UsersConfigsService = configsDataLayer;
            UpdateUsersList();

            CurrentUser = currentUser;

            CurrentUser.TheUser = string.Empty;
        }

        private void UpdateUsersList()
        {
            AllConfigs = UsersConfigsService.Read();
            Users = AllConfigs.Users;
        }

        private object? _selectedUser = null;
        public object? SelectedUser
        {
            get => _selectedUser;
            set
            {
                SetProperty(ref _selectedUser, value);
            }
        }


        [RelayCommand]
        async Task CreateUser()
        {
            Page page = App.Current!.Windows[0].Page!;
            var userName = await page.DisplayPromptAsync("Add TheUser", "What's your name ?");

            if (string.Empty == userName)
            {
                return;
            }

            if (Users.Any(u => string.Equals(u.Name, userName, StringComparison.OrdinalIgnoreCase)))
            {
                return;
            }
            var newUser = new UserSetting() { Name = userName };

            Users.Add(newUser);
            UsersConfigsService.Write(AllConfigs);

            UpdateUsersList();
        }

        [RelayCommand]
        async Task UserIsSelected()
        {
            if (SelectedUser is null)
            {
                return;
            }

            if (SelectedUser is UserSetting us)
            {
                var userset = Users.Where(u => string.Equals(u.Name, us.Name, StringComparison.OrdinalIgnoreCase)).FirstOrDefault();

                if (userset is not null)
                {
                    CurrentUser.TheUser = userset.Name;

                    Page page = App.Current!.Windows[0].Page!;
                    await page.Navigation.PushAsync(new AppShell());
                }
            }
        }
    }
}
