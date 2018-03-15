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

    private Rigidbody rigidbody;

    void Start() {
        rigidbody = GetComponent<Rigidbody>();
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
