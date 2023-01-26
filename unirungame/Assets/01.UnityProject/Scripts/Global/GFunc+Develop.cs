using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static partial class GFunc
{
    #region Print log func
    [System.Diagnostics.Conditional("DEBUG_MODE")]
    public static void Log(object message)
    {
        #if DEBUG_MODE
        Debug.Log(message);
        #endif
    }
    
    [System.Diagnostics.Conditional("DEBUG_MODE")]
    public static void Log(object message, UnityEngine.Object context)
    {
        #if DEBUG_MODE
        Debug.Log(message, context);
        #endif
    }
    #endregion  //Print log func

    #region Assert for debug
    [System.Diagnostics.Conditional("DEBUG_MOD")]
    public static void Assert(bool condition)
    {
        #if DEBUG_MODE
        Debug.Assert(condition);
        #endif
    }
    public static void Assert(bool condition, object message)
    {
        #if DEBUG_MODE
        Debug.Assert(condition, message);
        #endif
    }
    #endregion  //Assert for debug

    public static bool IsValid<T>(this T component_)
    {
        bool IsValid = component_.Equals(null) ==false;
        return IsValid;
    }
}
