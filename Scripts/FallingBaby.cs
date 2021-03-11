using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class FallingBaby : MonoBehaviour
{

    public float speed = 5f;

    public AudioClip crush;
    public AudioClip splash;

    public GameObject pointsText;

    public AudioClip BackgroundSoundGameOver;

    public int parentType;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //transform.position = new Vector3(transform.position.x, transform.position.y - speed * Time.deltaTime, transform.position.z);
        if (gameObject.transform.parent != null)
        {
            if (gameObject.transform.parent.tag == "catcher")
            {
                
                
                Destroy(gameObject.GetComponent<Rigidbody2D>());
                transform.position = new Vector3(transform.parent.position.x, transform.parent.position.y + transform.localScale.y / 2, transform.parent.position.z);
            }
        }

        if (gameObject.transform.position.x >= 23f)
        {
            Destroy(gameObject);
        }

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            SoundManager.Instance.StopMusic();
            SoundManager.Instance.PlayMusic(BackgroundSoundGameOver);
            SoundManager.Instance.PlaySFX(splash);
            SoundManager.Instance.PlaySFX2(crush);
            GameManager.Instance.isGameOver = true;
        }

        
        
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        if (collision.gameObject.tag == "catcher")
        {
            if (parentType == 0)
            {
                pointsText.GetComponent<TextMeshProUGUI>().text = "+50";
                StartCoroutine(GameManager.Instance.pointsFadeOut(1f, pointsText, 0));
                GameManager.Instance.score += 50;
            }
            else if (parentType == 1)
            {
                pointsText.GetComponent<TextMeshProUGUI>().text = "+100";
                StartCoroutine(GameManager.Instance.pointsFadeOut(1f, pointsText, 0));
                GameManager.Instance.score += 100;
            }
            else if (parentType == 2)
            {
                pointsText.GetComponent<TextMeshProUGUI>().text = "+150";
                StartCoroutine(GameManager.Instance.pointsFadeOut(1f, pointsText, 0));
                GameManager.Instance.score += 150;
            }
            transform.rotation = Quaternion.Euler(0f, 0f, 0f);
        }
        
    }

    void OnMouseDown()
    {
        if (!GameManager.Instance.isGameOver)
        {
            if (GameManager.Instance.activeWeapon == GameManager.NEEDLE)
            {
                Debug.Log("Nadel - Falling Baby");
            }

            else if (GameManager.Instance.activeWeapon == GameManager.SYRINGE)
            {
                Debug.Log("Spritze - Falling Baby");
            }

            else if (GameManager.Instance.activeWeapon == GameManager.WATER)
            {
                Debug.Log("Wasser - Falling Baby");
            }
        }

    }

    public void setParentType(int parent)
    {
        parentType = parent;
    }

}
