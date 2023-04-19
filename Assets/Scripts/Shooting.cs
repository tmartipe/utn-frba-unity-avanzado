using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    public Transform shootingPosition;
    
    public void ShootToPlayer(float dmg)
    {
        bool choco = Physics.Raycast(shootingPosition.position, transform.forward, out var hit);
        Debug.DrawRay(shootingPosition.position, transform.forward * 100, Color.green);
        if (choco && hit.transform.tag == "Player")
        {
            hit.transform.gameObject.GetComponent<Life>().ReceiveDamage(dmg);
        }
    }
    
    
}
