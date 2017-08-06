using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FruitScript : MonoBehaviour {

    public void Update()
    {
        
    }
    // wywolanie metody ktora zaczyna process "jedzenia" przez gracz
    // potem obiekt jest niszczony
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            other.GetComponent<PlayerControler>().eatingTrigger();
            GameObject.Find("Terrain").GetComponent<MapControlerr>().SpawnFruit();
            Destroy(gameObject);
        }
    }
}
