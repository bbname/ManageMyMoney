using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using MMM.Model;
using MMM.Repository.Interfaces;
using Moq;

namespace MMM.Repository.Mocks
{
    public class AccountRead
    {
        private Mock<IAccountReadRepository> _mock;
        public AccountRead(Mock<IAccountReadRepository> mock)
        {
            this._mock = mock;
        }

        private void ConfigureMock()
        {
            this._mock.Setup(m => m.GetAllData()).Returns(new List<Account>
            {
                new Account{Id = 1, Name = "Test 1", Balance = 1302.31M, Currency = (int)CurrencyFormat.PLN, User = new User{FirstName = "Janusz", LastName = "Testowy"}},
                new Account{Id = 2, Name = "Test 2", Balance = 33123.21M, Currency = (int)CurrencyFormat.EUR, User = new User{FirstName = "Stanisław", LastName = "Konik"}},
                new Account{Id = 3, Name = "Test 3", Balance = 600.00M, Currency = (int)CurrencyFormat.GBP, User = new User{FirstName = "Władysław", LastName = "Zamknięty"}},
                new Account{Id = 4, Name = "Test 4", Balance = 8900.00M, Currency = (int)CurrencyFormat.PLN, User = new User{FirstName = "Michalina", LastName = "Zasłabła"}},
                new Account{Id = 5, Name = "Test 5", Balance = 165432.99M, Currency = (int)CurrencyFormat.USD, User = new User{FirstName = "Grażyna", LastName = "Smaruj-Rogala"}}
            });
        }

        public Mock<IAccountReadRepository> GetMock()
        {
            this.ConfigureMock();
            return this._mock;
        }
    }
}
