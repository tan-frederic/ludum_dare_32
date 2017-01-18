using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class HealthPlayer : MonoBehaviour {

    public int startingHealth = 100;
    public int currentHealth = 100;
    public Image lifebar;
    public Image damageImage;
    public Image HealthColor;
    public float flashSpeed = 10.0f;
    public Color flashColor = new Color(1.0f, 0.0f, 0.0f, 0.1f);

    private bool isDead = false;
    private bool damaged = false;

    void Awake()
    {
        currentHealth = startingHealth;
    }

	void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
            TakeDamage(5);
        if (damaged)
            damageImage.color = flashColor;
        else
            damageImage.color = Color.Lerp(damageImage.color, Color.clear, flashSpeed * Time.deltaTime);
        damaged = false;	
	}

    public void TakeDamage(int amount)
    {
        float value;

        damaged = true;
        currentHealth -= amount;
        value = (float)currentHealth / (float)startingHealth;
        lifebar.fillAmount = value;
        if (value >= 0.7)
            HealthColor.color = Color.green;
        else if (value < 0.7 && value >= 0.4)
            HealthColor.color = new Color(1.0f, 135.0f/255.0f, 0.0f);
        else
            HealthColor.color = Color.red;
        if (currentHealth <= 0 && !isDead)
            Death();
    }

    void Death()
    {
        Debug.Log("The player is Death");
        isDead = true;
    }
}
