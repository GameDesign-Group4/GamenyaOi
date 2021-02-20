using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformGenerator : MonoBehaviour {

	public GameObject Platform;
	public Transform generationPoint;
	
	private float platformWidth;

	private float distanceBetween;
	public float distanceBetweenMin;
	public float distanceBetweenMax;

	public ObjectPooler theObjectPool;

	// Use this for initialization
	void Start () {
		platformWidth = Platform.GetComponent<BoxCollider2D>().size.x;
	}
	
	// Update is called once per frame
	void Update () {
		
		if(transform.position.x < generationPoint.position.x) {

			distanceBetween = Random.Range(distanceBetweenMin, distanceBetweenMax);

			transform.position = new Vector3(transform.position.x + platformWidth + distanceBetween, transform.position.y, transform.position.z);

			//Instantiate(Platform, transform.position, transform.rotation);
			GameObject newPlatform = theObjectPool.GetPooledObject();

			newPlatform.transform.position = transform.position;
			newPlatform.transform.rotation = transform.rotation;
			newPlatform.SetActive(true);

		}

	}
}
