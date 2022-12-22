using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class UIcode : MonoBehaviour
{
    public BTNType currentType;
    

    private void Start()
    {
        
    }

    public void OnBtnClick()
    { 
    switch(currentType)
        {
            case BTNType.Quit:
#if UNITY_EDITOR
                UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
                break;
        }
    }
   
}
