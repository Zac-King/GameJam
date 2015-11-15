using UnityEngine;
using System.Collections;

public class CameraOffset : MonoBehaviour
{
    public GameObject player;
    private Vector3 offset;

    void Start()
    {
        offset = transform.position - player.transform.position;
    }

    void LateUpdate()
    {
        transform.position = (player.transform.position + offset) * player.transform.localScale.x;
    }
}
