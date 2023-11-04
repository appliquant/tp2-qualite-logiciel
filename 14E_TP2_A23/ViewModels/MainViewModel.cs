﻿using _14E_TP2_A23.Services;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace _14E_TP2_A23.ViewModels
{
    public partial class MainViewModel : ObservableValidator
    {
        #region Propriétés
        private const int _UsernameMinLength = 1;
        private const int _UsernameMaxLength = 20;

        private const int _PasswordMinLength = 1;
        private const int _PasswordMaxLength = 20;

        [ObservableProperty]
        [NotifyDataErrorInfo]
        [MinLength(_UsernameMinLength, ErrorMessage = "Le nom d'utilisateur doit contenir au moins 1 caractères")]
        [MaxLength(_UsernameMaxLength, ErrorMessage = "Le nom d'utilisateur doit contenir au plus 20 caractères")]
        private string? _username;

        [ObservableProperty]
        [NotifyDataErrorInfo]
        [MinLength(_PasswordMinLength, ErrorMessage = "Le mot de passe doit contenir au moins 1 caractères")]
        [MaxLength(_PasswordMaxLength, ErrorMessage = "Le mot de passe doit contenir au plus 20 caractères")]
        private string? _password;

        private readonly IDALService? DAL;

        #endregion

        #region Constructeur
        public MainViewModel(IDALService dalService)
        {
            dalService = DAL;
        }

        #endregion

        #region Commandes
        [RelayCommand]
        public void Login()
        {
            if (!IsLoginFormValid())
            {
                return;
            }
            
            // Connexion
            

        }
        #endregion

        #region Méthodes de validations
        /// <summary>
        /// Valider si username et password sont remplis
        /// </summary>
        private bool IsLoginFormValid()
        {
            // Méthode de validation de ObservableValidator
            ValidateAllProperties();

            // Validation manuelle
            bool isValid = !string.IsNullOrEmpty(Username) &&
                           !string.IsNullOrEmpty(Password) &&
                           !HasErrors &&
                           Username.Length >= _UsernameMinLength &&
                           Username.Length <= _UsernameMaxLength &&
                           Password.Length >= _PasswordMinLength &&
                           Password.Length <= _PasswordMaxLength;

            return isValid;
        }

        #endregion

    }
}