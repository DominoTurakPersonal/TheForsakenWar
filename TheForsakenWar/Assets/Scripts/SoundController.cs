using UnityEngine;
using System.Collections;

public class SoundController : MonoBehaviour {

    public AudioSource menuClick;

    public void PlayMenuClick ( )
    {
        menuClick.Play();
    }
}
