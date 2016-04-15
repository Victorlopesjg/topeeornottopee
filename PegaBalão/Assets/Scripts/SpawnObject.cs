using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SpawnObject : MonoBehaviour {
	public GameObject[] objetos;

	public float minHeigth;
	public float maxHeigth;
	private bool isEsquerda = true;
	public float velocidade = 5f;
	public float mxDelay;
	
	public float instanciadorTempo = 5f;
	public float instanciadorDelay = 3f;
	
	private float timeMovimento = 0f;
	public int valorMinimoRandom = 0;

	private float randPosition;



	// Use this for initialization
	void Start () {
		InvokeRepeating ("Spawn", instanciadorTempo, instanciadorDelay);
	}
	
	// Update is called once per frame
	void Update () {

	}

	void Spawn(){
		float rand = Random.Range (0, 9);

		if (rand < 5){
			randPosition = minHeigth;
		} else {
			randPosition = maxHeigth;
		}

		int index = Random.Range (valorMinimoRandom, objetos.Length);
		Instantiate (objetos [index], new Vector2(transform.position.x, randPosition), objetos [index].transform.rotation);

		
	}
}
