using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Lesson2.Input
{
    public class BadInputField : MonoBehaviour, IInputField
    {
        [SerializeField] private Text input;
	
        private void Update()
        {
            /*
            if(EventSystem.current.firstSelectedGameObject != gameObject)
                return;
		    */
            
            if (UnityEngine.Input.GetKeyDown(KeyCode.KeypadEnter))
            {
                OnEndInput(input.text);
                input.text = "";
            }

            for (int i = (int)KeyCode.A; i < (int)KeyCode.Z; i++)
            {
                if (UnityEngine.Input.GetKeyDown((KeyCode) i))
                {
                    input.text += ((KeyCode) i).ToString();
                }
            }
        }

        public string Text
        {
            get { return input.text; }
        }

        public event Action<string> OnEndInput = delegate(string s) {  };
    }
}