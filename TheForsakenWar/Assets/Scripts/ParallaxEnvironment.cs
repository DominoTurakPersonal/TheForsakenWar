using UnityEngine;
using System.Collections;

public class ParallaxEnvironment : MonoBehaviour {

    public float infinity;
    public float horizon;
    public HeroController player;
    
    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public float getReferenceHeight()
    {
        return player.getPixelSize();
    }
}
