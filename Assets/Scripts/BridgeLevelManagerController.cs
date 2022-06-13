using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class BridgeLevelManagerController : MonoBehaviour
{
    private  string path = "Assets/Files/dictionary.txt";
    private int dictionaryLength = 0;
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

    private void Init()
    {
        StreamReader reader = new StreamReader(path);
        while (reader.ReadLine() != null)
        {
            dictionaryLength++;
        }
        reader.Close();
        Debug.Log(ChooseTheWord());

    }
}
