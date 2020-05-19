using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public Rigidbody rb;
    public float MovementSpeed = 30f;
    public float AccelerationSpeed = 0f;
    public float Timer;
    public Vector3 coastDirection;
    bool TimerClear = true;
    public float AccelerationTime = 2f;
    public float DecelerationTime = 1f;
    public float DecelerationSpeed = 0f;
    public float DecelerationTimer;
    public float OldAccelerationSpeed;

    // Start is called before the first frame update
    void Start()
    {
        Timer = 0;
        OldAccelerationSpeed = 0f;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //the best worst jump function ever created
        if (Input.GetButtonDown("Fire1")) //update to only work when touching ground
        {
            rb.AddForce(Vector3.up * 1500f);
        }

        //Goodbye acceleration code, you were too good for this world, although likely not terribly efficient
        /*if (Input.GetAxis("Horizontal") > 0 || Input.GetAxis("Horizontal") < 0 || Input.GetAxis("Vertical") < 0 || Input.GetAxis("Vertical") > 0)
        {
            
            coastDirection = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
            DecelerationTimer = 0f;
            DecelerationSpeed = 0f;
            if (Timer < AccelerationTime)
            {
                Timer += Time.deltaTime;
            }
            if (Timer > AccelerationTime)
            {
                Timer = AccelerationTime;
            }

            AccelerationSpeed = Mathf.Pow(2, 0.5f * Timer) - 1f; //oncollisionenter stop the capsule collider from accelerating in the direction of the collision obstacle
            //AccelerationSpeed = -1 * (Mathf.Pow(2, 0.5f * Timer) - 2f);

            /*if (AccelerationSpeed > OldAccelerationSpeed)
            {
                OldAccelerationSpeed = AccelerationSpeed;
            }

            OldAccelerationSpeed = AccelerationSpeed;
            
            Debug.Log(OldAccelerationSpeed);
        }
        else
        {
            Timer = 0f;
            AccelerationSpeed = 0f;
            if (DecelerationTimer < DecelerationTime)
            {
                DecelerationTimer += Time.deltaTime;
            }
            else if (DecelerationTimer >= DecelerationTime)
            {
                DecelerationTimer = DecelerationTime;
            }

            //DecelerationSpeed = Mathf.Pow(-1f * 0.25f * DecelerationTimer, 2f) + 1f; //Alternative deceleration method. requires Deceleration time to be 2f, uses a parabola instead of exponential
            //DecelerationSpeed = (Mathf.Pow(2, (-1 * DecelerationTimer) + 1f) - 1f);  //Alternative deceleration method, uses inverted exponential. requires deceleration time to be 1f.
            DecelerationSpeed = -1 * (Mathf.Pow(2, DecelerationTimer) - 2f);
            rb.AddForce(coastDirection * Time.fixedDeltaTime * MovementSpeed * DecelerationSpeed * OldAccelerationSpeed);
        }*/


        //Debug.Log(Input.GetAxis("Horizontal"));
        

        //This one is a lot more fun but doesn't work with collision :(
        //transform.Translate(new Vector3(Input.GetAxis("Horizontal") * Time.fixedDeltaTime * MovementSpeed * AccelerationSpeed, 0, Input.GetAxis("Vertical") * Time.fixedDeltaTime * MovementSpeed * AccelerationSpeed));
        
        //This is the boring smoring physics based one
        rb.AddForce(new Vector3(Input.GetAxis("Horizontal") * Time.fixedDeltaTime * MovementSpeed, 0, Input.GetAxis("Vertical") * Time.fixedDeltaTime * MovementSpeed));
    }
}
