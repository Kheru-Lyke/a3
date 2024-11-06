using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Com.KheruSEmporium.A3
{
    public class LevelManager : MonoBehaviour
    {
        [SerializeField] private SceneAsset level = default;
        [SerializeField] private Player player = default;

        private void Reload() {
            SceneManager.LoadScene(level.name);
        }

        /// Singleton
        private LevelManager instance;
        public LevelManager Instance => instance;

		private void Start() {
            instance = this;

            player.OnDeath += Reload;
		}
	}
}
