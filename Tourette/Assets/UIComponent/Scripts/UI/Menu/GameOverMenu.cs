using UnityEngine;
using System.Collections;

public class GameOverMenu : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {

    }

    void Update()
    {
        if (Input.GetButtonDown("Xbox_StartButton"))
            Application.LoadLevel("PlayerSelection");
    }
}
