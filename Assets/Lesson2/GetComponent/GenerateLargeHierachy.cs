using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class GenerateLargeHierachy : MonoBehaviour
{
    private int objectsCount = 50;
    private int maxNestedLevel = 3;
    private int specialNumber1 = 10000;
    private int specialNumber2 = 50000;
    private int globalCounter = 0;
    
    public void Generate()
    {
        //Clear old staff
        var objects = FindObjectsOfType<MonoBehaviour>().Where(p => p.GetType() != GetType());
        var roots = objects.Select(p => p.gameObject).Distinct().Where(p => p.transform.parent == null);

        globalCounter = 0;
        
        foreach (var root in roots)
        {
            Destroy(root);
        }
        
        GenerateRecursive(1, null);
    }

    private void GenerateRecursive(int currentLevel, GameObject root)
    {
        if (currentLevel > maxNestedLevel)
        {
            return;
        }

        for (int i = 0; i < objectsCount; i++)
        {
            globalCounter++;
            var go = new GameObject();
            if (root != null)
            {
                go.transform.parent = root.transform;
            }
            else
            {
                go.transform.parent = null;
            }

            if (globalCounter == specialNumber1 || globalCounter == specialNumber2)
            {
                //tag should be added in editor settings
                go.tag = "special";
                go.AddComponent<Image>();
            }
            
            go.name = "number " + i.ToString() + " nested " + currentLevel.ToString() + " " + globalCounter.ToString();
            go.AddComponent<Rigidbody2D>();
            //go.AddComponent<Button>();
            GenerateRecursive(currentLevel + 1, go);
        }
    }
}
