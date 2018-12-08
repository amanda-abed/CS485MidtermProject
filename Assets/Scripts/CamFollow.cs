using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamFollow : MonoBehaviour {

	[SerializeField]
	private float distanceAway;
	[SerializeField]
	private float distanceUp;
	[SerializeField]
	private float smooth;
	[SerializeField]
	private Transform follow;
	private Vector3 targetPosition;


	// Use this for initialization
	void Start () {
		follow = GameObject.FindWithTag("fish").transform;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void LateUpdate(){
		targetPosition = follow.position + follow.up * distanceUp - follow.forward * distanceAway;
		transform.position = Vector3.Lerp(transform.position, targetPosition, Time.deltaTime * smooth);
		transform.LookAt(follow);
	}
}
