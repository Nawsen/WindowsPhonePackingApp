using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;

namespace Project.Views
{
    public partial class TripDetailView : PhoneApplicationPage
    {
        public TripDetailView()
        {
            InitializeComponent();
            itemList.Items.Add(new TripListItemView());
            itemList.Items.Add(new TripListItemView());
            itemList.Items.Add(new TripListItemView());

        }
    }
}