using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Cubeseller : MonoBehaviour
{
    public UINickName uiNickname;
    public string NPCName;
          

    void Start()
    {
        uiNickname = GetComponentInChildren<UINickName>();
        uiNickname.Setname(NPCName);        
    }    
}
