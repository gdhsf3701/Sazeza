using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpanwObject : MonoBehaviour
{
    public GameObject prefabsObject;//������ ������
    public GameObject parent;//�θ�

    public List<GameObject> prefabs;

    private void Awake()
    {
        Spanw();
    }

    private void Parent() //�θ� �����
    {
        parent = new GameObject(prefabsObject.name + "_Prefabs");
    }

    private void Spanw() //�����ϱ�
    {
        //Parent();
        for (int j = 0; j < 10; j++)
        {
            GameObject newPrefabs = Instantiate(prefabsObject,transform); //����
            newPrefabs.SetActive(false);
            //newPrefabs.transform.SetParent(parent.transform); //�θ���
            prefabs.Add(newPrefabs);
        }
    }
}
