using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerDEMO : MonoBehaviour
{
    public static PlayerControllerDEMO playerInfo; // ref this script in other scripts

    [SerializeField] public PlayerSpriteRenderers playerSpriteRenderers; // ref children
    private Sprite alienSprite;

    // movement var
    [SerializeField] private float playerSpeed = 3f;
    private Rigidbody2D rb;
    private Vector2 playerMovement;

    // background bounds
    private float minX= -2.85f;
    private float maxX = 2.85f;
    private float minY = -5f;
    private float maxY = 5f;

    // player stats
    public int cowCount = 0;
    public int happiness = 5;
    public int conspiracy = 0;

    private void Awake()
    {
        playerInfo = this;
        DontDestroyOnLoad(transform.root);
    }

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        alienSprite = playerSpriteRenderers.Alien.sprite;
        var playerSizeX = playerInfo.alienSprite.bounds.size.x / 2; // get alien sprite, get size for object boundaries

        // new bounds
        minX += playerSizeX;
        maxX -= playerSizeX;
        minY += playerSizeX;
        maxY -= playerSizeX;
    }

    private void FixedUpdate()
    {
        // inputs
        float directionX = Input.GetAxisRaw("Horizontal");
        float directionY = Input.GetAxisRaw("Vertical");

        // movement
        playerMovement = new Vector3(directionX, directionY); // direction
        rb.velocity = new Vector3(playerMovement.x * playerSpeed, playerMovement.y * playerSpeed); // speed, physics for collision

        // get rb position
        float posX = rb.position.x + rb.velocity.x * Time.fixedDeltaTime;
        float posY = rb.position.y + rb.velocity.y * Time.fixedDeltaTime;

        // apply movement constraints
        // x bounds
        if (posX < minX || posX > maxX)
        {
            if (posX > maxX)
                rb.position = new Vector3(maxX, rb.position.y);
            else
                rb.position = new Vector3(minX, rb.position.y);

            playerMovement.x = 0;
        }
        // y bounds
        if (posY < minY || posY > maxY)
        {
            if (posY > maxY)
                rb.position = new Vector3(rb.position.x, maxY);
            else
                rb.position = new Vector3(rb.position.x, minY);

            playerMovement.x = 0;
        }
    }

    // ref sprite renderers of children
    [System.Serializable]
    public class PlayerSpriteRenderers
    {
        // ref alien child
        [SerializeField] private SpriteRenderer alien;
        public SpriteRenderer Alien { get { return this.alien; } }

        // ref pointer child
        [SerializeField] private SpriteRenderer pointer;
        public SpriteRenderer Pointer { get { return this.pointer; } }
    }
}
