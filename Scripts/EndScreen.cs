using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EndScreen : MonoBehaviour
{
    [SerializeField] Image background;
    [SerializeField] Image page;

    float a = 0;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(FadeIn());
    }

    // Update is called once per frame
    void Update() { }

    IEnumerator FadeIn()
    {
        background.color = new Color(0, 0, 0, 0);

        while (a < 1)
        {
            a += 0.01f;
            background.color = new Color(0, 0, 0, a);
            yield return null;
        }
        FindObjectOfType<Scrolling>().Scroll();
        background.enabled = false;
        //StartCoroutine(Traveling());

        yield return null;
    }

    //IEnumerator Traveling()
    //{
    //    //while (page.rectTransform.position.y > -2)
    //    //{
    //    //    page.rectTransform.position -= Vector3.up * 0.03f;

    //    //    yield return null;
    //    //}

    //    yield return new WaitForSeconds(2.0f);

    //    MenuManager.GoToMenu();

    //    yield return null;
    //}

    public void GoToMenu()
    {
        MenuManager.GoToMenu();
    }
}
