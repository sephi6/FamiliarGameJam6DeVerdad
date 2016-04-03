using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CalculaPosicion : MonoBehaviour {

	// Use this for initialization
    public int size=0;
    public GameObject[] posiciones = new GameObject[12];
    public bool[] posicionesOcupadas= new bool[12];
    public Dictionary<Card.TIPO,List<int>> diccionarioDeCosas=new Dictionary<Card.TIPO,List<int>>();

    public Recurso ruina;
    public Recurso cultivo;
    public Recurso militar;
    public Recurso construccion;
    public Recurso cultivoMareo;
    public Recurso militarMareo;
    public Recurso construccionMareo;

    public GameManager gameManager;

    
	void Start () {

        
        diccionarioDeCosas.Add(Card.TIPO.PIEDRA,new List<int>());
        diccionarioDeCosas.Add(Card.TIPO.PAPEL, new List<int>());
        diccionarioDeCosas.Add(Card.TIPO.TIJERA, new List<int>());
        diccionarioDeCosas.Add(Card.TIPO.NULL, new List<int>());

        List<Recurso> prueba = new List<Recurso>();
        prueba.Add(cultivo);
        prueba.Add(militar);
        prueba.Add(construccion);
       	// prueba.Add(ruina);
		/*
       for (int i = 0; i < posiciones.Length;i++ )
       {
            int random=Random.Range(0, 2);
            if (random == 0)
            {
                posicionesOcupadas[i] = true;
                construye(i, prueba[Random.Range(0,3)]);
            }
            else
            {
               posicionesOcupadas[i] = false;
            }
        }
        */
	
	}

	public void log () {
		Debug.Log ("OK");
	}
	
	// Update is called once per frame
	void Update () {

		/*
        if (Input.GetKeyDown(KeyCode.W))
        {
           int random= Random.Range(0, 12);

           if (!posicionLibre(random))
          {
               construye(random, ruina);
           }
           else
           {
               Debug.Log("Posición ocupada");
           }
        }
        */
	
	}

    public bool posicionLibre(int pos)
    {
         
        return posicionesOcupadas[pos];;
    }

    public void construye(int pos, Recurso recurso)
    {
		posicionesOcupadas[pos] = (recurso.tipo == Card.TIPO.NULL) ? false : true;
		Debug.Log ("posicion: " + pos + " recurso: " + recurso.tipo + " ocupado: " + posicionesOcupadas[pos]);
        Instantiate(recurso, posiciones[pos].transform.position,Quaternion.identity);
        diccionarioDeCosas[recurso.tipo].Add(pos);
    }

    public int consiguePosicionLibreOrdenado()
    {
        int res=0;
        for (int i=0; i < posicionesOcupadas.Length; i++)
        {
            if (posicionesOcupadas[i] == false)
            {
                return i;
            }
            
        }
        return res;
    }

    public int consiguePosicionLibreRandom()
    {
        int res = 0;
        int random; 
        bool bucle=true;
        while (bucle)
        {
            random = Random.Range(0, posicionesOcupadas.Length);
            if (!posicionesOcupadas[random])
            {
                res=random;
				bucle = false;
            }
        }
        return res;
    }

    
}
