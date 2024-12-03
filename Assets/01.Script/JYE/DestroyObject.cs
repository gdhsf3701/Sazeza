using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyObject : MonoBehaviour
{
    public bool isDango;
    private void OnCollisionEnter2D(Collision2D obj) //오브젝트 비활성화
    {
        if (obj.gameObject.TryGetComponent(out ObjectPlace objScript))
        {
            if (isDango && obj.gameObject.TryGetComponent(out Sauce sauce))
            {
                SpanwObject pScript = objScript.Parent.GetComponent<SpanwObject>();
                obj.gameObject.SetActive(false);
                pScript.prefabs.Add(obj.gameObject);
            }
            else if (!isDango)
            {
                SpanwObject pScript = objScript.Parent.GetComponent<SpanwObject>();
                obj.gameObject.SetActive(false);
                pScript.prefabs.Add(obj.gameObject);
            }
        }
    }
}
