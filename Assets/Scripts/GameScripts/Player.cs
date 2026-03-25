using UnityEngine;

public class Player : MonoBehaviour
{

    // Update is called once per frame
    public float moveDelay = 0.1f; // tiempo mínimo entre movimientos
    private bool canMove = true;
    private Vector3 spawnPoint = new Vector3(-0.5f, 0.5f, 0f);
    private Vector3 defaultCameraPoint = new Vector3(0, 4, -10);
    private bool onAMovingPlatform = false;
    private float max_y;
    private float backBorder = 0.5f;
    private float leftBorder = -6.5f;
    private float rightBorder = 6.5f;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Respawn();
    }


    void Update()
    {
        if (!canMove) return;

        Vector3 move = Vector3.zero;

        if (Input.GetKeyDown(KeyCode.UpArrow)) move = Vector3.up;
        if (Input.GetKeyDown(KeyCode.DownArrow) && transform.position.y > backBorder) move = Vector3.down;
        if (Input.GetKeyDown(KeyCode.LeftArrow) && transform.position.x > leftBorder) move = Vector3.left;
        if (Input.GetKeyDown(KeyCode.RightArrow) && transform.position.x < rightBorder) move = Vector3.right;

        if (move != Vector3.zero)
        {
            StartCoroutine(MoveStep(move));
        }

        if (transform.position.y > max_y)
        {
            max_y = transform.position.y;
            AdvanceScore(); 
        }

    }

    private System.Collections.IEnumerator MoveStep(Vector3 direction)
    {
        canMove = false;
        transform.position += direction; // mou una casella sencera
        yield return new WaitForSeconds(moveDelay);
        canMove = true;
        SoundManager.PlaySound(SoundType.Jump);    

    }

    public void Respawn()
    {
        transform.position = spawnPoint;
        max_y = 1;
        CameraController cam = FindFirstObjectByType<CameraController>();
        cam.MoveTo(defaultCameraPoint);
    
    }

    public void toggleMovingPlatform(bool state)
    {
        onAMovingPlatform = state;
    }

    public bool IsOnMovingPlatform()
    {
        return onAMovingPlatform;
    }

    public void Win()
    {
        Debug.Log("You win!");
        Respawn();

    }

    void AdvanceScore()
    {
        Score score = FindFirstObjectByType<Score>();
        score.UpdateScore(score.GetBaseScore());
    }

}
