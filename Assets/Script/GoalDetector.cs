using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoalDetector : MonoBehaviour
{
    public bool isGoal = false;
    public string result;
    public ShakeCapsule shakeCapsule;
    private GameObject enteredCapsule = null;
    private bool isDetectionActive = false;

    public void StartDetection(float delayTime)
    {
        enteredCapsule = null;
        isDetectionActive = true;
        StartCoroutine(EndDetectionAfterDelay(delayTime));
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (isDetectionActive && enteredCapsule == null && other.CompareTag("GameCapsule"))
        {
            isGoal = true;
            result = other.gameObject.name;
            enteredCapsule = other.gameObject;
        }
    }

    private IEnumerator EndDetectionAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        isDetectionActive = false;

        if (enteredCapsule != null)
        {
            Rigidbody2D rb = enteredCapsule.GetComponent<Rigidbody2D>();
            if (rb != null && shakeCapsule != null)
            {
                shakeCapsule.RemoveCapsule(rb);
            }
            Destroy(enteredCapsule);
        }
    }
}
