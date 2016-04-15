using UnityEngine;
using System.Collections;
//using System.IO.Ports;
using System.Text.RegularExpressions;
using System.Threading;
using System;
#if UNITY_EDITOR
using UnityEditor;
#endif

public class Luva : MonoBehaviour {
//	public SerialPort portaSerial;
	Thread read;

	private int testeCalibracao = 0;
	private int valorCalibrado = 0;

	private bool v = true;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {

	}

//	public void StartConnection(string portName, int bauds){
//		try{
//			portaSerial = new SerialPort();
//			portaSerial.PortName = portName;
//			portaSerial.BaudRate=bauds;
//			portaSerial.Parity=Parity.None;
//			portaSerial.DataBits=8;
//			portaSerial.StopBits=StopBits.One;
//			portaSerial.DtrEnable = true;
//			portaSerial.ReadTimeout=-1;
//			portaSerial.WriteTimeout=-1;
//			portaSerial.Open();
//		}catch(Exception ){
//			if(!portaSerial.IsOpen){
//				#if UNITY_EDITOR
//				v = EditorUtility.DisplayDialog ("Conecte a luva", "Erro ao tentar abrir conexão. " +
//				                                      "Por favor verifique se a luva está conectada corretamente, " +
//				                                      "e tente novamente", 
//				                                      "Tentar Novamente", 
//				                                      "Cancelar");
//				#endif
//				if(v){
//					StartConnection (portName, bauds);
//				}else{
//					Application.LoadLevel (0); 
//				}
//
//			}
//		}
//	}
//
//	public void Calibrar(bool esquerda){
//		testeCalibracao = 0;
//		valorCalibrado = 0;
//		while(testeCalibracao < 15){
//			string dados1 = portaSerial.ReadLine ();
////			Debug.Log (dados1);
//			string[] dado1 = dados1.Split (';');
//			
//			valorCalibrado = (int.Parse (dado1 [4])*5) / 5;
//
//			testeCalibracao++;
//		}
//
//		if(esquerda){
//			PlayerPrefs.SetInt("esquerda", valorCalibrado);
//			Debug.Log("esquerda " + valorCalibrado);
//		}else{
//			PlayerPrefs.SetInt("direita", valorCalibrado);
//			Debug.Log("direita " + valorCalibrado);
//		}
//
//		vibrar ();
//	}
//
//	public void close(){
//		portaSerial.Close ();
//	}
//	
//	public void vibrar(){
//		if (portaSerial.IsOpen) {
//			portaSerial.Write ("1");
//		}
//	}
//	
//	public void porta(){
//		string [] portas = SerialPort.GetPortNames();
//		for (int i=0; i<portas.Length; i++) {
//			try{
//				StartConnection(portas[i], 115200);
//				portaSerial.Write ("9");
//
//				string valor = portaSerial.ReadLine ();
//				if(valor == "9"){
//					PlayerPrefs.SetString("porta", portas[i]);
//					break;
//				}
//			}catch (Exception e) {
//				print("error");
//			} 
//		}
//	}
	
}
