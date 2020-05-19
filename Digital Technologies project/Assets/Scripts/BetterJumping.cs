using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BetterJumping : MonoBehaviour
{
    public float fallMultiplier = 5f;
    public float lowJumpMultiplier = 1f;

    Rigidbody rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }


    void FixedUpdate()
    {
        if (rb.velocity.y < 0)
        {
            rb.velocity += Vector3.up * Physics.gravity.y * (fallMultiplier) * Time.fixedDeltaTime;
        } /*else if (rb.velocity.y > 0 && !Input.GetButton("Fire1"))
        {
            rb.velocity += Vector3.up * Physics.gravity.y * (lowJumpMultiplier) * Time.deltaTime;
        }*/
    }
}
