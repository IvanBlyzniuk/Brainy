using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
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
    public TextMeshPro promptText;
    public TimerController timerController;
    public int timeToRemember;

    private AudioSource audioSource;
    private LevelUIController levelUIController;
    private PictureController[] pictures;
    private int[] correctPictureParts;
    private int correctPictureIndex;
    private int score;
    
    //String array for corresponding messages
    private string[] skyMsg = new string[]{"sky1", "sky2", "sky3", "sky4" };
    private string[] buildingMsg = new string[] { "building1", "building2", "building3", "building4" };
    private string[] groundMsg = new string[] { "ground1", "ground2", "ground3", "ground4" };
    private string[] objectMsg = new string[] { "object1", "object2", "object3", "object4" };

    // Start is called before the first frame update
    void Start()
    {
        levelUIController = FindObjectOfType<LevelUIController>();
        audioSource = GetComponent<AudioSource>();
        audioSource.volume = PlayerPrefs.GetFloat("Volume");
        pictures = new PictureController[4];
        pictures[0] = picture1;
        pictures[1] = picture2;
        pictures[2] = picture3;
        pictures[3] = picture4;
        StartSequence();
    }

    // Update is called once per frame
    void Update()
    {
        if(timerController.isActive && timerController.GetCurrentTime() <= 0)
        {
            timerController.isActive = false;
            goToImages();
        }
    }

    private void StartSequence()
    {
        timerController.timeStart = timeToRemember;
        timerController.isActive = true;
        correctPictureParts = new int[4];
        for (int i = 0; i < correctPictureParts.Length; i++)
            correctPictureParts[i] = UnityEngine.Random.Range(1, 5);

        Debug.Log($"Correct: Sky = {correctPictureParts[0]} Ground = {correctPictureParts[1]} Building = {correctPictureParts[2]} Object = {correctPictureParts[3]}");

        mainCameraTransform.position = new Vector3(cameraPos1.position.x, mainCameraTransform.position.y, mainCameraTransform.position.z);
        promptText.text = $"Correct: Sky = {skyMsg[correctPictureParts[0] - 1]} Ground = {groundMsg[correctPictureParts[1] - 1]} Building = {buildingMsg[correctPictureParts[2] - 1]} Object = {objectMsg[correctPictureParts[3] - 1]}";      
    }

    private void goToImages()
    {
        shufflePictures();
        pictures[0].Configure(correctPictureParts[0], correctPictureParts[1], correctPictureParts[2], correctPictureParts[3]);
        generateIncorret(pictures[1], correctPictureParts);
        generateIncorret(pictures[2], correctPictureParts);
        generateVeryIncorrect(pictures[3], correctPictureParts);

        mainCameraTransform.position = new Vector3(cameraPos2.position.x, mainCameraTransform.position.y, mainCameraTransform.position.z);
    }

    private void generateIncorret(PictureController pictureController, int[] correctPictureParts)
    {
        int partToChange = UnityEngine.Random.Range(0,4);
        int[] changedPictureParts = new int[4];
        Array.Copy(correctPictureParts, changedPictureParts,4);
        //Debug.Log($"Before: {changedPictureParts[partToChange]}");
        changedPictureParts[partToChange] = GenerateUnequal(changedPictureParts[partToChange], 1);
        //Debug.Log($"After: {changedPictureParts[partToChange]}");
        pictureController.Configure(changedPictureParts[0], changedPictureParts[1], changedPictureParts[2], changedPictureParts[3]);
    }

    private void generateVeryIncorrect(PictureController pictureController, int[] correctPictureParts)
    {
        int[] changedPictureParts = new int[4];
        int partToChange = UnityEngine.Random.Range(0, 4);
        Array.Copy(correctPictureParts, changedPictureParts, 4);
        changedPictureParts[partToChange] = GenerateUnequal(changedPictureParts[partToChange], 1);
        partToChange = GenerateUnequal(partToChange, 0);
        changedPictureParts[partToChange] = GenerateUnequal(changedPictureParts[partToChange], 1);
        pictureController.Configure(changedPictureParts[0], changedPictureParts[1], changedPictureParts[2], changedPictureParts[3]);
    }

    private int GenerateUnequal(int oldval, int lb)
    {
        int res = oldval;
        int valueincrement = UnityEngine.Random.Range(1, 4);
        res += valueincrement - lb;
        res %= 4;
        res += lb;
        return res;
    }

    private void shufflePictures()
    {
        for(int i=0;i<pictures.Length;i++)
        {
            int i1 = UnityEngine.Random.Range(0, 4);
            int i2 = UnityEngine.Random.Range(0, 4);
            swap(pictures, i1, i2);
        }
    }

    private void swap(PictureController[] list, int pos1, int pos2)
    {
        PictureController tmp;
        tmp = list[pos1];
        list[pos1] = list[pos2];
        list[pos2] = tmp;
    }

    public IEnumerator checkPicture(PictureController pictureToCheck)
    {
        if (pictureToCheck == pictures[0])
        {
            Debug.Log("correct");
            audioSource.Play();
            yield return new WaitForSeconds(1);
            StartSequence();
        }
        else
        {
            Debug.Log("incorrect");
            levelUIController.MakeMistake();
            if(levelUIController.GetLifesCount() == 0)
            {
                Time.timeScale = 0;//TODO: Go to end screen
            }
        }
    }

}
