using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopManager : MonoBehaviour
{
    private List<GameObject> shops = new List<GameObject>();
    private GameObject nowGameObject;
    private void Start()
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            shops.Add(transform.GetChild(i).gameObject);
            shops[i].SetActive(false);
        }
        ShopSetting(0);
    }
    public void ShopSetting(int i)
    {
        if (i < 0 || i >= shops.Count || nowGameObject == shops[i]) return;
        if(nowGameObject != null)
        {
            nowGameObject.SetActive(false);
        }
        nowGameObject = shops[i];
        nowGameObject.SetActive(true);
    }
}
