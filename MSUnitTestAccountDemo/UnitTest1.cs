namespace MSUnitTestAccountDemo
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        [DataRow(50, 150)]  
        [DataRow(-50, 100)]  
        [DataRow(0, 100)]    
        public void Deposit_TestCases(double amount, double expectedBalance)
        {
            BankAccount account = new BankAccount();

            if (amount <= 0)
            {
                Assert.ThrowsException<ArgumentException>(() => account.Deposit(amount));
                Assert.AreEqual(expectedBalance, account.GetBalance());
            }
            else
            {
                account.Deposit(amount);
                Assert.AreEqual(expectedBalance, account.GetBalance());
            }
        }

        [TestMethod]
        [DataRow(50, 50)]  
        [DataRow(150, 100)] 
        [DataRow(-50, 100)] 
        [DataRow(0, 100)]  
        public void Withdraw_TestCases(double amount, double expectedBalance)
        {
            BankAccount account = new BankAccount();

            if (amount > 100)
            { 
                Assert.ThrowsException<InvalidOperationException>(() => account.Withdraw(amount));
            }
            else if (amount <= 0)
            {
                Assert.ThrowsException<ArgumentException>(() => account.Withdraw(amount));
            }
            else
            {
                account.Withdraw(amount);
                Assert.AreEqual(expectedBalance, account.GetBalance());
            }
        }

        [TestMethod]
        [DataRow(100)]
        public void GetBalance_ShouldReturnBalance(double ExpectedOutput)
        {
            BankAccount account = new BankAccount();
            var balance = account.GetBalance();
            Assert.AreEqual(ExpectedOutput, balance);
        }

        [TestMethod]
        [DataRow(150,50)]
        public void Valid_Transfer_Test_Case(double ExpectedOutput,double amount)
        {
            BankAccount account1 = new BankAccount();
            BankAccount account2 = new BankAccount();

            var result = account1.Transfer(account2, amount);
            Assert.AreEqual(ExpectedOutput, account2.GetBalance());
        }
        [TestMethod]
        public void Transfer_AmountGreaterThanBalance()
        {
            BankAccount account1 = new BankAccount();
            BankAccount account2 = new BankAccount();

            Assert.ThrowsException<InvalidOperationException>(() => account1.Transfer(account2, 150));
        }

        [TestMethod]
        public void Transfer_ToInvalidAccount()
        {
            var account1 = new BankAccount();
            Assert.ThrowsException<ArgumentNullException>(() => account1.Transfer(null, 50));
        }
    }
}