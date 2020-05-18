using System;
using System.Collections.Generic;

[Serializable]
public class HighscoreObject
{
    public List<Score> highscoreList;

    [Serializable]
    public class Score
    {
        public string name;
        public string score;

        public Score(string _name, string _score)
        {
            name = _name;
            score = _score;
        }

    }
}