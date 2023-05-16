using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameOverText : MonoBehaviour
{
    [SerializeField] TMP_Text gameOverText;

    public void UpdateText(int score)
    {
        gameOverText.text = "Game Over!\nScore: "+ score;
    }
}

