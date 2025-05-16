using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ButtonController : MonoBehaviour
{
    public GoalDetector goalDetector;
    public ShakeCapsule shakeCapsule;
    public Button startbtn;
    public Transform lever;
    public ParticleSystem effectParticle;
    public GameObject endPopup;
    

    private void Start()
    {
        startbtn.onClick.AddListener(StartLever);
    }

    private void StartLever()
    {
        shakeCapsule.Shake();
        StartCoroutine(RotateOverTime());
        goalDetector.StartDetection(1.0f);
    }

    private IEnumerator RotateOverTime()
    {
        float duration = 1.0f;
        float current = 0f;
        float startZ = 0f;
        float endZ = 360f;

        while (current < duration)
        {
            current += Time.deltaTime;
            float t = Mathf.Clamp01(current / duration);
            float currentZ = Mathf.Lerp(startZ, endZ, t);
            Vector3 angles = lever.localEulerAngles;
            angles.z = currentZ;
            lever.localEulerAngles = angles;
            yield return null;
        }

        Vector3 finalAngles = lever.localEulerAngles;
        finalAngles.z = endZ;
        lever.localEulerAngles = finalAngles;

        if (goalDetector.isGoal)
        {
            effectParticle.Play();
            yield return new WaitForSeconds(2.0f);
            endPopup.SetActive(true);
        }
    }
}

