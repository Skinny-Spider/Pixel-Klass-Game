using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class Lifes : MonoBehaviour
{
    public TextMeshProUGUI Life;
    public Transform player;
    public int lifes;
    public bool lifeLost = false;

    // Start is called before the first frame update
    void Start()
    {
        // Setze den Startwert der Lebenspunkte
        lifes = 3;
    }

    // Update is called once per frame
    void Update()
    {
        // Überprüfe, ob der Spieler zu tief gefallen ist und noch kein Leben abgezogen wurde
        if (player.position.y <= -45 && !lifeLost)
        {
            // Ziehe ein Leben ab
            lifes = lifes - 1;
            lifeLost = true; // Setze die Variable, um zu verhindern, dass mehrere Leben gleichzeitig abgezogen werden

            // Gib eine Nachricht im Debug-Log aus
            Debug.Log("Leben abgezogen. Aktuelle Lebensanzahl: " + lifes);

            // Überprüfe, ob keine Lebenspunkte mehr vorhanden sind
            if (lifes == 0)
            {
                // Lade die entsprechende Szene (zum Beispiel Game Over)
                SceneManager.LoadScene(2);
            }
        }

        // Überprüfe, ob der Spieler wieder über eine gewisse Höhe gestiegen ist und setze die Variable zurück
        if (player.position.y > 1.5)
        {
            lifeLost = false;
        }

        // Aktualisiere den TextMeshPro-Text mit der aktuellen Lebensanzahl
        Life.text = "+" + lifes.ToString();
    }
}

