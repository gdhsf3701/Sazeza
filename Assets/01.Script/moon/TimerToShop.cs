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
        ToolkitManager.Instance.Paid();
        ToolkitManager.Instance.SetResult();
    }
    private void Update()
    {
        _timer -= Time.deltaTime;
        if(_timer < 0)
        {
            GameManager.Instance.ResetIngredient();
            ToolkitManager.Instance.Padii();
            SceneManager.LoadScene("Shop");
        }
    }
}
