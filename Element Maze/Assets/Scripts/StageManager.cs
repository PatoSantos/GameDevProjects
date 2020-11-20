using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageManager : MonoBehaviour
{
    public GameObject fireOrb, waterOrb, windOrb, earthOrb;
    public GameObject[] generators = new GameObject[10];

    // Start is called before the first frame update
    void Start()
    {
        
        GenerateOrb(fireOrb);
        GenerateOrb(waterOrb);
        GenerateOrb(windOrb);
        GenerateOrb(earthOrb);
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void GenerateOrb(GameObject orb)
    {
        RaycastHit2D raycast;
        int gen;
        do
        {
            gen = Random.Range(0, generators.Length);
            raycast = Physics2D.Raycast(generators[gen].transform.position, Vector2.up, Mathf.Infinity,
            LayerMask.GetMask("Orbs"));
        } while (raycast.collider != null);
        
        Instantiate(orb, generators[gen].transform.position, Quaternion.identity);
    }
}
