using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAController : MonoBehaviour
{
    public float playerSpeed = 5.0f;
    private Rigidbody2D rigidbody2d;

    bool holdingOrb;
    public string currentOrb;

    public GameObject orbImages;
    public GameObject stageManagerPrefab;
    StageManager stageManager;

    // Start is called before the first frame update
    void Start()
    {
        rigidbody2d = GetComponent<Rigidbody2D>();
        stageManager = stageManagerPrefab.GetComponent<StageManager>();
        holdingOrb = false;
        currentOrb = "";
    }

    // Update is called once per frame
    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        Vector2 move = new Vector2(horizontal * playerSpeed, vertical * playerSpeed);
        rigidbody2d.velocity = move;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!holdingOrb)
        {
            string orbType = collision.gameObject.GetComponent<OrbController>().orbType;
            if (orbType.Equals("fire"))
            {
                Debug.Log("Fire");
                holdingOrb = true;
                currentOrb = "fire";
                orbImages.GetComponent<UIOrbs>().currentOrb = currentOrb;
                Destroy(collision.gameObject);
            }
            else if (orbType.Equals("water"))
            {
                Debug.Log("Water");
                holdingOrb = true;
                currentOrb = "water";
                orbImages.GetComponent<UIOrbs>().currentOrb = currentOrb;
                Destroy(collision.gameObject);
            }
            else if (orbType.Equals("wind"))
            {
                Debug.Log("Wind");
                holdingOrb = true;
                currentOrb = "wind";
                orbImages.GetComponent<UIOrbs>().currentOrb = currentOrb;
                Destroy(collision.gameObject);
            }
            else if (orbType.Equals("earth"))
            {
                Debug.Log("Earth");
                holdingOrb = true;
                currentOrb = "earth";
                orbImages.GetComponent<UIOrbs>().currentOrb = currentOrb;
                Destroy(collision.gameObject);
            }
        } else if (collision.gameObject.GetComponent<PlateController>() != null)
        {
            string plateType = collision.gameObject.GetComponent<PlateController>().plateType;

            if (currentOrb.Equals(plateType))
            {
                currentOrb = "";
                orbImages.GetComponent<UIOrbs>().currentOrb = currentOrb;
                holdingOrb = false;
                stageManager.orbCount += 1;
            }
        }
    }
}
