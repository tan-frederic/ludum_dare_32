using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class VoiceSelection : MonoBehaviour {

    [Header("Image button voice")]
    public Image selectorVoicesBoy;
    public Image selectorVoicesGirl;

    [Header("Image button voice color selection")]
    public Color normalColor;
    public Color selectColor;

    public PlayerSelection player;

    private float WaitInput = 0.2f;
    private int voiceSelected = 0;
    private float frame;
    private bool selectable = false;

    public int VoiceSelected
    {
        get
        {
            return (voiceSelected);
        }
    }

    public bool Selectable
    {
        set
        {
            selectable = value;
            SelectVoiceColor();
        }
        get
        {
            return (selectable);
        }
    }

    void Awake()
    {

    }

    void Update()
    {
        if ((Mathf.Abs(Input.GetAxis("Xbox_LeftStickX")) > 0.5f || Input.GetAxis("Xbox_HorizontalCross") != 0 || Input.GetAxis("Horizontal") != 0.0f)
            && frame <= 0 && selectable)
        {
            voiceSelected = (voiceSelected + 1) % 2;
            if (voiceSelected == 0)
            {
                selectorVoicesBoy.color = selectColor;
                selectorVoicesGirl.color = normalColor;
            }
            else if (voiceSelected == 1)
            {
                selectorVoicesBoy.color = normalColor;
                selectorVoicesGirl.color = selectColor;
            }
            frame = WaitInput;
        }
        if (frame > 0)
            frame -= Time.deltaTime;
        if ((Input.GetButtonDown("Xbox_BButton") || Input.GetAxis("Xbox_VerticalCross") > 0 || Input.GetAxis("Xbox_LeftStickY") < -0.5f) && selectable)
        {
            selectable = false;
            ResetColorVoice();
            player.IsSelected = false;
        }
        if ((Input.GetButtonDown("Xbox_AButton") || Input.GetButtonDown("Xbox_StartButton"))
            && selectable)
        {
            PlayerPrefs.SetInt("PlayerVoice", voiceSelected);
            PlayerPrefs.Save();
        }
    }

    void SelectVoiceColor()
    {
        if (voiceSelected == 0)
        {
            selectorVoicesBoy.color = selectColor;
            selectorVoicesGirl.color = normalColor;
        }
        else if (voiceSelected == 1)
        {
            selectorVoicesBoy.color = normalColor;
            selectorVoicesGirl.color = selectColor;
        }
    }

    void ResetColorVoice()
    {
        selectorVoicesBoy.color = normalColor;
        selectorVoicesGirl.color = normalColor;
    }
}
