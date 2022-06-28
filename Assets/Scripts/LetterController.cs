using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// class which controls the letter button in a bridge game
/// </summary>
public class LetterController : MonoBehaviour
{
    private BridgeLevelManagerController bridgeLevelManagerController ;
    private char letter;
    private int id;

    public int Id { get => id; set => id = value; }
    public char Letter { get => letter; set => letter = value; }
    /// <summary>
    /// Start is called before the first frame update
    /// finds the BridgeLevelManagerController
    /// </summary>
    void Start()
    {
        bridgeLevelManagerController = FindObjectOfType<BridgeLevelManagerController>();
    }
    /// <summary>
    /// on mouse click checks the chosen letter and destroys it if it was correct 
    /// </summary>
    private void OnMouseDown()
    {
        if (bridgeLevelManagerController.CheckLetter(Letter) && Time.deltaTime > 0)
        {
            GameObject.Destroy(gameObject);
        }
    }
}
