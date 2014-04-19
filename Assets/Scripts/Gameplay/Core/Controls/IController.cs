using System;

public interface IController
{
	void Initialize(ICharacter character);

	protected void Start();

	protected void Update();
	
	protected void FixedUpdate();
}

