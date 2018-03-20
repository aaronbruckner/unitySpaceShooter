using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Boundry {
    public float xMin, xMax, zMin, zMax;
}

public class PlayerController : MonoBehaviour {
    
    public float speed;
    public float tilt;
    public Boundry boundry;
    public GameObject shot;
    public Transform shotSpwan;
    public float fireRate;

    private Rigidbody rigidBody;
    private AudioSource audioSource;
    private float nextFire = 0f;

    void Start() {
        rigidBody = GetComponent<Rigidbody>();
        audioSource = GetComponent<AudioSource>();
    }

    void Update() {
        if (Input.GetButton("Fire1") && Time.time > nextFire) {
            nextFire = Time.time + fireRate;
            Instantiate(shot, shotSpwan.position, Quaternion.Euler(0f, 0f, 0f));
            audioSource.Play();
        }
    }

    void FixedUpdate() {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");
        rigidBody.velocity = new Vector3(moveHorizontal, 0, moveVertical) * speed;
        rigidBody.position = new Vector3(
            Mathf.Clamp(rigidBody.position.x, boundry.xMin, boundry.xMax),
            0f,
            Mathf.Clamp(rigidBody.position.z, boundry.zMin, boundry.zMax)
        );
        rigidBody.rotation = Quaternion.Euler(rigidBody.velocity.z * 0.5f * tilt, 0f, rigidBody.velocity.x * -tilt); 
    }
}
