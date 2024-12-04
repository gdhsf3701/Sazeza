using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Random = UnityEngine.Random;

public class Shooting : MonoBehaviour
{
    [SerializeField]private float shootingSpeed;
    private Rigidbody2D rb;
    private bool canGetReward = true;
    public bool IsShooting = false;
    List<Transform>myChild = new List<Transform>();
    Transform nowChild;
    public event Action ResetPos;
    public int count;
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    private void Start()
    {
        for (int i = 0; i < transform.childCount; i++) 
        { 
            myChild.Add(transform.GetChild(i));
            MyIngredientType my = myChild[i].GetComponent<MyIngredientType>();
            my.mySprite.sprite = GameManager.Instance.IngredientSO[GameManager.Instance.Ingredient[i]].sprite;
            my.myEnum = GameManager.Instance.Ingredient[i];
            myChild[i].gameObject.SetActive(false);
        }
        AllDelChecker();
        NowChildSet();
    }
    public void PosReset(Vector3 pos)
    {
        transform.position = pos;
        IsShooting = false;
        canGetReward = true;
        rb.velocity = Vector3.zero;
    }
    public void Shoot(Vector3 pos)
    {
        rb.AddForce(pos * shootingSpeed,ForceMode2D.Impulse);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(canGetReward)
        {
            nowChild.parent = collision.transform;
            myChild.Remove(nowChild);
            nowChild = null;
            canGetReward = false;
            ResetPos?.Invoke();
            NowChildSet();
        }
    }
    private void Update()
    {
        if(rb.velocity == Vector2.zero&&IsShooting&& canGetReward)
        {
            GameManager.Instance.IngredientDirtyRatePlus(nowChild.GetComponent<MyIngredientType>().myEnum,20);
            canGetReward = true;
            ResetPos?.Invoke();
            NowDelChecker();
        }
    }
    public void NowChildSet()
    {
        if(myChild.Count == 0)
        {
            NextScene();
            return;
        }
        canGetReward = true;
        int rand = Random.Range(0, myChild.Count);
        nowChild = myChild[rand];
        nowChild.gameObject.SetActive(true);
    }
    private void NextScene()
    {
        GameManager.Instance.DirtyRateToScore();
        SceneManager.LoadScene("Stage4");
    }
    private void NowDelChecker()
    {
        if (GameManager.Instance.IngredientDirtyRate[nowChild.GetComponent<MyIngredientType>().myEnum] >= 100)
        {
            if(nowChild != null)
            {
                nowChild.gameObject.SetActive(false);
                myChild.Remove(nowChild);
                nowChild = null;
            }
            NowChildSet();
        }
    }
    private void AllDelChecker()
    {
        List<Transform> delChild = new List<Transform>();
        foreach (var item in myChild)
        {
            if (GameManager.Instance.IngredientDirtyRate[item.GetComponent<MyIngredientType>().myEnum] >= 100)
            {
                delChild.Add(item);
            }
        }
        foreach (var item in delChild)
        {
            myChild.Remove(item);
        }
    }
}
