using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Type { NONE_SELECTED, ARROW, CANNON, WIZARD, LASER, ICE };

public static class Utility
{
    public static AudioClip RandomClip(AudioClip[] clips)
    {
        int size = clips.Length;
        int randInt = Random.Range(0, size);
        return clips[randInt];
    }
}




