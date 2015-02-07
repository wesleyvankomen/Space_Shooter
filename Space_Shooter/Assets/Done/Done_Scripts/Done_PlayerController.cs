using UnityEngine;
using System.Collections;

[System.Serializable]
public class Done_Boundary 
{
	public float xMin, xMax, zMin, zMax;
}

public class Done_PlayerController : MonoBehaviour
{
	public float speed;
	public float tilt;
	public Done_Boundary boundary;

	public GameObject shot;
	public Transform shotSpawn;

	//edited variables
	public GameObject shot2;
	public Transform shotSpawn2;
	//edited variables
	public GameObject shot3;
	public Transform shotSpawn3;
	public GameObject shot4;
	public Transform shotSpawn4;
	public GameObject shot5;
	public Transform shotSpawn5;
	public GameObject shot6;
	public Transform shotSpawn6;
	public GameObject shot7;
	public Transform shotSpawn7;
	//end of edits

	public float fireRate;
	 
	private float nextFire;
	
	void Update ()
	{
		if (Input.GetButton("Fire1") && Time.time > nextFire) 
		{
			nextFire = Time.time + fireRate;
			Instantiate(shot, shotSpawn.position, shotSpawn.rotation);
			//new shot student code
			Instantiate(shot2, shotSpawn2.position, shotSpawn2.rotation);
			Instantiate(shot3, shotSpawn3.position, shotSpawn3.rotation);
			Instantiate(shot4, shotSpawn4.position, shotSpawn4.rotation);
			Instantiate(shot5, shotSpawn5.position, shotSpawn5.rotation);
			Instantiate(shot6, shotSpawn6.position, shotSpawn6.rotation);
			Instantiate(shot7, shotSpawn7.position, shotSpawn7.rotation);
			audio.Play ();
		}
	}

	void FixedUpdate ()
	{
		float moveHorizontal = Input.GetAxis ("Horizontal");
		float moveVertical = Input.GetAxis ("Vertical");

		Vector3 movement = new Vector3 (moveHorizontal, 0.0f, moveVertical);
		rigidbody.velocity = movement * speed;
		
		rigidbody.position = new Vector3
		(
			Mathf.Clamp (rigidbody.position.x, boundary.xMin, boundary.xMax), 
			0.0f, 
			Mathf.Clamp (rigidbody.position.z, boundary.zMin, boundary.zMax)
		);
		
		rigidbody.rotation = Quaternion.Euler (0.0f, 0.0f, rigidbody.velocity.x * -tilt);
	}
}
