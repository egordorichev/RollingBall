using TMPro;
using UnityEngine;

public class PlayerController : MonoBehaviour {
	private Rigidbody body;
	private int score;
	private float distanceToGround;
	private float letalY;
	
	public float Speed = 10f;
	public float JumpSpeed = 2000f;
	public GameObject ScoreLabel;

	public void Start() {
		body = GetComponent<Rigidbody>();
		distanceToGround = GetComponent<SphereCollider>().bounds.extents.y + 0.1f;
		letalY = transform.position.y - 2f;
	}

	public bool IsOnGround() {
		return Physics.Raycast(transform.position, Vector3.down, distanceToGround);
	}
	
	public void FixedUpdate() {
		if (IsOnGround()) {
			body.AddForce(Input.GetAxis("Horizontal") * Speed, 0, Input.GetAxis("Vertical") * Speed);
			
			if (Input.GetKeyDown(KeyCode.LeftShift)) {
				body.AddForce(0, JumpSpeed, 0);
			}
		} else if (transform.position.y < letalY) {
			Application.LoadLevel(Application.loadedLevel);
		}
	}

	public void OnTriggerEnter(Collider collider) {
		if (collider.gameObject.CompareTag("Pickup") && !collider.gameObject.GetComponent<PickupController>().Done) {
			collider.gameObject.GetComponent<PickupController>().AnimateDeath();

			score++;
			ScoreLabel.GetComponent<TextMeshProUGUI>().SetText($"{score}");
		}
	}
}