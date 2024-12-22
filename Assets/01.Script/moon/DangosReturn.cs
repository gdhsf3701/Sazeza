using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DangosReturn : MonoBehaviour
{
    [SerializeField]SpawnDango spawnDango;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out MyIngredientType myIngredientType))
        {
            spawnDango.AddDango(myIngredientType.gameObject);
        }
    }

}
