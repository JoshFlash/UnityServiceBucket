using System.Collections.Generic;
using UnityEngine;

public enum SampleEnum
{
    First,
    Second
}

public class SampleService : IService
{
    public SampleEnum SampleOption { get; private set; }
    private SampleEnum sampleOption = SampleEnum.Second;

    public void Init()
    {
        SampleOption = sampleOption;
    }
}