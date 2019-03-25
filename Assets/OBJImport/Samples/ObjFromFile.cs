using Dummiesman;
using System.IO;
using UnityEngine;

public class ObjFromFile : MonoBehaviour
{
    string objPath = "Assets/Scripts/Model.obj";
    string error = string.Empty;
  GameObject loadedObject;

   // void OnGUI() {
       // objPath = GUI.TextField(new Rect(0, 0, 256, 32), objPath);

       // GUI.Label(new Rect(0, 0, 256, 32), "Obj Path:");
       // if(GUI.Button(new Rect(256, 32, 64, 32), "Load File"))
      void Start()
      {
            //file path
            if (!File.Exists(objPath))
            {
                error = "File doesn't exist.";
                print("An error has occured! ");
            }
            else {
                if(loadedObject != null)            
                    Destroy(loadedObject);
                loadedObject = new OBJLoader().Load(objPath);
                loadedObject.transform.localPosition += new Vector3(515f, 41.6f,633.7f);
                loadedObject.transform.localScale += new Vector3(1000f,1000f,1000f);
                print("The model is loaded! ");
                error = string.Empty;

            }
     
        if(!string.IsNullOrWhiteSpace(error))
        {
            GUI.color = Color.red;
            GUI.Box(new Rect(0, 64, 256 + 64, 32), error);
            GUI.color = Color.white;
        }
      }
}
