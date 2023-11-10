using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveObject : MonoBehaviour
{
    [SerializeField] private float objectSpeed = 3;

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.position += new Vector3(0, -objectSpeed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "bottomBorder")
        {
            Debug.Log("destroy block");
            Destroy(this.gameObject);
        }

    }
}
