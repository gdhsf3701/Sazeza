using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPlace : MonoBehaviour
{
    //좌표 //작은 벽 -5, 0, 3
    [SerializeField] private List<Vector3> position; //좌표

    [SerializeField] private GameObject parent; //부모
    public GameObject Parent { get; set; }

    private float speed = 0.01f; //내려가는 속도

    private void Awake()
    {
        parent = gameObject.transform.parent.gameObject;
        Parent = parent;
    }
    private void OnEnable()
    {
        StartPosition();
    }

    private void Update()
    {
        MoveDown();
    }

    private void MoveDown() //아래로 내려가기
    {
        transform.position += Vector3.down * speed;
    }

    private void StartPosition() //시작 위치
    {
        transform.position = position[Random.Range(0, position.Count)];
    }

    private IEnumerator UpgradeSpeed()
    {
        yield return new WaitForSeconds(1);
        speed += speed + Time.deltaTime;
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.TryGetComponent<Sauce>(out Sauce sauce)) //만약 겹쳐지면 다시 스폰
        {
            SauceScoreSO so = sauce.so;
            if (so.type != SauceObjectType.Dango)
            {
                StartPosition();
                print("그래");
            }
        }
    }
}
