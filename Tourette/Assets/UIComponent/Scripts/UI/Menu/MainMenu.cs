using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class MainMenu : MonoBehaviour {

    public Color selectedColor;
    public Color normalColor;
    public Text[] buttons;
    public float WaitInput = 0.2f;

    private float frame;
    private int selector = 0;

    delegate void MyDelegate();
    MyDelegate[] function;

    void Start()
    {
        PlayerPrefs.SetInt("PlayerVoice", 0);
        PlayerPrefs.SetInt("PlayerSelected", 0);
        PlayerPrefs.SetInt("TypeAttackA", 1);
        PlayerPrefs.SetInt("TypeAttackB", 0);
        PlayerPrefs.SetInt("TypeAttackX", 1);
        PlayerPrefs.SetInt("TypeAttackY", 0);
    }

	void Awake ()
    {
        PlayerPrefs.SetInt("Score", 0);
        buttons[selector].color = selectedColor;
        function = new MyDelegate[3];
        function[0] = LoadGame;
        function[1] = ShowCredit;
        function[2] = QuitGame;
	}
	
	void Update ()
    {
        if ((Input.GetAxis("Xbox_LeftStickY") > 0.5f || Input.GetAxis("Vertical") < 0.0f || Input.GetAxis("Xbox_VerticalCross") < 0)
                && frame <= 0)
        {
            selector = (selector + 1) % buttons.Length; 
            foreach (Text button in buttons)
                button.color = normalColor;
            buttons[selector].color = selectedColor;
            frame = WaitInput;
        }
        else if ((Input.GetAxis("Xbox_LeftStickY") < -0.5f || Input.GetAxis("Vertical") > 0.0f || Input.GetAxis("Xbox_VerticalCross") > 0)
                && frame <= 0)
        {
            --selector;
            if (selector < 0)
                selector = buttons.Length - 1;
            foreach (Text button in buttons)
                button.color = normalColor;
            buttons[selector].color = selectedColor;
            frame = WaitInput;
        }
        if (frame > 0)
            frame -= Time.deltaTime;
        if (Input.GetButtonDown("Xbox_AButton") || Input.GetButtonDown("Xbox_StartButton"))
            function[selector]();
	}

    public void QuitGame()
    {
        Application.Quit();
    }

    public void ShowCredit()
    {
        Application.LoadLevel("Credit");
    }

    public void LoadGame()
    {
        Application.LoadLevel("PlayerSelection");
    }
}
