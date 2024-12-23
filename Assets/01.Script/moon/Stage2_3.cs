using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Stage2_3 : MonoBehaviour
{
    [SerializeField] SpawnDango spawnDango;
    int count;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        count++;
        if(collision.TryGetComponent(out MyIngredientType type))
        {
            if (type.isSouce)
            {
                GameManager.Instance.PlusScore(200);
            }
            else
            {
                GameManager.Instance.PlusScore(-100);
            }
        }
        spawnDango.AddDango(collision.gameObject);
        if(count >= 3)
        {
            SceneManager.LoadScene("Stage5");
        }
    }
}
