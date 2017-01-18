using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class DamagableEntity : MonoBehaviour
{

    public float MaxLife { get; set; }
    public float Life = 50.0f;
    public UnityEngine.UI.Image ProgressBar;
    public int type = 0;

    void Awake()
    {
        MaxLife = Life;
    }
    // Use this for initialization
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void InfligeDamage(float dam)
    {
        if (!enabled)
            return;
        Life -= dam;
        if (ProgressBar)
            ProgressBar.fillAmount = Life / MaxLife;
        if (Life <= 0)
        { 
            Destroy(gameObject);
            if (type == 1)
                Application.LoadLevel("GameOver");
            else if (type == 2)
                Application.LoadLevel("Congratulation");
        }
    }

    public void RestoreDamage(float dam)
    {
        Life += dam;
    }
}
