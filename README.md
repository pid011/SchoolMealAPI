# SchoolMealAPI
전국 초중고등학교 급식 API :meat_on_bone:  

## NuGet
https://www.nuget.org/packages/SchoolMealParser/

## 사용방법
* NuGet 패키지를 다운로드 해주세요. (SchoolMealAPI)
*  `using SchoolMeal; `네임스페이스를 추가해주세요.
* 급식 식단표를 가져오기 위해 인스턴스를 만들어주세요.
```{.cs}
Meal meal = new Meal(Regions.Gyeonggi, SchoolType.Middle, "J100005350");
```
* 급식 식단표를 파싱하여 정보를 가져오세요
```{.cs}
var menu = meal.GetMealMenu();
```
