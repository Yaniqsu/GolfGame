using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[System.Serializable]
class UnityTranformEvent : UnityEvent<Transform>
{

}

[RequireComponent(typeof(Collider2D))]
public class AreaTrigger : MonoBehaviour
{
    
    [SerializeField] LayerMask triggerLayer;
    [SerializeField] string triggerTag;
    [SerializeField] UnityTranformEvent onObjectEntered;
    [SerializeField] UnityTranformEvent onObjectExit;

    void Start()
    {

    }
    private void OnTriggerEnter2D(Collider2D c)
    {
        if (HasRightTag(c) && ((1 << c.gameObject.layer) & triggerLayer.value) != 0)
            onObjectEntered.Invoke(c.gameObject.transform);
    }
    private void OnTriggerExit2D(Collider2D c)
    {
        if (HasRightTag(c) && ((1 << c.gameObject.layer) & triggerLayer.value) != 0)
            onObjectExit.Invoke(c.gameObject.transform);
    }

    bool HasRightTag(Collider2D collider)
    {
        if (triggerTag == "") return true;

        return collider.CompareTag(triggerTag);
    }
}
