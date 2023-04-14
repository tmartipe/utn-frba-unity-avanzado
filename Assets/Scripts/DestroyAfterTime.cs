using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyAfterTime : MonoBehaviour
{
    public float timeUntilDeletion;
    void Update()
    {
        if (timeUntilDeletion == 0)
            Destroy(gameObject);
        else
            timeUntilDeletion -= Time.deltaTime;
    }
}
