using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FastBlock : Block
{
    [SerializeField] Rigidbody2D rb;
    public float force = 5;

    public override void Fall()
    {
        rb.AddForce(new Vector2(0, -force));
    }
}
