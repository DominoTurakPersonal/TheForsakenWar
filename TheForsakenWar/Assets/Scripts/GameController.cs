using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour {

    public GameObject mainCam;
    public GameObject hero;

	// Use this for initialization
	void Start () 
    {
	
	}
	
	// Update is called once per frame
	void Update () 
    {
	
	}

    void FixedUpdate ( )
    {
        // main camaera should follow player move
        mainCam.transform.localPosition = new Vector3(hero.transform.localPosition.x, mainCam.transform.localPosition.y, mainCam.transform.localPosition.z);
    }
}
