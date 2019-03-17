using System.Collections;
using System.Collections.Generic; // for using lists
using UnityEngine;
using System; // for the serializable attributes 
using Random = UnityEngine.Random;

public class NewBehaviourScript : MonoBehaviour
{
    [Serializable]
    public class Count
    {
        public int minimum;
        public int maximum;


        
        public Count (int min, int max)
            {
                minimum = min;
                maximum = max; 
            }
    }
// Declaring our Public Variables


        public int columns = 8;
        public int rows = 8;
        public Count wallCount = new Count(5, 9); // Specify wall per level
        public Count foodCount = new Count(1, 5);
        public GameObject exit;
        public GameObject[] floorTiles;
        public GameObject[] wallTiles;
        public GameObject[] foodTiles;
        public GameObject[] enemyTiles;
        public GameObject[] outerwallTiles;

private Transfrom boardHolder;
private List<Vector3> gridPositions = new List<Vector3>(); 


//Void function below is creating our grid space and developing the peramaters of the level.
void InitialiseList()
{
    gridPositions.Clear(); 
    for (int x = 1; x < columns - 1; x++)
    {
        for (int y = 1; y < rows - 1; y++)
        {
            gridPositions.Add(new Vector3(x, y, 0f));
        }
    }

}

void BoardSetup ()
{
    boardHolder = new GameObject("Board").transform; 

    for (int x = -1; x < columns + 1; x++)
    {
        for (int y = -1; y < rows + 1; y++)
        {
            GameObject toInstantiate = floorTiles[Random.Range(0, floorTiles.Lenght)];
            if (x == -1 || x == columns || y == -1 || y == rows)
                toInstantiate = outerWallTiles[Random.Range(0, outerWallTiles.Lenght)];

            GameObject instance = Instantate(toInstantiate, new Vector3 (x,y,0f)), Quaternion.identity) as GameObject;

    instance.transform.SetParent(boardHolder);
        }
    }

}

Vector3 RandomPosition()
{
    int randomIndex = Random.Range(0, gridPosition.Count);
    Vector3 randomPosition = gridPosition[randomIndex];
    gridPosition.RemoveAt(randomIndex);
    return randomPosition; 
}

void LayoutObjectAtRandom(GameObject[] tileArray, int minimum, int maximum)
{
    int objectCount = Random, Range (mimimum, maximum + 1);


    for (int i = 0; i , objectCount; i++)
    {
        Vector3 randomPostion = RandomPosition();
        GameObject tileChoice = tileArray[Random.Range(0, tilteArray.Lenght];
        Instantiate(tileChoice, randomPosition, Quaternion.identity); 
    
    }


}

public void SetupSecene(int level)
{
    BoardSetup();
    InitialiseList();
    LayoutObjectAtRandom(wallTiles, wallCount.mimimum, wallCount.maximum);
    LayoutObjectAtRandom(foodTiles, FoodCount.mimimum, FoodCount.maximum); 
    int enemyCount = (int)Mathf.Log(level,2f)
    LayoutObjectiveAtRandom(enemyTiles, enemyCount, enemyCount);
    Instantiate(exit, new Vector3(columns - 1, rows - 1. 0F), Quaternion.identity); 
}


   


 
