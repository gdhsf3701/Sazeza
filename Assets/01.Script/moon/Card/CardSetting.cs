using System.Runtime.CompilerServices;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class CardSetting : MonoBehaviour
{
    [SerializeField]private GameObject prefab;
    [SerializeField]private int xCardMany;
    [SerializeField]private int yCardMany;
    [SerializeField]private float distance = 0.1f;
    [SerializeField]IngredientTypeListSO cardData;
    List<IngredientTypeSO> cards = new List<IngredientTypeSO>();
    private Vector2 startVetor;
    private Vector2 nowVecor;
    private void Awake()
    {
        startVetor = transform.position;
        startVetor = new Vector2(startVetor.x + prefab.transform.localScale.x/2, startVetor.y - prefab.transform.localScale.y/2);
        nowVecor = startVetor;
        cards = cardData.ingredientTypes.Concat(cardData.ingredientTypes).ToList();

    }
    private void Start()
    {
        for (int x = 0; x < xCardMany; x++)
        {
            for(int y = 0; y < yCardMany; y++)
            {
                int rand = Random.Range(0, cards.Count);
                GameObject temp = Instantiate(prefab,nowVecor,Quaternion.identity,transform);
                if(temp.TryGetComponent(out Card card) && cards.Count > 0)
                {
                    card.myCard = cards[rand];
                    temp.GetComponent<Card>().myCard = cards[rand];
                    cards.RemoveAt(rand);
                }
                nowVecor = new Vector2(nowVecor.x + distance + prefab.transform.localScale.x, nowVecor.y);
            }
            nowVecor = new Vector2(startVetor.x, nowVecor.y - distance - prefab.transform.localScale.y);
        }
    }
}
