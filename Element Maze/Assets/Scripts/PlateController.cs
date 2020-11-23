using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlateController : MonoBehaviour
{
    public string plateType;
    public Sprite activePlate;
    Collider2D collider2d;
    // Start is called before the first frame update
    void Start()
    {
        collider2d = GetComponent<Collider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        string heldType = collision.gameObject.GetComponent<PlayerAController>().currentOrb;
        if (heldType.Equals(plateType))
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = activePlate;
            collider2d.enabled = false;
        }
    }
}
