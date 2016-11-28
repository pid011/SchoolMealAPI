using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SchoolMeal;

namespace Test
{
    class Program
    {
        static void Main(string[] args)
        {
            var p = new Program();
            p.Run();
            Console.WriteLine("종료");
            Console.ReadLine();
        }

        public void Run()
        {
            Meal meal = new Meal(Regions.Gyeonggi, SchoolType.Middle, "J100005350");
            var menu = meal.GetMealMenu();

            foreach (var item in menu)
            {
                Console.WriteLine(item.ToString());
            }
        }
    }
}
