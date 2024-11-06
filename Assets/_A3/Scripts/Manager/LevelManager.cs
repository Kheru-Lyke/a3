using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Com.KheruSEmporium.A3 {
    public class LevelManager : MonoBehaviour
    {
        [SerializeField] private SceneAsset level = default;
        [SerializeField] private Player player = default;

        private void Reload() {
            GameManager.Instance.Reload(level);
        }

		/// Singleton
		static private LevelManager instance;
		static public LevelManager Instance => instance;

		private void Start() {
            instance = this;

            player.OnDeath += Reload;
		}
	}
}
