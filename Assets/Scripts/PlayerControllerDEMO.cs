using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerDEMO : MonoBehaviour
{
    public static PlayerControllerDEMO player;

    [SerializeField] private float playerSpeed;
    private Rigidbody2D rb;
    private Vector2 playerMovement;

    public int cowCount = 0;
    public int happiness = 5;
    public int conspiracy = 0;

    private void Awake()
    {
        player = this;
        DontDestroyOnLoad(transform.root);
    }

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        float directionX = Input.GetAxisRaw("Horizontal");
        float directionY = Input.GetAxisRaw("Vertical");
        
        playerMovement = new Vector2(directionX, directionY);
    }

    private void FixedUpdate()
    {
        rb.velocity = new Vector2(playerMovement.x * playerSpeed, playerMovement.y * playerSpeed);
    }
}
