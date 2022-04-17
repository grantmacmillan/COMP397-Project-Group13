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
    public Animation anim;

    void Start()
    {
        Achievement.OnUnlock += Achievement_OnUnlock;
        anim = GetComponent<Animation>();
    }

    private void Achievement_OnUnlock(Achievement ach)
    {
        StartCoroutine(EnableGUI(ach));
    }

    private IEnumerator EnableGUI(Achievement ach)
    {
        title.text = ach.title;
        description.text = ach.description;
        image.sprite = ach.image;
        panel.SetActive(true);
        anim.Play("FadeIn");
        yield return new WaitForSeconds(3);
        anim.Play("Fadeout");
        yield return new WaitForSeconds(2);
        panel.SetActive(false);
    }
}
