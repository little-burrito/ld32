using UnityEngine;
using System.Collections;

public class SMS : MonoBehaviour {

	public string Sender;
	[TextArea(3,10)]
	public string Content;
	public int MinimumInvoices;
	public int MinimumDirtyCalls;
	public int MinimumSalesCalls;
	public int MinimumCash;
	public int Transaction;
	public int Priority;
	[HideInInspector]
	public bool Seen;
}
