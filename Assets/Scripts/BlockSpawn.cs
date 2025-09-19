using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockSpawn : MonoBehaviour
{
    float timer = 0;
    public float targetTime = 0.5f;
    [SerializeField] GameObject block;

    // Update is called once per frame
    void Update()
    {
        if (timer >= targetTime)
        {
            Instantiate(block, new Vector3(Random.Range(-8f, 8f), gameObject.transform.position.y, 0), Quaternion.identity);

            timer = 0;
        }
        else
        {
            timer += Time.deltaTime;
        }
    }
}
