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
        var todoList = ModelLoader<EGO.V_1.ToDoList>.Load();

        Debug.Log(JsonConvert.SerializeObject(todoList, Formatting.Indented));

        var Comm = new ModelUpdateCommand_Ver_1();
        Comm.Execute(todoList);
        Debug.Log(JsonConvert.SerializeObject(Comm.Result, Formatting.Indented));

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
