//------------------------------------------------------------------------------ // <auto-generated> //     Dieser Code wurde von einem Tool generiert. //     Laufzeitversion:4.0.30319.34011 // //     Änderungen an dieser Datei können falsches Verhalten verursachen und gehen verloren, wenn //     der Code erneut generiert wird. // </auto-generated> //------------------------------------------------------------------------------ using System; using Assets.Scripts.Gameplay.Core.Type;   namespace Assets.Scripts.Gameplay.Core.Gamestates  {     /// <summary>     /// The training     /// </summary> 	public class TrainingState : IGameState 	{ 		public TrainingState() 		{  		}   		#region IGameState implementation 		public string GetName() 		{ 			return "Training State"; 		}  		public GamestateType GetGamestateType() 		{ 			return GamestateType.Training; 		}  		public void Enter() 		{  		}  		public void Leave() 		{  		}  		public void Reset() 		{  		} 		#endregion 	} }  