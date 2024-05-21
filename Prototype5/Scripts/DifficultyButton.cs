using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DifficultyButton : MonoBehaviour
{
    [SerializeField]
    Button buttons;
    GameManager gameManager;
    [SerializeField]
    int difficultyValue;
    // Start is called before the first frame update
    void Start()
    {
        gameManager=GameObject.Find("GameManager").GetComponent<GameManager>();
        buttons=GetComponent<Button>();
        buttons.onClick.AddListener(() =>
        {
            SetDifficulty();
        });
    }

    void SetDifficulty()
    {
        gameManager.StartGame(difficultyValue);
        Debug.Log(buttons.gameObject.name+ " was Clicked");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
