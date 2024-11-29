using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPlace : MonoBehaviour
{
    //��ǥ //���� �� -5, 0, 3
    [SerializeField] private List<Vector3> position; //��ǥ

    private float speed = 0.01f; //�������� �ӵ�
    private void OnEnable()
    {
        StartPosition();
    }

    private void Update()
    {
        MoveDown();
    }

    private void MoveDown() //�Ʒ��� ��������
    {
        transform.position += Vector3.down * speed;
    }

    private void StartPosition() //���� ��ġ
    {
        transform.position = position[Random.Range(0, position.Count -1)];
    }
}
