using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.IO;
using System.IO.IsolatedStorage;
using System.Linq;
using System.Net;
using System.Runtime.Serialization;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using Microsoft.WindowsAzure.MobileServices;
using Project.Models;

namespace Project.Views
{
    public partial class RegisterScreen : PhoneApplicationPage
    {
        private List<User> users;
        public RegisterScreen()
        {
            InitializeComponent();
        }


        private async void SignUpBtn_OnClickancel_1(object sender, RoutedEventArgs e)
        {
            if (!Regex.IsMatch(Naam.Text.Trim(), @"^[A-Za-z_][a-zA-Z0-9_\s]*$"))
            {
                MessageBox.Show("Ongeldige naam");
            }
            else if (Password.Password.Length < 6)
            {
                MessageBox.Show("Paswoordlengte moet minimum 6 characters bezitten!");
            }
            else
            {
                Boolean userExists = false;
                User user = new User();
                user.Username = Naam.Text;
                user.Password = Password.Password;

                Debug.WriteLine("Begin");
                ObservableCollection<User> ocUsers = await GetUsersFromCloudAsync();
                List<User> users = ocUsers.ToList();
                foreach (User userObj in users)
                {
                    if (user.Username == userObj.Username)
                    {
                        userExists = true;
                    }
                }
                if (userExists)
                {
                    MessageBox.Show("Gebruiker bestaat al");
                }
                else
                {
                    App.MobileService.GetTable<User>().InsertAsync(user);
                    NavigationService.Navigate(new Uri("/Views/LoginScreen.xaml", UriKind.Relative));
                }
            }
        }
        public async Task<ObservableCollection<User>> GetUsersFromCloudAsync()
        {
            List<User> users =
            await App.MobileService.GetTable<User>().Take(100).ToListAsync();
            return new ObservableCollection<User>(users);
        }
        //    //After validation success ,store user detials in isolated storage  
        //    else if (naam.Text != "" && pwd.Password != "")
        //    {
        //        UserControl ObjUserData = new UserControl();
        //        ObjUserData.Naam = naam.Text;
        //        ObjUserData.p = pwd.Password;

        //        int Temp = 0;
        //        foreach (var UserLogin in ObjUserDataList)
        //        {
        //            if (ObjUserData.UserName == UserLogin.UserName)
        //            {
        //                Temp = 1;
        //            }
        //        }
        //        //Checking existing user names in local DB  
        //        if (Temp == 0)
        //        {
        //            ObjUserDataList.Add(ObjUserData);
        //            if (ISOFile.FileExists("RegistratioeDetails"))
        //            {
        //                ISOFile.DeleteFile("RegistratieDetails");
        //            }
        //            using (IsolatedStorageFileStream fileStream = ISOFile.OpenFile("RegistrationDetails", FileMode.Create))
        //            {
        //                DataContractSerializer serializer = new DataContractSerializer(typeof(List<UserData>));

        //                serializer.WriteObject(fileStream, ObjUserDataList);

        //            }
        //            MessageBox.Show("Congrats! U bent succesvol geregistered.");
        //            NavigationService.Navigate(new Uri("/Views/LoginPage.xaml", UriKind.Relative));
        //        }
        //        else
        //        {
        //            MessageBox.Show("Sorry! Gebruikersnaam al in gebruik.");
        //        }

        //    }
        //    else
        //    {
        //        MessageBox.Show("Vul alles velden in!");
        //    }
        //}

        private void CancelBtn_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}