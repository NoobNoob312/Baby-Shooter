using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEditor;
using UnityEngine;

public class WeaponWindow : MonoBehaviour
{
    private bool cursorOverWeaponMenu = false;
    private bool rayHitWeaponMenu = false;

    private float currentTime = 0f;
    private float endTime = 0.2f;

    private Vector3 startPoint;
    private Vector3 endPoint;



    public bool menuOpened = false;
    public bool previousState = false;



    // Start is called before the first frame update
    void Start()
    {
        startPoint = transform.position;
        endPoint = new Vector3(transform.position.x, -5f, transform.position.z);
    }

    // Update is called once per frame
    void Update()
    {

        /*Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit2D[] hits = Physics2D.RaycastAll(ray.origin, ray.direction);
        
        rayHitWeaponMenu = false;
        foreach (RaycastHit2D rayhit in hits)
        {
            if (rayhit.collider.gameObject.name == "WeaponWindow")
            {
                rayHitWeaponMenu = true;
            }
        }

        if (rayHitWeaponMenu != cursorOverWeaponMenu)
        {
            if (cursorOverWeaponMenu == false)
            {
                currentTime += Time.deltaTime;

                float normalizedTime = currentTime / endTime;
                transform.position = Vector3.Lerp(startPoint, endPoint, normalizedTime);
            }
            else
            {
                currentTime += Time.deltaTime;

                float normalizedTime = currentTime / endTime;
                transform.position = Vector3.Lerp(endPoint, startPoint, normalizedTime);
            }
            if (currentTime >= endTime)
            {
                currentTime = 0f;
                cursorOverWeaponMenu = rayHitWeaponMenu;
            }
        }*/

        if (previousState != menuOpened)
        {
            currentTime = 0f;
            previousState = menuOpened;
        }

        if (menuOpened)
        {
            currentTime += Time.deltaTime;

            float normalizedTime = currentTime / endTime;
            transform.position = Vector3.Lerp(startPoint, endPoint, normalizedTime);
        }
        else
        {
            currentTime += Time.deltaTime;

            float normalizedTime = currentTime / endTime;
            transform.position = Vector3.Lerp(endPoint, startPoint, normalizedTime);
        }

    }

    public void changeWeaponGUI(int newWeapon)
    {
        transform.GetChild(newWeapon).transform.localPosition = new Vector3(transform.GetChild(newWeapon).transform.localPosition.x, transform.GetChild(newWeapon).transform.localPosition.y + 0.02f, transform.GetChild(newWeapon).transform.localPosition.z);
        transform.GetChild(GameManager.Instance.activeWeapon).transform.localPosition = new Vector3(transform.GetChild(GameManager.Instance.activeWeapon).transform.localPosition.x, transform.GetChild(GameManager.Instance.activeWeapon).transform.localPosition.y - 0.02f, transform.GetChild(GameManager.Instance.activeWeapon).transform.localPosition.z);
        
        GameManager.Instance.changeWeapon(newWeapon);
    }

    private void OnMouseEnter()
    {
        menuOpened = !menuOpened;
    }

    private void OnMouseExit()
    {
        menuOpened = !menuOpened;
    }

}
