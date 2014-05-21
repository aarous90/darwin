
/// <summary>
/// Interface for ground animations.
/// </summary>
public interface IGroundAnimations
{
	// animations
		
	void OnIdleBegin();

	void OnIdleEnd();
		
	void OnBoringBegin();

	void OnBoringEnd();
		
	void OnWalkBegin();

	void OnWalkEnd();
		
	void OnJumpBegin();

	void OnJumpEnd();
		
	void OnHitBegin();

	void OnHitEnd();
		
	void OnDeathBegin();

	void OnDeathEnd();
}

