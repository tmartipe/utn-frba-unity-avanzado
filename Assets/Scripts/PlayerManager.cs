using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerManager : MonoBehaviour
{
   private Life _life;

   private void Awake()
   {
      _life = GetComponent<Life>();
   }

   private void Update()
   {
      if (_life.vidaRestante <= 0)
      {
         SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
      }
   }
}
