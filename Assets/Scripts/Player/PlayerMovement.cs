using UnityEngine;

public class PlayerMovement: MonoBehaviour {

	public float speed = 6f;
	float camRayLenght = 100f;
	int floorMask;
	Vector3 movement;
	Rigidbody playerRigBody;
	Animator animator;

	private void Awake() {
		floorMask = LayerMask.GetMask( "Floor" );
		animator = GetComponent<Animator>();
		playerRigBody = GetComponent<Rigidbody>();
	}

	void FixedUpdate() {
		var h = Input.GetAxisRaw( "Horizontal" );
		var v = Input.GetAxisRaw( "Vertical" );
		animating( h, v );
		move( h, v );
		turn();
	}

	public void move(float horizontal, float vertical) {
		movement.Set( horizontal, 0f, vertical );
		movement = movement.normalized * speed * Time.deltaTime;
		playerRigBody.MovePosition( movement + transform.position );
	}
	void turn() {
		Ray cam = Camera.main.ScreenPointToRay( Input.mousePosition );
		RaycastHit hitFloor;
		if(Physics.Raycast( cam, out hitFloor, camRayLenght, floorMask )) {

			Vector3 playerToMouse = hitFloor.point - transform.position;
			playerToMouse.y = 0f;
			Quaternion newRotation = Quaternion.LookRotation( playerToMouse );
			playerRigBody.MoveRotation( newRotation );
		}
	}
	public void animating(float h, float v) {
		bool walking = h != 0f || v != 0f;
		animator.SetBool( "isWalking", walking );
	}
}
