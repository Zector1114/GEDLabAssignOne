using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FastSpawn : BlockSpawn
{
    public FastBlock block;

    public override void Spawn()
    {
        Instantiate(block, new Vector3(Random.Range(-8f, 8f), gameObject.transform.position.y, 0), Quaternion.identity);
    }
}
