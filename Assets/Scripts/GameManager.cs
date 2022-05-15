using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Test
{
    public class GameManager : MonoBehaviour
    {
        public GameManager instance=null;

        public int CurrentLevel { get; private set; }


       
        private void Start()
        {
             
            if (instance == null)
            { 
               instance = this; 
            }
            else if (instance == this)
            { 
               Destroy(gameObject); 
            }
        }

        
    }
}
