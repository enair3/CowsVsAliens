using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerDEMO : MonoBehaviour
{
    [SerializeField] private float playerSpeed;
    private Rigidbody2D rb;
    private Vector2 playerMovement;

    public int cowCount = 0;
    public int happiness = 5;
    public int conspiracy = 0;

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

        //cast ray
        /*RaycastHit2D beam = Physics2D.Raycast(transform.position, Vector2.down);
        Debug.DrawRay(transform.position, Vector2.down, Color.cyan);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (beam)
            {
                Debug.Log("ray hit");
                if (beam.transform.CompareTag("cow")) Debug.Log("cow identified");
                {
                    Debug.Log("got cow");
                    Destroy(this.gameObject); //destroys player currently
                }
            }
        }*/
    }
}
