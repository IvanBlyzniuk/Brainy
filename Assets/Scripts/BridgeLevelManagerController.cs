using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using TMPro;

public class BridgeLevelManagerController : MonoBehaviour
{
    private  string path = "Assets/Files/dictionary.txt";
    private int dictionaryLength = 0;
    public GameObject earthLeft;
    public GameObject earthRight;
    public GameObject letterObjectPrefab;
    public GameObject middleBridgePartPrefab;
    public GameObject leftBridgePartPrefab;
    public GameObject rightBridgePartPrefab;
    public GameObject hero;
    private List<char> characters = new List<char>();
    private string selectedWord;
    private int curPosition = 0;
    public int mistakesCount = 0;
    // Start is called before the first frame update
    void Start()
    {
        Init();
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private string ChooseTheWord()
    {
        string word = "";
        StreamReader reader = new StreamReader(path);
        int stop = Random.Range(1, dictionaryLength);
        for(int i = 0; i < stop; i++)
        {
            word = reader.ReadLine();
        }
        reader.Close();
        return word;
    }

    public bool CheckLetter(char letter)
    {
        if (selectedWord[curPosition] == letter)
        {
            BuildBridge();
            curPosition++;
            if (curPosition == selectedWord.Length)
            {
                hero.GetComponent<Rigidbody2D>().velocity = new Vector2(5f, 0);
            }
             return true;
        }
        // MakeMistake();
        mistakesCount++;
        Debug.Log(mistakesCount);
        if (mistakesCount == 3)
        {
            hero.GetComponent<Rigidbody2D>().velocity = new Vector2(5f, 0);
        }
        return false;

    }

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

    private void swap(List<char> list, int pos1, int pos2)
    {
        char tmp;
        tmp = list[pos1];
        list[pos1] = list[pos2];
        list[pos2] = tmp;
    }
    private void Init()
    {
        
        StreamReader reader = new StreamReader(path);
        while (reader.ReadLine() != null)
        {
            dictionaryLength++;
        }
        reader.Close();
        selectedWord = ChooseTheWord();
        Debug.Log(selectedWord);

        for (int i = 0; i < selectedWord.Length; i++)
        {
            characters.Add(selectedWord[i]);
        }
        Shuffle(characters);
        earthLeft.transform.position = new Vector3(earthLeft.transform.position.x - (GetSpriteWidth(middleBridgePartPrefab) * selectedWord.Length / 2), earthLeft.transform.position.y, earthLeft.transform.position.z);
        earthRight.transform.position = new Vector3(earthRight.transform.position.x + (GetSpriteWidth(middleBridgePartPrefab) * selectedWord.Length / 2), earthRight.transform.position.y, earthRight.transform.position.z);

        for (int i = 0; i < selectedWord.Length; i++)
        {
            GameObject lo = GameObject.Instantiate(letterObjectPrefab, new Vector3(0 - (float)(GetSpriteWidth(letterObjectPrefab) * selectedWord.Length /2)  + GetSpriteWidth(letterObjectPrefab) / 2 + i * GetSpriteWidth(letterObjectPrefab)
                , 3f, 0f), Quaternion.identity);
            lo.GetComponent<LetterController>().letter = characters[i];
            lo.GetComponentInChildren<TextMeshPro>().text = characters[i].ToString();
        }
    }
    private void BuildBridge()
    {
       
        GameObject bridgePart;
        if (curPosition == 0)
        {
            bridgePart = GameObject.Instantiate(leftBridgePartPrefab, new Vector3(earthLeft.transform.position.x + (GetSpriteWidth(earthLeft) / 2) + curPosition * GetSpriteWidth(leftBridgePartPrefab) +
            GetSpriteWidth(leftBridgePartPrefab) / 2
            , earthLeft.transform.position.y + (GetSpriteHeigth(earthLeft) / 2) - GetSpriteHeigth(leftBridgePartPrefab) / 2
            , 0f), Quaternion.identity);
        }
        else if (curPosition == selectedWord.Length-1)
        {
            bridgePart = GameObject.Instantiate(rightBridgePartPrefab, new Vector3(earthLeft.transform.position.x + (GetSpriteWidth(earthLeft) / 2) + curPosition * GetSpriteWidth(rightBridgePartPrefab) +
            GetSpriteWidth(rightBridgePartPrefab) / 2
            , earthLeft.transform.position.y + (GetSpriteHeigth(earthLeft) / 2) - GetSpriteHeigth(rightBridgePartPrefab) / 2
            , 0f), Quaternion.identity);
        }
        else
            bridgePart = GameObject.Instantiate(middleBridgePartPrefab, new Vector3(earthLeft.transform.position.x + (GetSpriteWidth(earthLeft) / 2) + curPosition * GetSpriteWidth(middleBridgePartPrefab) +
            GetSpriteWidth(middleBridgePartPrefab) / 2
            , earthLeft.transform.position.y + (GetSpriteHeigth(earthLeft) / 2) - GetSpriteHeigth(middleBridgePartPrefab) / 2
            , 0f), Quaternion.identity);
    }
    private void MakeMistake()
    {
        if(mistakesCount!=3)
            mistakesCount++;
    }

    private float GetSpriteWidth(GameObject gameObject)
    {
        return gameObject.GetComponent<SpriteRenderer>().bounds.size.x;
    }
    private float GetSpriteHeigth(GameObject gameObject)
    {
        return gameObject.GetComponent<SpriteRenderer>().bounds.size.y;
    }
}
