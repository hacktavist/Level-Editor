using UnityEngine;
using System;
using System.Collections;


public class Loader : MonoBehaviour {

  public string fileName;

  public ColorToPrefab[] prefabColors;

  public Camera cam;

  void Start(){
    cam = GameObject.FindObjectOfType<Camera> ();
    LoadMap ();
  }

  void LoadAllLevelNames(){
    // Read file list from StreamingAssets
    // Do this later
    // string filePath = Application.dataPath + "StreamingAssets/";
  }

  void EmptyMap(){
    while (transform.childCount > 0) {
      Transform c = transform.GetChild (0);
      c.SetParent (null);
      Destroy (c.gameObject);
    }
  }

  void LoadMap(){
    EmptyMap ();

    string filePath = Application.dataPath + "/StreamingAssets/" + fileName;
    byte[] bytes = System.IO.File.ReadAllBytes (filePath);

    Texture2D level = new Texture2D (1, 1);
    level.LoadImage (bytes);

    Color32 [] allPixels = level.GetPixels32 ();
    int width, height;
    width = level.width;
    height = level.height;

    for (int x = 0; x < width; x++) {
      for (int y = 0; y < height; y++) {
        if(x < width*height/2 && y < width*height/2)
        SpawnTileAt (allPixels [(y * width) + x], x, y);
      }
    }
  }

  void SpawnTileAt(Color32 c, int x, int y){
    if (c.a <= 0) {
      return;
    } // exit if no pixels present

    foreach (ColorToPrefab ctp in prefabColors) {
      if(c.Equals(ctp.c)){
        GameObject go = (GameObject) Instantiate(ctp.prefab, new Vector3(x,y,0), Quaternion.identity);
        go.transform.SetParent(this.transform);
        return;
      }
    }
    Debug.Log ("No color");
  }


}
  