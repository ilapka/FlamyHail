using System;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace FlamyHail.Client
{
   public class SceneLoader
   {
      public event Action<SceneName> OnLoadingStarted;
      public event Action<float> OnLoadingProgressUpdated;
      public event Action<SceneName> OnLoadingCompleted;

      public AsyncOperation LoadGame()
      {
         SceneName sceneName = SceneName.Game;

         AsyncOperation asyncOperation = SceneManager.LoadSceneAsync(sceneName.ToString());
         OnLoadingStarted?.Invoke(sceneName);

         return asyncOperation;
      }
   }
}

public enum SceneName
{
   Game
}