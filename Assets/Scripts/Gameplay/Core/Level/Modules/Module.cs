using UnityEngine;
using System.Collections;

public class Module : MonoBehaviour
{

	// Use this for initialization
	void Start()
	{
		if (Spawns.Length != 3)
		{
			throw new UnityException("Each module needs three spawns for air, ground and water!");
		}
	}
	
	// Update is called once per frame
	void Update()
	{
	
	}

	/// <summary>
	/// Intersect the specified point.
	/// 
	/// Left handed
	/// 
	/// 	y	z
	///		|  /
	/// 	| /
	/// 	|/________
	/// 			  x
	/// </summary>
	/// <param name="point">Point.</param>
	public bool Intersect(Vector3 point)
	{
		Vector3 line = OutConnector.transform.position - InConnector.transform.position;

		Vector3 a = InConnector.transform.position;
		Vector3 p = point;
		float distance = Vector3.Distance((a - p), Vector3.Cross((a - p), line.normalized));
		return false;
	}

	/// <summary>
	/// Gets or sets the offset of this module in world-position from (0,0,0).
	/// </summary>
	/// <value>The offset.</value>
	public Vector3 Offset
	{
		get
		{
			return offset;
		}

		set
		{
			offset = value;
		}
	}

	/// <summary>
	/// The spawns, must be exactly two!
	/// </summary>
	public CharacterSpawn[] Spawns;

	/// <summary>
	/// The in connector.
	/// </summary>
	public ConnectorElement InConnector;

	/// <summary>
	/// The out connector.
	/// </summary>
	public ConnectorElement OutConnector;

	/// <summary>
	/// The offset of this module in world-position from (0,0,0).
	/// </summary>
	Vector3 offset;
}
