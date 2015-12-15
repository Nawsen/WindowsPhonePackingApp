using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using Project.Models;

namespace Project.Views
{
    public partial class LoginScreen : PhoneApplicationPage
    {
        public LoginScreen()
        {
            InitializeComponent();
        }

        private void SignUpBtn_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/Views/RegisterScreen.xaml", UriKind.Relative));
        }

        private async void SignInBtn_Click(object sender, RoutedEventArgs e)
        {
            /*
            VERWIJDEREN
            */
            Name.Text = "mathias3";
            Password.Password = "mathias";

            if (Name.Text != "" && Password.Password != "")
            {
                Boolean validUser = false;
                User user = new User();




                Debug.WriteLine("Begin");
                ObservableCollection<User> ocUsers = await GetUsersFromCloudAsync();
                List<User> users = ocUsers.ToList();
                foreach (User userObj in users)
                {
                    if (Name.Text == userObj.Username)
                    {
                        //MessageBox.Show("Deze gebruiker bestaat al!");
                        if (Password.Password == userObj.Password)
                        {
                            user = userObj;
                            validUser = true;
                        }
                    }
                }
                if (validUser)
                {
                    PhoneApplicationService.Current.State["user"] = user;
                    NavigationService.Navigate(new Uri("/Views/Main.xaml", UriKind.Relative));
                    //Tripsss trip = new Tripsss();
                    //trip.Name = "Test";
                    //trip.Deadline = DateTime.Today.AddDays(20);

                    //Item item = new Item("New Item");
                    //trip.AddItem(item);

                    //user.AddTrip(trip);
                    //await App.MobileService.GetTable<User>().UpdateAsync(user);
                    //Debug.WriteLine(user.Trips);
                    //User newUser = (User) PhoneApplicationService.Current.State["user"];

                }
                else
                {
                    MessageBox.Show("Invalid username or password.");
                }
            }
            else
            {
                MessageBox.Show("Username and password have to be filled in!");
            }
        }
        public async Task<ObservableCollection<User>> GetUsersFromCloudAsync()
        {
            List<User> users =
            await App.MobileService.GetTable<User>().Take(100).ToListAsync();
            return new ObservableCollection<User>(users);
        }
    }
}