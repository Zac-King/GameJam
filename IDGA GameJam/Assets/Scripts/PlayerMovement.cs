using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    private float speed = 1;

    Vector3 inputVelocity = Vector3.zero;

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Input.GetKeyDown(KeyCode.W)) // UP
        {
            inputVelocity.z += (speed * Time.deltaTime);
        }
        if (Input.GetKeyDown(KeyCode.S)) // Down
        {
            inputVelocity.z -= (speed * Time.deltaTime);
        }
        if (Input.GetKeyDown(KeyCode.D)) // Right
        {
            inputVelocity.x += (speed * Time.deltaTime);
        }
        if (Input.GetKeyDown(KeyCode.A)) // Left
        {
            inputVelocity.x -= (speed * Time.deltaTime);
        }

        gameObject.GetComponent<GalacticOrbit>().velocity += inputVelocity;
	}
}
