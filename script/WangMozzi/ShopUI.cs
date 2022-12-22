using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopUI : MonoBehaviour
{
    Moving character;

    ShopManager weapons;

    public Transform btnRoot;
    public Button[] btnWeaphons;

    public Text status;

    // Start is called before the first frame update
    void Start()
    {
        character = GameManager.playerCharacter;

        int btnCount = btnRoot.childCount;
        btnWeaphons = new Button[btnCount];

        for (int i = 0; i < btnCount; i++)
        {
            int curIdx = i;
            btnWeaphons[curIdx] = btnRoot.GetChild(curIdx).GetComponent<Button>();
            
            Item item = btnWeaphons[curIdx].GetComponent<Item>();
            item.SetInfo(ShopManager.weapons[curIdx]);

            btnWeaphons[curIdx].onClick.AddListener(() => {
                OnClickBtn(ShopManager.weapons[curIdx]);
            });
        }
    }

    public void OnClickBtn(Wpn weapons)
    {
        if (character.Pmoney >= weapons.price)
        {
            character.Pmoney -= weapons.price;
            character.Pl_Atk += weapons.wp_atk;            
            character.Havemoney.text = character.Pmoney + "골드";
            character.NowAtk.text = $"공격력 : {character.Pl_Atk}";

            Debug.Log($"공격력이 + {weapons.wp_atk} + 만큼 추가되었습니다.");

            if (status != null)
            {                
                status.text = $"공격력이 {weapons.wp_atk}만큼 추가되었습니다.";
                status.text = $"내 공격력 : {character.Pl_Atk}";            
            }            
        }
        else
        {
            Debug.Log("골드가 부족합니다.");
            if (status != null)
                status.text = "골드가 부족합니다.";
        }
    }
}
