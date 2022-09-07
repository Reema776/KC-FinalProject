using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movement : MonoBehaviour
{

    public float speed;
    public float sprintModifier;
    public float jumpForce;
    public Camera normalCam;
    public LayerMask ground;
    public Transform groundDedector;

    private Rigidbody rig;
    private float baseFOV;
    private float sprintFOVModifire = 1.5f;


    // Start is called before the first frame update
    private void Start()
    {
        baseFOV = normalCam.fieldOfView;
        Camera.main.gameObject.SetActive(false);
        rig = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //Axis
        float t_hmove = Input.GetAxis("Horizontal");
        float t_vmove = Input.GetAxis("Vertical");

        //controls
        bool spirt = Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.R);
        bool jump = Input.GetKey(KeyCode.Space);

        //states
        bool isGrounded = Physics.Raycast(groundDedector.position, Vector3.down, 0.1f, ground);
        bool isJumping = jump && isGrounded;
        bool isSpriting = spirt && t_vmove > 0 && !isJumping && isGrounded;
        

        //jumping
        if(isJumping)
        {
            rig.AddForce(Vector3.up * jumpForce);
        }


        Vector3 t_direction = new Vector3(t_hmove, 0, t_vmove);
        t_direction.Normalize();

        float t_edjustedSpeed = speed;
        if (isSpriting) t_edjustedSpeed *= sprintModifier;

        Vector3 t_targetVelocity = transform.TransformDirection(t_direction) * t_edjustedSpeed * Time.deltaTime;
        t_targetVelocity.y = rig.velocity.y;
        rig.velocity = t_targetVelocity;

        if (isSpriting) 
        { normalCam.fieldOfView = Mathf.Lerp(normalCam.fieldOfView, baseFOV * sprintFOVModifire, Time.deltaTime * 8f); }
        else
        { normalCam.fieldOfView = Mathf.Lerp(normalCam.fieldOfView, baseFOV, Time.deltaTime * 8f); }


    }


}
