using UnityEngine;
using System.Collections;

public class AudioMain : MonoBehaviour {

    public AudioClip bossClip;

    public void PlayBoss()
    {
        GetComponent<AudioSource>().clip = bossClip;
        GetComponent<AudioSource>().Play();
    }
}
