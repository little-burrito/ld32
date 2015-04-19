using UnityEngine;
using System.Collections;

public class Gem : MonoBehaviour {

	[TextArea(3,10)]
	public string Content;
	public int MinimumInvoices;
	public int MinimumKills;
	public int MinimumDirtyCalls;
	public int MinimumSalesCalls;
	public int MinimumCash;
	public float Transaction;
	[HideInInspector]
	public bool Seen = false;
}
