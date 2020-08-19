using UnityEngine;

public class PlatformController : MonoBehaviour {
	private Vector3 startPosition;
	private bool waiting;
	private float timer;
	private float direction = -1f;

	public Vector3 Movement;
	public float MovementTimer = 3f;
	public float WaitTimer = 3f;
	public float MovementSpeed = 10f;
	
	public void Start() {
		startPosition = transform.position;
		timer = WaitTimer;
		waiting = true;
	}

	public void Update() {
		timer -= Time.deltaTime;

		if (timer <= 0) {
			waiting = !waiting;

			if (waiting) {
				timer = WaitTimer;
			} else {
				timer = MovementTimer;
				direction *= -1;
				
				if (direction > 0) {
					// Just so that it doesn't drift anywhere
					transform.position = startPosition;
				}
			}
		} else if (!waiting) {
			transform.position += Movement * (direction * Time.deltaTime * MovementSpeed);
		}
	}
}