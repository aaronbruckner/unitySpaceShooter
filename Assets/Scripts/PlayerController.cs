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

    private Rigidbody rigidbody;
    private float nextFire = 0f;

    void Start() {
        rigidbody = GetComponent<Rigidbody>();
    }

    void Update() {
        if (Input.GetButton("Fire1") && Time.time > nextFire) {
            nextFire = Time.time + fireRate;
            Instantiate(shot, shotSpwan.position, shotSpwan.rotation);
        }
    }

    void FixedUpdate() {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");
        rigidbody.velocity = new Vector3(moveHorizontal, 0, moveVertical) * speed;
        rigidbody.position = new Vector3(
            Mathf.Clamp(rigidbody.position.x, boundry.xMin, boundry.xMax),
            0f,
            Mathf.Clamp(rigidbody.position.z, boundry.zMin, boundry.zMax)
        );
        rigidbody.rotation = Quaternion.Euler(rigidbody.velocity.z * 0.5f * tilt, 0f, rigidbody.velocity.x * -tilt); 
    }
}
