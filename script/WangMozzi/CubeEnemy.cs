using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CubeEnemy : MonoBehaviour
{
    public UINickName uiNickname;
    public string EnemyName;
    public int En_HP = 50;
    public int En_Atk = 20;
    public int Mmoney = 100;
    public Slider HPBar;
    public int FullHP = 100;
    public Text status;

    void Start()
    {
        uiNickname = GetComponentInChildren<UINickName>();
        uiNickname.Setname(EnemyName);
        Debug.Log("���� ��Ÿ�����ϴ�!");
        HPBar = GetComponentInChildren<Slider>();
    }
    public void EnemyDie()
    {

        Destroy(gameObject);
    
    }
}


