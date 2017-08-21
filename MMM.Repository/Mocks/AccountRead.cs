﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using MMM.Model;
using MMM.Repository.Interfaces;
using Moq;
using MMM.Infrastructure;

namespace MMM.Repository.Mocks
{
    public class AccountRead
    {
        private Mock<IBankAccountReadRepository> _mock;
        public AccountRead(Mock<IBankAccountReadRepository> mock)
        {
            this._mock = mock;
        }

        private void ConfigureMock()
        {
            this._mock.Setup(m => m.GetAllData()).Returns(new List<BankAccount>
            {
                new BankAccount{Id = 1, Name = "Test 1 zobaczmy jak", Balance = 1302.31M, Currency = (int)CurrencyFormat.PLN, User = new User{FirstName = "Janusz", LastName = "Testowy"}, Transactions = new List<Transaction>() {new Transaction() {Id = 1, Name = "Testowa transakcja 1",AccountBalance = 500M, Amount = 32.50M, SetDate = DateTime.Now}}},
                new BankAccount{Id = 2, Name = "Test 2", Balance = 33123.21M, Currency = (int)CurrencyFormat.EUR, User = new User{FirstName = "Stanisław", LastName = "Konik"}},
                new BankAccount{Id = 3, Name = "Test 3", Balance = -600.00M, Currency = (int)CurrencyFormat.GBP, User = new User{FirstName = "Władysław", LastName = "Zamknięty"}},
                new BankAccount{Id = 4, Name = "Test 4", Balance = 0.00M, Currency = (int)CurrencyFormat.PLN, User = new User{FirstName = "Michalina", LastName = "Zasłabła"}},
                new BankAccount{Id = 5, Name = "Test 5", Balance = 165432.99M, Currency = (int)CurrencyFormat.USD, User = new User{FirstName = "Grażyna", LastName = "Smaruj-Rogala"}}
            });
        }

        public Mock<IBankAccountReadRepository> GetMock()
        {
            this.ConfigureMock();
            return this._mock;
        }
    }
}
