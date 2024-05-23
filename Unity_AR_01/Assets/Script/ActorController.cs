using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActorController : MonoBehaviour
{
    [SerializeField] private float moveSpeed;

    private FixedJoystick fixedJoystick;
    private Rigidbody rb;

    private void OnEnable()
    {
        fixedJoystick = FindObjectOfType<FixedJoystick>();
        rb = gameObject.GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        float stick_horizontal = fixedJoystick.Horizontal;
        float stick_vertical   = fixedJoystick.Vertical;

        Vector3 movement = new Vector3(stick_horizontal , 0.0f , stick_vertical);
        rb.velocity = movement * moveSpeed;

        if (stick_horizontal != 0 && stick_vertical != 0)
        {
            //ジョイスティックの入力方向に基づいてオイラー角を算出
            transform.eulerAngles = new Vector3
                                   (
                                      transform.eulerAngles.x ,
                                      Mathf.Atan2(stick_horizontal , stick_vertical) * Mathf.Rad2Deg ,
                                      transform.eulerAngles.z
                                    );
        }
    }
}
