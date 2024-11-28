using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpanwObject : MonoBehaviour
{
    public List<GameObject> prefabs;//스폰할 프리팹들

    public List<GameObject> parent;//부모

    private void Awake()
    {
        Spanw();
    }

    private void Parent() //부모들 만들기
    {
        for (int i = 0; i < prefabs.Count; i++)
        {
            parent.Add(new GameObject(prefabs[i].name + "_Prefabs"));
        }
    }

    private void Spanw() //스폰하기
    {
        Parent();
        for(int i = 0; i < prefabs.Count; i++)
        {
            for(int j = 0; j <10; j++)
            {
                GameObject newPrefabs = Instantiate(prefabs[i]); //생성
                newPrefabs.SetActive(false);
                newPrefabs.transform.SetParent(parent[i].transform); //부모설정
            }
        }
    }
}
