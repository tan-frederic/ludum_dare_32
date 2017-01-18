using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using System.Collections;

public class PlayerSelection : MonoBehaviour {

    public Image[] selectorPlayer;
    public VoiceSelection voice;
    public float WaitInput = 0.02f;
    private bool isSelected = false;

    private int playerSelected = 0;
    private float frame;

    public int Selected
    {
        get
        {
            return (playerSelected);
        }
    }

    public bool IsSelected
    {
        get
        {
            return (isSelected);
        }

        set
        {
            isSelected = value;
        }
    }

	void Awake()
    {
        selectorPlayer[1].enabled = true;
        selectorPlayer[0].enabled = false;
    }
	
	void Update ()
    {
        if ((Mathf.Abs(Input.GetAxis("Xbox_LeftStickX")) > 0.5f || Input.GetAxis("Xbox_HorizontalCross") != 0 || Input.GetAxis("Horizontal") != 0.0f)
            && frame <= 0 && !isSelected)
        {
            selectorPlayer[0].enabled = !selectorPlayer[0].enabled;
            selectorPlayer[1].enabled = !selectorPlayer[1].enabled;
            playerSelected = (playerSelected + 1) % 2;
            frame = WaitInput;
        }
        if (frame > 0)
            frame -= Time.deltaTime;
        if ((Input.GetButtonDown("Xbox_AButton") || Input.GetAxis("Xbox_VerticalCross") < 0 || Input.GetAxis("Xbox_LeftStickY") > 0.5f) && !isSelected)
        {
            SaveParameter();
            isSelected = true;
            voice.Selectable = true;
        }
	}

    public void SaveParameter()
    {
        PlayerPrefs.SetInt("PlayerSelected", playerSelected);
        PlayerPrefs.Save();
    }
}
