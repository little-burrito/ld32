using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Path : MonoBehaviour {

	public enum PathMode {
		patrol,
		loop,
		single
	}

	public GameObject target;
	public bool walking = false;
	public float angle = 0f;
	public float speed = 1f;
	public PathMode mode = PathMode.single;

	private List<GameObject> waypoints;
	private int currentWaypoint = 0;
	private float waypointRadius = 1f;
	private bool returning = false;

	void startWalk() {
		walking = true;
		currentWaypoint = 0;
		target.transform.position = waypoints[currentWaypoint].transform.position;
		look();
	}

	void Start () {
		waypoints = findWaypoints();
		if (walking) {
			startWalk();
		}
	}

	int getNextWaypointNumber() {
		if (mode == PathMode.single && currentWaypoint + 1 == waypoints.Count) {
			return -1;
		}
		if (mode == PathMode.loop && currentWaypoint + 1 == waypoints.Count) {
			return 0;
		}
		if (!returning && currentWaypoint + 1 == waypoints.Count) {
			return currentWaypoint - 1;
		}
		if (returning && currentWaypoint == 0) {
			return 1;
		}
		int diff = returning ? -1 : 1;
		return (currentWaypoint + diff) % waypoints.Count;
	}

	GameObject getNextWaypoint(){
		int num = getNextWaypointNumber();
		if (num == -1) { return null; }
		return waypoints[num];
	}

	GameObject getCurrentWaypoint(){
		return waypoints[currentWaypoint];
	}

	Vector3 getDirection() {
		GameObject next = getNextWaypoint();
		if (!next) {return Vector3.zero;}
		return target.transform.position - getNextWaypoint().transform.position;
	}

	void look() {
		Vector3 diff = getDirection();
		float atan2 = Mathf.Atan2(diff.y, diff.x) *  Mathf.Rad2Deg;
		atan2 += angle;
		target.transform.rotation = Quaternion.AngleAxis(atan2, Vector3.forward);
	}

	void FixedUpdate() {
		if (!walking) { return; }
		Rigidbody2D rb = target.GetComponent<Rigidbody2D>();
		Vector3 direction = -getDirection();
		if (direction.magnitude < waypointRadius) {
			int next = getNextWaypointNumber();
			if (next == -1) {
				rb.velocity = Vector3.zero;
				walking = false;
				return;
			} else {
				int prev = currentWaypoint;
				currentWaypoint = next;
				if (mode == PathMode.patrol && getNextWaypointNumber() == prev) {
					returning = !returning;
				}
			}
		}
		look();
		rb.velocity = direction.normalized * speed;
	}

	List<GameObject> findWaypoints() {
		List<GameObject> waypoints = new List<GameObject>();
		foreach(Transform child in transform) {
			if (child.tag == "Waypoint") {
				waypoints.Add(child.gameObject);
			}
		}
		return waypoints;
	}

	// Update is called once per frame
	void OnDrawGizmos () {
		List<GameObject> waypoints = findWaypoints();
		if (waypoints.Count < 2) { return; }
		for (int i = 1; i < waypoints.Count; i++) {
			Debug.DrawLine(
				waypoints[i-1].transform.position,
				waypoints[i].transform.position,
				i == 1 ? Color.red : Color.magenta
			);
		}
	}
}
