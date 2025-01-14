using UnityEngine;

public class PlatformController : MonoBehaviour
{
    [SerializeField] private float angle;
    [SerializeField] private float forcePower;

    private void OnCollisionEnter(Collision collision)
    {
        collision.gameObject.GetComponent<Rigidbody>().AddForce(new Vector3(angle, 90, 0) * forcePower, ForceMode.Force);
        VibrationManager.Vibrate(20);
    }
}
