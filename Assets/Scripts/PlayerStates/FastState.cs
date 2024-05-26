using UnityEngine;

public class FastState : IPlayerState
{
    private const float playerSpeed = 150;
    private const float playerDrag = 0.15f;
    private const float playerMass = 0.75f;
    private const float playerSize = 0.75f;
    private readonly Color playerColor = Color.red;
    public void Enter(Player player)
    {
        player.speed = playerSpeed;
        player.rb.mass = playerMass;
        player.rb.drag = playerDrag; 
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
        player.tr.widthMultiplier = playerSize;
        player.sr.color = playerColor;
        player.transform.localScale = new Vector3(playerSize, playerSize, playerSize);
    }

    public void Next(ref IPlayerState playerState)
    {
        playerState = new PreciseState();
    }

}
