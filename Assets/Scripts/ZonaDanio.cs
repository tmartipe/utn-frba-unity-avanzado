using UnityEngine;
public class ZonaDanio : MonoBehaviour
    {

        public float atenuacion;
        private Life _vida;

        private void Awake()
        {
            _vida = GetComponentInParent<Life>();
        }

        public void RecibirDanio(float dmg)
        {
            _vida.vidaRestante -= (dmg * atenuacion);
            Debug.Log($"Se le hizo {dmg * atenuacion} de danio a {_vida.gameObject.name}");
            Debug.Log($"Le queda {_vida.vidaRestante} de vida");
            if(_vida.vidaRestante <= 0)
                Destroy(_vida.gameObject);
        }
    }
