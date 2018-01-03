using UnityEngine;
using UnityEngine.SceneManagement;

namespace SNDL
{
	public class GUI : MonoBehaviour
	{
		protected Game game;

		//=======================
		// Intialization
		//=======================
		protected virtual void Awake()
		{
			game = Game.GetGame<Game>();
		}

		//=======================
		// Main Menu
		//=======================
		public virtual void onTogglMainMenu()
		{
		}

		public virtual void onOpenMainMenu()
		{
		}

		public virtual void onCloseMainMenu()
		{
		}

		//=======================
		// Scene Loading
		//=======================
		public virtual void onLoadScene( int tSceneIndex )
		{
			game.onLoadLevel( tSceneIndex );
		}

		protected virtual void onSceneLoaded( Scene _scene, LoadSceneMode _mode )
		{
		}

		//=======================
		// Event Subscription
		//=======================
		protected void OnEnable()
		{
			SceneManager.sceneLoaded += onSceneLoaded;
		}

		protected void OnDisable()
		{
			SceneManager.sceneLoaded -= onSceneLoaded;
		}
	}
}

