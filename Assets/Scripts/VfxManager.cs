using UnityEngine;
public class VfxManager : MonoBehaviour
{
    [SerializeField] private GameObject boundaryEffect;
    [SerializeField] private GameObject[] scoreEffects;

    private int randomEffect;
    private void Start()
    {
        BallController.Instance.onBoundary += GetBoundaryEffect;
        BallController.Instance.onScore += GetScoreEffect;
    }
    public void GetBoundaryEffect(object position)
    {
        boundaryEffect.transform.position = (Vector3)position;
        boundaryEffect.gameObject.SetActive(true);
    }

    public void GetScoreEffect(object position)
    {
        randomEffect = Random.Range(0, scoreEffects.Length);
        scoreEffects[randomEffect].gameObject.transform.position = (Vector3)position;
        scoreEffects[randomEffect].gameObject.SetActive(true);
    }
}
