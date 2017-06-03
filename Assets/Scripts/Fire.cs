using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fire : MonoBehaviour {
    Transform shotpoint;
    public GameObject shotEffect;
    public Transform cam, dir;
    AudioSource audio;
	// Use this for initialization
	void Start () {
        shotpoint = transform.FindChild("firepoint");
        audio = GetComponent<AudioSource>();
	}
	// Update is called once per frame
	void Update () {
        if (Input.GetMouseButtonDown(0))
        {
            audio.Play();
            Shot();
        }
	}

    void Shot()
    {
        GameObject shot = (GameObject)Instantiate(shotEffect,shotpoint.position,transform.rotation,transform);
        Ray ray = Camera.main.ScreenPointToRay(new Vector3(Screen.width / 2, Screen.height / 2, 0));
        RaycastHit hit;
        if(Physics.Raycast(ray,out hit))
        {
            print(ray.ToString() + ";" + hit.transform.position);
            GameObject shothit = (GameObject)Instantiate(shotEffect, hit.point, Quaternion.identity);
        }
    }
}
