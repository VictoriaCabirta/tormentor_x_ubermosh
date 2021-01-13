using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MorirSonidos : MonoBehaviour
{
    #region Variables
    AudioSource audioSource;

    public AudioClip clipEnemigo, clipPlayer;

    public int cod = 0;
    #endregion

    void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {

        //Dependiendo de si es un enemigo o un genera enemigos, hace un sonido distinto
        #region Sonidos
        if (cod != 0)
        {
            switch (cod)
            {
                case 1:
                    audioSource.PlayOneShot(clipEnemigo, 1);
                    break;
                case 2:
                    audioSource.PlayOneShot(clipPlayer, 1);
                    break;
            }
            cod = 0;
        }
        #endregion

    }

}
