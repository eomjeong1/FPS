using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopManager : MonoBehaviour
{
    static GameObject shop = null;
    public static void OpenShopUI()
    {
        if (shop == null)
        {
            Object shopObject = Resources.Load("Store");
            shop = (GameObject) Instantiate(shopObject);
        }

        shop.SetActive(true);

    }

    public static void CloseShopUI()
        {
        if(shop != null)
        { shop.SetActive(false);}
            
    }

   public static Wpn[] weapons = {
            new Wpn("�ܰ�", 30, 5, 0),
            new Wpn("���", 50, 10, 0),
            new Wpn("Ȱ" , 200, 30, 0),
            new Wpn("ö����", 100, 0, 50),
            new Wpn("����", 300, 10, 100),
            new Wpn("�Ǳݰ���", 500, 30, 200)

        };
    }
