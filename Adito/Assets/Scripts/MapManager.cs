using UnityEngine;
using System.Collections.Generic;

public class MapManager : MonoBehaviour
{

    public List<GameObject> prefStaticObjects;

    public GameObject prefMapManagerEmptyObj;
    public GameObject prefFloor;
    public GameObject prefWall;

    public int mapWidth = 16;
    public int mapHeigth = 12;

    float imageSize = 50;


    // Use this for initialization
    void Start()
    {
        CreateMap();
        CreateStaticObjects();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void CreateStaticObjects()
    {
        float posY = 0f;
        float posX = 0f;
        float space = imageSize / 100f;

        for (int i = 0; i < 15; i++)
        {
            float p1 = Random.Range(0, mapHeigth);
            float p2 = Random.Range(0, mapWidth);

            GameObject g = (GameObject)Instantiate(prefStaticObjects[0], new Vector3(p2 * space, p1 * space), Quaternion.identity);
            g.transform.parent = prefMapManagerEmptyObj.transform;
        }
    }


    void CreateMap()
    {
        float posY = 0f;
        float posX = 0f;
        float space = imageSize / 100f;

        for (int y = 0; y < mapHeigth; y++)
        {
            for (int x = 0; x < mapWidth; x++)
            {
                if (y == 0)
                {
                    PlaceWalls(prefWall, posX, posY - space, 180);
                }

                if (y == mapHeigth - 1)
                {
                    PlaceWalls(prefWall, posX, posY + space, 0);
                }

                if (x == 0)
                {
                    PlaceWalls(prefWall, posX - space, posY, 90);
                }

                if (x == mapWidth - 1)
                {
                    PlaceWalls(prefWall, posX + space, posY, 270);
                }

                GameObject gFloor = (GameObject)Instantiate(prefFloor, new Vector3(posX, posY), Quaternion.identity);
                gFloor.transform.parent = prefMapManagerEmptyObj.transform;
                posX += space;
            }
            posX = 0;
            posY += space;
        }
    }

    void PlaceWalls(GameObject obj, float posX, float posY, float rotationAngle)
    {
        GameObject g = (GameObject)Instantiate(obj, new Vector3(posX, posY), Quaternion.Euler(0, 0, rotationAngle));
        g.transform.parent = prefMapManagerEmptyObj.transform;
    }
}
