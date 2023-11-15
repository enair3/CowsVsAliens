using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public static PlayerController playerInfo; // ref this script in other scripts
    public CollectionControls collectionControls;

    // sprite vars
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

    // player stats, can connect to UI objects
    public float cowCount = 0f;
    public float happiness = 25f;
    public float maxHappiness = 50f;
    public float conspiracy = 0f;
    public float maxConspiracy = 50f;

    public bool inCowDrought;
    public float timeWithoutCowCollected;

    private void Awake()
    {
        playerInfo = this;
        Time.timeScale = 1;
        //DontDestroyOnLoad(transform.root);
    }

    // Start is called before the first frame update
    void Start()
    {
        collectionControls = GameObject.FindObjectOfType<CollectionControls>();
        
        rb = GetComponent<Rigidbody2D>();

        alienSprite = playerSpriteRenderers.Alien.sprite;
        var playerSizeX = playerInfo.alienSprite.bounds.size.x / 4; // get alien sprite, get size for object boundaries

        // new bounds
        minX += playerSizeX;
        maxX -= playerSizeX;
        minY += playerSizeX;
        maxY -= playerSizeX;

        // cow drought
        inCowDrought = false;
        timeWithoutCowCollected = 0f;
    }

    private void Update()
    {
        // cow drought
        timeWithoutCowCollected += Time.deltaTime; // timer between cow collections

        // cow drought penalty

        
        //PlayerControllerDEMO.playerInfo.happiness -= (0.2f * (timeWithoutCowCollected - 8.0f)); 
        if (timeWithoutCowCollected >= 8.0f)
        {
            inCowDrought = true;
            CowDroughtPenalty();
        }

        // edge cases
        if (cowCount < 0)
        {
            cowCount = 0;
        }

        if (happiness < 0 || happiness > maxHappiness)
        {
            if (happiness < 0)
                happiness = 0;
            else
                happiness = maxHappiness;
        }
    }

    // need to recheck this
void CowDroughtPenalty()
{
    if (Time.timeScale == 1)
    {
        if (inCowDrought)
        {
            // decrease happiness by value per time in drought, not incl threshold
            happiness -= (0.0005f * (timeWithoutCowCollected - 8.0f));
        }
        else
        {
            timeWithoutCowCollected = 0f;
        }
    }
}
    

private void FixedUpdate()
    {
        PlayerMovement();
    }

    private void PlayerMovement()
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

    // ref sprite renderers of children. can act/deact later
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
