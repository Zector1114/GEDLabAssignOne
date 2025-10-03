using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HorBlock : Block
{
    [SerializeField] Rigidbody2D rb;
    public float force = 5;

    public override void Fall()
    {
        rb.velocity += new Vector2(Random.Range(-force, force), 0);
    }
}
