using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseDango : MonoBehaviour
{
    private float RollSpeed = 300; //당고 돌아가는 속도
    private float Speed = 5; //당고 따라가는 속도

    private void Update()
    {
        MoveDango();
        RollDango();
    }

    private void MoveDango() //당고가 마우스를 따라다님
    {
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition); //마우스 위치
        mousePosition.z = 0; //안하면 -10 되는데 그럼 화면에 안보임

        gameObject.transform.parent.transform.position = Vector3.Lerp(
            gameObject.transform.parent/*사실상 얘 엄마가 본체라*/.transform.position,mousePosition,Speed * Time.deltaTime); //천천히 따라가라고
    }
    private void RollDango() //당고를 돌림
    {
        transform.Rotate(new Vector3(0, 0, RollSpeed * Time.deltaTime));
    }
}
