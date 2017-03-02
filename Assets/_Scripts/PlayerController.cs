using UnityEngine;
using System.Collections;

[System.Serializable]
public class Boundary{
	public float xMin,xMax,zMin,zMax;
}

public class PlayerController : MonoBehaviour {


	public float speed;
	public float tilt;
	public Boundary boundary;

	public GameObject shot;
	public Transform spawner;
	public float fireRate;

	private float nextFire;
	private Rigidbody rb;
	private AudioSource fireSound;


	void Start ()
	{
		rb = this.GetComponent<Rigidbody>();
		fireSound = this.GetComponent<AudioSource> ();
	}

	void Update(){
		if (Input.GetButton("Fire1") && Time.time > nextFire)
		{
			nextFire = Time.time + fireRate;
			Instantiate (shot,spawner.position,spawner.rotation);
			fireSound.Play();
		}
	}


	void FixedUpdate(){

        /*
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis ("Vertical");
        Vector3 movement = new Vector3 (moveHorizontal, 0, moveVertical);
        rb.velocity = movement*speed;

		rb.position = new Vector3
			(
				Mathf.Clamp(rb.position.x,boundary.xMin,boundary.xMax),
				0.0f,
				Mathf.Clamp(rb.position.z,boundary.zMin,boundary.zMax)
			);

        */

        Vector3 mouse = Input.mousePosition;


        rb.position = new Vector3
            (
                Mathf.Clamp( (mouse.x/600)*(Mathf.Abs(boundary.xMax)+ Mathf.Abs(boundary.xMin))-(Mathf.Abs(boundary.xMax) + Mathf.Abs(boundary.xMin))/2 , boundary.xMin, boundary.xMax),
                0.0f,
                 Mathf.Clamp((mouse.y / 900) * (Mathf.Abs(boundary.zMax) + Mathf.Abs(boundary.zMin)) - (Mathf.Abs(boundary.zMax) + Mathf.Abs(boundary.zMin)) / 2, boundary.zMin, boundary.zMax)
            );

        rb.rotation = Quaternion.Euler (0.0f, 0.0f, rb.velocity.x * -tilt);

    }
}
