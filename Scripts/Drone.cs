using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drone : MonoBehaviour
{

    public GameObject baby;
    public GameObject fallingBabyPrefab;
    public GameObject fallingBaby;

    public AudioClip destroyed;

    private float speed = 5;

    public float currentTime = 0f;

    private float[] random;

    // Start is called before the first frame update
    void Start()
    {
        random = new float[4];
        for (int i = 0; i < random.Length; i++)
        {
            random[i] = Random.Range(1f, 3f);
        }
        


    }

    // Update is called once per frame
    void Update()
    {
        currentTime += Time.deltaTime;
        if (!GameManager.Instance.isGameOver)
        {
            transform.position = new Vector3(transform.position.x - (speed * Time.deltaTime + Mathf.Sin(currentTime * random[0]) * Time.deltaTime * random[1]), transform.position.y + Mathf.Sin(currentTime * 2) * (Time.deltaTime * 2), transform.position.z);
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
                fallingBaby.GetComponent<SpriteRenderer>().sprite = GameManager.Instance.sprites[transform.GetChild(0).GetComponent<Baby>().texture];
                fallingBaby.GetComponent<FallingBaby>().setParentType(2);
                fallingBaby.transform.parent = null;
                Destroy(gameObject);
                Debug.Log("Nadel - Drone");
            }

            else if (GameManager.Instance.activeWeapon == GameManager.SYRINGE)
            {
                
                Debug.Log("Spritze - Drone");
            }

            else if (GameManager.Instance.activeWeapon == GameManager.WATER)
            {
                SoundManager.Instance.PlaySFX(destroyed);
                fallingBaby = Instantiate(fallingBabyPrefab, baby.transform.position, Quaternion.identity);
                fallingBaby.GetComponent<SpriteRenderer>().sprite = GameManager.Instance.sprites[transform.GetChild(0).GetComponent<Baby>().texture];
                fallingBaby.GetComponent<FallingBaby>().setParentType(2);
                fallingBaby.transform.parent = null;
                Destroy(gameObject);
                Debug.Log("Wasser - Drone");
            }
        }
        
    }
}
