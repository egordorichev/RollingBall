using UnityEngine;

public class CameraController : MonoBehaviour {
	public GameObject Target;
	public float LerpSpeed = 6f;
	public float VelocityFactor = 0.6f;
	public float VelocityAngleFactor = -1f;
	public float AngleLerpSpeed = 2f;
	
	private Vector3 offset;
	
	public void Start() {
		offset = transform.position - Target.transform.position;
	}

	public void LateUpdate() {
		var velocity = Target.GetComponent<Rigidbody>().velocity;
		var target = Target.transform.position + velocity * VelocityFactor;

		transform.position = Vector3.Lerp(transform.position, new Vector3(target.x + offset.x, offset.y + target.y, target.z + offset.z), Time.deltaTime * LerpSpeed);
		transform.eulerAngles = Vector3.Lerp(transform.eulerAngles, new Vector3(45f + velocity.z * VelocityAngleFactor, 0, 0), Time.deltaTime * AngleLerpSpeed);
	}
}