using Core.SaveSystem.PlayerPrefsSaveSystem;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.ScoreSystem
{
    public class ScoreCounter
    {
        public event Action<int> OnScoreChange;
        private int highScore;
        private int score;
        private PPSaveSystem saveSystem;

        public int Score => score;
        public int Highscore => highScore;

        public ScoreCounter(PPSaveSystem saveSystem)
        {
            this.saveSystem = saveSystem;
            highScore = saveSystem.Load().Highscore;
        }

        public void ResetScore()
        {
            score = 0;
        }

        public void AddScore(int points)
        {
            score += points;
            OnScoreChange?.Invoke(score);
        }
        public void GetScoreInfo(out float currentScore, out float highScore)
        {
            currentScore = score;
            highScore = saveSystem.Load().Highscore;
        }
    }
}
