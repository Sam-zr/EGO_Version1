using System.Collections;
using System.Collections.Generic;
using EGO.Util;
using Newtonsoft.Json;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class Playground
{
    // A Test behaves as an ordinary method
    [Test]
    public void PlaygroundSimplePasses()
    {
        // Use the Assert class to test conditions
        //var propety = new Propety<int>(10);
        //Debug.Log(JsonUtility.ToJson(propety));
        //Debug.Log(JsonConvert.SerializeObject(propety));
        //Debug.Log(propety.mValue);

        //var intPropety = new IntPropety();
        //intPropety.Value = 10;
        //Debug.Log(JsonUtility.ToJson(intPropety));
        //Debug.Log(JsonConvert.SerializeObject(intPropety));
        //Debug.Log(intPropety.Value);

        //Debug.Log(JsonUtility.ToJson(propety));
        //Debug.Log(JsonConvert.SerializeObject(propety));
        //Debug.Log(propety.mValue);

        //  ╤оят
        Assert.IsTrue(true);
    }

    // A UnityTest behaves like a coroutine in Play Mode. In Edit Mode you can use
    // `yield return null;` to skip a frame.
    [UnityTest]
    public IEnumerator PlaygroundWithEnumeratorPasses()
    {
        // Use the Assert class to test conditions.
        // Use yield to skip a frame.
        yield return null;
    }
}
