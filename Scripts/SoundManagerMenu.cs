using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class SoundManagerMEnu : MonoBehaviour
{
    List<AudioSource> sources = null;

    private void Start()
    {
        sources = GetComponentsInChildren<AudioSource>().ToList();
        sources.ForEach(s => s.Play());
    }
}
