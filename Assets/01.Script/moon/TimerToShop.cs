using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TimerToShop : MonoBehaviour
{
    [SerializeField] float _timer;
    private void Awake()
    {
        ToolkitManager.Instance.timer2(5);
        ToolkitManager.Instance.ChangeSceneName("5. ��� �Ǹ� ���");
        ToolkitManager.Instance.SetResult();
        GameManager.Instance.ResetIngredient();
        SoundManager.Instance.PlaySound(Sound.Tada);
        SoundManager.Instance.PlaySound(Sound.Receipt);
    }
    private void Update()
    {
        _timer -= Time.deltaTime;
        if(_timer < 0)
        {
            ToolkitManager.Instance.Padii();
            SceneManager.LoadScene("Shop");
        }
    }
}