using System;
using UnityEngine;

public class BallController : MonoBehaviour
{
    public static BallController instance;
    public static BallController Instance
    {
        get
        {
            if (instance == null)
                instance = FindFirstObjectByType<BallController>();
            return instance;
        }
    }

    public Action<object> onBoundary;
    public Action onFinish;
    public Action<object> onScore;
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Boundary")
        {
            VibrationManager.Vibrate(10);
            ContactPoint contact = collision.contacts[0];
            onBoundary?.Invoke(contact.point);
        }
        if (collision.gameObject.tag == "BottomBoundary")
        {
            VibrationManager.Vibrate(30);
            onFinish?.Invoke();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Net")
        {
            VibrationManager.Vibrate(50);
            onScore?.Invoke(gameObject.transform.position);
        }
    }
}
