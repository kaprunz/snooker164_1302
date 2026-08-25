using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

public class Game_Manager : MonoBehaviour
{
    [SerializeField]
    private int playerScore;

    public int PlayerScore
    {
        get { return playerScore; }
        set { playerScore = value; }
    }

    [SerializeField]
    private GameObject[] ballPositions;

    [SerializeField]
    private GameObject ballPrefab;

    [SerializeField]
    private GameObject cueBall;

    [SerializeField]
    private float xInput = 0f;

    [SerializeField]
    private GameObject ballLine;

    [SerializeField]
    private GameObject cam;

    [SerializeField]
    private TMP_Text notiText;

    public static Game_Manager instance;

    private void Awake()
    {
        instance = this;
    }

    void Start()
    {
        SetBall(BallColor.Red, 1);
        SetBall(BallColor.Yellow, 2);
        SetBall(BallColor.Green, 3);
        SetBall(BallColor.Brown, 4);
        SetBall(BallColor.Blue, 5);
        SetBall(BallColor.Pink, 6);
        SetBall(BallColor.Black, 7);

        CameraBehindCueBall();
    }

    // Update is called once per frame
    void Update()
    {
        RotateBall();

        if (Keyboard.current.spaceKey.wasPressedThisFrame)
            ShootBall();
        if (Keyboard.current.backspaceKey.wasPressedThisFrame)
            StopBall();
        if (Keyboard.current.aKey.isPressed || Keyboard.current.leftArrowKey.isPressed)
            xInput = -0.5f;
        else if (Keyboard.current.dKey.isPressed || Keyboard.current.rightArrowKey.isPressed)
            xInput = +0.5f;
        else
            xInput = 0f;

    }

    private void SetBall(BallColor col, int i)
    {
        GameObject obj = Instantiate(ballPrefab,
                                    ballPositions[i].transform.position,
                                    Quaternion.identity);
        Ball b = obj.GetComponent<Ball>();
        b.SetColorAndPoint(col);
    }

    private void ShootBall()
    {
        Rigidbody rd = cueBall.GetComponent<Rigidbody>();
        rd.AddRelativeForce(Vector3.forward*50,ForceMode.Impulse);

        ballLine.SetActive(false);

        cam.transform.parent = null;
        cam.transform.position = new Vector3(0f, 30f, -45f);
        cam.transform.eulerAngles = new Vector3(45f, 0f, 0f);
    }

    private void RotateBall()
    {
        if (cueBall!=null)
            cueBall.transform.Rotate(new Vector3(0f,xInput,0f));
    }

    private void StopBall()
    {
        Rigidbody rb = cueBall.GetComponent<Rigidbody>();
        rb.linearVelocity = Vector3.zero;
        rb.angularVelocity = Vector3.zero;
        cueBall.transform.eulerAngles = new Vector3(0f,0f,0f);

        ballLine.SetActive(true);
        CameraBehindCueBall();
    }

    private void CameraBehindCueBall()
    {
        cam.transform.parent = cueBall.transform;
        cam.transform.position = cueBall.transform.position + new Vector3(0f,7f,-15f);
        cam.transform.eulerAngles = new Vector3(30f,0f,0f);
    }

    public void ShowScoreText(int n)
    {
        playerScore += n;

        if (notiText != null)
        {
            notiText.gameObject.SetActive(true); // Ensure the text object is active
            notiText.text = $"Ball Point:{n}\nTotal Score:{PlayerScore}";
        }
    }

    public void ShowString(string s)
    {
        if (notiText != null)
        {
            notiText.gameObject.SetActive(true); // Ensure the text object is active
            notiText.text = s;
        }
    }

    public void SaveGame()
    {
        StopBall();
        if (cueBall != null)
        {
            PlayerPrefs.SetFloat("cueBallPosX", cueBall.transform.position.x);
            PlayerPrefs.SetFloat("cueBallPosY", cueBall.transform.position.y);
            PlayerPrefs.SetFloat("cueBallPosZ", cueBall.transform.position.z);
            Debug.Log("SAVE");

        }
    }
        public void LoadGame()
    {
        if (cueBall != null)
        {
            PlayerPrefs.GetFloat("cueBallPosX");
            PlayerPrefs.GetFloat("cueBallPosY");
            PlayerPrefs.GetFloat("cueBallPosZ");
            Debug.Log("LOAD");

        }
    }
}
