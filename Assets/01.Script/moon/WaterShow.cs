using System.Collections;
using System.Collections.Generic;
using System.Xml;
using Unity.Collections.LowLevel.Unsafe;
using UnityEngine;
using Random = UnityEngine.Random;

public class WaterShow : MonoBehaviour
{
    [SerializeField] private GameObject[] prefab; 
    [SerializeField] private int xWaterMany;
    [SerializeField] private int yWaterMany;
    [SerializeField] private float distance = 0.1f;
    private Vector2 startVetor;
    private Vector2 nowVecor;
    private Transform[] WaterPoses;
    private int WaterMany => yWaterMany * xWaterMany;
    private float timer;

    private int lastWater;
    private void Awake()
    {
        WaterPoses = transform.GetComponentsInChildren<Transform>();
        Initialize();
    }
    private void Initialize()
    {
        WaterPoses = new Transform[WaterMany];
        transform.position = new Vector3(-(prefab[0].transform.localScale.x * 2 + distance * 2), prefab[0].transform.localScale.y * 2 + distance * 2, 0);
        startVetor = transform.position;
        startVetor = new Vector2(startVetor.x + prefab[0].transform.localScale.x / 2, startVetor.y - prefab[0].transform.localScale.y / 2);
        nowVecor = startVetor;
        timer = Random.Range(1f,2f);
    }
    private void Start()
    {
        int count = 0;
        int ycount = 0;
        for (int x = 0; x < xWaterMany; x++)
        {
            for (int y = 0; y < yWaterMany; y++)
            {
                WaterPoses[count] = Instantiate(prefab[(count % 2 + ycount % 2) % 2], nowVecor, Quaternion.identity, transform).transform;
                nowVecor = new Vector2(nowVecor.x + distance + prefab[(count % 2 + ycount % 2) % 2].transform.localScale.x, nowVecor.y);
                WaterPoses[count].GetChild(0).gameObject.SetActive(false);
                count++;
            }
            ycount++;
            nowVecor = new Vector2(startVetor.x, nowVecor.y - distance - prefab[(count % 2 + ycount % 2) % 2].transform.localScale.y);
        }
        WaterReset();
    }
    private void Update()
    {
         timer -= Time.deltaTime;
        if(timer < 0)
        {
            timer = Random.Range(1f, 2f);
            WaterReset();
        }
    }
    private void WaterReset()
    {
        WaterPoses[lastWater].GetChild(0).gameObject.SetActive(false);
        lastWater = Random.Range(0, WaterMany);
        WaterPoses[lastWater].GetChild(0).gameObject.SetActive(true);
    }
}
