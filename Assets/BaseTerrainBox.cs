using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public class BaseTerrainBox  {
    // generycja klasa dla skladowych blokow terenowych
    public int id;
    public bool fruit;
    public bool wall;
    public bool snakehead;
    public int turn;
   
    public BaseTerrainBox(int newId, bool hasFruit, bool hasWall, bool isPlayerIn, int whichTurn)
    {
        id = newId;
        fruit = hasFruit;
        wall = hasWall;
        snakehead = isPlayerIn;
        turn = whichTurn;
    }



}
