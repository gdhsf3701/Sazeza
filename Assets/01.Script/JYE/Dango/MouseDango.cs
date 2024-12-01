using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseDango : MonoBehaviour
{
    private float RollSpeed = 300; //당고 돌아가는 속도
    private float Speed = 5; //당고 따라가는 속도

    private Vector3 mousePosition = new Vector3(0,-5,0); //당고가 따라갈 마우스 위치

    public SauceScoreSO mySO;

    private void Update()
    {
        Move();
        RollDango();
    }

    private void Move()
    {
        Vector3 mouse = Camera.main.ScreenToViewportPoint(Input.mousePosition); //마우스 위치 (0,0,0 ~ 1,1,1)

        if(mouse.x >= 0 && mouse.y >= 0 && mouse.x <= 1 && mouse.y <= 1)//움직이는 부분 (화면 안)
        {
            mousePosition = MousePosition(); //당고가 따라갈 마우스 위치 받기
        }

        Vector3 myPosition = gameObject.transform.parent.position; //본인 위치
        gameObject.transform.parent.position = Vector3.Lerp(myPosition, mousePosition, Speed * Time.deltaTime); //천천히 따라가라고
    }

    private Vector3 MousePosition() //마우스 위치
    {
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition); //마우스 위치
        mousePosition.z = 0; //안하면 -10 되는데 그럼 화면에 안보임
        return mousePosition;
    }

    private void RollDango() //당고를 돌림
    {
        transform.Rotate(new Vector3(0, 0, RollSpeed * Time.deltaTime));
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.TryGetComponent<Sauce>(out Sauce sauce))
        {
            SauceScoreSO so = sauce.so;
            sauce.sauceScore += so.type == SauceObjectType.SauceBall? sauce.sauceScore : -sauce.sauceScore;//소스 더하기
            
            mySO.sauceText.text = sauce.sauceScore.ToString(); //소스 점수 보이기
        }
    }
}
