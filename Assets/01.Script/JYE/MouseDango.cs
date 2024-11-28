using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseDango : MonoBehaviour
{
    private float RollSpeed = 300; //��� ���ư��� �ӵ�
    private float Speed = 5; //��� ���󰡴� �ӵ�

    private void Update()
    {
        MoveDango();
        RollDango();
    }

    private void MoveDango() //��� ���콺�� ����ٴ�
    {
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition); //���콺 ��ġ
        mousePosition.z = 0; //���ϸ� -10 �Ǵµ� �׷� ȭ�鿡 �Ⱥ���

        gameObject.transform.parent.transform.position = Vector3.Lerp(
            gameObject.transform.parent/*��ǻ� �� ������ ��ü��*/.transform.position,mousePosition,Speed * Time.deltaTime); //õõ�� ���󰡶��
    }
    private void RollDango() //��� ����
    {
        transform.Rotate(new Vector3(0, 0, RollSpeed * Time.deltaTime));
    }
}
