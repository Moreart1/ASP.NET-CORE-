namespace TimeSheets.DAL.Models
{
    public class BankAccount
    {
        public Guid BankAccountId { get; private set;}

        public DateTime DateOfOpening { get; private set;}
        public double Amount { get; private set;}
        public bool IsClosed { get; private set;}

        private Guid BankAccountIdGenerate()
        {
            return Guid.NewGuid();
        }

        public BankAccount Create()
        {
            var bank = new BankAccount();
            bank.BankAccountId = BankAccountIdGenerate();
            bank.DateOfOpening = DateTime.Now;
            bank.Amount = 0;
            bank.IsClosed = false;
            return bank;
        }

        public BankAccount IncludeSheets(BankAccount bank)
        {
            var _bank = new BankAccount();
            _bank.BankAccountId = bank.BankAccountId;
            _bank.DateOfOpening = DateTime.Now;
            _bank.Amount += bank.Amount;
            _bank.IsClosed = false;
            return _bank;
        }

        public BankAccount Close(BankAccount bank)
        {
            var _bank = new BankAccount();
            _bank.BankAccountId = bank.BankAccountId;
            _bank.DateOfOpening = DateTime.Now;
            _bank.Amount = bank.Amount;
            _bank.IsClosed = true;
            return _bank;
        }
    }
}
