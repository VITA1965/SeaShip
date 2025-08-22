using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] GameObject[] controlCapsules;
    [SerializeField] TextMeshProUGUI score;
    int allIslandsValue;
    int currentScore = 0;

    private void Start()
    {
        allIslandsValue = controlCapsules.Length;
        score.text = $" Open Islands : {currentScore}/{allIslandsValue}";
    }

    public void OpenIsland()
    {
        
        currentScore += 1;
        score.text = $" Open Islands : {currentScore}/{allIslandsValue}";
        if (currentScore >= allIslandsValue)
        {
            Debug.Log("Win");
        }
    }
}
