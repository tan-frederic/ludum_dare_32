using UnityEngine;
using System.Collections;

public class Skill : MonoBehaviour {

    public AudioClip clipMale;
    public AudioClip clipFemale;
	public GameObject	skillFX;
	public float		cooldown = 1f;
	private float		timer = 0.0f;

	// Use this for initialization
	void Start () 
	{
		timer = cooldown;
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (timer < cooldown)
		{
			timer += Time.deltaTime;
		}
	}

    public void LaunchSkill(bool isTurnLeft)
	{
		if (timer >= cooldown)
        {
            if (PlayerPrefs.GetInt("PlayerSelected") == 0)
                GetComponent<AudioSource>().clip = clipMale;
            else
                GetComponent<AudioSource>().clip = clipFemale;
            GetComponent<AudioSource>().Play();
            GameObject fire = (GameObject)Instantiate(skillFX, this.transform.position, Quaternion.identity);
            if (isTurnLeft)
                fire.transform.Rotate(new Vector3(0, 180, 0));
            timer = 0f;
		}
	}
}
