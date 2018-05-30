using System;
using System.Collections;


[Serializable]
public class UserState
{
	public string userName;
	public int playedGames;
	public int bestScore;
	public int lastScore;
}

public interface IApplicationStateManager
{
	void SaveState(UserState user);
	UserState GetState();
}