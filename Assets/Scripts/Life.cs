using TMPro;
using UnityEngine;

public class Life : MonoBehaviour
{
    public float vidaRestante;

    public void ReceiveDamage(float dmg)
    {
        vidaRestante -= dmg;
        Debug.Log(vidaRestante);
    }
}
