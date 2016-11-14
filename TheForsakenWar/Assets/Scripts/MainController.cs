using UnityEngine;
using System.Collections;

// Contains all variables, which are needed for player and for correct game running
public class MainController : MonoBehaviour {

    public GameObject game;
    public SoundController soundController;
    public ScreenFader sf;

    [Header("Screens")]
    public GameObject startScreen;   

    [Header ("Cursors")]
    public CursorMode cursorMode = CursorMode.Auto;
    public Texture2D cursorTexture;

    void Start ( )
    {
        Cursor.SetCursor(cursorTexture, Vector2.zero, cursorMode);
    }
    
	
	// Update is called once per frame
	void Update () 
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            StopCoroutine(BackToMenu());
            StartCoroutine(BackToMenu());
        }
	}

    public void StartNewGame ( )
    {
        StopCoroutine(StartNewGameCoroutine());
        StartCoroutine(StartNewGameCoroutine());
    }

    private IEnumerator StartNewGameCoroutine ( )
    {
        yield return StartCoroutine(sf.FadeOutCoroutine());
        startScreen.SetActive(false);
        game.SetActive(true);
        yield return StartCoroutine(sf.FadeInCoroutine());        
    }

    public void QuitGame ( )
    {
        StopCoroutine(QuitGameCoroutine());
        StartCoroutine(QuitGameCoroutine());
    }

    private IEnumerator QuitGameCoroutine ( )
    {
        yield return StartCoroutine(sf.FadeOutCoroutine());
        Application.Quit();
    }

    private IEnumerator BackToMenu ( )
    {        
        yield return StartCoroutine(sf.FadeOutCoroutine());  
        game.SetActive(false);      
        startScreen.SetActive(true);
        yield return StartCoroutine(sf.FadeInCoroutine());             
    }

    


}
