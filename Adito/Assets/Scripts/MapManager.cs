using UnityEngine;
using System.Collections.Generic;

public class MapManager : MonoBehaviour
{
    private MapShape[,] mapArr;


    public List<GameObject> prefStaticObjects;

    public GameObject prefMapManagerEmptyObj;
    public GameObject prefFloor;
    public GameObject prefWall;
    public GameObject prefPlayer;


    private int mapWidth = 18;
    private int mapHeigth = 14;
    private float imageSize = 50;


    // Use this for initialization
    void Start()
    {
        mapArr = new MapShape[mapWidth, mapHeigth];

        CreateNewMap();
        AddPlayer();
    }

    // Update is called once per frame
    void Update()
    {

    }


    void placeWallsDummy()
    {
        mapArr[2, 2].Prefab = prefStaticObjects[0];
        mapArr[2, 3].Prefab = prefStaticObjects[0];
        mapArr[2, 4].Prefab = prefStaticObjects[0];
        mapArr[2, 9].Prefab = prefStaticObjects[0];
        mapArr[2, 10].Prefab = prefStaticObjects[0];
        mapArr[2, 11].Prefab = prefStaticObjects[0];

        mapArr[3, 2].Prefab = prefStaticObjects[0];
        mapArr[3, 11].Prefab = prefStaticObjects[0];
        mapArr[4, 2].Prefab = prefStaticObjects[0];
        mapArr[4, 11].Prefab = prefStaticObjects[0];

        mapArr[5, 9].Prefab = prefStaticObjects[0];
        mapArr[6, 9].Prefab = prefStaticObjects[0];
        mapArr[7, 9].Prefab = prefStaticObjects[0];
        mapArr[5, 4].Prefab = prefStaticObjects[0];
        mapArr[6, 4].Prefab = prefStaticObjects[0];
        mapArr[7, 4].Prefab = prefStaticObjects[0];
        mapArr[7, 6].Prefab = prefStaticObjects[0];
        mapArr[7, 7].Prefab = prefStaticObjects[0];
        mapArr[10, 9].Prefab = prefStaticObjects[0];
        mapArr[11, 9].Prefab = prefStaticObjects[0];
        mapArr[12, 9].Prefab = prefStaticObjects[0];
        mapArr[10, 7].Prefab = prefStaticObjects[0];
        mapArr[10, 6].Prefab = prefStaticObjects[0];
        mapArr[10, 4].Prefab = prefStaticObjects[0];
        mapArr[11, 4].Prefab = prefStaticObjects[0];
        mapArr[12, 4].Prefab = prefStaticObjects[0];
        mapArr[13, 11].Prefab = prefStaticObjects[0];
        mapArr[14, 11].Prefab = prefStaticObjects[0];
        mapArr[15, 11].Prefab = prefStaticObjects[0];
        mapArr[15, 10].Prefab = prefStaticObjects[0];
        mapArr[15, 9].Prefab = prefStaticObjects[0];
        mapArr[13, 2].Prefab = prefStaticObjects[0];
        mapArr[14, 2].Prefab = prefStaticObjects[0];
        mapArr[15, 2].Prefab = prefStaticObjects[0];
        mapArr[15, 3].Prefab = prefStaticObjects[0];
        mapArr[15, 4].Prefab = prefStaticObjects[0];


    }
    void AddPlayer()
    {
        Instantiate(prefPlayer, mapArr[1, 1].Position, Quaternion.Euler(0, 0, 0));
    }


    void CreateNewMap()
    {
        float posX = 0;
        float posY = 0;
        float imageSpace = imageSize / 100f;

        //fill Arr
        for (int y = 0; y < mapHeigth; y++)
        {
            for (int x = 0; x < mapWidth; x++)
            {
                mapArr[x, y] = new MapShape(prefFloor, new Vector2(posX, posY), imageSize);

                if (x == 0)
                {
                    mapArr[x, y] = new MapShape(prefWall, new Vector2(posX, posY), imageSize, 90);
                }
                if (y == 0)
                {
                    mapArr[x, y] = new MapShape(prefWall, new Vector2(posX, posY), imageSize, 180);
                }
                if (x == mapWidth - 1)
                {
                    mapArr[x, y] = new MapShape(prefWall, new Vector2(posX, posY), imageSize, 270);
                }
                if (y == mapHeigth - 1)
                {
                    mapArr[x, y] = new MapShape(prefWall, new Vector2(posX, posY), imageSize);
                }

                posX += imageSpace;
            }
            posX = 0;
            posY += imageSpace;
        }

        placeWallsDummy();

        for (int y = 0; y < mapHeigth; y++)
        {
            for (int x = 0; x < mapWidth; x++)
            {
                GameObject gObj = (GameObject)Instantiate(mapArr[x, y].Prefab, mapArr[x, y].Position, Quaternion.Euler(0, 0, mapArr[x, y].ImageRotation));
                gObj.transform.parent = prefMapManagerEmptyObj.transform;
            }
        }
    }
     
}


public class MapShape
{
    public Vector2 Position { get; set; }
    public GameObject Prefab { get; set; }
    public float Size { get; set; }
    public int ImageRotation { get; set; }

    public MapShape() { }
    public MapShape(GameObject pref, Vector2 pos, float size, int imgRotation = 0)
    {
        Position = pos;
        Prefab = pref;
        Size = size;
        ImageRotation = imgRotation;
    }
}