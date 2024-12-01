using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyObject : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D obj) //������Ʈ ��Ȱ��ȭ
    {
        if (obj.gameObject.TryGetComponent(out ObjectPlace objScript))
        {
            SpanwObject pScript = objScript.Parent.GetComponent<SpanwObject>();
            obj.gameObject.SetActive(false);
            pScript.prefabs.Add(obj.gameObject);
        }
    }
}
