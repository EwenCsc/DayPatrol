using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VignetteManager : MonoBehaviour
{
    [SerializeField] Animator police = null;
    [SerializeField] Animator thiev = null;

    [SerializeField] GameObject policeRenderer = null;
    [SerializeField] GameObject thievRenderer = null;

    const float waitToChangeAnim = 5;

    PoliceState currentPoliceState = PoliceState.Normal;
    ThiefState currentThievState = ThiefState.Normal;

    float policeTimer = 0;
    float thievTimer = 0;

    public enum PoliceState
    {
        None, Speed, Normal
    }

    public enum ThiefState
    {
        None, Speed, Normal, Barrier
    }

    private void Start()
    {
        SetPoliceAnimator(PoliceState.Normal);
        SetThiefAnimator(ThiefState.Normal);
        policeTimer = waitToChangeAnim;
        thievTimer = waitToChangeAnim;
    }

    private void Update()
    {
        policeTimer -= Time.deltaTime;
        if (policeTimer <= 0)
        {
            if (currentPoliceState == PoliceState.Normal)
            {
                SetPoliceAnimator(PoliceState.Speed);
                currentPoliceState = PoliceState.Speed;
            }
            else
            {
                SetPoliceAnimator(PoliceState.Normal);
                currentPoliceState = PoliceState.Normal;
            }
        }
        thievTimer -= Time.deltaTime;
        if (thievTimer <= 0)
        {
            if (currentThievState == ThiefState.Normal)
            {
                currentThievState = ThiefState.Speed;
                SetThiefAnimator(ThiefState.Speed);
            }
            else
            {
                currentThievState = ThiefState.Normal;
                SetThiefAnimator(ThiefState.Normal);
            }
        }
    }

    public void SetPoliceAnimator(PoliceState _state)
    {
        policeRenderer.SetActive(true);
        police.SetBool("Speed", false);
        police.SetBool("Normal", false);
        switch (_state)
        {
            case PoliceState.None:
                policeRenderer.SetActive(false);
                break;
            case PoliceState.Speed:
                police.SetBool("Speed", true);
                break;
            case PoliceState.Normal:
                police.SetBool("Normal", true);
                break;
            default:
                break;
        }
        policeTimer += waitToChangeAnim;
    }

    public void SetThiefAnimator(ThiefState _state)
    {
        thievRenderer.SetActive(true);
        thiev.SetBool("Speed", false);
        thiev.SetBool("Normal", false);
        thiev.SetBool("Barrier", false);
        switch (_state)
        {
            case ThiefState.None:
                thievRenderer.SetActive(false);
                break;
            case ThiefState.Speed:
                thiev.SetBool("Speed", true);
                break;
            case ThiefState.Normal:
                thiev.SetBool("Normal", true);
                break;
            case ThiefState.Barrier:
                thiev.SetBool("Barrier", true);
                break;
            default:
                break;
        }
        thievTimer += waitToChangeAnim;
    }
}
