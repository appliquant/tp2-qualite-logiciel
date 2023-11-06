﻿using _14E_TP2_A23.Models;
using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Threading.Tasks;

namespace _14E_TP2_A23.Services.CustomerManagement
{
    public partial class CustomerManagementService : ObservableObject, ICustomerManagementService
    {
        #region Propriétés
        private readonly IDALService _dal;
        #endregion

        #region Constructeur
        public CustomerManagementService(IDALService dalService)
        {
            _dal = dalService;
        }
        #endregion

        #region Méthodes
        /// <summary>
        /// Ajoute un client dans la base de données
        /// </summary>
        /// <param name="customer">Le client</param>
        /// <returns>True si le client est ajouté</returns>
        /// <exception cref="Exception">Si le client existe déjà</exception>
        public async Task<bool> AddCustomer(Customer customer)
        {
            try
            {
                var customerAlreadyExists = await _dal.FindCustomerByEmailAsync(customer.Email);
                if (customerAlreadyExists != null)
                {
                    throw new Exception("Le client existe déjà");
                }

                return await _dal.AddCustomerAsync(customer);
            }
            catch (Exception)
            {
                throw;
            }

        }

        /// <summary>
        /// Mettre à jour un client dans la base de données
        /// </summary>
        /// <param name="customer">Le client à ajouter</param>
        /// <returns></returns>
        public Task<bool> UpdateCustomer(Customer customer)
        {
            throw new NotImplementedException();
        }
        #endregion
    }
}
