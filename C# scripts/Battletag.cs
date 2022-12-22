using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Battletag : MonoBehaviour
{
    public string Btag;
    public Text t;
    void Update()
    {
        t.text = Btag;
    }
}
