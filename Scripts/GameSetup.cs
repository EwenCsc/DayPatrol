using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSetup : MonoBehaviour
{
    [SerializeField] GameObject tutoPopup = null;
    [SerializeField] Camera cam = null;
    [SerializeField] Transform policePos = null;
    //float finalCameraSize = 4.61f;
    float finalCameraSize = 6f;

    private void Start()
    {
        StartCoroutine(SmoothZoom());
    }

    float timer = 0;
    float timeToZoom = 5;
    private IEnumerator SmoothZoom()
    {
        float originSize = cam.orthographicSize;
        Vector3 originPos = cam.transform.position;
        while(timer < timeToZoom)
        {
            timer += Time.deltaTime;
            cam.orthographicSize = Mathf.Lerp(originSize, finalCameraSize, timer / timeToZoom);
            cam.transform.position = Vector3.Lerp(originPos, policePos.position, timer / timeToZoom);
            yield return null;
        }
        tutoPopup.SetActive(true);
        gameObject.SetActive(false);
        cam.GetComponent<CameraCustom>().enabled = true;
        cam.transform.position = originPos;
        yield return null;
    }
}
