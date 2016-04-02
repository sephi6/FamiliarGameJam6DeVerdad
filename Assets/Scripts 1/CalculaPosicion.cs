using UnityEngine;
using System.Collections;

public class CalculaPosicion : MonoBehaviour {

	// Use this for initialization
    public int size=0;
    public GameObject[] posiciones = new GameObject[12];
    public bool[] posicionesOcupadas= new bool[12];

    public GameObject ruina;
    public GameObject cultivo;
    public GameObject militar;
    public GameObject construccion;
    public GameObject cultivoMareo;
    public GameObject militarMareo;
    public GameObject construccionMareo;

    public GameManager gameManager;

    
	void Start () {

        for (int i = 0; i < posiciones.Length;i++ )
        {
            int random=Random.Range(0, 2);
            if (random == 0)
            {
                posicionesOcupadas[i] = false;
                construye(i, construccion);
            }
            else
            {
                posicionesOcupadas[i] = true;
            }
        }
	
	}
	
	// Update is called once per frame
	void Update () {

        if (Input.GetKeyDown(KeyCode.W))
        {
           int random= Random.Range(0, 11);

           if (posicionLibre(random))
           {
               construye(random, ruina);
           }
           else
           {
               Debug.Log("Posición ocupada");
           }
        }
	
	}

    public bool posicionLibre(int pos)
    {
         
        return posicionesOcupadas[pos];;
    }

    public void construye(int pos, GameObject recurso)
    {
            posicionesOcupadas[pos] = false;
            Instantiate(recurso, posiciones[pos].transform.position,Quaternion.identity);
        
    }

    
}
