using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BubbleLevelManagerController : MonoBehaviour
{
    [SerializeField]
    private GameObject leftSpawningBound;
    [SerializeField]
    private GameObject rightSpawningBound;
    [SerializeField]
    private GameObject bubble;
    [SerializeField]
    private float timeBetweenSpawns;

    private float timeTillSpawnLeft;
    private float _spawnLB;
    private float _spawnRB;
    private float _spawnY;
    private int lives = 3;
    private int livesLeft;
    private float speedModifier = 1;
    private LevelUIController levelUIController;

    // Start is called before the first frame update
    void Start()
    {
        Destroy(FindObjectOfType<MainMusicController>().gameObject);
        TimerController timer = FindObjectOfType<TimerController>();
        GameObject.Destroy(timer.gameObject, 4f);
        _spawnLB = leftSpawningBound.transform.position.x;
        _spawnRB = rightSpawningBound.transform.position.x;
        _spawnY = leftSpawningBound.transform.position.y;
        levelUIController = GameObject.FindObjectOfType<LevelUIController>();
        timeTillSpawnLeft = 0;
        livesLeft = lives;
        GetComponent<AudioSource>().volume = PlayerPrefs.GetFloat("Volume");
    }

    // Update is called once per frame
    void Update()
    {
        if(timeTillSpawnLeft <= 0)
        {
            timeTillSpawnLeft = timeBetweenSpawns;
            Instantiate(bubble,new Vector2(Random.Range(_spawnLB, _spawnRB), _spawnY), Quaternion.identity);
        }
        else
        {
            timeTillSpawnLeft -= Time.deltaTime;
        }
            
    }

    public void addScore()
    {
        levelUIController.AddScore(1);
        if (levelUIController.GetScore() % 5 == 0)
        {
            speedModifier += 0.2f;
            if(timeBetweenSpawns > 1)
                timeBetweenSpawns -= 0.2f;
        }
    }
    public void loseLife()
    {
        livesLeft--;
        levelUIController.MakeMistake();
        if (livesLeft == 0)
        {
            SavesManager.getInstance().saveBubbleGameScore(levelUIController.GetScore());
            levelUIController.LoseTheGame();
        }
    }

    public float getSpeedModifier()
    {
        return speedModifier;
    }
}
