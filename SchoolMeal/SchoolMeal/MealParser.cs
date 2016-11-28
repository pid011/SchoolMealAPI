using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SchoolMeal.Exception;
using HtmlAgilityPack;
using System.Text.RegularExpressions;

namespace SchoolMeal
{
    /// <summary>
    /// 식단표 관련 파싱 메서드 모음을 나타냅니다.
    /// </summary>
    internal static class MealParser
    {
        /// <summary>
        /// 매개변수로 받은 HTML을 급식메뉴로 바꿔줍니다.
        /// </summary>
        /// <exception cref="FaildToParseException"/>
        /// <param name="doc">파싱할 <see cref="HtmlDocument"/>인스턴스</param>
        /// <returns></returns>
        public static List<MealMenu> ParseHtml(HtmlDocument doc)
        {
            try
            {
                List<MealMenu> menu = new List<MealMenu>();

                var tbodyNode = doc.DocumentNode.SelectSingleNode("//tbody");
                var trNodeCollection = tbodyNode.SelectNodes("//tr");

                var trNode = trNodeCollection.First();
                var tdNodeCollection = trNode.SelectNodes("//td");
                foreach (var tdNode in tdNodeCollection)
                {
                    var contents = tdNode.SelectSingleNode("div").InnerHtml;
                    if (string.IsNullOrWhiteSpace(contents))
                    {
                        continue;
                    }
                    var result = StringToMealMenu(contents);
                    menu.Add(result);
                }

                return menu;

            }
            catch (System.Exception)
            {
                throw new FaildToParseException();
            }
        }
        
        private static MealMenu StringToMealMenu(string contents)
        {
            contents = contents.Replace("(석식)", string.Empty);
            contents = contents.Replace("(선)", string.Empty);

            var strList = Regex.Split(contents, "<br>").ToList();
            var date = new DateTime(DateTime.Now.Year, DateTime.Now.Month, Convert.ToInt32(strList[0]));
            strList.Remove(strList[0]);
            if (strList.Count == 0)
            {
                return new MealMenu(date);
            }

            List<string> breakfast = null;
            List<string> lunch = null;
            List<string> dinner = null;

            const string breakfastWord = "[조식]";
            const string lunchWord = "[중식]";
            const string dinnerWord = "[석식]";

            foreach (var item in strList)
            {
                if (item == breakfastWord)
                {
                    var breakfastIndex = strList.FindIndex(x => x == item);
                    if (strList.Contains(lunchWord) || strList.Contains(dinnerWord))
                    {
                        var lastIndex = strList.FindIndex(x => x.First() == '[');
                        breakfast = strList.GetRange(breakfastIndex + 1, lastIndex - (breakfastIndex + 1));
                        continue;
                    }
                    else
                    {
                        breakfast = strList;
                        breakfast.Remove(breakfast.First());
                        break;
                    }
                }
                if (item == lunchWord)
                {
                    var lunchIndex = strList.FindIndex(x => x == item);
                    if (strList.Contains(dinnerWord))
                    {
                        var dinnerIndex = strList.FindIndex(x => x == dinnerWord);
                        lunch = strList.GetRange(lunchIndex + 1, dinnerIndex - (lunchIndex + 1));
                        continue;
                    }
                    else
                    {
                        lunch = strList.GetRange(lunchIndex, strList.Count - 1);
                        lunch.Remove(lunch.First());
                        break;
                    }
                }
                if (item == dinnerWord)
                {
                    var dinnerIndex = strList.FindIndex(x => x == item);
                    dinner = strList.GetRange(dinnerIndex, strList.Count - 1);
                    dinner.Remove(dinner.First());
                    continue;
                }
            }

            return new MealMenu(date, breakfast, lunch, dinner);
        }
    }
}
