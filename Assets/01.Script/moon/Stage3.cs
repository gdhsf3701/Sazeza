using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stage3 : MonoBehaviour
{
    private Vector3 shootingPos;
    [SerializeField]private Shooting shooting;
    private void Awake()
    {
        shootingPos = shooting.transform.position;
        shooting.ResetPos += PosReset;
        ToolkitManager.Instance.ChangeSceneName("3. ´ç°í Àç·á ²¿Ä¡¿¡ ³¢¿ì±â");
    }
    private void Update()
    {
        if (Input.GetMouseButtonDown(0)&&!shooting.IsShooting)
        {
            shooting.Shoot(Vector3.up);
            shooting.IsShooting = true;
        }
    }
    private void PosReset()
    {
        shooting.PosReset(shootingPos);
    }
}
