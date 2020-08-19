using UnityEngine;

public class PickupController : MonoBehaviour {
	private float movementOffset;
	public bool Done;
	public GameObject ParticleSystem;

	private float doneTimer = 3f;
	
	public void Start() {
		movementOffset = Random.Range(0, 1f);
		transform.Rotate(new Vector3(Random.Range(-5f, 5f), Random.Range(-5f, 5f), Random.Range(-5f, 5f)));
	}

	public void Update() {
		transform.Rotate(new Vector3(15f, 30f, 45f) * Time.deltaTime);
		transform.position += new Vector3(0f, Mathf.Sin(Time.time * 2f + movementOffset), 0f) * Time.deltaTime;

		if (Done) {
			doneTimer -= Time.deltaTime;
			transform.localScale = Vector3.Lerp(transform.localScale, Vector3.zero, Time.deltaTime);

			if (doneTimer <= 0) {
				gameObject.SetActive(false);
			}
		}
	}

	public void AnimateDeath() {
		Done = true;
		
		var particles = Instantiate(ParticleSystem, transform.position, Quaternion.identity);
		particles.GetComponent<ParticleSystem>().Play();
		
		Destroy(this, 3);
		Destroy(particles, 3);
	}
}