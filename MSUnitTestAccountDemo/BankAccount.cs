using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MSUnitTestAccountDemo
{
    internal class BankAccount
    {
        double _balance;
        double initialBalance = 100;

        public BankAccount()
        {
            _balance = initialBalance;
        }

        public void Deposit(double amount)
        {
            if (amount <= 0)
            {
                throw new ArgumentException("Deposit Positive Amount");
            }
            _balance += amount;
        }

        public bool Withdraw(double amount)
        {
            if (amount <= 0)
            {
                throw new ArgumentException("Withdraw Positive Amount");
            }
            if (amount > _balance)
            {
                throw new InvalidOperationException("Balance is Insufficient");
            }
            _balance -= amount;
            return true;
        }

        public double GetBalance()
        {
            return _balance;
        }

        public bool Transfer(BankAccount account2, double amount)
        {
            if (account2 == null)
            {
                throw new ArgumentNullException("Target Account is not Present");
            }
            if (Withdraw(amount))
            {
                account2.Deposit(amount);
                return true;
            }
            return false;
        }
    }
}
