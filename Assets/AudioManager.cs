using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [SerializeField] AudioSource source;
    [SerializeField] AudioClip boundarySoundEffect;
    [SerializeField] AudioClip scoreSoundEffect;

    public static AudioManager instance;
    public static AudioManager Instance
    {
        get
        {
            if (instance == null)
                instance = GameObject.FindFirstObjectByType<AudioManager>();
            return instance;
        }
    }
    private void Start()
    {
        BallController.Instance.onBoundary += BoundarySoundEffect;
        BallController.Instance.onScore += ScoreSoundEffect;

    }

    private void BoundarySoundEffect(object a)
    {
        source.PlayOneShot(boundarySoundEffect);
    }
    private void ScoreSoundEffect(object p)
    {
        source.PlayOneShot(scoreSoundEffect);
    }
}
