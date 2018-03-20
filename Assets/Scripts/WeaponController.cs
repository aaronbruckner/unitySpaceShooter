using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponController : MonoBehaviour {
    public GameObject shot;
    public Transform shotSpawn;
    public float fireRate;
    public float startDelay;

    private AudioSource audioSource;
	// Use this for initialization
	void Start () {
        audioSource = GetComponent<AudioSource>();
        InvokeRepeating("Fire", startDelay, fireRate);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void Fire() {
        Instantiate(shot, shotSpawn.position, shotSpawn.rotation);
        audioSource.Play();
    }
}
