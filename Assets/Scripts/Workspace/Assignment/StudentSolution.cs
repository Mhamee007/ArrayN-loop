using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using AssignmentSystem.Services;
using UnityEngine;
using UnityEngine.UIElements;
using static UnityEngine.GraphicsBuffer;
using Debug = AssignmentSystem.Services.AssignmentDebugConsole;

namespace Assignment
{
    public class StudentSolution : MonoBehaviour, IAssignment
    {

        #region Lecture

        public void LCT01_SyntaxArray()
        {
            string[] ironManSuit = new string[2];
            ironManSuit[0] = "Mark I";
            ironManSuit[1] = "Mark II";
            string TonyStarkWear = ironManSuit[0];
            Debug.Log($"TonyStark Wear: {TonyStarkWear}");
            Debug.Log($"Room size: {ironManSuit.Length}");
            Debug.Log(ironManSuit[0]);
            Debug.Log(ironManSuit[1]);
        }

        public void LCT02_ArrayInitialize()
        {
            string[] spiderMan = {
                "Classic SpiderMan", 
                "Black Suit", 
                "Iron Spider Suit"
            };
            int roomSizeOfspiderMan = spiderMan.Length;
            Debug.Log($"Room size: {roomSizeOfspiderMan}");
            Debug.Log(spiderMan[0]);
            Debug.Log(spiderMan[1]);
            Debug.Log(spiderMan[2]);
         

            string[] batMan = new string[2] {
                "Classic BatMan", 
                "White bat"
            };
            int roomsizeOfBatMan = batMan.Length;
            Debug.Log($"Room size: {roomsizeOfBatMan}");
            Debug.Log(batMan[0]);
            Debug.Log(batMan[1]);

        }

        public void LCT03_SyntaxLoop()
        {
            for (int i = 0; i < 10; i++) //0-9
            {
                Debug.Log("<10 : " +i);
            }
            Debug.Log("===");
            for (int i = 1; i <= 10; i++) //1-10
            {
                Debug.Log("<=10 : " + i);
            }
        }

        public void LCT04_LoopAndArray(string[] ironManSuitNames)
        {
            for (int i = 0; i < ironManSuitNames.Length; i++)
            {
                Debug.Log(ironManSuitNames[i]);
            }
            Debug.Log("===");
            for (int i = 0; i < ironManSuitNames.Length; i+=2)
            {
                Debug.Log(ironManSuitNames[i]);
            }
        }
         
        public void LCT05_Syntax2DArray()
        {
            //row,column
            int[,] my2DArray = new int[2, 2] {
                {1,2},//row [0,0],[0,1]
                {3,4}//column [1,0], [1,1]
            };
            Debug.Log($"my2DArray[0, 0] = {my2DArray[0,0]}");
            Debug.Log($"my2DArray[0, 1] = {my2DArray[0,1]}");
            Debug.Log($"my2DArray[1, 0] = {my2DArray[1,0]}");
            Debug.Log($"my2DArray[1, 1] = {my2DArray[1,1]}");
            my2DArray[0,1] = 6;
            my2DArray[1,1] = 8;
            Debug.Log("After change value");
            Debug.Log($"my2DArray[0, 1] = {my2DArray[0,1]}");
            Debug.Log($"my2DArray[1, 1] = {my2DArray[1,1]}");
        }

        public void LCT06_SizeOf2DArray(int[,] my2DArray)
        {
            int row = my2DArray.GetLength(0); //X
            int col = my2DArray.GetLength(1); //y
            Debug.Log("rows = " + row);
            Debug.Log("cols = " + col);
        }

        public void LCT07_SyntaxNestedLoop(int columns, int rows)
        {
            for (int i = 0; i < rows; i++)
            {
                string text = "";

                for (int j = 0; j < columns; j++)
                {
                    text += "*";
                }
                Debug.Log(text);
            }
        }

        #endregion

        #region Assignment

        public void AS01_RandomItemDrop(GameObject[] items)
        {
           int randomIndex = UnityEngine.Random.Range(0, items.Length);
           GameObject gameObject = items[randomIndex];

           Instantiate(gameObject);
           Debug.Log($"Got item: {gameObject.name}");
        }

        public void AS02_NestedLoopForCreate2DMap(GameObject[] floorTiles, int columns, int rows)
        {
            for (int x = 0; x < columns; x++)
            {
                for (int y = 0; y < rows; y++)
                {    
                    int r = UnityEngine.Random.Range(0, floorTiles.Length);
                    GameObject floor = floorTiles[r];
                  
                    GameObject tile = Instantiate(floor, new Vector2(x, y), Quaternion.identity);
                    tile.name = $"[{x}:{y}]";

                    Debug.Log($"Created tile: {tile.name}");
                    
                }

            }   
        }

        public void AS03_NestedLoopForMakingWallAround(GameObject wall, int columns, int rows)
        {
            
            for (int x = 0; x < columns; x++)
            {
                for (int y = 0; y < rows; y++)
                {
                    if (x == 0 || x == columns - 1 || y == 0 || y == rows - 1)
                    {
                        wall.name = $"[{x}:{y}]";
                        Instantiate(wall, new Vector2(x, y), transform.rotation);
                    }
                }
            }
            
            
        }

        public void AS04_AttackEnemy(int[] enemyHP, int damage, int target)
        {
            enemyHP[0] -= damage;
            if (enemyHP[0] < 0) enemyHP[0] = 0;
            int first = enemyHP[0];

            enemyHP[enemyHP.Length - 1] -= damage;
            if (enemyHP[enemyHP.Length - 1] < 0) enemyHP[enemyHP.Length - 1] = 0;
            int last = enemyHP[enemyHP.Length - 1];

            enemyHP[target] -= damage;
            if (enemyHP[target] < 0) enemyHP[target] = 0;
            int secTarget = enemyHP[target];
           
            Debug.Log("FirstEnemy hp :" +first);
            Debug.Log("LastEnemy hp :" +last);
            Debug.Log($"TargetEnemy {target} hp :{secTarget}");
        }

        public void AS05_DynamicIterationLoop(int n)
        {
            for (int i = 0; i < n; i++)
            {
                Debug.Log(i);
            }
        }

        public void AS06_WhileLoopAndArray(string[] ironManSuitNames)
        {
            int i = 0;
            while (i < ironManSuitNames.Length)
            {
                Debug.Log(ironManSuitNames[i]);
                i++;
            }

            Debug.Log("===");

            i = 0;
            while (i < ironManSuitNames.Length)
            {
                Debug.Log(ironManSuitNames[i]);
                i+= 2;
            }
        }

        public void AS07_HealTargetAtIndex(int[] heroHPs, int heal, int targetIndex)
        {
            int first = heroHPs[0] += heal;
            int last = heroHPs[heroHPs.Length - 1] += heal;
            int secTarget = heroHPs[targetIndex] += heal;

            Debug.Log("FirstHero hp :" + first);
            Debug.Log("LastHero hp :" + last);
            Debug.Log($"TargetHero {targetIndex} hp :{secTarget}");
        
        }

        public void AS08_RandomPickingDialogue(string[] dialogues)
        {
           
            int randomDialogues = UnityEngine.Random.Range(0, dialogues.Length);
            string d = dialogues[randomDialogues];
            Debug.Log(d);
            
        }

        public void AS09_MultiplicationTable(int n)
        {
            for (int i = 1; i <= 12; i++)
            {
                Debug.Log($"{n}x{i}={n * i}");      
            }
        }

        public void AS10_FindSummationFromZeroToNUsingWhileLoop(int n)
        {
            int sum = 0;
            int i = 0;

            while (i <= n)
            {
                sum += i;
                i++;
            }

            Debug.Log($"ผลรวมของ n จาก 0 ถึง {n} คือ {sum}");
        }

        public void AS11_SpawnEnemies(int[] enemyHPs, GameObject enemyPrefab)
        {
            for (int i = 0; i < enemyHPs.Length; i++)
            {
                Vector2 Position = new Vector2(i + 1, 0);
                Debug.Log($"new enemy at position x = {Position.x}");
            }
        }

        public IEnumerator AS12_CountTime(float CountTime)
        {
            float time = 0f;
            
            while (time <= CountTime)
            {
                time += Time.deltaTime;
                Debug.Log($"timer : {time.ToString("F2")}");
                yield return null;
            }
            Debug.Log($"End timer : {CountTime}");
        }

        public void AS13_SumOfNumbersInRow(int[,] matrix, int row)
        {
            matrix = new int[3, 3]
            {
                {1,2,3},
                {4,5,6}, 
                {7,8,9}
            };
          
            int sum = 0;
            
            for (int j = 0; j < matrix.GetLength(1); j++)  
            {
                    sum += matrix[row, j];
            }
            
            Debug.Log(sum);
        }

        public void AS14_SumOfNumbersInColumn(int[,] matrix, int column)
        {
            matrix = new int[3, 3]
             {
                {1,2,3},
                {4,5,6},
                {7,8,9}
             };

            int sum = 0;

            for (int j = 0; j < matrix.GetLength(1); j++)
            {
                sum += matrix[j, column];
            }

            Debug.Log(sum);
        }

        public void AS15_MakeTheTriangle(int size)
        {
            string text = "";
            for (int i = 0; i < size; i++)
            {
        
                text += "*";
                for (int j = 1; j < size; j++)
                {
                    text += "";
                }
                Debug.Log(text);
            }
        }

        public void AS16_MultiplicationTableOf_2_3_and_4()
        {
            for (int i = 1; i <= 12; i++) 
            {
                string number = "";
                for (int j = 2; j <= 4; j++) 
                {
                    number += $"{j} x {i} = {j * i}" + "\t";
                }
                Debug.Log(number);
            }
        }

        #endregion

        #region Extra assignment

        public void EX_01_TicTacToeGame_TurnPlay(string[,] board, string playerTurn, int row, int column)
        {
            
        }

        private void PrintBoard(string[,] board)
        {
            StringBuilder sb = new();
            for (int i = 0; i < 3; i++)
            {
                sb.AppendLine("-------------");
                sb.AppendLine(
                    "| " + board[i, 0] + " | " 
                         + board[i, 1] + " | " 
                         + board[i, 2] + " |");
            }
            sb.AppendLine("-------------");
            Debug.Log(sb.ToString());
        }
        #endregion
    }
}
