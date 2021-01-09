using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIOrbs : MonoBehaviour
{
    [SerializeField] GameObject[] uiOrbs;
    private PlayerController player;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player").GetComponent<PlayerController>();

        for (int i = 0; i < uiOrbs.Length; i++)
        {
            uiOrbs[i].SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < uiOrbs.Length; i++)
        {
            if (uiOrbs[i].GetComponent<OrbController>().orbType.Equals(player.currentOrb))
            {
                uiOrbs[i].SetActive(true);
            }
            else
            {
                uiOrbs[i].SetActive(false);
            }
        }
    }
}
