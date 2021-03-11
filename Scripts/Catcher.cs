using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Catcher : MonoBehaviour
{

    public AudioClip landing;
    public bool isLocked = false;

    //public float speed = 5f;

    void Start()
    {
        
    }

    void Update()
    {
        /*if (!GameManager.Instance.isGameOver)
        {
            transform.position = new Vector3(transform.position.x + speed * Time.deltaTime, transform.position.y, transform.position.z);
        }*/
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "fallingBaby")
        {
            if (!isLocked)
            {
                SoundManager.Instance.PlaySFX(landing);
                isLocked = true;
                //gameObject.GetComponent<BoxCollider2D>().isTrigger = false;
                gameObject.GetComponent<CircleCollider2D>().isTrigger = false;
                collision.transform.parent = gameObject.transform;
            }
        }
    }

    void OnMouseDown()
    {
        if (!GameManager.Instance.isGameOver)
        {
            if (GameManager.Instance.activeWeapon == GameManager.NEEDLE)
            {
                Debug.Log("Nadel - Catcher");
            }

            else if (GameManager.Instance.activeWeapon == GameManager.SYRINGE)
            {
                Debug.Log("Spritze - Catcher");
            }

            else if (GameManager.Instance.activeWeapon == GameManager.WATER)
            {
                Debug.Log("Wasser - Catcher");
            }
        }

    }

}
