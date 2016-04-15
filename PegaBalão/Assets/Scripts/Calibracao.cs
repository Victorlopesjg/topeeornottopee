using UnityEngine;
using System.Collections;
//using System.IO.Ports;
using System.Text.RegularExpressions;
using System.Threading;
using System;

public class Calibracao : MonoBehaviour {

	public GUISkin skinMenu;
	public Texture2D btnMenuCalibrar;
	public Texture2D btnPlay;

	public TextMesh Texto;

	string t = "";
	
	private Gerenciador gerenciador;

	private Luva luva;

	private int tempo = 0;

	private bool esquerda = true;

	private bool esquerdaCalibrada = false;
	private bool direitaCalibrada = false;

	public GameObject[] objetos;

	private GameObject temp;

	// Use this for initialization
	void Start () {
		gerenciador = FindObjectOfType (typeof(Gerenciador)) as Gerenciador;
		luva = FindObjectOfType (typeof(Luva)) as Luva;
//		luva.StartConnection ("/dev/tty.SLAB_USBtoUART", 115200);
//		luva.StartConnection ("COM4", 115200);
		Instantiate (objetos [0], new Vector2(0, -0.3644072f), objetos [0].transform.rotation);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
//	void OnGUI(){
//		GUI.skin = skinMenu;
//
//		bool calibrar = GUI.Button(new Rect (Screen.width-670, Screen.height-100,64,64), btnMenuCalibrar);
//		
//		bool play = GUI.Button(new Rect (Screen.width-100, Screen.height-100,64,64), btnPlay);
//
//		t = GUI.TextField (new Rect (Screen.width-300, Screen.height-200,200,30), t);
//
//		
//		if (calibrar) {
//			Debug.Log ("Entrou no if de calibrar");
//			if(esquerda)
//				esquerdaCalibrada = true;
//			else
//				direitaCalibrada = true;
//
////			Debug.Log ("Calibrando...");
//			Texto.text = "Calibrando...";
//			if(luva.portaSerial.IsOpen){
////				Debug.Log ("Abriu no IF");
//				luva.Calibrar(esquerda);
//				esquerda = false;
//				Texto.text = "Calibrado!";
//				luva.vibrar();
//
//				while(tempo < 0){
//					tempo ++;
//				}
//
//				Instantiate (objetos [1], new Vector2(0, -0.3644072f), objetos [1].transform.rotation);
//			}else{
//				Texto.text = "Conecte a luva";
//			}
//
//		}
//
//		if (esquerdaCalibrada && direitaCalibrada) {
//			Texto.text = "Começe o Jogo!";
//		}else if(!direitaCalibrada && esquerdaCalibrada){
//			Texto.text = "Feche o máximo";
//		}
//		
//		if(play){
//			if (esquerdaCalibrada && direitaCalibrada) {
//				PlayerPrefs.SetInt("id", int.Parse(t));
//				luva.close();
//				gerenciador.ProximoLevel(gerenciador.proximoLevel);
//			}
//		}
//	}
}
