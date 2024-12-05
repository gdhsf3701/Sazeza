using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPlace : MonoBehaviour
{
    //��ǥ //���� �� -5, 0, 3
    [SerializeField] private List<Vector3> position; //��ǥ

    [SerializeField] private GameObject parent; //�θ�
    public GameObject Parent { get; set; }

    private static float speed = 0.01f; //�������� �ӵ�

    private void Awake()
    {
        parent = gameObject.transform.parent.gameObject;
        Parent = parent;
    }
    private void OnEnable()
    {
        StartPosition();
        StartCoroutine(UpgradeSpeed());
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
        transform.position = position[Random.Range(0, position.Count)];
    }

    //private IEnumerator UpgradeSpeed()
    //{

    //}

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.TryGetComponent<Sauce>(out Sauce sauce)) //���� �������� �ٽ� ����
        {
            yield return new WaitForSeconds(1.2f);
            speed += 0.01f;
        }
    }
}
