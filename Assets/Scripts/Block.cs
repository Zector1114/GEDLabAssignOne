using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Block : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        Fall();

        if (gameObject.transform.position.y <= -20f)
        {
            Destroy(gameObject);
        }
    }

    public abstract void Fall();
}
