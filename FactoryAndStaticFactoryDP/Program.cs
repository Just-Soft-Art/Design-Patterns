using System;
using System.Linq;

namespace FactoryMethod
{
    enum Skills
    {
        Jenkins,
        Docker,
        TeamCity,
        CSharp,
        CleanCode,
        Selenium,
        Postman,
        BlazeMeter
    }

    interface IEmployee
    {

    }

    class DevOps : IEmployee
    {

    }

    class CSharpDeveloper : IEmployee
    {

    }

    class Tester : IEmployee
    {

    }

    interface IHiringAgency
    {
        IEmployee Hire(Skills[] expectedSkills);
    }

    class EmployeeFactory : IHiringAgency
    {
        public IEmployee Hire(Skills[] expectedSkills)
        {
            if (Enumerable.SequenceEqual(expectedSkills,
                new[] { Skills.Jenkins, Skills.Docker, Skills.TeamCity }))
            {
                return new DevOps();
            }
            if (Enumerable.SequenceEqual(expectedSkills,
                new[] { Skills.CSharp, Skills.CleanCode }))
            {
                return new CSharpDeveloper();
            }
            if (Enumerable.SequenceEqual(expectedSkills,
                new[] { Skills.Selenium, Skills.Postman, Skills.BlazeMeter }))
            {
                return new Tester();
            }
            throw new ArgumentException("Unexpected skillset");

        }
    }

    //this class implement STATIC Factory Method design pattern - not to be confused with Factory Method design pattern!
    class BankAccount
    {
        private int _maxWithdrawalSum;

        private BankAccount(bool isForChildren)
        {
            if (isForChildren)
            {
                _maxWithdrawalSum = 1000;
            }
            else
            {
                _maxWithdrawalSum = 10000;
            }
        }

        public static BankAccount ForChildren()
        {
            return new BankAccount(true);
        }

        public static BankAccount Regular()
        {
            return new BankAccount(false);
        }
    }

    //public class MyService
    //{
    //    private MyService() { }

    //    public static async Task<MyService> CreateAsync()
    //    {
    //        await Task.Delay(100); // Simulate async work
    //        return new MyService();
    //    }
    //}

    //static async Task Main()
    //    {
    //        var service = await MyService.CreateAsync();
    //        Console.WriteLine("Service created!");
    //    } // Uncomment this part to test the async factory method



    class Program
    {
        static void Main(string[] args)
        {
            var firstEmployeeRequiredSkills = new[] { Skills.Jenkins, Skills.Docker, Skills.TeamCity };
            var secondEmployeeSkills = new[] { Skills.CSharp, Skills.CleanCode };
            var thirdEmployeeSkills = new[] { Skills.Selenium, Skills.Postman, Skills.BlazeMeter };

            IEmployee? employee = new EmployeeFactory().Hire(firstEmployeeRequiredSkills);
            Console.WriteLine($"Hired employee is {employee}");

            var bankAccount = BankAccount.ForChildren();
            var otherBankAccount = BankAccount.Regular();

            Console.ReadKey();
        }
    }

    interface INew
    {
        Task<string> GetAsync();
    }
    class Old
    {
        public Task<string> FetchAsync() => Task.FromResult("Old");
    }
    class Adapter : INew
    {
        private Old _old;

        public Adapter(Old old)
        {
            _old = old;
        }

        public Task<string> GetAsync()
        {
            return _old.FetchAsync();
        }
    }

    class P
    {
        static async Task Main()
        {
            string s = await new Adapter(new Old()).GetAsync();
            System.Console.WriteLine(s);
        }
    }

}
