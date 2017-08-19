using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerControler : MonoBehaviour {
    public int score;
    public string playerName;
    public GameObject activeBlock;
    public GameObject TailtoCopy;
    public List<GameObject> tailobjectList = new List<GameObject>();
    public bool lost;
    public bool pauseActive;
    public int prePauseSpeed;
    public int speed;
    public AudioSource startMelody;
   
	// Use this for initialization
	void Start () {
        //ustawienie podstawowy zmiennych
        score = 0;
        
        speed = 20;
        prePauseSpeed = speed; //uzywane przy wznowieniu z pauzy
        playerName = "JZ";
        pauseActive = false;
        lost = false; 
        
    }
	
	// Update is called once per frame
	void Update () {
        //ruch waz zawsze brnie do przodu
        transform.position += GetComponent<Camera>().transform.forward * (Time.deltaTime * speed);
        //pobranie input od gracz 
        transform.Rotate(new Vector3(0, Input.GetAxis("Horizontal") * (speed/5), 0));
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            PauseBtn();
        }

       
        //sprawdzenie przegranej
        if(lost)
        {
            PauseBtn();
        }
       
    }

    
    

    //funckja zjadania
    public void FruitEat()
    {
        //dzwiek zjadania owocu
        GetComponent<AudioSource>().Play();
        Vector3 TailSpawnPosition; // zmienna do ustalenie gdzie ma sie pojawic nowy fragment
        score += 10;//dodawanie punktow
        //sprawdzenie czy to pierwszy fragment
        if (tailobjectList.Count == 0)
        {
            TailSpawnPosition = gameObject.transform.position + gameObject.transform.forward * (-5);
        }
        else
        {
            //jezeli nie to wtedy pozycja jest brana z ostatniego fragmentu na liscie
            TailSpawnPosition = tailobjectList[tailobjectList.Count - 1].transform.position + tailobjectList[tailobjectList.Count - 1].transform.forward * (-5);
        }
        //instancjonwanie z kopii bedacej poza zasiegiem wzroku gracz
            tailobjectList.Add(new GameObject("tailfragment" + tailobjectList.Count));
            tailobjectList[tailobjectList.Count - 1] = Instantiate(TailtoCopy, tailobjectList[tailobjectList.Count - 1].transform.position = TailSpawnPosition,transform.rotation);
            tailobjectList[tailobjectList.Count - 1].transform.localScale = new Vector3(2, 2, 2);
            tailobjectList[tailobjectList.Count - 1].name = "Tail Section" + tailobjectList.Count;
        //nawigacja dla fragmentow uzywajac NavMesh 
        if (tailobjectList.Count == 1)
        {
          
            tailobjectList[tailobjectList.Count - 1].GetComponent<tailNavigationScript>().Target = gameObject;
            tailobjectList[tailobjectList.Count - 1].GetComponent<NavMeshAgent>().Warp(gameObject.transform.position + gameObject.transform.forward * (-5));
        }
        else
        {
            tailobjectList[tailobjectList.Count - 1].GetComponent<tailNavigationScript>().Target = tailobjectList[tailobjectList.Count - 2];
            tailobjectList[tailobjectList.Count - 1].GetComponent<NavMeshAgent>().Warp(tailobjectList[tailobjectList.Count - 1].transform.position + tailobjectList[tailobjectList.Count - 1].transform.forward * (-5));
        }

        //po kazdym zjedzeniu szybkosc wzrasta
        speed += 1;
        prePauseSpeed = speed;
        for (int y = 0; y<tailobjectList.Count;y++)
        {
            tailobjectList[y].GetComponent<NavMeshAgent>().speed += 1;
        }



    }

    //trigger ktory rozpoczyna opoznione pojawienie sie fragmentu ogona
    public void eatingTrigger()
    {
        StartCoroutine(tailadddelay());
    }

    // opoznienie pojawienia sie fragmentu ogona aby uniknac kolizji
    IEnumerator tailadddelay()
    {
        
        yield return new WaitForSeconds(0.2f);
        FruitEat();
        StopAllCoroutines();
    }

    //pauza i przegrana ktora jest pauza bez mozliwosci powrotu do gry
    public void PauseBtn()
    {
        
        if(!pauseActive)
        {
            // zatrzymanie nawigacji i kolizji w czasie pauzy
            for(int i = 0; i <tailobjectList.Count;i++)
            {
                tailobjectList[i].GetComponent<BoxCollider>().enabled = false;
                tailobjectList[i].GetComponent<NavMeshAgent>().isStopped = true;

            }
            pauseActive = true;
            speed = 0;
            GetComponent<Camera>().enabled = false;
        }
        else
        {
            if(pauseActive && !lost)
            {
                for (int i = 0; i < tailobjectList.Count; i++)
                {
                    tailobjectList[i].GetComponent<BoxCollider>().enabled = true;
                    tailobjectList[i].GetComponent<NavMeshAgent>().isStopped = false;
                }
                pauseActive = false;
                speed = prePauseSpeed;
                GetComponent<Camera>().enabled = true;
            }
        }
    }
}
