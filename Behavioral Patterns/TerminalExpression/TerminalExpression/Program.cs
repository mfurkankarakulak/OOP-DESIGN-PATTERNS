using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TerminalExpression
{
    class Contex
    {
        public string HexValue { get; set; }
        public int OndalikValue { get; set; }
    }

    interface ITerminalExpression
    {
        void Interpret(Contex context);
    }

    class TerminalExpA : ITerminalExpression
    {
        public void Interpret(Contex context)
        {
            if (context.HexValue.Contains("A"))
                context.OndalikValue += 10;
        }
    }

    class TerminalExpB : ITerminalExpression
    {
        public void Interpret(Contex context)
        {
            if (context.HexValue.Contains("B"))
                context.OndalikValue += 11;
        }
    }

    class TerminalExpC : ITerminalExpression
    {
        public void Interpret(Contex context)
        {
            if (context.HexValue.Contains("C"))
                context.OndalikValue += 12;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Contex c = new Contex { HexValue = "ABCABB" };

            List<ITerminalExpression> ExpList = new List<ITerminalExpression>();

            foreach (char item in c.HexValue.ToCharArray())
            {
                switch (item)
                {
                    case 'A':
                        ExpList.Add(new TerminalExpA());
                        break;
                    case 'B':
                        ExpList.Add(new TerminalExpB());
                        break;
                    case 'C':
                        ExpList.Add(new TerminalExpC());
                        break;
                    default:
                        throw new Exception("Geçersiz karakter " + item + " ...");
                }
            }

            foreach (ITerminalExpression item in ExpList)
            {
                item.Interpret(c);
            }

            Console.WriteLine(c.OndalikValue);
            Console.ReadKey();
        }
    }
}
