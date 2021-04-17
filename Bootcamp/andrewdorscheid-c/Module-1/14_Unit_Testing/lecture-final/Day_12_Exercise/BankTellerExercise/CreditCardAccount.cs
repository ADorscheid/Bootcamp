namespace BankTellerExercise
{
    public class CreditCardAccount : IAccountable
    {
        public int Debt { get; private set; }
        public string AccountHolderName { get; private set; }
        public string AccountNumber { get; private set; }
        public int Balance
        {
            get { return -Debt; }
        }

        public CreditCardAccount(string accountHolder, string accountNumber)
        {
            AccountHolderName = accountHolder;
            AccountNumber = accountNumber;
        }

        public int Pay(int amountToPay)
        {
            Debt -= amountToPay;
            return Debt;
        }

        public int Charge(int amountToCharge)
        {
            Debt += amountToCharge;
            return Debt;
        }

    }
}
