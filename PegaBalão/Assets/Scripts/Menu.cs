using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Menu : MonoBehaviour {
	public Texture2D btnMenuPlay;
	
	private Gerenciador gerenciador;

	string prefabName;
	
	// Use this for initialization
	void Start () {
		gerenciador = FindObjectOfType (typeof(Gerenciador)) as Gerenciador;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnGUI(){
		bool play = GUI.Button(new Rect(Screen.width-160, Screen.height-100,64,64), btnMenuPlay);
		if (play) {
//			gerenciador.Calibracao();
			gerenciador.Jogo();
		}
	}


}
