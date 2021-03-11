using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ballon : MonoBehaviour
{

    public GameObject baby;
    public GameObject fallingBabyPrefab;
    public GameObject fallingBaby;

    public AudioClip destroyed;

    public float speed = 5;
    public float currentTime = 0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        currentTime += Time.deltaTime;
        if (!GameManager.Instance.isGameOver)
        {
            transform.position = new Vector3(transform.position.x - speed * Time.deltaTime, (transform.position.y + Mathf.Sin(currentTime * 1f) * (Time.deltaTime / 2f)), transform.position.z);
        }
        
        if (transform.position.x <= -25f)
        {
            Destroy(gameObject);
        }


        if (transform.position.x <= -25f)
        {
            Destroy(gameObject);
        }

        if (GameManager.Instance.score > 500)
        {
            speed = 5f;
        }
        else if (GameManager.Instance.score >= 150 && GameManager.Instance.score <= 500)
        {
            speed = 3f;
        }
        else if (GameManager.Instance.score < 150)
        {
            speed = 3f;
        }

    }

    void OnMouseDown()
    {
        if (!GameManager.Instance.isGameOver)
        {
            if (GameManager.Instance.activeWeapon == GameManager.NEEDLE)
            {
                SoundManager.Instance.PlaySFX(destroyed);
                fallingBaby = Instantiate(fallingBabyPrefab, baby.transform.position, Quaternion.identity);

                fallingBaby.GetComponent<FallingBaby>().setParentType(0);
                fallingBaby.GetComponent<SpriteRenderer>().sprite = GameManager.Instance.sprites[transform.GetChild(0).GetComponent<Baby>().texture];

                fallingBaby.transform.parent = null;

                Destroy(gameObject);

                Debug.Log("Nadel - Ballon");
            }

            else if (GameManager.Instance.activeWeapon == GameManager.SYRINGE)
            {
                Debug.Log("Spritze - Ballon");
            }

            else if (GameManager.Instance.activeWeapon == GameManager.WATER)
            {
                Debug.Log("Wasser - Ballon");
            }
        }
        
    }
}
