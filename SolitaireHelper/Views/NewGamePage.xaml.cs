using SolitaireHelper.Models;
using SolitaireHelper.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SolitaireHelper.Views
{
    public partial class NewGamePage : ContentPage
    {
        public Game game { get; set; }

        public NewGamePage()
        {
            InitializeComponent();
            BindingContext = new NewGameViewModel();
        }
    }
}