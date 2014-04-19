using UnityEngine;
using System.Collections;

public class MovementController : MonoBehaviour
{

	public MovementController(string joystickName, uint joystickID)
	{
		this.joystickID = joystickID;
		this.joystickName = joystickName;
	}

	// Use this for initialization
	void Start()
	{
	
	}
	
	// Update is called once per frame
	void Update()
	{
	
	}

	////////////////////////////////////////////////////////////////////

	public void UseCharacter(ICharacter character)
	{
		currentCharacter = character;

		if (currentCharacter is AirCharacter)
		{
			airController.Initialize(character);
		}
		else if (currentCharacter is GroundCharacter)
		{
			groundController.Initialize(character);
		}
		else if (currentCharacter is WaterCharacter)
		{
			waterController.Initialize(character);
		}

		/**
		switch (type)
		{
			case ControlType.Air:
				{


				}
				break;
			case ControlType.Ground:
				{

				}
				break;
			case ControlType.Water:
				{

				}
				break;
			case ControlType.Invalid: // no break here
			default:
				{

				}
				break;
		}
		*/
	}

	////////////////////////////////////////////////////////////////////

	string joystickName;
	uint joystickID;

	ControlType currentControlType;

	ICharacter currentCharacter;

	AirController airController = new AirController();
	GroundController groundController = new GroundController();
	WaterController waterController = new WaterCharacter();

}
