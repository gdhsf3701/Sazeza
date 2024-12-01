using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyObject : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D obj) //오브젝트 비활성화
    {
        if (obj.gameObject.TryGetComponent(out ObjectPlace objScript))
        {
            SpanwObject pScript = objScript.Parent.GetComponent<SpanwObject>();
            obj.gameObject.SetActive(false);
            pScript.prefabs.Add(obj.gameObject);
        }
    }
}
