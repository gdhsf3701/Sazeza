using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpanwObject : MonoBehaviour
{
    public GameObject prefabsObject;//������ ������

    public List<GameObject> prefabs;
    [SerializeField] private float spanwTime; //������ ����

    private void Awake()
    {
        Pool();
    }

    private void Start()
    {
        StartCoroutine(Spanw());
    }

    private void Pool() //�����ϱ�
    {
        //Parent();
        for (int j = 0; j < 10; j++)
        {
            GameObject newPrefabs = Instantiate(prefabsObject,transform); //����
            newPrefabs.SetActive(false);
            prefabs.Add(newPrefabs);
        }
    }

    private IEnumerator Spanw() //Ȱ��ȭ
    {
        while (true)
        {
            yield return new WaitForSeconds(spanwTime);

            GameObject newPrefabs = prefabs[0];
            newPrefabs.SetActive(true);

            prefabs.Remove(newPrefabs);
        }
    }
}