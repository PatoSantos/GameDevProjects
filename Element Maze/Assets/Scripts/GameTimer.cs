using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameTimer : MonoBehaviour
{
    float timer = 0;

    private GameManager gameManager;
    private Text timerField;
    
    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
        timerField = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        if (gameManager.orbCount != 4)
        {
            timer += Time.deltaTime;
            var minutes = System.Math.Floor(timer / 60);
            var seconds = (timer % 60);

            timerField.text = string.Format("{0:00} : {1:00}", minutes, seconds);
        }
    }
}
