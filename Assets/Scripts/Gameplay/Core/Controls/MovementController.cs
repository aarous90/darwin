using UnityEngine;

/// <summary>
/// The Movement controller manages to switch between different input settings for each terrain (Air, Ground, Water).
/// </summary>
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
		// Switch on control type
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
			default:
			{
				throw new UnityException("Invalid control type!");
			}
		}
	}

	////////////////////////////////////////////////////////////////////
	
	/// <summary>
	/// Take control of a certain character. Automaticly switches the input layout!
	/// </summary>
	public void UseCharacter(ICharacter character)
	{
		// TODO: free old character
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

	/// <summary>
	/// The type of the current control.
	/// </summary>
	ControlType currentControlType;

	/// <summary>
	/// The current used character.
	/// </summary>
	ICharacter currentCharacter;

	/// <summary>
	/// The air controller.
	/// </summary>
	AirController airController = new AirController();

	/// <summary>
	/// The ground controller.
	/// </summary>
	GroundController groundController = new GroundController();

	/// <summary>
	/// The water controller.
	/// </summary>
	WaterController waterController = new WaterController();

}
