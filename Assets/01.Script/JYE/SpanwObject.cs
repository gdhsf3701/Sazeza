using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpanwObject : MonoBehaviour
{
    public List<GameObject> prefabs;//������ �����յ�

    public List<GameObject> parent;//�θ�

    private void Awake()
    {
        Spanw();
    }

    private void Parent() //�θ�� �����
    {
        for (int i = 0; i < prefabs.Count; i++)
        {
            parent.Add(new GameObject(prefabs[i].name + "_Prefabs"));
        }
    }

    private void Spanw() //�����ϱ�
    {
        Parent();
        for(int i = 0; i < prefabs.Count; i++)
        {
            for(int j = 0; j <10; j++)
            {
                GameObject newPrefabs = Instantiate(prefabs[i]); //����
                newPrefabs.SetActive(false);
                newPrefabs.transform.SetParent(parent[i].transform); //�θ���
            }
        }
    }
}
