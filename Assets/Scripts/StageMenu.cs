using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StageMenu : MonoBehaviour
{
    public int stagesCount = 2;
    public RawImage stagePreview;
    public Text highscoreText;

    private int currentStage = 1;

    public void Start()
    {
        GetHighScores();
    }

    private void GetHighScores()
    {
        HighscoreObject highscores;

        String highscoreTxt = PlayerPrefs.GetString("Highscore", "");
        if (highscoreTxt == "")
        {
            return;
        }
        else
        {
            highscores = JsonUtility.FromJson<HighscoreObject>(highscoreTxt);
        }

        int id = 1;
        String txt = "";
        foreach (var highscore in highscores.highscoreList)
        {
            string name = highscore.name;
            string score = highscore.score;

            txt += id + ". " + name + " - " + score + " points \n";

            id++;
        }
        highscoreText.text = txt;
    }

    public void ClearHighscore()
    {
        PlayerPrefs.DeleteKey("Highscore");
        highscoreText.text = "";
    }

    public void StartStage()
    {
        SceneManager.LoadScene("Stage-" + currentStage);
    }

    public void NextStage()
    {
        if (currentStage == stagesCount)
        {
            currentStage = 1;
        }
        else
        {
            currentStage++;
        }
        ChangeStagePreview();
    }

    public void PrevStage()
    {
        if (currentStage == 1)
        {
            currentStage = stagesCount;
        }
        else
        {
            currentStage--;
        }
        ChangeStagePreview();
    }

    private void ChangeStagePreview()
    {
        Texture2D tex = null;
        if (File.Exists("Assets/Images/Stage-" + currentStage + ".JPG"))
        {
            byte[] fileData = File.ReadAllBytes("Assets/Images/Stage-" + currentStage + ".JPG");
            tex = new Texture2D(2, 2);
            tex.LoadImage(fileData);
            stagePreview.texture = tex;
        }
    }
}
