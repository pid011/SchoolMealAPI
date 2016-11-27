using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SchoolMeal;
using System.Collections.Generic;

namespace SchoolMealTests
{
    [TestClass]
    public class UnitTest1
    {
        private List<MealMenu> menu;

        [TestMethod]
        public void TestMethod1()
        {
            Meal meal = new Meal(Meal.Regions.Gyeonggi, Meal.SchoolType.Middle, "J100005350");
            GetMealMenuAsync(meal);
        }

        private async void GetMealMenuAsync(Meal meal) => this.menu = await meal.GetMealMenuAsync();
    }
}
