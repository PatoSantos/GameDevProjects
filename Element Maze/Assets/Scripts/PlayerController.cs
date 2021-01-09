using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float playerSpeed = 5.0f;
    public bool holdingOrb;
    public string currentOrb;
    private float horizontal, vertical;

    private Rigidbody2D playerRb;

    private GameManager gameManager;

    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody2D>();
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
        holdingOrb = false;
        currentOrb = "";
    }

    // Update is called once per frame
    void Update()
    {
        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");
    }

    private void FixedUpdate()
    {
        Vector2 move = new Vector2(horizontal * playerSpeed, vertical * playerSpeed);
        playerRb.velocity = move;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!holdingOrb)
        {
            holdingOrb = true;
            currentOrb = collision.gameObject.GetComponent<OrbController>().orbType;
            Destroy(collision.gameObject);
        } 
        else if (collision.gameObject.GetComponent<PlateController>() != null)
        {
            string plateType = collision.gameObject.GetComponent<PlateController>().plateType;

            if (currentOrb.Equals(plateType))
            {
                currentOrb = "";
                holdingOrb = false;
                gameManager.orbCount += 1;
            }
        }
    }
}
