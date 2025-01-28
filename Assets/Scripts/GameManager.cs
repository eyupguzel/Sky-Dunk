using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static int score;
    [SerializeField] private Sprite[] backgrounds;
    [SerializeField] private Material[] materials;
    [SerializeField] private SpriteRenderer renderer;
    [SerializeField] private GameObject ball;

    [HideInInspector] public int highScore;

    [Header("HoopSettings")]
    [SerializeField] GameObject hoop;
    [SerializeField] float minX,maxX,minY,maxY;
    Vector3 newPos;
    private float timer;
    private int duration;
    private void Start()
    {
        Application.targetFrameRate = 60;
        score = 0;
        highScore = PlayerPrefs.GetInt("HighScore");
        ChangeSpriteAndMaterial();
    }
    private void Update()
    {
        timer += Time.deltaTime;
        if(timer >= duration)
        {
            RandomHoopPosition();
            timer = 0;
        }
    }

    private void RandomHoopPosition()
    {
        newPos = new Vector3(Random.Range(minX,maxX), Random.Range(minY,maxY),0);
        hoop.gameObject.SetActive(false);
        hoop.transform.position = newPos;
        hoop.gameObject.SetActive(true);
        duration = Random.Range(10, 40);
    }
    private void ChangeSpriteAndMaterial()
    {
        renderer.sprite = backgrounds[Random.Range(0, backgrounds.Length)];
        ball.gameObject.GetComponent<Renderer>().material = materials[Random.Range(0, materials.Length)];
    }
    public void UpdateHighScore()
    {
        if (score >= highScore)
        {
            PlayerPrefs.SetInt("HighScore", score);
            highScore = score;
        }
    }

}
