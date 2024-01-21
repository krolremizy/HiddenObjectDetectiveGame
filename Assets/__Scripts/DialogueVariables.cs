using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Ink.Runtime;
using System.IO;

public class DialogueVariables
{
    public void StartListening(Story story)
    {
        VariableToStory(story);
        story.variablesState.variableChangedEvent += VariableChanged;
    }
    public void StopListening(Story story)
    {
        story.variablesState.variableChangedEvent -= VariableChanged;
    }
    public static void VariableChanged(string name, Ink.Runtime.Object value)
    {
       if(GameManager.Instance.variables.ContainsKey(name))
       {
            GameManager.Instance.variables.Remove(name);
            GameManager.Instance.variables.Add(name, value);
       }
    }

    public static void VariableToStory(Story story)
    {
        foreach(KeyValuePair<string,Ink.Runtime.Object> variable in GameManager.Instance.variables)
        {
            story.variablesState.SetGlobal(variable.Key, variable.Value);
        }
    }
}
