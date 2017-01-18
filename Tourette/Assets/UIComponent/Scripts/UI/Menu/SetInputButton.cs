using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class SetInputButton : MonoBehaviour {

    public Text textButtonA;
    public Text textButtonB;
    public Text textButtonX;
    public Text textButtonY;

    private string[] nameAttackCac;
    private string[] nameAttackDist;
    private int typeAttackA = 1;
    private int typeAttackB = 0;
    private int typeAttackX = 1;
    private int typeAttackY = 0;

    void Awake()
    {
        nameAttackCac = new string[4];
        nameAttackDist = new string[4];

        nameAttackCac[0] = "";
        nameAttackCac[1] = "Fuck you !";
        nameAttackCac[2] = "Asshole !";
        nameAttackCac[3] = "Piece of shit !";

        nameAttackDist[0] = "";
        nameAttackDist[1] = "Shut up !";
        nameAttackDist[2] = "Mother Fucker !";
        nameAttackDist[3] = "Son of a bitch !";

        textButtonA.text = nameAttackCac[typeAttackA];
        textButtonB.text = nameAttackCac[typeAttackB];
        textButtonX.text = nameAttackDist[typeAttackX];
        textButtonY.text = nameAttackDist[typeAttackY];
    }

	void Update () {
        if (Input.GetButtonDown("Xbox_AButton"))
            SetAButtonText();
        if (Input.GetButtonDown("Xbox_BButton"))
            SetBButtonText();
        if (Input.GetButtonDown("Xbox_XButton"))
            SetXButtonText();
        if (Input.GetButtonDown("Xbox_YButton"))
            SetYButtonText();
        if (Input.GetButtonDown("Xbox_StartButton"))
        {
            PlayerPrefs.SetInt("TypeAttackA", typeAttackA);
            PlayerPrefs.SetInt("TypeAttackB", typeAttackB);
            PlayerPrefs.SetInt("TypeAttackX", typeAttackX);
            PlayerPrefs.SetInt("TypeAttackY", typeAttackY);
            PlayerPrefs.Save();
            Application.LoadLevel("Level01 - Let s Begin");
        }
	}

    void SetAButtonText()
    {
        typeAttackA = (typeAttackA + 1) % 4;
        if (typeAttackA == typeAttackB)
            typeAttackA = (typeAttackA + 1) % 4;
        textButtonA.text = nameAttackCac[typeAttackA];
    }

    void SetBButtonText()
    {
        typeAttackB = (typeAttackB + 1) % 4;
        if (typeAttackB == typeAttackA)
            typeAttackB = (typeAttackB + 1) % 4;
        textButtonB.text = nameAttackCac[typeAttackB];

    }

    void SetXButtonText()
    {
        typeAttackX = (typeAttackX + 1) % 4;
        if (typeAttackX == typeAttackY)
            typeAttackX = (typeAttackX + 1) % 4;
        textButtonX.text = nameAttackDist[typeAttackX];
    }

    void SetYButtonText()
    {
        typeAttackY = (typeAttackY + 1) % 4;
        if (typeAttackY == typeAttackX)
            typeAttackY = (typeAttackY + 1) % 4;
        textButtonY.text = nameAttackDist[typeAttackY];
    }
}
