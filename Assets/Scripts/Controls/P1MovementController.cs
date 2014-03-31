using UnityEngine;
using System.Collections;

public class P1MovementController : MonoBehaviour, IInputListener {

	public InputManager						GlobalInput;

	// Use this for initialization
	void Start () {
		UnityEngine.Object.DontDestroyOnLoad(this);
		GlobalInput.RegisterListener(InputManager.InputCategory.Ground, this);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	private void ranged(){
		}

	private void melee(){
	}

	private void special(){
		transform.Translate (Vector2.right * 0.5f);
	}

	private void move(){

	}

    public void OnButtonUp(string button){
		if (button == InputStringMapping.GroundInputMapping.P1_SpecialSkill)
		{
			special();
		}
	}
	public void OnButtonPressed(string button){
	}
	public void OnButtonDown(string button){
	}
	
	public void OnAxis(string axisName, float axisValue){
	}

	public void OnMovement(string moveName, int x, int y){
	}
	
}
