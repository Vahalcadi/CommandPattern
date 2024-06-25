using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public CommandProcessor commandProcessor;

    private void Awake()
    {
        if(Instance != null)
            Destroy(Instance.gameObject);
        else
            Instance = this;

        commandProcessor = new CommandProcessor();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.K))
            commandProcessor.Undo();

        if (Input.GetKeyDown(KeyCode.L))
            commandProcessor.UndoAll();

        if (Input.GetKeyDown(KeyCode.G))
            commandProcessor.Redo();

        if (Input.GetKeyDown(KeyCode.H))
            commandProcessor.RedoAll();
    }

}
