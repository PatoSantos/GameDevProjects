using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlateController : MonoBehaviour
{
    public string plateType;

    [SerializeField] Sprite activePlate;
    private Collider2D collider2d;

    // Start is called before the first frame update
    void Awake()
    {
        collider2d = GetComponent<Collider2D>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        string heldType = collision.gameObject.GetComponent<PlayerController>().currentOrb;
        if (heldType.Equals(plateType))
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = activePlate;
            collider2d.enabled = false;
        }
    }
}
