using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindowGameLevelManager : MonoBehaviour
{
    public PictureController picture1;
    public PictureController picture2;
    public PictureController picture3;
    public PictureController picture4;
    public Transform cameraPos1;
    public Transform cameraPos2;
    public Transform mainCameraTransform;
    private PictureController[] pictures;
    private int[] correctPictureParts;
    // Start is called before the first frame update
    void Start()
    {
        StartSequence();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void StartSequence()
    {
        correctPictureParts = new int[4];
        for (int i = 0; i < correctPictureParts.Length; i++)
            correctPictureParts[i] = Random.Range(1, 4);
        mainCameraTransform.position = new Vector3(cameraPos1.position.x, mainCameraTransform.position.y, mainCameraTransform.position.z);
        //TODO: show text
        mainCameraTransform.position = new Vector3(cameraPos2.position.x, mainCameraTransform.position.y, mainCameraTransform.position.z);
    }
}
