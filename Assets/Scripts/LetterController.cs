using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LetterController : MonoBehaviour
{
    private BridgeLevelManagerController bridgeLevelManagerController ;
    public char letter;
    public int id;
    // Start is called before the first frame update
    void Start()
    {
        bridgeLevelManagerController = FindObjectOfType<BridgeLevelManagerController>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnMouseDown()
    {
        if (bridgeLevelManagerController.CheckLetter(letter))
        {
            GameObject.Destroy(gameObject);
        }
    }
}
