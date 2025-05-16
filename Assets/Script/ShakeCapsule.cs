using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShakeCapsule : MonoBehaviour
{
    public List<Rigidbody2D> capsules = new List<Rigidbody2D>();

    public float forceMultiplier = 20f; 

    public void Shake()
    {

        foreach (Rigidbody2D rb in capsules)
        {
            Vector2 randomDir = new Vector2(
                Random.Range(-1f, 1f),
                Random.Range(-0.5f, 1f)
            ).normalized;

            rb.AddForce(randomDir * forceMultiplier,ForceMode2D.Impulse);
        }
    }

    public void RemoveCapsule(Rigidbody2D rb)
    {
        if (capsules.Contains(rb))
        {
            capsules.Remove(rb);
        }
    }
}
