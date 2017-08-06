using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapControlerr : MonoBehaviour {
    
    public GameObject[] innerTerrainBoxesArray;
    public GameObject[] wallTerrainBoxesArray;
    public GameObject fruitBlock; // ktory blok ma owoc


	// Use this for initialization
	void Start () {
        //wypelnienie dwoch tablic z blokami wewnatrz planszy i scian
        innerTerrainBoxesArray = GameObject.FindGameObjectsWithTag("terrainBlock");
        wallTerrainBoxesArray = GameObject.FindGameObjectsWithTag("WallBlocks");

        

        for(int i = 0; i < innerTerrainBoxesArray.Length;i++)
        {
            innerTerrainBoxesArray[i].GetComponent<terrainBlockControler>().terrainbox.id = i;
        }

        for(int i = 0; i < wallTerrainBoxesArray.Length;i++)
        {
            wallTerrainBoxesArray[i].GetComponent<terrainBlockControler>().terrainbox.id = innerTerrainBoxesArray.Length + i;
        }

        SpawnFruit();   

    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void SpawnFruit()
    {
        //wylosowanie miejsca dla pojawienia sie owocu

        fruitBlock = innerTerrainBoxesArray[Random.Range(0, innerTerrainBoxesArray.Length - 1)];
        //nawet sprawdzenie czy owoc juz byl w danym miejscu
        if (fruitBlock.GetComponent<terrainBlockControler>().terrainbox.fruit == true)
        {
            fruitBlock.GetComponent<terrainBlockControler>().fruitSpawned = false;

        }
        else
        {
            fruitBlock.GetComponent<terrainBlockControler>().terrainbox.fruit = true;
        }

    }

    //metoda wywolujaca przegrana
    public void GameOver()
    {
        GameObject.Find("SnakeHead").GetComponent<PlayerControler>().lost = true;
    }
}
