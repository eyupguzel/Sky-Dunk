using Unity.VisualScripting;
using UnityEngine;

public class BoundaryForce : MonoBehaviour
{
    private Vector3 startPosition;
    [SerializeField] float speed;
    [SerializeField] float distance;

    private void Start()
    {
        startPosition = transform.position;

    }

    private void Update()
    {
         float offset = Mathf.PingPong(Time.time * speed, distance);
         transform.position = startPosition + new Vector3(offset, 0, 0);
    }
}
