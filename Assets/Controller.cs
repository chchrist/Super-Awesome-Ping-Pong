using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour { 
    public GUISkin guiSkin;
    public int maxScore = 12;

    private int player1Score = 0;
    private int player2Score = 0;
    private Paddle player1, player2;

    void Start() {
        player1 = GameObject.Find("Paddle1").GetComponent<Paddle>();
        player2 = GameObject.Find("Paddle2").GetComponent<Paddle>();
    }

    void OnGUI() {
        GUI.skin = guiSkin;
        GUI.Label(new Rect(Screen.width / 2 - 165, 20, 100, 100), "" + player1Score);
        GUI.Label(new Rect(Screen.width / 2 + 165, 20, 100, 100), "" + player2Score);
    }

    /*
     * Adds a point to the specified player's score.
     */
    public void AddPoint(string player) {
        // Increment score
        // ---------------
        if (player == "Player1") {
            player1Score++;
            Debug.Log("Player 1 scores! Current score: " + player1Score);
        }
        else {
            player2Score++;
            Debug.Log("Player 2 scores! Current score: " + player2Score);
        }

        // Reset player scores if there's a winner
        // ---------------------------------------
        if (player1Score == maxScore || player2Score == maxScore) {
            player1Score = player2Score = 0;
        }

        // Reset paddles
        // -------------
        player1.Reset();
        player2.Reset();
    }
}
