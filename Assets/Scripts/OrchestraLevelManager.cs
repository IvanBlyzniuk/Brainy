using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrchestraLevelManager : MonoBehaviour
{
    [SerializeField]
    private int sequenceLength;
    private int score = 0;
    private int curPosition = 0;
    private List<int> inputs;
    private List<MusicianController> controllers;
    [SerializeField]
    private GameObject musician1;
    [SerializeField]
    private GameObject musician2;
    [SerializeField]
    private GameObject musician3;
    [SerializeField]
    private GameObject musician4;
    private MusicianController musician1Controller;
    private MusicianController musician2Controller;
    private MusicianController musician3Controller;
    private MusicianController musician4Controller;
    private LevelUIController levelUIController;
    private bool isScreenActive = true;
    private bool isPlayingMusicSequence = false;
    [SerializeField]
    private AudioSource winningMusic;

    public bool IsScreenActive { get => isScreenActive; set => isScreenActive = value; }
    public bool IsPlayingMusicSequence { get => isPlayingMusicSequence; set => isPlayingMusicSequence = value; }

    // Start is called before the first frame update
    void Start()
    {
        winningMusic.volume = PlayerPrefs.GetFloat("Volume");
        controllers = new List<MusicianController>();
        levelUIController = FindObjectOfType<LevelUIController>();
        musician1Controller = musician1.GetComponent<MusicianController>();
        musician2Controller = musician2.GetComponent<MusicianController>();
        musician3Controller = musician3.GetComponent<MusicianController>();
        musician4Controller = musician4.GetComponent<MusicianController>();
        controllers.Add(musician1Controller);
        controllers.Add(musician2Controller);
        controllers.Add(musician3Controller);
        controllers.Add(musician4Controller);
        StartCoroutine(WaitUntillTheFirstStart());
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void Init()
    {
        
        inputs = new List<int>();
        for (int i = 0; i < sequenceLength; i++)
        {
            int input = Random.Range(0,4);
            inputs.Add(input);
        }
        IsPlayingMusicSequence = true;
        StartCoroutine(PlayMusicSequence());
    }

    private IEnumerator PlayMusicSequence()
    {
        for(int i = 0; i < inputs.Count; i++)
        {
            StartCoroutine(controllers[inputs[i]].PlayMusic());
            yield return new WaitForSeconds(1f);
        }
        IsScreenActive = true;
        IsPlayingMusicSequence = false;
    }

    public IEnumerator CheckChoosenMusician(int number)
    {
        if (IsScreenActive && !IsPlayingMusicSequence && Time.deltaTime > 0)
        {
            
            if (inputs[curPosition] == number)
            {

                curPosition++;
                StartCoroutine(controllers[number].PlayMusic());
                if (curPosition == sequenceLength)
                {
                    yield return new WaitForSeconds(1f);
                    winningMusic.Play();
                    levelUIController.AddScore(1 + score / 3);
                    score++;
                    Debug.Log(score);
                    if (score % 3 == 0)
                    {
                        sequenceLength++;
                    }
                    curPosition = 0;
                    IsScreenActive = false;
                    yield return new WaitForSeconds(1.8f);
                    Init();
                }
            }
            else
            {
                levelUIController.MakeMistake();
                if(levelUIController.GetLifesCount() <= 0)
                {
                    levelUIController.LoseTheGame();
                }
                Debug.Log("Bad");
            }

        }
    }
    private IEnumerator WaitUntillTheFirstStart()
    {
        yield return new WaitForSeconds(1f);
        Init();  
    }
}
