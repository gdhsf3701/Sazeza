using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.U2D;

public class MouseClickCheck : MonoBehaviour
{
    [SerializeField] Stage2 stage;
    [SerializeField] SpriteRenderer sprite;
    [SerializeField] WaterShow waterShow;
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
                        waterShow.TimerZeroSet();
                    }
                }
            }
            else
            {
                GameManager.Instance.IngredientDirtyRatePlus(GameManager.Instance.NowIngredientType, 20);
                SetDarty();
            }
        }
    }
    private void SetDartyRate()
    {
        Color temp = sprite.color;
        GameManager.Instance.IngredientDirtyRateMinus(GameManager.Instance.NowIngredientType, 20);
        if (GameManager.Instance.IngredientDirtyRate[GameManager.Instance.NowIngredientType] <= 0)
        {
            stage.NewIngredientType();
        }
        temp.a = GameManager.Instance.IngredientDirtyRate[GameManager.Instance.NowIngredientType]/100f;
        sprite.color = temp;
    }
    private void SetDarty()
    {
        Color temp = sprite.color;
        GameManager.Instance.IngredientDirtyRatePlus(GameManager.Instance.NowIngredientType, 20);
        temp.a = GameManager.Instance.IngredientDirtyRate[GameManager.Instance.NowIngredientType] / 100f;
        sprite.color = temp;
    }
}
