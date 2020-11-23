using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageManager : MonoBehaviour
{
    public GameObject fireOrb, waterOrb, windOrb, earthOrb;
    public GameObject firePlate, waterPlate, windPlate, earthPlate;
    public GameObject[] generators = new GameObject[10];

    public int orbCount;

    // Start is called before the first frame update
    void Start()
    {
        orbCount = 0;
        Generate(fireOrb);
        Generate(waterOrb);
        Generate(windOrb);
        Generate(earthOrb);

        Generate(firePlate);
        Generate(waterPlate);
        Generate(windPlate);
        Generate(earthPlate);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("x"))
        {
            Debug.Log(orbCount);
        }
    }

    void Generate(GameObject prefab)
    {
        RaycastHit2D raycast;
        int gen;
        do
        {
            gen = Random.Range(0, generators.Length);
            raycast = Physics2D.Raycast(generators[gen].transform.position, Vector2.up, Mathf.Infinity,
            LayerMask.GetMask("Orbs"));
        } while (raycast.collider != null);
        
        Instantiate(prefab, generators[gen].transform.position, Quaternion.identity);
    }
}
