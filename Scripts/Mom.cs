using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mom : MonoBehaviour
{

    private float speed = 5f;
    private float speedmultiplier = 1f;

    private bool run = false;
    private float currentTime = 0f;
    private float speedTimer = 0.5f;

    public GameObject pointsText;

    public AudioClip poke;

    public bool interactedForBonus = false;

    public Animator anim;

    private void Start()
    {
        anim = this.GetComponent<Animator>();
    }

    void Update()
    {
        
        if (run)
        {
            currentTime += Time.deltaTime;
            speed = speed * (speedmultiplier * 2);
            if (currentTime >= speedTimer)
            {
                currentTime = 0f;
                run = false;
            }
        }
        

        if (!GameManager.Instance.isGameOver)
        {
            transform.position = new Vector3(transform.position.x + speed * Time.deltaTime, transform.position.y, transform.position.z);
        }
        else
        {
            anim.SetTrigger("stop");
        }


        if (transform.position.x >= 25f)
        {
            Destroy(gameObject);
        }


        if (GameManager.Instance.score > 500)
        {
            speed = 4f;
        }
        else if (GameManager.Instance.score >= 150 && GameManager.Instance.score <= 500)
        {
            speed = 4f;
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
                if (!interactedForBonus)
                {
                    interactedForBonus = true;
                    GameManager.Instance.score += GameManager.Instance.bonus;
                    StartCoroutine(GameManager.Instance.pointsFadeOut(1f, pointsText, 0));
                }
                SoundManager.Instance.PlaySFX(poke);
                run = true;
                Debug.Log("Nadel - Mom");
            }

            else if (GameManager.Instance.activeWeapon == GameManager.SYRINGE)
            {
                if (!interactedForBonus)
                {
                    interactedForBonus = true;
                    GameManager.Instance.score += GameManager.Instance.bonus;
                }
                Debug.Log("Spritze - Mom");
            }

            else if (GameManager.Instance.activeWeapon == GameManager.WATER)
            {
                if (!interactedForBonus)
                {
                    interactedForBonus = true;
                    GameManager.Instance.score += GameManager.Instance.bonus;
                }
                Debug.Log("Wasser - Mom");
            }
        }

    }

    IEnumerator pointsFadeOut(float seconds)
    {
        float currentAlpha = 1f;
        float startAlpha = 1f;
        float myTime = 0f;

        while (myTime < seconds)
        {
            myTime += Time.deltaTime;
            currentAlpha -= (startAlpha / seconds * Time.deltaTime) / startAlpha;

            pointsText.GetComponent<CanvasRenderer>().SetAlpha(currentAlpha);
            pointsText.transform.position = new Vector3(pointsText.transform.position.x, pointsText.transform.position.y - (pointsText.transform.position.y * Time.deltaTime)/5, pointsText.transform.position.z);

            yield return null;
        }
    }

}
