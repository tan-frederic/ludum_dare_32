using UnityEngine;
using UnityEngine.UI;
using System.Collections;

[RequireComponent(typeof(Image))]
public class HealthtUI : MonoBehaviour {

    private Image LifeBar;

    void Awake()
    {
        LifeBar = gameObject.GetComponent<Image>();
    }

	// Update is called once per frame
	void Update () {
	    
	}

    public void FillAmountHealth(float value)
    {
        LifeBar.fillAmount = value;
    }
}
