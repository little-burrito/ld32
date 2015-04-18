using UnityEngine;
using System.Collections;

public class Colleague : MonoBehaviour {

	private bool dead = false;
	public string name = "";
	public float cash = 0;
	public int type = 0;

	public bool Dead {
		get { return dead; }
		set { dead = value; }
	}

	void Start () {

	}
}
