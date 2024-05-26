using UnityEngine;

public class DefaultState : IPlayerState
{
    private const float PlayerSpeed = 100;
    private const float PlayerDrag = 0.5f;
    private const float PlayerMass = 0.75f;
    private const float PlayerSize = 1f;
    private readonly Color playerColor = Color.blue;

    public void Enter(Player player)
    {
        player.speed = PlayerSpeed;
        player.rb.mass = PlayerMass;
        player.rb.drag = PlayerDrag; 
        var gradient = new Gradient();

        // Blend color from red at 0% to blue at 100%
        var colors = new GradientColorKey[2];
        colors[0] = new GradientColorKey(playerColor, 0.5f);
        colors[1] = new GradientColorKey(playerColor, 1.0f);

        // Blend alpha from opaque at 0% to transparent at 100%
        var alphas = new GradientAlphaKey[2];
        alphas[0] = new GradientAlphaKey(1.0f, 0.0f);
        alphas[1] = new GradientAlphaKey(0.0f, 1.0f);

        gradient.SetKeys(colors, alphas);
        player.tr.colorGradient = gradient;
        player.tr.widthMultiplier = PlayerSize;
        player.sr.color = playerColor;
        player.transform.localScale = new Vector3(PlayerSize, PlayerSize, PlayerSize);
    }
    public void Next(ref IPlayerState playerState)
    {
        playerState = new FastState();
    }
}
