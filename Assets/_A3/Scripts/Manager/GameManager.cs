using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Cinemachine.DocumentationSortingAttribute;
using UnityEngine.SceneManagement;
using UnityEditor;
using System;

namespace Com.KheruSEmporium.A3
{
    public class GameManager : MonoBehaviour
    {
		[SerializeField] private SceneAsset startScene = default;
		[SerializeField] private SceneAsset loadingScene = default;

		AsyncOperation sceneLoad = default;
		AsyncOperation loadingSceneLoad = default;
		private float elapsedTime = 0;
		[SerializeField] private float minLoadTime = 3;

		public float LoadProgress => sceneLoad.progress;
		public float MinLoadTime => minLoadTime;


		public void Reload(SceneAsset level) {
			loadingSceneLoad.allowSceneActivation= true;

			elapsedTime = 0;
			StartCoroutine(LoadSceneCoroutine(level));
		}

		private IEnumerator LoadSceneCoroutine(SceneAsset level) {
			sceneLoad = SceneManager.LoadSceneAsync(level.name);
			sceneLoad.allowSceneActivation = false;

			while (sceneLoad.progress < 0.89 || elapsedTime <= minLoadTime) {
				elapsedTime += Time.deltaTime;

				yield return null;
			}

			sceneLoad.allowSceneActivation = true;
			LoadLoadingScreen();
		}

		private void LoadLevel(AsyncOperation sceneLoad) {
			sceneLoad.allowSceneActivation= true;
		}

		private void LoadLoadingScreen(AsyncOperation sceneLoad = null) {
			loadingSceneLoad = SceneManager.LoadSceneAsync(loadingScene.name);
			loadingSceneLoad.allowSceneActivation = false;
		}


		/// Singleton
		static private GameManager instance;
		static public GameManager Instance => instance;


		private void Start() {
			instance = this;
			DontDestroyOnLoad(gameObject);

			sceneLoad = SceneManager.LoadSceneAsync(startScene.name);
			sceneLoad.completed += LoadLoadingScreen;
		}
	}
}
