using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ScreenFader : MonoBehaviour {

    private bool isFading = false;

    public IEnumerator FadeInCoroutine ( )
    {        
        this.gameObject.SetActive(true);
        isFading = true;
        GetComponent<Animator>().SetTrigger("FadeIn");

        while(isFading)
            yield return null;            
    }

    public IEnumerator FadeOutCoroutine ( )
    {
        this.gameObject.SetActive(true);
        isFading = true;
        GetComponent<Animator>().SetTrigger("FadeOut");

        while(isFading)
            yield return null;
            
    }

    void AnimationComplete ( )
    {              
        isFading = false;
    }
	
}
