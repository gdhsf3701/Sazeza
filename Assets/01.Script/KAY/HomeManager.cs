using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HomeManager : MonoSingleton<HomeManager>
{
    [SerializeField] Animator _animator;
    public void SetAnimator(string setType,int setNum)
    {
        _animator.SetInteger(setType, setNum);
    }

    public void Dama()
    {
        SceneManager.LoadScene("Stage1");
    }
}
