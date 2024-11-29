using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpanwObject : MonoBehaviour
{
    public GameObject prefabsObject;//스폰할 프리팹
    public GameObject parent;//부모

    public List<GameObject> prefabs;

    private void Awake()
    {
        Spanw();
    }

    private void Parent() //부모 만들기
    {
        parent = new GameObject(prefabsObject.name + "_Prefabs");
    }

    private void Spanw() //스폰하기
    {
        //Parent();
        for (int j = 0; j < 10; j++)
        {
            GameObject newPrefabs = Instantiate(prefabsObject,transform); //생성
            newPrefabs.SetActive(false);
            //newPrefabs.transform.SetParent(parent.transform); //부모설정
            prefabs.Add(newPrefabs);
        }
    }
}
