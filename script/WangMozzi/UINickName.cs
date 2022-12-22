using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UINickName : MonoBehaviour
{
    public Image bg;
    public Text txt;
    Color originColor;
    void Awake()
    {
        txt = GetComponentInChildren<Text>();
        originColor = bg.color;
    }

    public void Setname(string name)
    { 
        txt.text = name;
    }
    public void SetColor(Color c)
    {
        bg.color = c;
    }
    public void SetOriginColor()
    {
        bg.color = originColor;
    }
}
