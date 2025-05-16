using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using DG.Tweening;

public class EndPopup : MonoBehaviour
{
    public string coutString;

    public Button openBtn;

    public GoalDetector goals;

    public TextMeshProUGUI mPro;

    public GameObject desc;

    private void Start()
    {
        openBtn.onClick.AddListener(EndGame);
        desc.transform.DOScale(1.5f, 1.0f).SetLoops(-1,LoopType.Yoyo);
        mPro.text = goals.result;
        switch (goals.result)
        {
            case "red":
                mPro.text = "»¡°­";
                mPro.color = Color.red;
                break;
            case "orange":
                mPro.text = "ÁÖÈ²";
                mPro.color = new Color32(255, 165, 0, 255);
                break;
            case "yellow":
                mPro.text = "³ë¶û";
                mPro.color = Color.yellow;
                break;
            case "green":
                mPro.text = "ÃÊ·Ï";
                mPro.color = Color.green;
                break;
            case "blue":
                mPro.text = "ÆÄ¶û";
                mPro.color = Color.blue;
                break;
            case "puple":
                mPro.text = "º¸¶ó";
                mPro.color = new Color32(128, 0, 128, 255);
                break;
        }
    }

    void EndGame()
    {
        mPro.gameObject.SetActive(true);
        desc.SetActive(false);
        StartCoroutine(QuitUnity(1.0f));
    }

    IEnumerator QuitUnity(float time)
    {
        yield return new WaitForSeconds(time);
        Application.Quit();
    }
}
