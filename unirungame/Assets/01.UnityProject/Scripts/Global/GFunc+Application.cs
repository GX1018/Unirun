using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.SceneManagement;
public static partial class GFunc
{
    public static void QuitThisGame(){
        #if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying=false;
        #else
        Application.Quit();
        #endif
    }

    //public static void HTFunc(this GameObject obj_){
    //    Debug.Log("이것은 내가 만든 함수가 분명하다.");
    //}

    public static void LoadScene(string sceneName_){
        SceneManager.LoadScene(sceneName_);
    }
}
//