using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class DeathScreen : MonoBehaviour
{
    public GameObject inputField;
    public Text score;

    public void SaveScore()
    {
        HighscoreObject highscores;

        String userName = inputField.GetComponent<InputField>().text;
        if (userName == "")
        {
            userName = "Player";
        }
        HighscoreObject.Score playerScore = new HighscoreObject.Score(userName, score.text);
        String highscoreTxt = PlayerPrefs.GetString("Highscore", "");
        if(highscoreTxt != "")
        {
            highscores = JsonUtility.FromJson<HighscoreObject>(highscoreTxt);
        }
        else
        {
            highscores = new HighscoreObject();
            highscores.highscoreList = new List<HighscoreObject.Score>();
        }
        highscores.highscoreList.Add(playerScore);
        highscores.highscoreList = highscores.highscoreList.OrderByDescending(i => i.score).ToList();

        //remove lowest score if more than 10
        if (highscores.highscoreList.Count > 10 && highscores.highscoreList.Any())
        {
            highscores.highscoreList.RemoveAt(highscores.highscoreList.Count - 1);
        }

        PlayerPrefs.SetString("Highscore", JsonUtility.ToJson(highscores));

        SceneManager.LoadScene("Menu");
    }
}
