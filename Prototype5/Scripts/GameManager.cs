using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    private List<GameObject> targets;
    [SerializeField]
    float spawnRate =1f; // spawn every 1 sec
    [SerializeField]
    TextMeshProUGUI textMeshProUGUI;
    [SerializeField]
    TextMeshProUGUI gameOverText;
    int score;
    [HideInInspector]
    public bool isGameActive = false;
    [SerializeField]
    Button button;
    [SerializeField]
    GameObject titleScreen;

    // Start is called before the first frame update
    void Start()
    {
       
    }

    public void StartGame(int diificulty)
    {
        spawnRate /= diificulty;
        titleScreen.SetActive(false);
        isGameActive = true;
        StartCoroutine(SpawnTargets());
        score = 0;
        RestartButton();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator SpawnTargets()
    {
        while (isGameActive)
        {
            yield return new WaitForSeconds(spawnRate);
            int index = Random.Range(0, targets.Count);
            Instantiate(targets[index]);
        }
    }

    public void UpdateScore(int scoreToAdd)
    {
        score += scoreToAdd;
        textMeshProUGUI.text = "Score: " + score;
    }

    public void GameOver()
    {
        gameOverText.gameObject.SetActive(true);
        isGameActive=false;
        button.gameObject.SetActive(true);
    }

    public void RestartButton()
    {
        button.onClick.AddListener(() =>
        {
            SceneManager.LoadScene(0);
        });
    }
}
