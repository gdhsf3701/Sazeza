using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseDango : MonoBehaviour
{
    private float RollSpeed = 300; //��� ���ư��� �ӵ�
    private float Speed = 5; //��� ���󰡴� �ӵ�

    private Vector3 mousePosition = new Vector3(0,-5,0); //��� ���� ���콺 ��ġ

    public SauceScoreSO mySO;

    private void Update()
    {
        Move();
        RollDango();
    }

    private void Move()
    {
        Vector3 mouse = Camera.main.ScreenToViewportPoint(Input.mousePosition); //���콺 ��ġ (0,0,0 ~ 1,1,1)

        if(mouse.x >= 0 && mouse.y >= 0 && mouse.x <= 1 && mouse.y <= 1)//�����̴� �κ� (ȭ�� ��)
        {
            mousePosition = MousePosition(); //��� ���� ���콺 ��ġ �ޱ�
        }

        Vector3 myPosition = gameObject.transform.parent.position; //���� ��ġ
        gameObject.transform.parent.position = Vector3.Lerp(myPosition, mousePosition, Speed * Time.deltaTime); //õõ�� ���󰡶��
    }

    private Vector3 MousePosition() //���콺 ��ġ
    {
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition); //���콺 ��ġ
        mousePosition.z = 0; //���ϸ� -10 �Ǵµ� �׷� ȭ�鿡 �Ⱥ���
        return mousePosition;
    }

    private void RollDango() //��� ����
    {
        transform.Rotate(new Vector3(0, 0, RollSpeed * Time.deltaTime));
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.TryGetComponent<Sauce>(out Sauce sauce))
        {
            SauceScoreSO so = sauce.so;
            sauce.sauceScore += so.type == SauceObjectType.SauceBall? sauce.sauceScore : -sauce.sauceScore;//�ҽ� ���ϱ�
            
            mySO.sauceText.text = sauce.sauceScore.ToString(); //�ҽ� ���� ���̱�
        }
    }
}
