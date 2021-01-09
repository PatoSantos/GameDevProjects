using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public int orbCount = 0;
    private bool isGameActive;

    [SerializeField] GameObject[] orbs, plates, generators;
    [SerializeField] GameObject pauseMenu, gameOverMenu;
    [SerializeField] Button startButton;

    private PlayerController player;

    // Start is called before the first frame update
    void Start()
    {
        isGameActive = false;
        player = GameObject.Find("Player").GetComponent<PlayerController>();

        RandomizePositions();
        Time.timeScale = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (orbCount == 4)
        {
            gameOverMenu.SetActive(true);
            isGameActive = false;
            Time.timeScale = 0;
        }
        if (Input.GetKeyDown("q") && isGameActive)
        {
            PauseGame();
        }
    }

    public void StartGame()
    {
        startButton.gameObject.SetActive(false);
        isGameActive = true;
        Time.timeScale = 1;
    }

    public void PauseGame()
    {
        pauseMenu.SetActive(true);
        Time.timeScale = 0;
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void RestartGame()
    {
        SceneManager.LoadScene("Game");
    }

    public void ResumeGame()
    {
        pauseMenu.gameObject.SetActive(false);
        Time.timeScale = 1;
    }

    void RandomizePositions()
    {
        for (int i = 0; i < plates.Length; i++)
        {
            int gen = LocateEmptyGenerator();
            Instantiate(plates[i], generators[gen].transform.position, Quaternion.identity);
        }

        for (int i = 0; i < orbs.Length; i++)
        {
            int gen = LocateEmptyGenerator();
            Instantiate(orbs[i], generators[gen].transform.position, Quaternion.identity);
        }
    }

    int LocateEmptyGenerator()
    {
        RaycastHit2D raycast;
        int gen;
        do
        {
            gen = Random.Range(0, generators.Length);
            raycast = Physics2D.Raycast(generators[gen].transform.position, Vector2.up, Mathf.Infinity,
            LayerMask.GetMask("Orbs"));
        } while (raycast.collider != null);

        return gen;
    }
}
