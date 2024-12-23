using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEditor.Search;
using UnityEngine;
using Random = UnityEngine.Random;

public class SpawnDango : MonoBehaviour
{
    [SerializeField] float _Timer;
    float _timer;
    [SerializeField] GameObject dango;
    Queue<GameObject> dangos = new Queue<GameObject>();
    public List<IngredientTypeEnum> Ingredient;
    [SerializeField] Transform StartPos;
    [SerializeField] Transform EndPos;
    private void Awake()
    {
        InitializeDango();
    }
    private void Update()
    {
        _timer -= Time.deltaTime;
        if(_timer <= 0)
        {
            TryDequeue();
            _timer = _Timer;
        }
    }
    private void InitializeDango()
    {
        _timer = _Timer;
        foreach(IngredientTypeEnum item in (IngredientTypeEnum[])Enum.GetValues(typeof(IngredientTypeEnum)))
        {
            Ingredient.Add(item);
            print(item.ToString());
        }
        for (int i = 0; i < Enum.GetValues(typeof(IngredientTypeEnum)).Length; i++)
        {
            GameObject temp = Instantiate(dango);
            dangos.Enqueue(temp);
            temp.GetComponent<MyIngredientType>().myEnum = Ingredient[i];
            temp.GetComponent<MyIngredientType>().mySprite.sprite = GameManager.Instance.IngredientSO[Ingredient[i]].sprite;
            temp.GetComponent<SpriteMask>().sprite = GameManager.Instance.IngredientSO[Ingredient[i]].sprite;
            temp.SetActive(false);
        }
    }
    public void AddDango(GameObject obj)
    {
        dangos.Enqueue(obj);
        obj.SetActive(false);
    }
    private void TryDequeue()
    {
        GameObject dango = dangos.Dequeue();
        dango.transform.position = new Vector3(Random.Range(StartPos.position.x, EndPos.position.x), StartPos.position.y);
        dango.SetActive(true);
        float random = Random.Range(0.0f, 100.1f);

        if (random < 20f)
        {
            dango.transform.GetChild(0).gameObject.SetActive(true);
            dango.GetComponent<MyIngredientType>().isSouce = true;
        }
        else
        {
            dango.transform.GetChild(0).gameObject.SetActive(false);
            dango.GetComponent<MyIngredientType>().isSouce = false;
        }
    }
}
