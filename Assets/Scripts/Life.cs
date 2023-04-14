using TMPro;
using UnityEngine;

public class Life : MonoBehaviour
{
    public float damage;
    private TMP_Text _text;

    private void Awake()
    {
        _text = GameObject.Find(transform.name + "Text").GetComponent<TMP_Text>();
    }

    public void ReceiveDamage(float dmg)
    {
        damage += dmg;
        _text.SetText(damage.ToString());
    }
}
