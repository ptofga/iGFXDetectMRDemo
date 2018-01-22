using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

public class DetectSystemInfo : MonoBehaviour {
    public static DetectSystemInfo Singleton = null;

    public enum INTEL_GPU_LEVELS
    {
        OFF,
        LOW,        
        HIGH        
    };

    INTEL_GPU_LEVELS MyGPUSystemLevel = INTEL_GPU_LEVELS.OFF;

    public INTEL_GPU_LEVELS GPUCapabilityLevel
    {
        get
        {
            return MyGPUSystemLevel;
        }
        set
        {
            MyGPUSystemLevel = value;
        }
    }
    private string mGPUName;

    void Awake()
    {
        if (!Singleton)
        {
            Singleton = this;
        }
        else
        {
            Assert.IsNotNull(Singleton, "(Obj:" + gameObject.name + ") Only 1 instance of DetectSystemInfo needed at once");
            DestroyImmediate(this);
        }
    }
       
    public void Init()
    {
        mGPUName = SystemInfo.graphicsDeviceName;
        Debug.Log(mGPUName);

        if (IsIntelGPU())
        {
            MyGPUSystemLevel = DetectIntelGPULevel();
            if (INTEL_GPU_LEVELS.HIGH == MyGPUSystemLevel)
                Debug.Log("this is high level Intel GPU");
        }
        else
            Debug.Log("this is not Intel GPU");

    }
    bool IsIntelGPU()
    {
        if (mGPUName.ToLower().Contains("intel"))
            return true;
        else
            return false;

    }
    INTEL_GPU_LEVELS DetectIntelGPULevel()
    {
        if (mGPUName.ToLower().Contains("iris") )
            return INTEL_GPU_LEVELS.HIGH;
        return INTEL_GPU_LEVELS.LOW;
    }
    
}
