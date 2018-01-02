﻿using UnityEngine;

namespace SNDL
{
	public class Level : MonoBehaviour
	{
		protected Game game;
		public string levelName;

		// DEFAULT INITIAL PAWN
		public Pawn defaultPawn;

		protected virtual void Awake()
		{
			game = Game.GetGame<Game>();
		}

		protected virtual void Start()
		{
			Debug.Log( levelName + " level has started" );
			if( defaultPawn )
			{
				setDefaultPawn( defaultPawn );
			}
		}

		// IF THERE IS A DEFAULT LEVEL PAWN
		// SET IT ON LEVEL START
		protected virtual void setDefaultPawn( Pawn tPawn )
		{
			game.controller.setCurrentPawn( tPawn );
		}
	}
}
