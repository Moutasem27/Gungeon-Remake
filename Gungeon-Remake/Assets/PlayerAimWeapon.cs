using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CodeMonkey.Utils;
public class PlayerAimWeapon : MonoBehaviour
{
    // Start is called before the first frame update
    private Transform aimTransform;
    private void Awake()
    {
        aimTransform = transform.Find("Aim");
    }

    // Update is called once per frame
    private void Update()
    {
        Vector3 mousePosiiton = UtilsClass.GetMouseWorldPosition();

        Vector3 aimDirection = (mousePosiiton - transform.position).normalized;
        float angle = Mathf.Atan2(aimDirection.y, aimDirection.x) * Mathf.Rad2Deg;
        aimTransform.eulerAngles = new Vector3(0, 0, angle);
        Debug.Log(angle);
    }
}