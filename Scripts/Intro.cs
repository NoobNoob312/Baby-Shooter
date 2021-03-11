using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Intro : MonoBehaviour
{

    public Canvas startMenu;
    public Canvas background;
    public GameObject Logo;
    public AudioClip babyIntro;

    // Start is called before the first frame update
    void Start()
    {
        //GameManager.Instance.IntroBabySpawn();
        SoundManager.Instance.PlaySFX(babyIntro);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.anyKeyDown)
        {
            gameObject.SetActive(false);
            background.gameObject.SetActive(true);
            startMenu.gameObject.SetActive(true);
        }
        /*if (Input.GetKeyDown(KeyCode.N))
        {
            Logo.SetActive(true);
        }*/
    }
}
