﻿/**
 * Author: Sander Homan
 * Copyright 2012
 **/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

class ConsoleGUI : MonoBehaviour
{
    private int historyScrollValue;
    private int commandIndex = 0;

    private string command = "";
    private bool returnPressed = false;

    public GUISkin skin = null;
    public int linesVisible = 17;

    private bool isOpen = false;
    private string partialCommand = "";

    private bool moveCursorToEnd;

    public bool showHierarchy = true;

    private string[] displayObjects = null;
    private string[] displayComponents = null;
    private Vector2 hierarchyScrollValue;
    private Vector2 componentScrollValue;

    private int commandLastPos;
    private int commandLastSelectPos;

    private string[] displayMethods = null;
    private Vector2 methodScrollValue;
    private bool wasCursorVisible;

    private int hierarchyWidth = 150;

    void Start()
    {
        //InvokeRepeating("PrintLine", 2, 0.1f);
        //Console.Instance.RegisterCommand("printchildren", this, "PrintChildren");
        //Console.Console.Instance.RegisterCommand("printcomponents", this, "PrintComponents");
        //Console.Instance.RegisterCommand("testParse", this, "TestParse");

        displayObjects = Console.Instance.GetGameobjectsAtPath("/");
        displayComponents = Console.Instance.GetComponentsOfGameobject("/");
        displayMethods = Console.Instance.GetMethodsOfComponent("/");

        float height = Screen.height / 2;
        height -= skin.box.padding.top + skin.box.padding.bottom;
        height -= skin.box.margin.top + skin.box.margin.bottom;
        height -= skin.textField.CalcHeight(new GUIContent(""),10);
        linesVisible = (int)(height / skin.label.CalcHeight(new GUIContent(""),10)) - 2;

        // set max line width
        float width = Screen.width - 10;
        width -= hierarchyWidth;
        width -= skin.verticalScrollbar.CalcSize(new GUIContent("")).x;
        Console.Instance.maxLineWidth = (int)(width / skin.label.CalcSize(new GUIContent("A")).x);
    }

    void OnGUI()
    {
        GUI.skin = skin;

        if (Event.current.type == EventType.keyDown && Event.current.keyCode == KeyCode.Return)
        {
            returnPressed = true;
        }
        else
        {
            returnPressed = false;
        }

        bool upPressed = false;
        if (Event.current.type == EventType.keyDown && Event.current.keyCode == KeyCode.UpArrow)
        {
            upPressed = true;
            Event.current.Use();
        }

        bool downPressed = false;
        if (Event.current.type == EventType.keyDown && Event.current.keyCode == KeyCode.DownArrow)
        {
            downPressed = true;
            Event.current.Use();
        }

        bool escPressed = false;
        if (Event.current.type == EventType.keyDown && Event.current.keyCode == KeyCode.Escape)
        {
            escPressed = true;
            Event.current.Use();
        }

        if (isOpen)
        {
            GUI.depth = -100;
            GUILayout.BeginArea(new Rect(5, 5, Screen.width - 10, Screen.height / 2), (GUIStyle)"box");
            GUILayout.BeginHorizontal();

            GUILayout.BeginVertical();
            var lines = Console.Instance.Lines;
            // display last 10 lines
            for (int i = lines.Count() - Mathf.Min(linesVisible, lines.Count()) - historyScrollValue; i < lines.Count() - historyScrollValue; i++)
            {
                GUILayout.Label(lines.GetItemAt(i));
            }
            GUILayout.EndVertical();
            if (lines.Count() > linesVisible)
                historyScrollValue = (int)GUILayout.VerticalScrollbar(historyScrollValue, linesVisible, lines.Count(), 0, GUILayout.ExpandHeight(true));

            if (showHierarchy)
            {
                GUILayout.BeginVertical(GUILayout.Width(hierarchyWidth), GUILayout.ExpandHeight(true));
                int firstDot = command.IndexOf('.');
                if (firstDot == -1 || command.IndexOf('.', firstDot + 1) == -1)
                {
                    hierarchyScrollValue = GUILayout.BeginScrollView(hierarchyScrollValue, (GUIStyle)"box");
                    foreach (var go in displayObjects)
                    {
                        if (GUILayout.Button(go, (GUIStyle)"GameObjectListLabel"))
                        {
                            if (command.LastIndexOf('/') >= 0)
                                command = command.Substring(0, command.LastIndexOf('/'));
                            command += "/" + go.Replace(" ", "\\ ") + "/";
                            displayObjects = Console.Instance.GetGameobjectsAtPath(command);
                            displayComponents = Console.Instance.GetComponentsOfGameobject(command);
                            moveCursorToEnd = true;
                        }
                    }
                    GUILayout.EndScrollView();

                    componentScrollValue = GUILayout.BeginScrollView(componentScrollValue, (GUIStyle)"box");
                    foreach (var comp in displayComponents)
                    {
                        if (GUILayout.Button(comp, (GUIStyle)"GameObjectListLabel"))
                        {
                            if (firstDot > 0)
                                command = command.Substring(0, firstDot);
                            if (command.EndsWith("/"))
                                command = command.Substring(0, command.Length - 1);
                            command += "." + comp + ".";
                            displayObjects = Console.Instance.GetGameobjectsAtPath(command);
                            displayComponents = Console.Instance.GetComponentsOfGameobject(command);
                            displayMethods = Console.Instance.GetMethodsOfComponent(command);
                            moveCursorToEnd = true;
                        }
                    }
                    GUILayout.EndScrollView();
                }
                else
                {
                    methodScrollValue = GUILayout.BeginScrollView(methodScrollValue, (GUIStyle)"box");
                    foreach (var method in displayMethods)
                    {
                        if (GUILayout.Button(method, (GUIStyle)"GameObjectListLabel"))
                        {
                            command = command.Substring(0, command.IndexOf('.', firstDot + 1));
                            command += "." + method;
                            moveCursorToEnd = true;
                        }
                    }
                    GUILayout.EndScrollView();
                }
                GUILayout.EndVertical();
            }
            GUILayout.EndHorizontal();
            GUILayout.FlexibleSpace();
            GUILayout.BeginHorizontal();
            GUI.SetNextControlName("CommandTextField");
            string oldCommand = command;
            command = GUILayout.TextField(command);
            if (command != oldCommand)
            {
                displayObjects = Console.Instance.GetGameobjectsAtPath(command);
                displayComponents = Console.Instance.GetComponentsOfGameobject(command);
                displayMethods = Console.Instance.GetMethodsOfComponent(command);
                TextEditor te = (TextEditor)GUIUtility.GetStateObject(typeof(TextEditor), GUIUtility.keyboardControl);
                if (te != null)
                {
                    commandLastPos = te.pos;
                    commandLastSelectPos = te.selectPos;
                }
            }
#if UNITY_IPHONE || UNITY_ANDROID || UNITY_EDITOR
            if (GUILayout.Button("Submit", GUILayout.ExpandWidth(false)))
            {
                returnPressed = true;
            }
#endif
            GUILayout.EndHorizontal();
            GUILayout.EndArea();

            if (Event.current.type == EventType.repaint && moveCursorToEnd)
            {
                TextEditor te = (TextEditor)GUIUtility.GetStateObject(typeof(TextEditor), GUIUtility.keyboardControl);
                if (te != null)
                {
                    te.MoveTextEnd();
                    te.pos = te.selectPos;
                    te.graphicalCursorPos = te.style.GetCursorPixelPosition(new Rect(0f, 0f, te.position.width, te.position.height), te.content, te.pos);
                    commandLastPos = te.pos;
                    commandLastSelectPos = te.selectPos;
                }
                moveCursorToEnd = false;
            }

            if (GUI.GetNameOfFocusedControl() == "CommandTextField" && returnPressed)
            {
                Console.Instance.Print("> " + command);
                Console.Instance.Eval(command);
                command = "";
                commandIndex = 0;
                displayObjects = Console.Instance.GetGameobjectsAtPath(command);
                displayComponents = Console.Instance.GetComponentsOfGameobject(command);
            }

            if (GUI.GetNameOfFocusedControl() == "CommandTextField" && upPressed)
            {
                if (commandIndex == 0)
                    partialCommand = command;

                commandIndex++;
                var commandsCount = Console.Instance.Commands.Count();
                if (commandsCount > 0)
                {
                    if (commandIndex > commandsCount) commandIndex--;

                    command = Console.Instance.Commands.GetItemAt((commandsCount - 1) - (commandIndex - 1));

                    moveCursorToEnd = true;
                }
            }

            if (GUI.GetNameOfFocusedControl() == "CommandTextField" && downPressed)
            {
                commandIndex--;
                var commandsCount = Console.Instance.Commands.Count();
                if (commandIndex < 0) commandIndex = 0;

                if (commandsCount > 0)
                {
                    if (commandIndex > 0)
                        command = Console.Instance.Commands.GetItemAt((commandsCount - 1) - (commandIndex - 1));
                    else
                        command = partialCommand;

                    moveCursorToEnd = true;
                }
            }
        }
#if UNITY_IPHONE || UNITY_ANDROID
        else
        {
            // show open button
            if (GUILayout.Button("Open Console"))
            {
                isOpen = true;
            }
        }
#endif

        if (!isOpen && Event.current.type == EventType.keyUp && Event.current.keyCode == KeyCode.BackQuote)
        {
            isOpen = true;
            Event.current.Use();
            Event.current.type = EventType.used;
            wasCursorVisible = Screen.showCursor;
        }

        if (isOpen)
            Screen.showCursor = true;

        if (isOpen && escPressed)
        {
            isOpen = false;
            Screen.showCursor = wasCursorVisible;
        }

        // refocus the textfield if focus is lost
        if (isOpen && Event.current.type == EventType.layout && GUI.GetNameOfFocusedControl() != "CommandTextField")
        {
            GUI.FocusControl("CommandTextField");
            TextEditor te = (TextEditor)GUIUtility.GetStateObject(typeof(TextEditor), GUIUtility.keyboardControl);
            if (te != null)
            {
                te.pos = commandLastPos;
                te.selectPos = commandLastSelectPos;
            }
        }
    }

    int test(int value)
    {
        return value + 1;
    }

    //void PrintChildren(string path)
    //{
    //    foreach (var s in Console.Instance.GetGameobjectsAtPath(path))
    //    {
    //        Console.Instance.Print(s);
    //    }
    //}

    //void PrintComponents(string path)
    //{
    //    foreach (var s in Console.Instance.GetComponentsOfGameobject(path))
    //    {
    //        Console.Instance.Print(s);
    //    }
    //}

    //void TestParse(params string[] args)
    //{
    //    string line = "";
    //    foreach (string s in args)
    //    {
    //        line += s + " ";
    //    }

    //    string command;
    //    string[] gameobjectPath;
    //    string componentName;
    //    string methodName;
    //    string[] parameters;
    //    Console.Instance.Print(line);
    //    Console.parseCommand(line, out command, out gameobjectPath, out componentName, out methodName, out parameters);

    //    Console.Instance.Print("command: " + command);
    //    string goPath = "";
    //    if (gameobjectPath!=null)
    //        foreach (string s in gameobjectPath)
    //        {
    //            goPath += "/" + s;
    //        }
    //    Console.Instance.Print("gameobjectPath: " + goPath);
    //    Console.Instance.Print("componentName: " + componentName);
    //    Console.Instance.Print("methodName: " + methodName);
    //    string par = "";
    //    if (parameters!=null)
    //        foreach (string s in parameters)
    //        {
    //            par += ";" + s;
    //        }
    //    Console.Instance.Print("parameters: " + par);
    //}
}

