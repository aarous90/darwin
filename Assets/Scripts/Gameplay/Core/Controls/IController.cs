using System;

public abstract class IController
{
	public abstract void Initialize(ICharacter character);

	public abstract void Start();

	public abstract void Update();
	
	public abstract void FixedUpdate();
}

