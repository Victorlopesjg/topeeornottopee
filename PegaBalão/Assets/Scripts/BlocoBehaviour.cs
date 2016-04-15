using UnityEngine;
using System.Collections;

public class BlocoBehaviour : MonoBehaviour {

	public float speed;
	public GameObject bloco;

	private PlayerControl player;

	private bool passou;

	void Start () {
		player = FindObjectOfType (typeof(PlayerControl)) as PlayerControl;
	}
	
	// Update is called once per frame
	void Update () {

		transform.position += new Vector3 (speed, 0, 0) * Time.deltaTime;

		if (transform.position.x < player.transform.position.x && !passou) {
			player.addPontos();
			passou = true;
			GetComponent<AudioSource>().Play();
		}

		if (transform.position.x < -10) {
			Destroy(bloco);
		}
	}

	void OnEnable(){
		passou = false;
	}


}
