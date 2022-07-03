using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class MenuButtonsManager : MonoBehaviour
{
    public List<GameObject> buttons;

    [Header("Animation Setup")]
    public float duration = .2f;
    public float delay = .05f;
    public Ease ease = Ease.InOutBack;

    private void OnEnable()
    {
        HideButtons();
        ShowButtons();
    }
    private void HideButtons()
    {
        foreach (var b in buttons)
        {
            b.transform.localScale = Vector3.zero;
            b.SetActive(false);
        }
    }
    private void ShowButtons()
    {
        StartCoroutine(ShowButtonsWithDelay());
    }

    IEnumerator ShowButtonsWithDelay()
    {
        int i = 0;
        foreach(var b in buttons)
        {
            yield return new WaitForSeconds(i*delay);
            b.SetActive(true);
            b.transform.DOScale(1, duration).SetEase(ease);
            i++;
        }
    }
}
