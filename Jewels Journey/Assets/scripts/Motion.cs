using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Motion : MonoBehaviour
{
    public float speed;

    private Rigidbody rig;

    private void Start()
    {
        rig = GetComponent<Rigidbody>();
    }
    void FixedUpdate()
    {
        float t_Hmove = Input.GetAxis("horizantal");
        float t_Vmove = Input.GetAxis("Virtical");

        Vector2 t_diriction = new Vector2 (t_Hmove, t_Vmove);
        t_diriction.Normalize();

        rig.velocity = transform.TransformDirection(t_diriction) * speed;
    }
}
