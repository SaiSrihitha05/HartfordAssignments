using System;
namespace Test
{
    delegate void Print();
    class Money
    {
        protected uint note;
        protected uint coin;
        public Money(uint n, uint c)
        {
            this.note = n;
            this.coin = c;
        }
    }
    class Rupee : Money
    {
        public Rupee(uint rupees, uint paise) : base(rupees, paise) { }
        public void Display()
        {
            Console.WriteLine("Rs. {0}.{1}", note, coin);
        }
    }
    class Dollar : Money
    {
        public Dollar(uint dollar, uint cent) : base(dollar, cent) { }
        public void Info()
        {
            Console.WriteLine("${0}.{1}", note, coin);
        }
    }
    class Test
    {
        static void Main()
        {
            Rupee m1 = new Rupee(1000, 55);
            Dollar m2 = new Dollar(100, 75);
            Print GP = m1.Display;
            GP();
            GP = m2.Info;
            GP();
        }
    }
}
