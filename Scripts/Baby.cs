using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Baby : MonoBehaviour
{

    public AudioClip[] crying;
    public AudioClip syringe;
    public AudioClip water;

    public GameObject pointsText;

    public int texture;

    public bool interactedForBonus = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
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
                    StartCoroutine(GameManager.Instance.pointsFadeOut(1f, pointsText, 1));
                }
                SoundManager.Instance.PlaySFX(crying[Random.Range(0, 2)]);
                Debug.Log("Nadel - Baby");
            }

            else if (GameManager.Instance.activeWeapon == GameManager.SYRINGE)
            {
                if (!interactedForBonus)
                {
                    interactedForBonus = true;
                    GameManager.Instance.score += GameManager.Instance.bonus;
                }
                SoundManager.Instance.PlaySFX(syringe);
                Debug.Log("Spritze - Baby");
            }

            else if (GameManager.Instance.activeWeapon == GameManager.WATER)
            {
                if (!interactedForBonus)
                {
                    interactedForBonus = true;
                    GameManager.Instance.score += GameManager.Instance.bonus;
                }
                SoundManager.Instance.PlaySFX(water);
                Debug.Log("Wasser - Baby");
            }
        }

    }
}
