using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class AchievementTicker : MonoBehaviour
{
    public TextMeshProUGUI title, description;
    public Image image;
    public GameObject panel;

    void Start()
    {
        Achievement.OnUnlock += Achievement_OnUnlock;
    }

    private void Achievement_OnUnlock(Achievement ach)
    {
        StartCoroutine(EnableGUI(ach));
    }

    private IEnumerator EnableGUI(Achievement ach)
    {
        title.text = ach.title;
        description.text = ach.description;
        image = ach.image;
        panel.SetActive(true);
        yield return new WaitForSeconds(3);
        panel.SetActive(false);
    }
}
