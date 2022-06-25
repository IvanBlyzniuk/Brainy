using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PictureController : MonoBehaviour
{
    [SerializeField]
    private SpriteRenderer sky;
    [SerializeField]
    private SpriteRenderer ground;
    [SerializeField]
    private SpriteRenderer building;
    [SerializeField]
    private SpriteRenderer theObject;
    [SerializeField]
    private SpriteRenderer border;

    private WindowGameLevelManager levelManager;
    private Sprite borderSprite;
    private Sprite borderSelectedSprite;
    // Start is called before the first frame update
    void Start()
    {
        levelManager = FindObjectOfType<WindowGameLevelManager>();
        borderSprite = Resources.Load<Sprite>($"Sprites/Window Game/Frame regular");
        borderSelectedSprite = Resources.Load<Sprite>($"Sprites/Window Game/Frame selected");
        border.sprite = borderSprite;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Configure(int skyIndex, int groundIndex, int buildingIndex, int objectIndex)
    {
        sky.sprite = Resources.Load<Sprite>($"Sprites/Window Game/Image Parts/Sky_{skyIndex}");
        ground.sprite = Resources.Load<Sprite>($"Sprites/Window Game/Image Parts/Ground_{groundIndex}");
        building.sprite = Resources.Load<Sprite>($"Sprites/Window Game/Image Parts/Building_{buildingIndex}");
        theObject.sprite = Resources.Load<Sprite>($"Sprites/Window Game/Image Parts/Object_{objectIndex}");
    }

    private void OnMouseDown()
    {
        if(Time.deltaTime > 0)
            StartCoroutine(levelManager.checkPicture(this));
    }

    private void OnMouseEnter()
    {
        if (Time.deltaTime > 0)
            border.sprite = borderSelectedSprite;
    }

    private void OnMouseExit()
    {
        border.sprite = borderSprite;
    }
}
