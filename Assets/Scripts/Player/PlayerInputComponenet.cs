using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInputComponenet : MonoBehaviour
{
    [Header("Input Action Asset")]
    [SerializeField] private InputActionAsset _playerControls;

    [Header("Action Map Name References")]
    [SerializeField] private string _actionMapName = "Player";

    [Header("Action Name Refrence")]
    [SerializeField] private string _move = "Move";
    [SerializeField] string _action1 = "Action1";
    [SerializeField] string _action2 = "Action2";
    [SerializeField] string _action3 = "Action3";
    [SerializeField] string _action4 = "Action4";

    private InputAction _moveAction;
    private InputAction _inputAction1;
    private InputAction _inputAction2;
    private InputAction _inputAction3;
    private InputAction _inputAction4;

    public Vector2 MoveInput { get; private set; }
    public bool Action1 { get; private set; }
    public bool Action2 { get; private set; }
    public bool Action3 { get; private set; }
    public bool Action4 { get; private set; }   
    
    //Singleton, May only have one instance 
    public static PlayerInputComponenet Instance { get; private set; }

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else 
        {
            Destroy(gameObject);
        }

        _moveAction = _playerControls.FindActionMap(_actionMapName).FindAction(_move);
        _inputAction1 = _playerControls.FindActionMap(_actionMapName).FindAction(_action1);
        _inputAction2 = _playerControls.FindActionMap(_actionMapName).FindAction(_action2);
        _inputAction3 = _playerControls.FindActionMap(_actionMapName).FindAction(_action3);
        _inputAction4 = _playerControls.FindActionMap(_actionMapName).FindAction(_action4);
        RegisterActions();
    }

    void RegisterActions()
    {
        _moveAction.performed += context => MoveInput = context.ReadValue<Vector2>();
        _moveAction.canceled += context => MoveInput = Vector2.zero;

        _inputAction1.performed += context => Action1 = true;
        _inputAction1.canceled += context => Action1 = false;

        _inputAction2.performed += context => Action2 = true;
        _inputAction2.canceled += context => Action2 = false; 
        
        _inputAction3.performed += context => Action3 = true;
        _inputAction3.canceled += context => Action3 = false;

        _inputAction4.performed += context => Action4 = true;
        _inputAction4.canceled += context => Action4 = false;
    }

    private void OnEnable()
    {    
        _moveAction.Enable();
        _inputAction1.Enable();
        _inputAction2.Enable();
        _inputAction3.Enable();
        _inputAction4.Enable();
    }

   private void OnDisable() 
   {
        _moveAction.Disable();
        _inputAction1.Disable();
        _inputAction2.Disable();
        _inputAction3.Disable();
        _inputAction4.Disable();
   }

}
