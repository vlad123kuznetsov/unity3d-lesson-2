using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Lesson2.Basic
{
    public class BasicMonoMethod : MonoBehaviour
    {
        [SerializeField] private Transform go;

        private void OnApplicationFocus()
        {
            Debug.Log("focused");
        }

        private void OnApplicationPause(bool paused)
        {
            Debug.Log("paused");
        }

        private void OnApplicationQuit()
        {
            Debug.Log("quit");
        }

        private void OnBecameInvisible()
        {
            Debug.Log("invisible");
        }

        private void OnBecameVisible()
        {
            Debug.Log("visible");
        }

        private void OnDrawGizmos()
        {
            Gizmos.DrawCube(transform.position, Vector3.one * 1000); 
        }

        private void OnGUI()
        {   
            if (GUILayout.Button("change scene"))
            {
                SceneManager.LoadScene("test_scene_3", LoadSceneMode.Single);
            }

            if (GUILayout.Button("load additive"))
            {
                SceneManager.LoadScene("test_scene_3", LoadSceneMode.Additive);
            }
            
            if (GUILayout.Button("load scene async"))
            {
                StartCoroutine(LoadSceneAsync());
            }
        }

        private IEnumerator LoadSceneAsync()
        {
            var loadOperation = SceneManager.LoadSceneAsync("test_scene2");
            loadOperation.allowSceneActivation = true;
           
            while (!loadOperation.isDone)
            {
                Debug.Log(loadOperation.progress.ToString());
                yield return null;
            }
        }

        private void OnColiisioEnter(Collider collider)
        {
            
        }
        
        

        private void OnTriggerEnter()
        {
            Debug.Log("trigger enter");   
        }

        private void OnTriggerEnter2D()
        {
            Debug.Log("trigger enter 2d");
        }

        private void Awake()
        {
            //dont destroty if change scene
            DontDestroyOnLoad(this.gameObject);
        }
        
        
    }
}