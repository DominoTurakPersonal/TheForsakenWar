using UnityEngine;
using System.Collections;

public class ParallaxSprite : MonoBehaviour
{
    
    public float scaleToCharacter;
    public bool autoScale;
    public bool autoDistanceHorizon;
    public bool autoDistanceRelative;
    public float distance;

    public bool realistic;
    public float absX;
    public Camera cam;

    public ParallaxEnvironment env;

    private float origX;
    private float origY;
    private float origPlayerPos;

    // Use this for initialization
    void Start()
    {
    
        origPlayerPos = env.player.transform.position.x;
        origX = transform.position.x;
        origY = transform.position.y;

        float camX = cam.transform.position.x;
        float camZ = -cam.transform.position.z;
        absX = camX + (origX-camX) * (distance + camZ) / camZ;
        if (autoScale)
        { 
            setScale();
        }
        if (autoDistanceHorizon)
        {
            setDistance(false);
        }
        if (autoDistanceRelative)
        {
            setDistance(true);
        }
    }

    float getPerspectiveFactor()
    {
        if(realistic)
        {
            float camZ = -cam.transform.position.z;
            return 1 * camZ / (distance + camZ);
        }
        else
        {
            return (env.infinity - distance) * (-distance / (distance + 15) + 2) / env.infinity / 2;
        }
    }

    void setDistance(bool relative)
    {
        var pos = transform.position;
        pos.y = (relative ? origY : env.horizon) - env.getReferenceHeight()* getPerspectiveFactor();
        pos.z = distance;
        transform.position = pos;
    }

    void setScale()
    {
        float charHeight = env.getReferenceHeight();
        float myHeight = GetComponent<Renderer>().bounds.size.y;

        float targetHeight = charHeight * scaleToCharacter;
        float newScaleRatio = targetHeight / myHeight;
        float perspectiveRatio = getPerspectiveFactor();
        //perspectiveRatio = 1;
        transform.localScale *= newScaleRatio * perspectiveRatio;
    }

    // Update is called once per frame
    void Update ()
    {
        var pos = transform.position;
        if (realistic)
        {
            float camX = cam.transform.position.x;
            float camZ = -cam.transform.position.z;
            pos.x = camX + (absX - camX) * camZ / (distance + camZ);
        }
        else
        {
            float playerX = env.player.transform.position.x;
            pos.x = origX + (1 - getPerspectiveFactor()) * (playerX - origPlayerPos);
        }
        transform.position = pos;
    }
}
