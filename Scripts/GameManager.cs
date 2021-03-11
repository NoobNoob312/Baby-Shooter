using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{

    public AudioClip BackgroundClip;
    public AudioClip Won;

    private static GameManager instance = null;

    public static GameManager Instance
    {
        get
        {
            return instance;
        }
    }

    private void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(this.gameObject);
        }

    }

    public GameObject ballon;
    public GameObject bird;
    public GameObject drone;
    public GameObject catcherPrefab;
    public GameObject catcher;

    public Sprite[] sprites;

    public float score;
    public float bonus = 10f;

    public float currentTime = 0f;

    private float gameDuration = 60f;
    public float currentGameTime = 0f;
    public GameObject gameTimeText;

    public Texture2D cursor;

    public bool isGameOver = false;

    public GameObject scoreText;
    public GameObject gameoverScreen;
    public GameObject timeOverScreen;
    public GameObject backgroundScreen;
    public GameObject bloodSplatter;
    public Button restartBTN;
    public GameObject gameOverScore;
    public GameObject timeOverScore;

    public const int NEEDLE = 0;
    public const int SYRINGE = 1;
    public const int WATER = 2;

    public GameObject fallingBabyPrefab;

    private int randomSpawn;

    public enum Weapons { Needle, Syringe, Water };

    public int activeWeapon;

    // Spawn
    float randX;
    Vector2 whereToSpawn;
    private float spawnRate = 2.5f;
    private float spawnRateCatcher = 3.5f;
    private float currentTimeCatcher = 0f;
    float nextSpawn = 0.0f;

    public bool isPaused = true;
    public bool isStartMenu = true;
    public bool isHowToPlay = false;

    public GameObject[] timeOverBabys;

    public GameObject buttonHandler;

    public bool soundPlayed = false;

    void Start()
    {
        SoundManager.Instance.PlayMusic(BackgroundClip);

        score = 0f;
        Cursor.SetCursor(cursor, new Vector2(cursor.width / 2, cursor.height / 2), CursorMode.Auto);

        Button btn = restartBTN.GetComponent<Button>();
        btn.onClick.AddListener(() => { RestartBTN(true); });

        activeWeapon = NEEDLE;

        Time.timeScale = 0;
    }

    // Update is called once per frame
    void Update()
    {
        /*Time.timeScale = 1f;
        if (Input.GetKeyDown(KeyCode.B))
        {
            IntroBabySpawn();
        }*/
        if (Input.GetKeyDown("escape"))
        {
            buttonHandler.GetComponent<ButtonHandler>().HandleEscape();
        }

        if (isGameOver && currentGameTime < gameDuration)
        {
            gameoverScreen.SetActive(true);
            bloodSplatter.SetActive(true);
            gameOverScore.GetComponent<TextMeshProUGUI>().text = "Your Score: " + score;
        }
        else if (isGameOver && currentGameTime >= gameDuration)
        {
            if (!soundPlayed)
            {
                soundPlayed = true;
                SoundManager.Instance.PlaySFX3();
            }
            
            backgroundScreen.SetActive(true);
            timeOverScreen.SetActive(true);
            timeOverScore.GetComponent<TextMeshProUGUI>().text = "Your Score: " + score;
        }

        scoreText.GetComponent<TextMeshProUGUI>().SetText(score.ToString());
        gameTimeText.GetComponent<TextMeshProUGUI>().SetText(((int)(gameDuration - currentGameTime)).ToString());
        if (!isGameOver)
        {
            currentTime += Time.deltaTime;
            currentTimeCatcher += Time.deltaTime;
            currentGameTime += Time.deltaTime;
            if (currentGameTime >= gameDuration)
            {
                isGameOver = true;
            }
            if (currentTimeCatcher >= spawnRateCatcher)
            {
                currentTimeCatcher = 0f;
                randX = Random.Range(-20f, -14f);
                whereToSpawn = new Vector3(randX, -3.3f, -0.1f);
                catcher = Instantiate(catcherPrefab, whereToSpawn/*new Vector3(-18f, -4.65f, -0.1f)*/, Quaternion.identity);


            }

            

            if (currentTime >= spawnRate)
            {
                if (score > 500)
                {
                    randomSpawn = Random.Range(0, 3);
                }
                else if (score >= 150 && score <= 500)
                {
                    randomSpawn = Random.Range(0, 2);
                }
                else if (score < 150)
                {
                    randomSpawn = Random.Range(0, 1);
                }

                if (randomSpawn == 0)
                {

                    currentTime = 0f;
                    randX = Random.Range(12.0f, 18.0f);
                    whereToSpawn = new Vector3(randX, 3.5f, -7f);
                    int randomBaby = Random.Range(0, sprites.Length);
                    GameObject newObject = Instantiate(ballon, /*new Vector3(18f, 4.5f, -7f)*/ whereToSpawn, Quaternion.identity);
                    newObject.transform.GetChild(0).GetComponent<SpriteRenderer>().sprite = sprites[randomBaby];
                    newObject.transform.GetChild(0).GetComponent<Baby>().texture = randomBaby;
                }

                else if (randomSpawn == 1)
                {

                    currentTime = 0f;
                    randX = Random.Range(12.0f, 18.0f);
                    whereToSpawn = new Vector3(randX, 4.5f, -7f);
                    int randomBaby = Random.Range(0, sprites.Length);
                    GameObject newObject = Instantiate(bird, whereToSpawn, Quaternion.identity);
                    newObject.transform.GetChild(0).GetChild(0).GetComponent<SpriteRenderer>().sprite = sprites[randomBaby];
                    newObject.transform.GetChild(0).GetChild(0).GetComponent<Baby>().texture = randomBaby;

                }
                else if (randomSpawn == 2)
                {

                    currentTime = 0f;
                    randX = Random.Range(12.0f, 18.0f);
                    whereToSpawn = new Vector3(randX, 2.5f, -7f);
                    int randomBaby = Random.Range(0, sprites.Length);
                    GameObject newObject = Instantiate(drone, whereToSpawn, Quaternion.identity);
                    newObject.transform.GetChild(0).GetComponent<SpriteRenderer>().sprite = sprites[randomBaby];
                    newObject.transform.GetChild(0).GetComponent<Baby>().texture = randomBaby;

                }
            }
        }




    }

    IEnumerator waitSeconds(float x)
    {
        yield return new WaitForSecondsRealtime(x);
        gameoverScreen.SetActive(true);
        bloodSplatter.SetActive(true);
    }

    public void RestartBTN(bool reloadMusic)
    {
        Time.timeScale = 1;
        isPaused = false;
        soundPlayed = false;
        currentGameTime = 0f;
        currentTime = 0f;
        currentTimeCatcher = 0f;
        score = 0f;
        activeWeapon = NEEDLE;
        gameoverScreen.SetActive(false);
        timeOverScreen.SetActive(false);
        bloodSplatter.SetActive(false);
        isGameOver = false;
        if (reloadMusic)
        {
            SoundManager.Instance.StopMusic();
            SoundManager.Instance.PlayMusic(BackgroundClip);
        }
        UnityEngine.SceneManagement.SceneManager.LoadScene(0);
    }

    public void changeWeapon(int newWeapon)
    {
        activeWeapon = newWeapon;
    }

    public void moveTimeOverBabys()
    {
        //StartCoroutine(mTBCoroutine());
    }

    public void IntroBabySpawn()
    {
        for (int i = 0; i < 2500; i++)
        {
            GameObject newBaby = Instantiate(fallingBabyPrefab, new Vector3(Random.Range(-10.5f, 10.5f), Random.Range(10.6f, 29f), 0), Quaternion.Euler(0f, 0f, Random.Range(0f, 360f)));
            newBaby.GetComponent<BoxCollider2D>().enabled = false;
            newBaby.GetComponent<SpriteRenderer>().sprite = sprites[Random.Range(0, sprites.Length)];
            newBaby.GetComponent<Rigidbody2D>().gravityScale = Random.Range(0.3f, 3f);
        }
    }

    public IEnumerator pointsFadeOut(float seconds, GameObject text, int direction)
    {
        float currentAlpha = 1f;
        float startAlpha = 1f;
        float myTime = 0f;

        while (myTime < seconds)
        {
            myTime += Time.deltaTime;
            currentAlpha -= (startAlpha / seconds * Time.deltaTime) / startAlpha;

            text.SetActive(true);
            text.GetComponent<CanvasRenderer>().SetAlpha(currentAlpha);
            if (direction == 0)
            {
                text.transform.position = new Vector3(text.transform.position.x, text.transform.position.y - (text.transform.position.y * Time.deltaTime) / 5, text.transform.position.z);
            }
            else
            {
                text.transform.position = new Vector3(text.transform.position.x, text.transform.position.y + (text.transform.position.y * Time.deltaTime) / 5, text.transform.position.z);
            }


            yield return null;
        }
    }

}
