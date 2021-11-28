using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public partial class UIManager : MonoBehaviour
{
    public void SelectSection()
    {// player가 raycast 할 때 layer가 section이라면 호출
        int i=0;
        switch (tableName)
        {
            case "babyProduct":
                SetFunctionButton(i++, MatchUnitData, "기저귀/물티슈");
                SetFunctionButton(i++, MatchUnitData, "유아용품");
                break;
            case "cleaningProduct":
                SetFunctionButton(i++, MatchUnitData, "일반/드럼세제");
                SetFunctionButton(i++, MatchUnitData, "섬유유연제/표백제/세탁비누");
                SetFunctionButton(i++, MatchUnitData, "청소용품/청소세제");
                SetFunctionButton(i++, MatchUnitData, "방향/탈취/제습/살충제");
                SetFunctionButton(i++, MatchUnitData, "주방용품/주방세제");
                SetFunctionButton(i++, MatchUnitData, "세탁용품/욕실용품");
                break;
            case "dailySupplies":
                SetFunctionButton(i++, MatchUnitData, "화장지/티슈/키친타월");
                SetFunctionButton(i++, MatchUnitData, "물티슈");
                SetFunctionButton(i++, MatchUnitData, "위생용품");
                break;
            case "fruit":
                SetFunctionButton(i++, MatchUnitData, "사과/배");
                SetFunctionButton(i++, MatchUnitData, "토마토/방울토마토");
                SetFunctionButton(i++, MatchUnitData, "수박/참외/멜론");
                SetFunctionButton(i++, MatchUnitData, "감귤/한라봉/오렌지");
                SetFunctionButton(i++, MatchUnitData, "포도/복숭아");
                SetFunctionButton(i++, MatchUnitData, "딸기/블루베리/아로니아");
                SetFunctionButton(i++, MatchUnitData, "감/곶감");
                SetFunctionButton(i++, MatchUnitData, "매실/자두");
                SetFunctionButton(i++, MatchUnitData, "키위/참다래"); 
                break;
            case "meat":
                SetFunctionButton(i++, MatchUnitData, "소고기");
                SetFunctionButton(i++, MatchUnitData, "돼지고기");
                SetFunctionButton(i++, MatchUnitData, "닭고기");
                SetFunctionButton(i++, MatchUnitData, "오리고기");
                SetFunctionButton(i++, MatchUnitData, "계란/구운계란");
                break;
            case "milkProduct":
                SetFunctionButton(i++, MatchUnitData, "분유/유아식");
                SetFunctionButton(i++, MatchUnitData, "우유/두유");
                SetFunctionButton(i++, MatchUnitData, "요구르트");
                SetFunctionButton(i++, MatchUnitData, "치즈/버터");
                break;
            case "rice":
                SetFunctionButton(i++, MatchUnitData, "중량별 쌀");
                SetFunctionButton(i++, MatchUnitData, "품종별 쌀");
                SetFunctionButton(i++, MatchUnitData, "지역별 쌀");
                SetFunctionButton(i++, MatchUnitData, "친환경 쌀");
                SetFunctionButton(i++, MatchUnitData, "잡곡");
                SetFunctionButton(i++, MatchUnitData, "친환경 잡곡");
                SetFunctionButton(i++, MatchUnitData, "즉석 도정미");
                break;
            case "seafood":
                SetFunctionButton(i++, MatchUnitData, "고등어/갈치/삼치/대구");
                SetFunctionButton(i++, MatchUnitData, "굴비/조기/명태/동태");
                SetFunctionButton(i++, MatchUnitData, "오징어/낙지/문어/쭈꾸미");
                SetFunctionButton(i++, MatchUnitData, "새우/게");
                SetFunctionButton(i++, MatchUnitData, "전복/굴/조개");
                SetFunctionButton(i++, MatchUnitData, "멸치/건새우/황태");
                SetFunctionButton(i++, MatchUnitData, "김/미역");
                SetFunctionButton(i++, MatchUnitData, "건오징어/진미/어포/육포");
                SetFunctionButton(i++, MatchUnitData, "기타 해산물");
                break;
            case "vegetable":
                SetFunctionButton(i++, MatchUnitData, "감자/고구마/당근");
                SetFunctionButton(i++, MatchUnitData, "오이/호박/가지/옥수수");
                SetFunctionButton(i++, MatchUnitData, "고추/파프리카/피망");
                SetFunctionButton(i++, MatchUnitData, "양파/파/마늘/생강");
                SetFunctionButton(i++, MatchUnitData, "무/알타리무/열무/얼갈이");
                SetFunctionButton(i++, MatchUnitData, "배추/절임배추/봄동");
                SetFunctionButton(i++, MatchUnitData, "양배추/양상추/브로콜리/샐러드");
                SetFunctionButton(i++, MatchUnitData, "상추/깻잎/쌈채소");
                SetFunctionButton(i++, MatchUnitData, "버섯류");
                break;    
        }
    }
}
