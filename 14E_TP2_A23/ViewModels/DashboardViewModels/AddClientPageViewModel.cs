﻿using _14E_TP2_A23.Services;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.ComponentModel.DataAnnotations;

namespace _14E_TP2_A23.ViewModels.DashboardViewModels
{
    /// <summary>
    /// View model de AddClientPage.xaml
    /// </summary>
    public partial class AddClientPageViewModel : ObservableValidator
    {
        #region Propriétés
        private const int _fullNameMinLength = 1;
        private const int _fullNameMaxLength = 70;

        private const int _emailMinLength = 1;
        private const int _emailMaxLength = 320;

        [ObservableProperty]
        [NotifyDataErrorInfo]
        [MinLength(_fullNameMinLength, ErrorMessage = "Le nom d'utilisateur doit contenir au moins 1 caractères")]
        [MaxLength(_fullNameMaxLength, ErrorMessage = "Le nom d'utilisateur doit contenir au plus 70 caractères")]
        private string? _fullName;

        [ObservableProperty]
        [NotifyDataErrorInfo]
        [MinLength(_emailMinLength, ErrorMessage = "Le courriel doit contenir au moins 1 caractères")]
        [MaxLength(_emailMaxLength, ErrorMessage = "Le courriel doit contenir au plus 320 caractères")]
        [RegularExpression(@"^[\w-\.]+@([\w-]+\.)+[\w-]{2,4}$", ErrorMessage = "Le courriel n'est pas valide")]
        private string? _email;

        [ObservableProperty]
        private DateTime? _membershipStartDate = DateTime.Today;

        [ObservableProperty]
        private bool? _isMembershipActive;

        /// <summary>
        /// Service de navigation injecté par le service provider
        /// </summary>
        private readonly IAppNavigationService _appNavigtionService;
        #endregion

        #region Constructeur
        public AddClientPageViewModel(IAppNavigationService appNavigtionService)
        {
            _appNavigtionService = appNavigtionService;
        }

        #endregion

        #region Commandes
        [RelayCommand]
        /// <summary>
        /// Ajoute un client
        /// </summary>
        public void AddCustomer()
        {
            if (!IsFormValid())
            {
                return;
            }

            // TODO : ajouter le client
        }

        [RelayCommand]
        /// <summary>
        /// Commande retourner à la page précédente
        /// </summary>
        public void GoBack()
        {
            _appNavigtionService.GoBack();
        }
        #endregion

        #region Validation
        /// <summary>
        /// Valide le formulaire
        /// </summary>
        private bool IsFormValid()
        {
            if (string.IsNullOrEmpty(FullName) || string.IsNullOrEmpty(Email))
            {
                return false;
            }

            // Valide le formulaire
            ValidateAllProperties();

            if (HasErrors)
            {
                return false;
            }

            if (FullName.Length < _fullNameMinLength || FullName.Length > _fullNameMaxLength)
            {
                return false;
            }

            if (Email.Length < _emailMinLength || Email.Length > _emailMaxLength)
            {
                return false;
            }

            // Valider si courriel est valide (regex)
            if (!new EmailAddressAttribute().IsValid(Email))
            {
                return false;
            }

            // Valider si courriel est unique
            // TODO : valider si courriel est unique
            return true;
        }
        #endregion
    }
}
