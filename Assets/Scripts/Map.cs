using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Map : MonoBehaviour
{

    public GameObject BGTilePrefab;
    public GameObject FloorTilePrefab;
    public GameObject SideWallTilePrefab;
    public GameObject CharacterImagePrefab;

    public Character PlayingCharacter;

    private float BGStartingPositionZ = 10f;

    private float FloorTileWidth = 1f;

    private float BGTileHeight = 3f;
    private float BGTileWidth = 4f;

    private float BaseYPosition = 0f;
    private float BaseXStart = -8.5f;
    private float BaseXLength = 30f;

    private int BaseFloors = 1;


    private Vector3 velocity = Vector3.zero;

    void Start()
    {
        CreateBackground();
        CreateFloor();
        CreateCharacter();

        Physics2D.gravity = new Vector2(0, -9.8f);
        
        PlayingCharacter.GO.AddComponent<BoxCollider2D>();
        Rigidbody2D rigid = PlayingCharacter.GO.AddComponent<Rigidbody2D>();
        rigid.mass = 5;
    }

    void CreateCharacter()
    {
        this.PlayingCharacter = new Character(CharacterImagePrefab, new Vector2(0,5));
    }

    void CreateFloor()
    {
        GameObject CurrentTile = (GameObject)Instantiate(SideWallTilePrefab);
        CurrentTile.transform.position = new Vector2(BaseXStart,
                                                     3);
        CurrentTile.transform.SetParent(this.transform);
        CurrentTile.AddComponent<BoxCollider2D>();

        for(float i = 0; i < BaseXLength / FloorTileWidth; i += FloorTileWidth)
        {
            CurrentTile = (GameObject)Instantiate(FloorTilePrefab);
            CurrentTile.transform.position = new Vector2(BaseXStart + i,
                                                         BaseYPosition);
            CurrentTile.transform.SetParent(this.transform);
            CurrentTile.AddComponent<BoxCollider2D>();
        }
        CurrentTile = (GameObject)Instantiate(SideWallTilePrefab);
        CurrentTile.transform.position = new Vector2(BaseXStart + BaseXLength,
                                                     3);
        CurrentTile.transform.SetParent(this.transform);
        CurrentTile.AddComponent<BoxCollider2D>();
    }

    void CreateBackground()
    {
        for(float y = 0; y < BaseFloors * BGTileHeight; y++)
        {
            for(float x = 0; x < BaseXLength / BGTileWidth; x++)
            {
                GameObject CurrentTile = (GameObject)Instantiate(BGTilePrefab);
                CurrentTile.transform.position = new Vector3((int)(BaseXStart + x * BGTileWidth),
                                                             (int)(BaseYPosition + y * BGTileHeight),
                                                             BGStartingPositionZ);
                CurrentTile.transform.SetParent(this.transform);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
    }
}
