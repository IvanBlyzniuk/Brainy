using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PictureController : MonoBehaviour
{
    public SpriteRenderer sky;
    public SpriteRenderer ground;
    public SpriteRenderer building;
    public SpriteRenderer theObject;
    public int index;
    // Start is called before the first frame update
    void Start()
    {
        Configure(2, 2, 2, 2);
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
        Debug.Log("press");
    }
}
