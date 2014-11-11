using UnityEngine;
using System.Collections;

public class LevelStart : MonoBehaviour
{
    public PlayerMovement[] Players;
    public TextCountdown CountdownText;
    public int Count;

	// Use this for initialization
	void Start ()
	{
	    StartCoroutine(Countdown());
	}

    private IEnumerator Countdown()
    {
        for (int i = Count; i >= 0; --i)
        {
            foreach (PlayerMovement p in Players)
            {
                var text = (TextCountdown)Instantiate(CountdownText);
                text.Text.text = i == 0 ? "GO!" : i.ToString();
                text.Player = p.transform;

                if (i == 1) p.Engine.Ignite();
            }
            
            yield return new WaitForSeconds(CountdownText.LifeTime);
        }
        foreach (var player in Players)
            player.Launched = true;
    }

    // Update is called once per frame
	void Update () {
	
	}
}
