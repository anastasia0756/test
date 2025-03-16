using System.Globalization;
using System.Text.RegularExpressions;

namespace Homework4
{
    public class program
    {
        static void Main(string[] args)
        {
            //1
            task1("168.190.255.0");
            task1("255.255.255.255");
            task1("1.1.1.1");
            //2
            string number = "С065МК78,Р098ЕК61,ПЩ57932,С063ХО78";
            foreach (var x in task2(number))
            {
                Console.WriteLine($"{x}");
            }
            //3
            Console.WriteLine(task3("*this is italic*"));
            Console.WriteLine(task3("**bold text(not italic)**"));
            //4
            string html = File.ReadAllText("task4Test.html");
            Console.WriteLine(task4(html));
            //5
            Console.WriteLine(task5("USD=100 RUB=200.75 USD=70 BYN=800.40 EUR=800 JPY=1000 RUB=20", "JPY"));
            Console.WriteLine(task5("USD=100 RUB=200.75 USD=70 BYN=800.40 EUR=800 JPY=1000 RUB=20", "EUR"));
            Console.WriteLine(task5("USD=100 RUB=200.75 USD=70 BYN=800.40 EUR=800 JPY=1000 RUB=20", "RUB"));
            //6
            string s = "ThisIsSomeText";
            Console.WriteLine(task6(s));
        }
        //1
        static void task1(string a)
        {
            string pattern = @"((25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)\.){3}(25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)";
            var r = Regex.Match(a, pattern);
            if (r.Success)
            {
                Console.WriteLine(r.Value);

            }

        }
        //2
        static string[] task2(string a)
        {
            string pattern = @"[А,В,Е,К,М,Н,О,Р,С,Т,У,Х]{1}\d{3}[А,В,Е,К,М,Н,О,Р,С,Т,У,Х]{2}\d{2,3}";
            var result = Regex.Matches(a, pattern).Select(x => x.Value).ToArray();
            return result;
        }
        //3
        static string task3(string a)
        {
            string pattern = @"(?<!\*)\*([^*]+?)\*(?!\*)";
            string result = Regex.Replace(a, pattern, "<em>$1</em>");
            return result;

        }
        //4
        static string? task4(string a)
        {
            string pattern = @"<[^/](.|\n)*?>";
            var result = Regex.Matches(a, pattern).Select(x => x.Value).Distinct().Aggregate("", (y, z) => y + z + " ");
            return result;
        }
        //5
        static double task5(string a, string v)
        {
            string pattern = $@"{v}=(\d+\.?\d*)";
            var result = Regex.Matches(a, pattern).Select(x => double.Parse(x.Groups[1].Value, CultureInfo.InvariantCulture)).Sum();
            return result;

        }
        //6
        static string task6(string a)
        {
            string pattern = @"(?<=[a-z])(?=[A-Z])";
            string result = Regex.Replace(a, pattern, " ");
            return result;
        }
    }
}
//1 задание
//168.190.255.0
//255.255.255.255
//1.1.1.1
//2 задание
//С065МК78
//Р098ЕК61
//С063ХО78
//3 задание
//<em>this is italic</em>
//**bold text(not italic)**
//4 задание
//<h5> <p> <span style="font-size: 15px;"> <em> <strong> <ul> <li>
//5 задание
//1000
//800
//220,75
//6 задание
//This Is Some Text
