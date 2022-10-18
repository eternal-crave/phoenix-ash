using System;
using UnityEngine;

namespace Core.SaveSystem.PlayerPrefsSaveSystem
{
    public class PPSaveSystem : ISaveSystem<PPSaveSystemData>
    {
        private const string highscoreValueKey = "Highscore";
        public PPSaveSystemData Load()
        {
           return new PPSaveSystemData() { 
               Highscore = PlayerPrefs.GetInt(highscoreValueKey, 0) };
        }

        public void Save(PPSaveSystemData data)
        {
            PlayerPrefs.SetInt(highscoreValueKey,data.Highscore);
        }
    }
}
