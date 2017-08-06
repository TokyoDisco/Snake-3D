using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TailContant : MonoBehaviour {
    //sprawdzenie kolizji z ogonem
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            GameObject.Find("Terrain").GetComponent<MapControlerr>().GameOver();
        }
    }
}
