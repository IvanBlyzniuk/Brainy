using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
/// <summary>
/// class which controls te bridge game
/// </summary>
public class BridgeLevelManagerController : MonoBehaviour
{
    private bool isActive = true;
    private bool lost = false;
    private int curPosition = 0;
    private int level = 0;
    private int scoreToAdd = 1;
    private string selectedWord;
    private List<char> characters;
    private List<GameObject> objects;
    private List<GameObject> bridgeParts;
    private Vector3 instatntEarthLeftPosition;
    private Vector3 instatntEarthRightPosition;
    private LevelUIController levelUIController;
    [SerializeField]
    private GameObject earthLeft;
    [SerializeField]
    private GameObject earthRight;
    [SerializeField]
    private GameObject letterObjectPrefab;
    [SerializeField]
    private GameObject middleBridgePartPrefab;
    [SerializeField]
    private GameObject leftBridgePartPrefab;
    [SerializeField]
    private GameObject rightBridgePartPrefab;
    [SerializeField]
    private GameObject hero;
    [SerializeField]
    private TimerController timer;
    [SerializeField]
    private AudioSource music;
    [SerializeField]
    private TextAsset dictionary;
    private Animator anim;
    private AudioSource winSound;
    private string[] words;

    /// <summary>
    /// Start is called before the first frame update
    /// </summary>
    void Start()
    {
        if (FindObjectOfType<MainMusicController>()!= null)
            Destroy(FindObjectOfType<MainMusicController>().gameObject);
        timer = FindObjectOfType<TimerController>();
        levelUIController = FindObjectOfType<LevelUIController>();
        instatntEarthLeftPosition = earthLeft.transform.position;
        instatntEarthRightPosition = earthRight.transform.position;
        anim = hero.GetComponent<Animator>();
        winSound = GetComponent<AudioSource>();
        winSound.volume = PlayerPrefs.GetFloat("Volume");
        Init();
    }

    /// <summary>
    /// Update is called once per frame
    /// </summary>
    void Update()
    {
        if (timer.GetCurrentTime()<=0 && isActive)
        {
            isActive = false;
            levelUIController.MakeMistake();
            if (levelUIController.GetLifesCount() == 0)
                lost = true;
            Debug.Log("Lose");
            StartCoroutine(GoToTheLose());
        } 
    }
    /// <summary>
    /// choses the random word from the dictionary 
    /// </summary>
    /// <returns>randomly chosen word</returns>
    private string ChooseTheWord()
    {
        if (words == null)
            words = dictionary.text.Split(new char[] { '\n', '\r' },System.StringSplitOptions.RemoveEmptyEntries);
        int index = Random.Range(0, words.Length);
        string word = words[index];
        return word;
    }
    /// <summary>
    /// checks if the player choses the right letter
    /// </summary>
    /// <param name="letter">letter on which player clicks</param>
    /// <returns>true if the letter is correct, otherwise - false</returns>
    public bool CheckLetter(char letter)
    {
        if (isActive && Time.deltaTime > 0)
        {
            if (selectedWord[curPosition] == letter)
            {
                BuildBridge();
                curPosition++;
                if (curPosition == selectedWord.Length)
                {
                    winSound.Play();
                    StartCoroutine(GoToTheWin());
                }
                return true;
            }
            levelUIController.MakeMistake();
            if (levelUIController.GetLifesCount() <= 0)
            {
                isActive = false;
                lost = true;
                StartCoroutine(GoToTheLose());
            }
        }
        return false;

    }
    /// <summary>
    /// shuffles the list of chars
    /// </summary>
    /// <param name="list">list to shuffle</param>
    public void Shuffle(List<char> list)
    {
        int firstIndex;
        int secondIndex;
        for (int i = 0; i < list.Count; i++)
        {
            firstIndex = Random.Range(0, list.Count);
            secondIndex = Random.Range(0, list.Count);
            swap(list,firstIndex,secondIndex);
        }
    }
    /// <summary>
    /// swaps two elements of the list of given positions
    /// </summary>
    /// <param name="list">list of elements</param>
    /// <param name="pos1">first element position</param>
    /// <param name="pos2">second element position</param>
    private void swap(List<char> list, int pos1, int pos2)
    {
        char tmp;
        tmp = list[pos1];
        list[pos1] = list[pos2];
        list[pos2] = tmp;
    }
    /// <summary>
    /// initiates the game conditions: moves the earth, choses the word and creates buttons with letters
    /// </summary>
    private void Init()
    {
        isActive = true;
        timer.IsActive = true;
        timer.TimeStart = GetTimeForLevel();
        characters = new List<char>();
        Debug.Log("Created array");
        objects = new List<GameObject>();
        bridgeParts = new List<GameObject>();
        curPosition = 0;
        //dictionaryLength = 0;
        //StreamReader reader = new StreamReader(path);
        //while (reader.ReadLine() != null)
        //{
        //    dictionaryLength++;
        //}
        //reader.Close();
        selectedWord = ChooseTheWord();
        for (int i = 0; i < selectedWord.Length; i++)
        {
            characters.Add(selectedWord[i]);
        }
        Shuffle(characters);
        earthLeft.transform.position = new Vector3(earthLeft.transform.position.x - (GetSpriteWidth(middleBridgePartPrefab) * (selectedWord.Length-2) / 2)  - GetSpriteWidth(leftBridgePartPrefab) +1f, earthLeft.transform.position.y, earthLeft.transform.position.z);
        earthRight.transform.position = new Vector3(earthRight.transform.position.x + (GetSpriteWidth(middleBridgePartPrefab) * selectedWord.Length / 2)-1f, earthRight.transform.position.y, earthRight.transform.position.z);
        for (int i = 0; i < selectedWord.Length; i++)
        {
            GameObject lo = GameObject.Instantiate(letterObjectPrefab, new Vector3(0 + i * (GetSpriteWidth(letterObjectPrefab)+0.1f) - ((float)(GetSpriteWidth(letterObjectPrefab) + 0.1) * selectedWord.Length / 2) + GetSpriteWidth(letterObjectPrefab) / 2
                , 3f, 0f), Quaternion.identity);
            lo.GetComponent<LetterController>().Letter = characters[i];
            lo.GetComponentInChildren<TextMeshPro>().text = characters[i].ToString();
            objects.Add(lo);
        }
        hero.transform.position = new Vector3(-8f,0f,0f);
        
    }
    /// <summary>
    /// adds one port of the bridge in certain place
    /// </summary>
    private void BuildBridge()
    {
       
        GameObject bridgePart;
        if (curPosition == 0)
        {
            bridgePart = GameObject.Instantiate(leftBridgePartPrefab, new Vector3(earthLeft.transform.position.x - 0.5f  + GetSpriteWidth(earthLeft)/2  + GetSpriteWidth(leftBridgePartPrefab)/2 ,
                earthLeft.transform.position.y + GetSpriteHeigth(earthLeft) / 2 + GetSpriteHeigth(leftBridgePartPrefab) / 2 - 0.1f,
                0),Quaternion.identity); 
        }
        else if (curPosition == selectedWord.Length-1)
        {
            bridgePart = GameObject.Instantiate(rightBridgePartPrefab, new Vector3(bridgeParts[curPosition - 1].transform.position.x + GetSpriteWidth(bridgeParts[curPosition - 1]) / 2 + GetSpriteWidth(rightBridgePartPrefab) / 2 - 0.1f,
                bridgeParts[curPosition - 1].transform.position.y, 0), Quaternion.identity);
        }
        else
            bridgePart = GameObject.Instantiate(middleBridgePartPrefab, new Vector3(bridgeParts[curPosition - 1].transform.position.x + GetSpriteWidth(bridgeParts[curPosition - 1])/2 + GetSpriteWidth(middleBridgePartPrefab) / 2 - 0.1f,
                bridgeParts[curPosition - 1].transform.position.y, 0), Quaternion.identity);

        bridgeParts.Add(bridgePart);
    }
    
    /// <summary>
    /// return sprite width of a gameObject
    /// </summary>
    /// <param name="gameObject">gameObject to get sprite width</param>
    /// <returns>width of the sprite of the object</returns>
    private float GetSpriteWidth(GameObject gameObject)
    {
        return gameObject.GetComponent<SpriteRenderer>().bounds.size.x;
    }
    /// <summary>
    /// return sprite heigth of a gameObject
    /// </summary>
    /// <param name="gameObject">gameObject to get sprite width heigth</param>
    /// <returns>heigth of the sprite of the object</returns>
    private float GetSpriteHeigth(GameObject gameObject)
    {
        return gameObject.GetComponent<SpriteRenderer>().bounds.size.y;
    }
    /// <summary>
    /// ienumerator to start coroutine when we want player to go through the bridge and win the level
    /// </summary>
    /// <returns>time to wait</returns>
    IEnumerator GoToTheWin()
    {
        isActive = false;
        timer.IsActive = false;
        level++;
        hero.GetComponent<Rigidbody2D>().velocity = new Vector2(5f, 0);
        anim.SetFloat("Speed", hero.GetComponent<Rigidbody2D>().velocity.x);
        levelUIController.AddScore(scoreToAdd);
        yield return new WaitForSeconds(4f);
        RecreateGameConditions();
    }
    /// <summary>
    /// ienumerator to start coroutine when we want player to go through the unfinished bridge and lose the level
    /// </summary>
    /// <returns>time to wait</returns>
    IEnumerator GoToTheLose()
    {
        timer.IsActive = false;
        hero.GetComponent<Rigidbody2D>().velocity = new Vector2(5f, 0);
        yield return new WaitForSeconds(4f);
        if (lost)
        {
            SavesManager.getInstance().saveBridgeGameScore(levelUIController.GetScore());
            levelUIController.LoseTheGame();
        }
        else
        {
            RecreateGameConditions();
        }
        
    }
    /// <summary>
    /// restarts the level recreating different game conditions to their initial state
    /// </summary>
    private void RecreateGameConditions()
    {
        foreach (GameObject gameObject in objects)
            Destroy(gameObject);
        
        foreach (GameObject gameObject in bridgeParts)
            Destroy(gameObject);
        earthLeft.transform.position = instatntEarthLeftPosition;
        earthRight.transform.position = instatntEarthRightPosition;
        hero.GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
        anim.SetFloat("Speed", hero.GetComponent<Rigidbody2D>().velocity.x);
        Init();
    }
    /// <summary>
    /// choses the difficulty in time for the current level
    /// </summary>
    /// <returns></returns>
    private float GetTimeForLevel()
    {
        switch (level)
        {
            case <= 4:
                return 20;
            case <= 8:
                scoreToAdd = 2;
                return 15;
            case <= 15:
                scoreToAdd = 3;
                return 10;
            case <= 20:
                scoreToAdd = 4;
                return 8;
            case > 20:
                scoreToAdd = 5;
                return 6;
        }
    }
}
