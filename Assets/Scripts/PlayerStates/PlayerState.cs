using UnityEngine;

public interface IPlayerState
{
    public abstract void Enter(Player player);
    public abstract void Next(ref IPlayerState playerState);
}
