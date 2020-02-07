using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Scrolling : MonoBehaviour
{
    [SerializeField] GameObject win = null;
    [SerializeField] GameObject lose = null;

    [SerializeField] Image textWin = null;
    [SerializeField] Image textLose = null;

    GameObject image = null;
    Image text = null;

    public void Win()
    {
        image = win;
        text = textWin;
        //StartCoroutine(ScrollRoutine());
    }

    public void Lose()
    {
        image = lose;
        text = textLose;
        //StartCoroutine(ScrollRoutine());
    }

    public void Scroll()
    {
        StartCoroutine(ScrollRoutine());
    }

    float timer = 0;
    float timeToScroll = 5;
    bool alreadyShown = false;
    private IEnumerator ScrollRoutine()
    {
        //Debug.Log(image.name);
        image.SetActive(true);
        //image.transform.position = new Vector3.
        if (image == null) yield return null;
        while(timer < timeToScroll)
        {
            timer += Time.deltaTime;
            if (timer >= timeToScroll / 2 && !alreadyShown)
            {
                alreadyShown = true;
                StartCoroutine(ShowText());
            }
            image.transform.localPosition = Vector3.Lerp(Vector3.zero, new Vector3(0, -450, 0), timer / timeToScroll);
            yield return null;
        }
        yield return null;
    }

    float a = 0;
    private IEnumerator ShowText()
    {
        while(a < 1)
        {
            a += 0.01f;
            text.color = new Color(1, 1, 1, a);
            yield return null;
        }
        yield return new WaitForSeconds(2);
        MenuManager.GoToMenu();
    }
}
