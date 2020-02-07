using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutoPopup : MonoBehaviour
{
    [SerializeField] GameObject tuto = null;
    [SerializeField] GameObject police = null;
    [SerializeField] GameObject thief = null;
    [SerializeField] GameObject vignette = null;

    float maxScale = 1.2f;

    float timer = 0.0f;
    float timeToPush = 2.0f;

    float timerFromBegining = 0;

    void Update()
    {
        timerFromBegining += Time.deltaTime;
        if (Input.GetKey(KeyCode.Space))
        {
            timer += Time.deltaTime;

            gameObject.transform.localScale = Vector3.Lerp(Vector3.one, new Vector3(maxScale, maxScale, maxScale), timer / timeToPush);

            if (timer >= timeToPush)
            {
                police.GetComponent<Controller>().enabled = true;//.SetActive(true);
                thief.GetComponent<ThiefCar>().enabled = true; //SetActive(true);
                vignette.SetActive(true);

                tuto.SetActive(false);
            }
        }
        else
        {
            timer = 0;
            gameObject.transform.localScale = Vector3.Lerp(Vector3.one, new Vector3(1.5f, 1.5f, 1.5f), Mathf.Abs(Mathf.Sin(timerFromBegining)));
        }
    }
}
