using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CubeNPC : MonoBehaviour
{
    public UINickName uiNickname;
    public string NPCName;
    public int heal;
   
    

    void Start()
    {
        uiNickname = GetComponentInChildren<UINickName>();
        uiNickname.Setname(NPCName);
    }
  

        
        
    

    }
