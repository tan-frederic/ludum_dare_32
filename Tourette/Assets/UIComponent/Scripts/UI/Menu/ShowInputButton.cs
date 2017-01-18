using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ShowInputButton : MonoBehaviour {

    public Text textButtonA;
    public Text textButtonB;
    public Text textButtonX;
    public Text textButtonY;

    private string[] nameAttackCac;
    private string[] nameAttackDist;

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

        textButtonA.text = nameAttackCac[PlayerPrefs.GetInt("TypeAttackA")];
        textButtonB.text = nameAttackCac[PlayerPrefs.GetInt("TypeAttackB")];
        textButtonX.text = nameAttackDist[PlayerPrefs.GetInt("TypeAttackX")];
        textButtonY.text = nameAttackDist[PlayerPrefs.GetInt("TypeAttackY")];
    }
	
	// Update is called once per frame
	void Update () {
	
	}
}
