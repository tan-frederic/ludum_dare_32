using UnityEngine;
using System.Collections;

[RequireComponent(typeof(AudioSource))]
public class SoundMenu : MonoBehaviour {

    public AudioSource soundMove;
    public AudioSource validate;
    public AudioSource remove;
    public static SoundMenu Instance;

    private float WaitInput = 0.2f;
    private float frame;
	
    void Awake()
    {
        if (Instance)
            DestroyImmediate(gameObject);
        else
        {
            DontDestroyOnLoad(this);
            Instance = this;
        }
    }

	// Update is called once per frame
	void Update () {
        if (Application.loadedLevelName == "PartyTest")
            DestroyImmediate(gameObject);
        if ((Input.GetAxis("Xbox_LeftStickY") > 0.5f || Input.GetAxis("Xbox_LeftStickY") < -0.5f || Input.GetAxis("Vertical") != 0.0f || Input.GetAxis("Xbox_VerticalCross") != 0
             || Input.GetAxis("Xbox_LeftStickX") > 0.5f || Input.GetAxis("Xbox_LeftStickX") < -0.5f || Input.GetAxis("Xbox_HorizontalCross") != 0)
                && frame <= 0)
        {
            soundMove.Play();
            frame = WaitInput;
        }
        if (Input.GetButtonDown("Xbox_AButton") || Input.GetButtonDown("Xbox_BButton") || Input.GetButtonDown("Xbox_XButton") || Input.GetButtonDown("Xbox_YButton")
            && frame <= 0)
        {
            validate.Play();
            frame = WaitInput;
        }
        if (frame > 0)
            frame -= Time.deltaTime;
	}
}