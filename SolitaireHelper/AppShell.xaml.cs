using SolitaireHelper.ViewModels;
using SolitaireHelper.Views;
using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace SolitaireHelper
{
    public partial class AppShell : Xamarin.Forms.Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute(nameof(GameDetailPage), typeof(GameDetailPage));
            Routing.RegisterRoute(nameof(NewGamePage), typeof(NewGamePage));
        }

    }
}
