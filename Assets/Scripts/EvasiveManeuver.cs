using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EvasiveManeuver : MonoBehaviour {
    public float dodge;
    public float maneuverSpeed;
    public float tilt;
    public Vector2 startWait;
    public Vector2 maneuverTime;
    public Vector2 maneuverWait;

    private float targetManeuver;
    private Rigidbody rb;
	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody>();
        StartCoroutine(Evade());
	}
	
	IEnumerator Evade() {
        yield return new WaitForSeconds(Random.Range(startWait.x, startWait.y));
        while(true) {
            targetManeuver = Random.Range(1, dodge) * -Mathf.Sign(transform.position.x);
            yield return new WaitForSeconds(Random.Range(maneuverTime.x, maneuverTime.y));
            targetManeuver = 0;
            yield return new WaitForSeconds(Random.Range(maneuverWait.x, maneuverWait.y));
        }
    }

    void FixedUpdate() {
        float newManeuver = Mathf.MoveTowards(rb.velocity.x, targetManeuver, Time.deltaTime * maneuverSpeed);
        rb.velocity = new Vector3(newManeuver, 0.0f, rb.velocity.z);
        rb.rotation = Quaternion.Euler(0f, 0f, rb.velocity.x * -tilt);
    }
}
