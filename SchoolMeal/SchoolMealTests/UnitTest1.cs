using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SchoolMeal;
using System.Collections.Generic;
using System.Diagnostics;

namespace SchoolMealTests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            Meal meal = new Meal(Regions.Gyeonggi, SchoolType.Middle, "J100005350");

            var menu = meal.GetMealMenu();

            Assert.AreEqual(menu.Count, 30);
        }
    }
}
