using UnityEngine;
using System.Collections;
//using System.IO.Ports;
using System.Text.RegularExpressions;
using System.Threading;
using System;
using System.IO;

public class PlayerControl : MonoBehaviour {
//	SerialPort portaSerial;
	Thread read;
	private int andar = 0;

	public GameObject player;

	public float maxHeight;
	public float minHeight;
	private float posAnterior = 0;

	public float speed;

	private Gerenciador gerenciador;

	private int pontos, bateu;

	private int vidas = 10;

	public TextMesh mascaraPontos;

	public TextMesh mascaraTempo;

	public TextMesh mascaraVidas;

	private int direita, esquerda, sumEsquerda, sumDireita;

	float minutes = 5;
	float seconds = 0;
	float miliseconds = 0;

	int paciente = 0;

	void Awake(){
		gerenciador = FindObjectOfType (typeof(Gerenciador)) as Gerenciador;
	}

	void Start () {
		paciente = PlayerPrefs.GetInt ("id");
		Debug.Log (paciente);
		bateu = 0;

		mascaraVidas.text = "Vidas: " + vidas.ToString();

		direita = PlayerPrefs.GetInt ("direita");
		esquerda = PlayerPrefs.GetInt ("esquerda");

		sumDireita = 0;
		sumEsquerda = 0;

//		StartConnection ("/dev/tty.SLAB_USBtoUART", 115200);
//		StartConnection ("COM4", 115200);
//		StartConnection ("/dev/tty.linvor-DevB", 9600);

//		read = new Thread(Ler);
//		read.Start();
	}
	
	// Update is called once per frame
	void Update () {
		Movimentar ();
		mascaraPontos.text = pontos.ToString();
		tempo ();
	}

	void Movimentar(){
		float translation = Input.GetAxis ("Vertical") * speed;
		player.transform.Translate (0, translation, 0);
		
		//Debug.Log (translation);
		//Debug.Log (Input.GetAxis ("Vertical"));
		
//		player.transform.Translate (0, translation, 0);
//		
		if (player.transform.position.y > maxHeight) {
			player.transform.position = new Vector2(transform.position.x, maxHeight);
		}
		
		if (player.transform.position.y < minHeight) {
			player.transform.position = new Vector2(transform.position.x, minHeight);
		}

//		float translation = Input.GetAxis ("Vertical") * speed;
		
//		Debug.Log (translation);
//		Debug.Log (Input.GetAxis ("Vertical"));
		
//		if (andar <= direita+10 && andar != 0) {
//			player.transform.position = new Vector2(transform.position.x, maxHeight);
//		}
//		
//		if (andar >= esquerda-10 && andar != 0) {
//			player.transform.position = new Vector2(transform.position.x, minHeight);
//
//		}
	}

	void OnTriggerEnter2D (Collider2D collider){
		//portaSerial.Close ();
//		finalizarSecao();

//		float translation = Input.GetAxis ("Vertical") * speed;
//
//		player.transform.Translate (0, translation, 0);
//		Debug.Log (player.transform.position.y);
//		if(player.transform.position.y == 0.3046415){
//			player.transform.position = new Vector2(transform.position.x, minHeight);
//		}

//		player.transform.position = new Vector2(transform.position.x, minHeight);

//		float translation = Input.GetAxis ("Vertical") * speed;
//		player.transform.Translate (0, translation, 0);
//
//		if (andar <= direita+10 && andar != 0) {
//			player.transform.position = new Vector2(transform.position.x, maxHeight);
//		}
//		
//		if (andar >= esquerda-10 && andar != 0) {
//			player.transform.position = new Vector2(transform.position.x, minHeight);
//		}

		if (vidas <= 1){
			gerenciador.GameOver();	
			finalizarSecao ();
		}else{
			vidas--;
			mascaraVidas.text = "Vidas: " + vidas.ToString();
		}
			
		
		
	}

	public void addPontos(){
		pontos++;
	}

//	public void Ler(){
//		while (true) {
//			
//			try {
//				if (portaSerial.IsOpen) {
//
//					int aux = andar;
//
//					string dados = portaSerial.ReadLine ();
//					string[] dado = dados.Split (';');
//					
//					andar = (int.Parse (dado [4])*5) / 5;
//
//					if(andar < aux-10 && andar < esquerda-10){
//						sumEsquerda++;
//					}
//
//					if(andar > aux+10 && andar > direita-10){
//						sumDireita++;
//					}
//
////					if(aux != andar){
////						if(andar > aux){
////							sumDireita++;
////						}
////
////						if(andar < aux){
////							sumEsquerda++;
////						}
////					}
//
//				} else
//					Debug.Log ("fechada");
//			} catch (TimeoutException e) {
//				Debug.LogError (e.Message.ToString ());
//			}
//		}
//	}
//
//	public void StartConnection(string portName, int bauds){
//		portaSerial = new SerialPort();
//		portaSerial.PortName = portName;
//		portaSerial.BaudRate=bauds;
//		portaSerial.Parity=Parity.None;
//		portaSerial.DataBits=8;
//		portaSerial.StopBits=StopBits.One;
//		portaSerial.DtrEnable = true;
//		portaSerial.ReadTimeout=-1;
//		portaSerial.WriteTimeout=-1;
//		portaSerial.Open();
//	}

	void tempo(){
		if(miliseconds <= 0){
			if(seconds <= 0){
				//minutes--;
				seconds = 1;
			}
			else if(seconds >= 0){
				seconds++;

				if(seconds > 295){
					finalizarSecao();
				}
			}
			
			miliseconds = 100;
		}
		
		miliseconds -= Time.deltaTime * 100;

		mascaraTempo.text = string.Format("{1}:{2}", minutes, seconds, (int)miliseconds);
		
		//Debug.Log(string.Format("{0}:{1}:{2}", minutes, seconds, (int)miliseconds));
	}

	void escreveArquivo(){
		string data = System.DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
//		StreamWriter writer = new StreamWriter(@"/Users/victoroliveira/Desktop/"+paciente+"_"+data+".txt");
//		StreamWriter writer = new StreamWriter(@"C:/Users/PRODIAVC/Desktop/Dados_SmartGlove/"+paciente+"_"+data+".txt");
		StreamWriter writer = new StreamWriter(@"C:/"+paciente+"_"+data+".txt");

//		writer.WriteLine("Paciente: " + paciente.ToString);
		writer.WriteLine("Duração Trial: 00:" + seconds.ToString());
		writer.WriteLine("Pontos: " + pontos.ToString());
		writer.WriteLine("Numero de Flexões: " + sumEsquerda.ToString());
		writer.WriteLine("Número de Extensões: " + sumDireita.ToString());	
		writer.WriteLine("Flexão: " + esquerda.ToString());
		writer.WriteLine("Extensão: " + direita.ToString());

		//Fechando o arquivo
		writer.Close();
		//Limpando a referencia dele da memória
		writer.Dispose();
	}

	void finalizarSecao(){
		PlayerPrefs.GetInt ("sumDireita", sumDireita);
		PlayerPrefs.GetInt ("sumEsquerda", sumEsquerda);
		PlayerPrefs.GetFloat ("tempo", seconds);
		PlayerPrefs.GetInt ("pontos", pontos);
//		escreveArquivo ();
		enviarDados ();
//		gerenciador.GameOver();
	}

	void enviarDados(){
//		string url = "http://localhost:8888/smartglove/sistema/includes/postdados.php";
		string url = "http://smartglove.hol.es/sistema/includes/postdados.php";
		try{
			WWWForm form = new WWWForm();
			form.AddField("id_paciente", paciente);
			form.AddField("duracao_trial", string.Format("{1}:{2}", minutes, seconds, (int)miliseconds));
			form.AddField("pontos", pontos);
			form.AddField("num_flexoes", sumEsquerda);
			form.AddField("num_extensoes", sumDireita);
			form.AddField("valor_flexao", esquerda);
			form.AddField("valor_extensao", direita);


			WWW www = new WWW(url, form);
			StartCoroutine(WaitForRequest(www));
		}catch(Exception e){
			e.Message.ToString();
		}


	}

	IEnumerator WaitForRequest(WWW www)
	{
		yield return www;
			
		if (www.error == null){
			Debug.Log("WWW Ok!: " + www.data);
		} else {
			Debug.Log("WWW Error: "+ www.error);
		}    
	}    

}
