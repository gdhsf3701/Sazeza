using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseClickCheck : MonoBehaviour
{
    [SerializeField] Stage2 stage;
    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            RaycastHit2D hit = Physics2D.Raycast(mousePosition, Vector2.zero);
            if (hit)
            {
                if (hit.transform.TryGetComponent(out Water water))
                {
                    if(water.canWater)
                    {
                        water.canWater = false;
                        SetDartyRate();
                    }
                }
            }
        }
    }
    private void SetDartyRate()
    {
        GameManager.Instance.IngredientDirtyRateMinus(GameManager.Instance.nowIngredientType, 20);
        if (GameManager.Instance.IngredientDirtyRate[GameManager.Instance.nowIngredientType] <= 0)
        {
            stage.NewIngredientType();
        }
    }
}
