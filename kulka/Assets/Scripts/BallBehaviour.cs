using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallBehaviour : MonoBehaviour
{
    [SerializeField] GameEvent onBallStopped;
    [SerializeField] Rigidbody2D rb;

    private void Start()
    {
        StartCoroutine(WaitUntilMove());
    }

    IEnumerator WaitUntilMove()
    {
        yield return new WaitUntil(() => rb.velocity.x > .1f);
        StartCoroutine(WaitUntilStop());
    }
    IEnumerator WaitUntilStop()
    {
        yield return new WaitUntil(() => Mathf.Abs(rb.velocity.x) < .01f);
        onBallStopped.Invoke();
    }
}
