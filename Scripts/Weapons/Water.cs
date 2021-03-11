using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Water : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnMouseDown()
    {
        transform.parent.gameObject.GetComponent<WeaponWindow>().changeWeaponGUI(GameManager.WATER);
    }

    private void OnMouseEnter()
    {
        transform.GetComponentInParent<WeaponWindow>().menuOpened = !transform.GetComponentInParent<WeaponWindow>().menuOpened;
    }

    private void OnMouseExit()
    {
        transform.GetComponentInParent<WeaponWindow>().menuOpened = !transform.GetComponentInParent<WeaponWindow>().menuOpened;
    }
}
