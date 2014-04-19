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

	void FixedUpdate()
	{
		switch (currentControlType)
		{
			case ControlType.Air:
			{
				airController.FixedUpdate();
			}
				break;
			case ControlType.Ground:
			{
				groundController.FixedUpdate();
			}
				break;
			case ControlType.Water:
			{
				waterController.FixedUpdate();
			}
				break;
			case ControlType.Invalid: // no break here
			default:
			{
				throw new UnityException("Invalid control type!");
			}
		}
	}

	////////////////////////////////////////////////////////////////////

	public void UseCharacter(ICharacter character)
	{
		currentCharacter = character;

		if (currentCharacter is AirCharacter)
		{
			currentControlType = ControlType.Air;
			airController.Initialize(character);
		}
		else if (currentCharacter is GroundCharacter)
		{
			currentControlType = ControlType.Ground;
			groundController.Initialize(character);
		}
		else if (currentCharacter is WaterCharacter)
		{
			currentControlType = ControlType.Water;
			waterController.Initialize(character);
		}
		else
		{
			currentControlType = ControlType.Invalid;
			throw new UnityException("Invalid control type!");
		}
	}

	////////////////////////////////////////////////////////////////////

	string joystickName;
	uint joystickID;

	ControlType currentControlType;

	ICharacter currentCharacter;

	AirController airController = new AirController();
	GroundController groundController = new GroundController();
	WaterController waterController = new WaterController();

}
