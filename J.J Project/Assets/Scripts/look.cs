using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class look : MonoBehaviour
{
    public static bool cursorLocked = true;

    public Transform player;
    public Transform cams;
    //public Transform Weapon;

    public float xsensitivity;
    public float ysensitivity;
    public float maxAngle;

    private Quaternion camCenter;

    // Start is called before the first frame update
    void Start()
    {
        camCenter = cams.localRotation;
    }

    // Update is called once per frame
    void Update()
    {
        SetY();
        SetX();
        UpdateCursorLock();
    }

    void SetY()
    {
        float t_Input = Input.GetAxis("Mouse Y") * ysensitivity * Time.deltaTime;
        Quaternion t_adj = Quaternion.AngleAxis(t_Input, -Vector3.right);
        Quaternion t_delta = cams.localRotation * t_adj;

        if (Quaternion.Angle(camCenter, t_delta) < maxAngle)
        {
            cams.localRotation = t_delta;
        }
        //Weapon.rotation = cams.rotation;
    }


    void SetX()
    {
        float t_Input = Input.GetAxis("Mouse X") * xsensitivity * Time.deltaTime;
        Quaternion t_adj = Quaternion.AngleAxis(t_Input, Vector3.up);
        Quaternion t_delta = player.localRotation * t_adj;
        player.localRotation = t_delta;
        

    }

    void UpdateCursorLock()
    {
        if (cursorLocked)
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;

            if(Input.GetKeyDown(KeyCode.Escape))
            {
                cursorLocked = false;
            }
        }
        else
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;

            if (Input.GetKeyDown(KeyCode.Escape))
            {
                cursorLocked = true;
            }
        }

    }

}
