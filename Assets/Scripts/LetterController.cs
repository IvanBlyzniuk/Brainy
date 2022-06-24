using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LetterController : MonoBehaviour
{
    private BridgeLevelManagerController bridgeLevelManagerController ;
    private char letter;
    private int id;

    public int Id { get => id; set => id = value; }
    public char Letter { get => letter; set => letter = value; }

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
        if (bridgeLevelManagerController.CheckLetter(Letter) && Time.deltaTime > 0)
        {
            GameObject.Destroy(gameObject);
        }
    }
}
