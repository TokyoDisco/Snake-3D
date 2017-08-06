using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoBorderMapTrigger : MonoBehaviour {
    //nie dokonczone sciany ktore zamiast blokowania by teleportowaly gracza
    private void OnTriggerEnter(Collider other)
    {
        switch(name)
        {
            case "WallHitbox1":
                Vector3 teleport = new Vector3(other.GetComponent<Transform>().transform.position.x+10, other.GetComponent<Transform>().transform.position.y, other.GetComponent<Transform>().transform.position.z);
                other.GetComponent<Transform>().transform.position = teleport;
                break;
            case "WallHitbox2":
                other.GetComponent<Transform>().transform.position = new Vector3(other.GetComponent<Transform>().transform.position.x - 1, other.GetComponent<Transform>().transform.position.y, other.GetComponent<Transform>().transform.position.z);
                break;
            case "WallHitbox3":
                other.GetComponent<Transform>().transform.position = new Vector3(other.GetComponent<Transform>().transform.position.x, other.GetComponent<Transform>().transform.position.y, other.GetComponent<Transform>().transform.position.z-1);
                break;
            case "WallHitbox4":
                other.GetComponent<Transform>().transform.position = new Vector3(other.GetComponent<Transform>().transform.position.x, other.GetComponent<Transform>().transform.position.y, other.GetComponent<Transform>().transform.position.z+1);
                break;
        }
    }
}
