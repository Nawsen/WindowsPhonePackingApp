﻿#pragma checksum "C:\Users\Mathias\Documents\Windows Phone\WindowsPhonePackingApp\Project\Views\TripView.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "6D6034AD636603726F2784ACBCA7E801"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Automation.Peers;
using System.Windows.Automation.Provider;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Interop;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Resources;
using System.Windows.Shapes;
using System.Windows.Threading;


namespace Project.Views {
    
    
    public partial class TripView : System.Windows.Controls.UserControl {
        
        internal System.Windows.Controls.Grid LayoutRoot;
        
        internal System.Windows.Controls.Image tripImg;
        
        internal System.Windows.Controls.ProgressBar packingProg;
        
        internal System.Windows.Controls.TextBlock tripName;
        
        internal System.Windows.Controls.TextBlock tripDate;
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Windows.Application.LoadComponent(this, new System.Uri("/Project;component/Views/TripView.xaml", System.UriKind.Relative));
            this.LayoutRoot = ((System.Windows.Controls.Grid)(this.FindName("LayoutRoot")));
            this.tripImg = ((System.Windows.Controls.Image)(this.FindName("tripImg")));
            this.packingProg = ((System.Windows.Controls.ProgressBar)(this.FindName("packingProg")));
            this.tripName = ((System.Windows.Controls.TextBlock)(this.FindName("tripName")));
            this.tripDate = ((System.Windows.Controls.TextBlock)(this.FindName("tripDate")));
        }
    }
}

