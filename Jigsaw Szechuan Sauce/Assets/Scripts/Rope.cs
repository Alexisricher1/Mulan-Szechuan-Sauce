using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rope : MonoBehaviour {

    public bool isRightRope;
    public float currentMaxDist = 10;

    private BoxCollider boxCollider;
    // Use this for initialization
    void Start ()
    {
        boxCollider = GetComponent<BoxCollider>();
    }
	
	// Update is called once per frame
	void Update ()
    {
		
	}
}
