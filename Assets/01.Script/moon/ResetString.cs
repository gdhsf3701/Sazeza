using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetString : MonoBehaviour
{
    [SerializeField] private float _timer = 10f;
    private string[] hi = new string[] { 
        "이 요리사는 제대로 된 요리를 하는 것을 본 적이 없어.",
        "정말 환상적인 당고를 기대 할게요.",
        "이런, 냄새만 맡아도 군침이 도는걸.",
        "천마가 추천한 당고집, 정말 기대되는걸.",
        "소문에 의하면 이 당고가 마약당고라던데...",
        "이 당고가 맛있다면 경찰에 신고할 생각이야.",
        "나에게 빈 찬합을 주다니 가게 주인께서는 내가 필요없다는 거구나.",
        "더 살아 무엇하리.",
        "당고 대신에 니 집을 줘.",
        "하오.",
        "빨간 당 줄까, 파란 당 줄까?",
        "이 집은 물이 제일 맛있어.",
        "너무 빨리 나와서 배가 등이 되겠어요.",
        "이 집은 물 빼곤 다 별로야.",
        "저는 이 당고 덕에 새 세상을 살아가게 되었어요.",
        "오 나의 신, 당고, 이 당고는, 나의 인생, 나의 빛,",
        "세상에 70억에 당고 팬이 있다면 나는 그중 하나 일 것 ...................",
        "당고 = 나",
        "이제부터 당고에 대한 지지를 철회한다 나와 당고는 이제부터 한 몸이 되어 당고에 대한 공격은 나에 대한 공격으로 간주하겠다.",
        "폭포가 나의 당고를 씻었어",
        "하느님의 홍해가 갈리듯 나의 당고는 씻겼어"
    };
    float nowTime = 0;
    private void Start()
    {
        nowTime = _timer;
    }
    private void Update()
    {
        nowTime -= Time.deltaTime;
        if(nowTime < 0)
        {
            nowTime = _timer;

        }
    }
    private void SetString()
    {
        int rand = Random.Range(0, hi.Length);
        //text = hi[rand];
    }
}
