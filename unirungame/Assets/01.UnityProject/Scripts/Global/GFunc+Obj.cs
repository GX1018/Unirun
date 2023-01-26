using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.SceneManagement;

public static partial class GFunc
{
    //! 특정 오브젝트의 자식 오브젝트를 서치해서 찾아주는 함수
    public static GameObject FindChildObj(this GameObject targetObj_, string objName_){
        GameObject searchResult =default;
        GameObject searchTarget =default;
        for(int i=0; i<targetObj_.transform.childCount; i++){
            searchTarget = targetObj_.transform.GetChild(i).gameObject;
            if(searchTarget.name.Equals(objName_)){
                searchResult = targetObj_.transform.GetChild(i).gameObject;
                return searchResult;
            }
            else{
                searchResult = FindChildObj(searchTarget, objName_);
            }
        }

        //방어로직
        if(searchResult == null || searchResult ==default){/*pass*/}
        else{return searchResult;}
        //
        
        return searchResult;
    }
    
    
    //! 씬의 루트 오브젝트를 서치해서 찾아주는 함수
    public static GameObject GetRootObj(string objName_){
        Scene activeScene_ = GetActiveScene();
        GameObject[] rootObjs_ = activeScene_.GetRootGameObjects();

        GameObject targetObj_ =default;
        foreach(GameObject rootObj in rootObjs_){
            if(rootObj.name.Equals(objName_)){
                targetObj_=rootObj;
                return targetObj_;
            }
            else{continue;}
        }
        return targetObj_;
    }

    //! RectTransform 에서 sizeDelta를 찾아 리턴하는 함수
    public static Vector2 GetRectSizeDelta(this GameObject obj_){
        return obj_.GetComponentMust<RectTransform>().sizeDelta;
    }


    //!현재 활성화 되어 있는 씬을 찾아주는 함수
    public static Scene GetActiveScene(){
        Scene activeScene_ = SceneManager.GetActiveScene();
        return activeScene_;
    }

    //! 오브젝트의 로컬 포지션을 변경하는 함수
    public static void SetLocalPos(this GameObject obj_, float x, float y, float z){
        obj_.transform.localPosition = new Vector3(x,y,z);
    }

    //! 트랜스폼을 사용해서 오브젝트를 움직이는 함수
    public static void Translate(this Transform transform_, Vector2 moveVector){
        transform_.Translate(moveVector.x, moveVector.y, 0f);
    }
    
    //! 컴포넌트 가져오는 함수
    public static T GetComponentMust<T>(this GameObject obj)
    {
        T component_ = obj.GetComponent<T>();
        
        GFunc.Assert(component_.IsValid<T>() !=false , string.Format("{0}에서 {1}을 찾을 수 없습니다.", obj.name, component_.GetType().Name));

        return component_;
    }

}
