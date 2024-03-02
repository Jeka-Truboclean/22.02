namespace _22._02
{
    class Program
    {
        static void Main(string[] args)
        {
            Deposit deposit = new Deposit
            {
                Id = 1,
                FullName = "Abrahim Abrahimov Abrahimovich",
                DepositSum = 150000,
                DeadLine = 12,
                Percent = 5,
                DateTime = DateTime.Now.AddMonths(-6)
            };

            Console.WriteLine(deposit.GetInfo());
            deposit.CloseDeposit();

            Console.WriteLine(new string('-',30));

            Credit credit = new Credit
            {
                Id = 2,
                FullName = "Saitama Saitamov Saitamovich",
                DepositSum = 50000,
                DeadLine = 6,
                Percent = 10,
                DateTime = DateTime.Now.AddMonths(-3)
            };

            Console.WriteLine(credit.GetInfo());
            credit.CloseDeposit();
        }
    }
    public class Deposit
    {
        public virtual string GetInfo()
        {
            return $"Id: {Id}\nFull name: {FullName}\nDeposit: {DepositSum}\nDeadline: {DeadLine}\nPercent: {Percent}\nDate time: {DateTime}";
        }

        public virtual int Id { get; set; }
        public virtual string FullName { get; set; }
        public virtual decimal DepositSum { get; set; }
        public virtual int DeadLine { get; set; }
        public virtual int Percent { get; set; }
        public virtual DateTime DateTime { get; set; }

        public virtual decimal CloseDeposit()
        {
            int FullMonths = (DateTime.Now - DateTime).Days / 30;
            decimal Sum = DepositSum * (1 + Percent * FullMonths / 100);
            Console.WriteLine($"Deposit is closed. You got: {Sum}");
            return Sum;
        }
    }
    public class Credit : Deposit
    {
        public override decimal DepositSum
        {
            get { return base.DepositSum; }
            set
            {
                if (value > 0)
                    base.DepositSum = -value;
                else
                    throw new ArgumentException("Credit sum should be positiv.");
            }
        }
        public override string GetInfo()
        {
            return $"Id: {Id}\nFull name: {FullName}\nDeposit: {DepositSum}\nDeadline: {DeadLine}\nPercent: {Percent}\nDate time: {DateTime}";
        }
    }
}
