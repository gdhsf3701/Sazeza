using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopClickChecker : MonoBehaviour
{
    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            RaycastHit2D hit = Physics2D.Raycast(mousePosition, Vector2.zero);
            if (hit)
            {
                if (hit.transform.GetChild(0).TryGetComponent(out Item item))
                {
                    item.Buy();
                }
            }
        }
    }
}
