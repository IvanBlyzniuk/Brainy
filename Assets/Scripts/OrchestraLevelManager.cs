using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrchestraLevelManager : MonoBehaviour
{

    private int level;
    private List<int> inputs;
    private List<MusicianController> controllers;
    public GameObject musician1;
    public GameObject musician2;
    public GameObject musician3;
    public GameObject musician4;
    private MusicianController musician1Controller;
    private MusicianController musician2Controller;
    private MusicianController musician3Controller;
    private MusicianController musician4Controller;
    // Start is called before the first frame update
    void Start()
    {
        musician1Controller = musician1.GetComponent<MusicianController>();
        musician2Controller = musician2.GetComponent<MusicianController>();
        musician3Controller = musician3.GetComponent<MusicianController>();
        musician4Controller = musician4.GetComponent<MusicianController>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void Init()
    {
        inputs = new List<int>();
        for (int i = 0; i < level; i++)
        {
            int input = Random.Range(0,4);
            inputs.Add(input);
        }
    }

    private IEnumerable PlayMusicSequence()
    {
        for(int i = 0; i < inputs.Count; i++)
        {
            
            yield return new WaitForSeconds(1.5f);
        }
        
    }
}
