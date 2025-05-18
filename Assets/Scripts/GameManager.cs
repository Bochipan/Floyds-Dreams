using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
  

        public static GameManager Instance = new GameManager();
        

        private void Awake()
        {
            if (Instance == null)
            {
                DontDestroyOnLoad(gameObject);

        }
            else
            {  
                Destroy(gameObject);
            }
        }

        public int currentChoice = 0;
        public bool[] choices = new bool[5];
        public bool paused = false;

}
