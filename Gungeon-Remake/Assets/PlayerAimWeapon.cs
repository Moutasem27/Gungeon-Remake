using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CodeMonkey.Utils;
public class PlayerAimWeapon : MonoBehaviour
{
    // Start is called before the first frame update
    private Transform aimTransform;
    private Animator aimAnimator;
    private void Awake()
    {
        aimTransform = transform.Find("Aim");
        aimAnimator = aimTransform.GetComponent<Animator>();
    }

    // Update is called once per frame
    private void Update()
    {
        HandleAiming();
        HandleShooting();
    }
    
    private void HandleAiming()
    {
        Vector3 mousePosiiton = UtilsClass.GetMouseWorldPosition();

        Vector3 localScale = Vector3.one;

        Vector3 aimDirection = (mousePosiiton - transform.position).normalized;
        float angle = Mathf.Atan2(aimDirection.y, aimDirection.x) * Mathf.Rad2Deg;
        aimTransform.eulerAngles = new Vector3(0, 0, angle);
        Debug.Log(angle);
        if (angle > 90 || angle < -90)
        {
            localScale.y = -1f;
        }
        else
        {
            localScale.y = +1f;
        }
      //  aimTransform.localScale.y = localScale.y;
    }

    private void HandleShooting()
    {
        if(Input.GetMouseButtonDown(0))
        {
            aimAnimator.SetTrigger("Shoot");
        }
    }
}