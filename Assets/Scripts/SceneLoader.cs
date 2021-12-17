using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader
{
   public event Action<SceneName> loadingStarted;
   public event Action<float> loadingProgressUpdated;
   public event Action<SceneName> loadingCompleted;

   public AsyncOperation LoadGame()
   {
      SceneName sceneName = SceneName.Game;
      
      AsyncOperation asyncOperation = SceneManager.LoadSceneAsync(sceneName.ToString());
      loadingStarted?.Invoke(sceneName);

      return asyncOperation;
   }
   
   
   
}

public enum SceneName
{
   Game
}