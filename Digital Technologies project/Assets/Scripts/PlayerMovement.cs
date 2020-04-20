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
    void Update()
    {
        if (Input.GetButtonDown("Fire"))
        {
            Debug.Log("jump");
        }


        if (Input.GetAxis("Horizontal") > 0 || Input.GetAxis("Horizontal") < 0 || Input.GetAxis("Vertical") < 0 || Input.GetAxis("Vertical") > 0)
        {
            
            coastDirection = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical")); //this is wrong because vector2 uses x and y not x and z, valve plz fix
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

            AccelerationSpeed = Mathf.Pow(2, 0.5f * Timer) - 1f;
            //AccelerationSpeed = -1 * (Mathf.Pow(2, 0.5f * Timer) - 2f);

            /*if (AccelerationSpeed > OldAccelerationSpeed)
            {
                OldAccelerationSpeed = AccelerationSpeed;
            }*/

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
            transform.Translate(coastDirection * Time.deltaTime * MovementSpeed * DecelerationSpeed * OldAccelerationSpeed);
        }


        //Debug.Log(Input.GetAxis("Horizontal"));
        transform.Translate(Input.GetAxis("Horizontal") * Time.deltaTime * MovementSpeed * AccelerationSpeed, 0, Input.GetAxis("Vertical") * Time.deltaTime * MovementSpeed * AccelerationSpeed);
    }
}
