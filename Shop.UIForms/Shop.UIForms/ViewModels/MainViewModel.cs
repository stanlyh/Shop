﻿using GalaSoft.MvvmLight.Command;
using Shop.Common.Models;
using Shop.UIForms.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;

namespace Shop.UIForms.ViewModels
{
    public class MainViewModel
    {
        private static MainViewModel instance; //apuntador a la misma clase

        public User User { get; set; }

        public ObservableCollection<MenuItemViewModel> Menus { get; set; }

        public TokenResponse Token { get; set; }

        public string UserEmail { get; set; } //redundante se podria utilizar lo de User lin 16

        public string UserPassword { get; set; }

        public LoginViewModel Login { get; set; }

        public ProductsViewModel Products { get; set; }

        public AddProductViewModel AddProduct { get; set; }

        public EditProductViewModel EditProduct { get; set; }

        public RegisterViewModel Register { get; set; }

        public RememberPasswordViewModel RememberPassword { get; set; }

        public ProfileViewModel Profile { get; set; }

        public ChangePasswordViewModel ChangePassword { get; set; }

        public ICommand AddProductCommand => new RelayCommand(this.GoAddProduct);        

        public MainViewModel()
        {
            instance = this;
            this.LoadMenus();
        }

        private async void GoAddProduct()
        {
            this.AddProduct = new AddProductViewModel();
            await App.Navigator.PushAsync(new AddProductPage());
        }

        private void LoadMenus()
        {
            var menus = new List<Menu>
        {
            new Menu
            {
                Icon = "ic_info",
                PageName = "AboutPage",
                Title = "About"
            },

            new Menu
            {
                Icon = "ic_person",
                PageName = "ProfilePage",
                Title = "Modify User"
            },

            new Menu
            {
                Icon = "ic_phonelink_setup",
                PageName = "SetupPage",
                Title = "Setup"
            },

            new Menu
            {
                Icon = "ic_exit_to_app",
                PageName = "LoginPage",
                Title = "Close session"
            }
        };

            this.Menus = new ObservableCollection<MenuItemViewModel>(
                menus.Select(m => new MenuItemViewModel
            {
                Icon = m.Icon,
                PageName = m.PageName,
                Title = m.Title
            }).ToList());
        }


        public static MainViewModel GetInstance()
        {
            if (instance == null)
            {
                return new MainViewModel();
            }

            return instance;
        }
    }
}
