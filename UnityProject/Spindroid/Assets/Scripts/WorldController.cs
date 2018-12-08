using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class WorldController : MonoBehaviour {

    public static WorldController instance = null;
    public List<GameObject> levels;
    public player_control playerRoot;
    private GameObject currentLevel;
    
    private int numLives;
    public int maxLives = 3;
    private List<GameObject> lives = new List<GameObject>();
    public Material ballMaterial;
    public GameObject buttonsGame;
    public GameObject gameOverCanvas;
    public GameObject levelCompletedCanvas;
    public GameObject selectorCanvas;
    public GameObject pauseCanvas;
    public GameObject gameRoot;

    [HideInInspector] // Hides var below
    public int numBricks;
    public int numLevel = 0;




    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }else if (instance != this)
        {
            Destroy(gameObject);
        }
        //Sets this to not be destroyed when reloading scene
        DontDestroyOnLoad(gameObject);


    }
    public static WorldController getWorldController()
    {
        
        return instance;
    }
   

    // Use this for initialization
    void Start () {
       
        //loadLevel(numLevel);
        /*
         * numLives = maxLives;
        for (int i = 0; i < numLives; i++)
        {
            GameObject sphere = GameObject.CreatePrimitive(PrimitiveType.Sphere);
            sphere.transform.localScale = new Vector3(0.1f, 0.1f, 0.1f);
            sphere.transform.position = new Vector3(-1.9f + i * 0.15f, 0.9f, 5);
            sphere.GetComponent<Renderer>().material = ballMaterial;
            lives.Add(sphere);
        }
        */

    }
	
	// Update is called once per frame
	void Update () {
		
	}


    public void hitBrick(Brick brick)
    {

        brick.hit();

        //NIVEL TERMINADO
        if(numBricks ==0)//Se cuenta 1 y no 0, porque Unity no borra el objeto instantaneamente.
        {
            levelCompleted();
        }

    }

    public void loseLife() {
        if (numLives > 0)
        {
            Destroy(lives[numLives - 1]);
            lives.RemoveAt(numLives - 1);
        }
        
        numLives--;
        if (numLives < 0)
        {
            //GAME OVER
            buttonsGame.GetComponent<Canvas>().planeDistance = -1;
            gameOverCanvas.GetComponent<Canvas>().planeDistance = 1;
            playerRoot.notMove();

        }
    }
    public void loadNextLevel()
    {

        loadLevel(numLevel);
    }
    public void loadLevel(int lv)
    {
        gameRoot.SetActive(true);
        numLevel = lv;
        Destroy(currentLevel);
        currentLevel = GameObject.Instantiate(levels[lv], new Vector3(0, 0, 10), new Quaternion(0, 0, 0, 0));
        currentLevel.transform.parent = gameRoot.transform;
        numBricks = currentLevel.transform.childCount;
        GameObject.FindGameObjectsWithTag("ball")[0].GetComponent<BallController>().resetBall();
        resetLives();

    }
    private void resetLives()
    {
        for(int i =0; i < numLives; i++)
        {
            Destroy(lives[0]);
            lives.RemoveAt(0);

        }
        numLives = maxLives;
        for (int i = 0; i < numLives; i++)
        {
            GameObject sphere = GameObject.CreatePrimitive(PrimitiveType.Sphere);
            sphere.transform.localScale = new Vector3(0.1f, 0.1f, 0.1f);
            sphere.transform.position = new Vector3(-1.9f + i * 0.15f, 0.9f, 5);
            sphere.GetComponent<Renderer>().material = ballMaterial;
            lives.Add(sphere);
        }
    }

    public void resetLevel()
    {
        
        loadLevel(numLevel);

        resetLives();

    }

    public void pause()
    {
        playerRoot.notMove();
        
        buttonsGame.GetComponent<Canvas>().planeDistance = -1;
        pauseCanvas.SetActive(true);
        pauseCanvas.GetComponent<Canvas>().planeDistance = 5;
        foreach (GameObject ball  in GameObject.FindGameObjectsWithTag("ball") )
        {
            ball.GetComponent<BallController>().pause();
        }


    }

    public void unpause()
    {
        
        buttonsGame.GetComponent<Canvas>().planeDistance = 5;
        pauseCanvas.GetComponent<Canvas>().planeDistance = -5;
        foreach (GameObject ball in GameObject.FindGameObjectsWithTag("ball"))
        {
            ball.GetComponent<BallController>().unpause();
        }
    }

    public void goToSelector()
    {
        unpause();
        gameRoot.SetActive(false);
        selectorCanvas.GetComponent<Canvas>().planeDistance = 1;
        

    }
    private void levelCompleted()
    {
        buttonsGame.SetActive(false);
        numLevel++;
        if (numLevel < levels.Count)
        {
            levelCompletedCanvas.SetActive(true);
            playerRoot.notMove();
            GameObject.FindGameObjectsWithTag("ball")[0].GetComponent<BallController>().resetBall();

            GameObject.Find("ButtonLevel" + (numLevel + 1)).GetComponent<UnityEngine.UI.Button>().interactable = true;

        }
        //FIN DEL JUEGO 
        else
        {
            goToSelector();
        }
        
            

    }
    
}
