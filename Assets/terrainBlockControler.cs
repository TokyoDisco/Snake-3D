using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class terrainBlockControler : MonoBehaviour {
   
    public GameObject fruit;
    
    public GameObject spawning;
    public BaseTerrainBox terrainbox;
    public bool fruitSpawned;


	// Use this for initialization
	void Start () {
        terrainbox.fruit = false;
        fruitSpawned = false; //zmiena sprawdzajaca czy owoc zostaw utworzony w danym bloku aby unikanac masowego tworzenia
       
		
	}
	
	// Update is called once per frame
	void Update () {

        // tworzenie owocu jezeli ten blok zostal wylosowany
        if(terrainbox.fruit && !fruitSpawned)
        {
            spawning = Instantiate(fruit, GameObject.Find("Terrain").GetComponent<Transform>().transform, true);
            spawning.GetComponent<Transform>().position = gameObject.transform.position;
            spawning.transform.localScale = new Vector3(0.03f, 0.03f, 0.03f);
            
            spawning.name = "newFruit";
            fruitSpawned = true;
        }

        
		
	}




}
