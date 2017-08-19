using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
// funkcje nawigacyjne dla ogona
public class tailNavigationScript : MonoBehaviour {
    public GameObject Target;
    public NavMeshAgent agent;
    public int speed;

	// Use this for initialization
	void Start () {

        agent = GetComponent<NavMeshAgent>();
        speed = GameObject.Find("SnakeHead").GetComponent<PlayerControler>().speed + 5;
	}
	
	// Update is called once per frame
	void Update () {
       
        if (name != "tailToCopy")
        {
            agent.speed = speed;
            agent.destination = Target.transform.position;
        }
        else
        {
            agent = null;
        }

	}

    public void stopChase()
    {
      
    }
}
