using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.SceneManagement;

public class CostumeChanger : MonoSingleton<CostumeChanger>
{



    Animator animator;

    int cloth, hat, hair = 0;

    private void Awake()
    {
        animator = GetComponent<Animator>();
        Change();
        DontDestroyOnLoad(gameObject);
        if(Instance != null)
            Destroy(Instance);
      //  CostumeChanger.Instance = this;
    }

    private void Update()
    {
       
    }


    public void Change()
    {
        
        cloth = Random.Range(1, 21);
        hat = Random.Range(1, 14);
        hair = Random.Range(1, 20);

        animator.SetInteger("Cloth", cloth);
        animator.SetInteger("Hat", hat);
        animator.SetInteger("Hair", hair);
    }

   
}
