using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bird : MonoBehaviour
{

    public AudioClip hit;

    public GameObject baby;
    public GameObject fallingBabyPrefab;
    public GameObject fallingBaby;
    public Animator anim;

    public AudioClip birdSound;

    public float speed = 5;

    // Start is called before the first frame update
    void Start()
    {
        anim = this.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!GameManager.Instance.isGameOver)
        {
            transform.position = new Vector3(transform.position.x - speed * Time.deltaTime, transform.position.y + Mathf.Sin(Time.time * 3f) * Time.deltaTime, transform.position.z);
        }
        else
        {
            anim.SetTrigger("stop");
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
                SoundManager.Instance.PlaySFX(hit);
                fallingBaby = Instantiate(fallingBabyPrefab, baby.transform.position, Quaternion.identity);
                fallingBaby.GetComponent<SpriteRenderer>().sprite = GameManager.Instance.sprites[transform.GetChild(0).GetChild(0).GetComponent<Baby>().texture];
                fallingBaby.GetComponent<FallingBaby>().setParentType(1);
                fallingBaby.transform.parent = null;
                Destroy(gameObject);
                Debug.Log("Nadel - Bird");
            }

            else if (GameManager.Instance.activeWeapon == GameManager.SYRINGE)
            {
                SoundManager.Instance.PlaySFX(birdSound);
                fallingBaby = Instantiate(fallingBabyPrefab, baby.transform.position, Quaternion.identity);
                fallingBaby.GetComponent<SpriteRenderer>().sprite = GameManager.Instance.sprites[transform.GetChild(0).GetChild(0).GetComponent<Baby>().texture];
                fallingBaby.GetComponent<FallingBaby>().setParentType(1);
                fallingBaby.transform.parent = null;
                Destroy(gameObject);
                Debug.Log("Spritze - Bird");
            }

            else if (GameManager.Instance.activeWeapon == GameManager.WATER)
            {
                Debug.Log("Wasser - Bird");
            }
        }
        
        
    }
}
