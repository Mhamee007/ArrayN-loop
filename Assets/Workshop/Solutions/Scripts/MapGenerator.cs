using System;
using UnityEngine;

namespace Workshop.Solution
{
    public class MapGenerator : MonoBehaviour
    {
        public int columns = 10;
        public int rows = 10;

        public GameObject[] floorTiles;
        public GameObject[] wallTiles;
        public GameObject[] foodTiles;
        public GameObject[] Players;
        public GameObject Exit;
        int r;

        public string[,] saveItemMap = new string[3, 3] {
            { " ", "Soda", " "},
            { " ", " ", " "},
            { " ", " ", "Food"},
        };

        public GameObject[] playerPrefab = new GameObject[2];

        public void Start()
        {
            // 1. random player at the position <0, 0> map
            {
                r = UnityEngine.Random.Range(0, Players.Length); //make ramdom by first obj in lenght of arrey 
                Instantiate(Players[r], new Vector2(0, 0), Quaternion.identity);
            }

            // 2. create obstacles

            for (int i = 0; i < 5; i++)
            {
                r = UnityEngine.Random.Range(0, wallTiles.Length);
                Instantiate(wallTiles[r], new Vector2(i, 1), Quaternion.identity);
            }

   
            // 3. create floor
            for (int x = 0; x <rows; x++)
            {
                for (int y = 0; y < columns; y++)
                {
                    r = UnityEngine.Random.Range(0, wallTiles.Length);
                    Instantiate(floorTiles[r], new Vector2(x,y),Quaternion.identity);
                }
            }



            // 4. create walls
            for (int x = -1; x < rows+1; x++)
            {
                for (int y = -1; y < columns+1; y++)
                {
                    if (x == -1 || y == -1 || x==rows || y == columns)
                    {
                        r = UnityEngine.Random.Range(0, wallTiles.Length);
                        Instantiate(wallTiles[r], new Vector2(x, y), Quaternion.identity);
                    }
                    
                }
            }


            // 5. random foods

            int posX = UnityEngine.Random.Range(0,rows);
            int posY = UnityEngine.Random.Range(0, columns);
            r = UnityEngine.Random.Range(0, foodTiles.Length);
            Instantiate(foodTiles[r], new Vector2(posX, posY), Quaternion.identity);

          

            // 6. generate item along with the saveItemMap

            for (int x = 0; x < saveItemMap.GetLength(0); x++)
            {
                for (int y = 0; y < saveItemMap.GetLength(1); y++)
                {
                    if (saveItemMap[x, y] !=" ")
                    {
                        foreach (GameObject g in foodTiles)
                        {
                            if (g.name == saveItemMap[x, y])
                            {
                                Instantiate(g, new Vector2(y, x), Quaternion.identity);
                            }

                        }      
                            
                    }
                }
            }

            // 7. place exit
            Instantiate(Exit, new Vector2(rows - 1, columns -1), Quaternion.identity);
        }
    }
}