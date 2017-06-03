using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shot : MonoBehaviour {

	// Use this for initialization
	void Start () {
        Invoke("Des", .1f);
        print("Start");
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    private void Des()
    {
        Destroy(this.gameObject);
        print("Destroy");
    }
}
