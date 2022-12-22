using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Wpn
{
    public string name;
    public int price;
    public int wp_atk;
    public int Armor;

    public Wpn(string weaponname, int price, int wp_atk, int Armor)
    {
        this.name = weaponname;
        this.price = price;
        this.wp_atk = wp_atk;
        this.Armor = Armor;

    }
}
public class Item : MonoBehaviour
{
    public Text WpName;
    public Text Cost;
    public Text Atk;
    public Text Amr;
    private void Start()

    {
        
    }
    public void SetInfo(Wpn wpn)
    {
        WpName.text = $"{wpn.name}";
        Cost.text = $"{wpn.price}";
        Atk.text = $"°ø:{wpn.wp_atk}";
        Amr.text = $"¹æ:{wpn.Armor}";


    }
}
