using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolMeal
{
    /// <summary>
    /// 급식메뉴에 대한 속성들을 제공합니다.
    /// </summary>
    public class MealMenu
    {
        /// <summary>
        /// 아침 메뉴를 제공합니다.
        /// </summary>
        public List<Food> Breakfast { get; }

        /// <summary>
        /// 점심 메뉴를 제공합니다.
        /// </summary>
        public List<Food> Lunch { get; }

        /// <summary>
        /// 저녁 메뉴를 제공합니다.
        /// </summary>
        public List<Food> Dinner { get; }

        /// <summary>
        /// 식사메뉴를 지정하여 <see cref="MealMenu"/>클래스의 새 인스턴스를 초기화합니다. 식사메뉴가 존재하지 않는다면 null을 지정합니다.
        /// </summary>
        /// <param name="breakfast">아침식사 메뉴</param>
        /// <param name="lunch">점심식사 메뉴</param>
        /// <param name="dinner">저녁식사 메뉴</param>
        public MealMenu(List<Food> breakfast = null, List<Food> lunch = null, List<Food> dinner = null)
        {
            this.Breakfast = breakfast;
            this.Lunch = lunch;
            this.Dinner = dinner;
        }

    }

    /// <summary>
        /// 음식의 정보에 대한 속성들을 제공합니다.
        /// </summary>
    public class Food
    {
        /// <summary>
        /// 음식 이름을 제공합니다.
        /// </summary>
        public string Name { get; }

        /// <summary>
        /// 알레르기 정보를 제공합니다.
        /// </summary>
        public List<int> Allergy { get; }

        /// <summary>
        /// 속성에 값을 지정해서 <see cref="Food"/>클래스의 새 인스턴스를 초기화합니다.
        /// </summary>
        /// <param name="name">음식 이름</param>
        /// <param name="allergy">알레르기 정보</param>
        public Food(string name, List<int> allergy = null)
        {
            this.Name = name;
            this.Allergy = allergy;
        }
    }
}
