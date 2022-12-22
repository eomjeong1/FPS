using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WordColor : MonoBehaviour
{
    public Color C;
    public Text t;
    // Start is called before the first frame update
    public void Wordcolor()
    {
        t.color = C;
    }
}


    
   
