using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public DoorTrigger[] cages;
    public MeshRenderer[] ghostGate;
    public List<Weapon> weapons;
    public Weapon currentWeapon;
    public Weapon _defaultWeap;
    public Enemy boss;
    private bool stage4Convo = false;

    public int _maxHealth;
    public int _currHealth;

    private bool inConversation;
    public static PlayerController instance;
    public NarrativeController nc;

    public Rigidbody _theRB;

    public DoomChalicev2 _controls;

    public float _moveSpeed = 5f;

    public GameObject _leverFlip;

    private Vector3 _moveInput;
    private Vector3 _lookInput;

    public float _mouseSens = 1f;

    public Camera _viewPort;

    public int _currentAmmo;
    public int _currentSpecialAmmo;

    public float _speed;

    private void Awake()
    {
        instance = this;
        _controls = new DoomChalicev2();
    }

    private void OnEnable()
    {
        _controls.DoomGuy.Walk.performed += Walk_performed;
        _controls.DoomGuy.Walk.Enable();

        _controls.DoomGuy.Look.performed += Look_performed;
        _controls.DoomGuy.Look.Enable();

        _controls.DoomGuy.Jump.performed += Jump_performed;
        _controls.DoomGuy.Jump.Enable();

        _controls.DoomGuy.StopWalk.performed += StopWalk_performed;
        _controls.DoomGuy.StopWalk.Enable();

        _controls.DoomGuy.Quit.performed += Quit_performed;
        _controls.DoomGuy.Quit.Enable();

        _controls.DoomGuy.FlipLever.performed += FlipLever_performed;
        _controls.DoomGuy.FlipLever.Enable();

        _controls.DoomGuy.Fire.performed += Fire_performed;
        _controls.DoomGuy.Fire.Enable();

        _controls.DoomGuy.Weapon1.performed += Weapon1_performed;
        _controls.DoomGuy.Weapon1.Enable();

        _controls.DoomGuy.Weapon2.performed += Weapon2_performed;
        _controls.DoomGuy.Weapon2.Enable();
    }

    private void Weapon2_performed(UnityEngine.InputSystem.InputAction.CallbackContext obj)
    {
        if (weapons.Count > 1)
        {
            currentWeapon = weapons[1];
            weapons[1].setCurrentGun();
        }
    }

    private void Weapon1_performed(UnityEngine.InputSystem.InputAction.CallbackContext obj)
    {
        currentWeapon = weapons[0];
        weapons[0].setCurrentGun();
    }

    private void OnDisable()
    {
        _controls.DoomGuy.Walk.performed -= Walk_performed;
        _controls.DoomGuy.Walk.Disable();

        _controls.DoomGuy.Look.performed -= Look_performed;
        _controls.DoomGuy.Look.Disable();

        _controls.DoomGuy.Jump.performed -= Jump_performed;
        _controls.DoomGuy.Jump.Disable();

        _controls.DoomGuy.StopWalk.performed -= StopWalk_performed;
        _controls.DoomGuy.StopWalk.Disable();

        _controls.DoomGuy.Quit.performed -= Quit_performed;
        _controls.DoomGuy.Quit.Disable();

        _controls.DoomGuy.FlipLever.performed -= FlipLever_performed;
        _controls.DoomGuy.FlipLever.Disable();

        _controls.DoomGuy.Fire.performed -= Fire_performed;
        _controls.DoomGuy.Fire.Disable(); 
        
        _controls.DoomGuy.Weapon1.performed -= Weapon1_performed;
        _controls.DoomGuy.Weapon1.Disable();

        _controls.DoomGuy.Weapon2.performed -= Weapon2_performed;
        _controls.DoomGuy.Weapon2.Disable();
    }

    private void Fire_performed(UnityEngine.InputSystem.InputAction.CallbackContext ctx)
    {
        if (!inConversation)
        {
            if (currentWeapon.CanShoot())
            {
                Ray _ray = _viewPort.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));
                RaycastHit _hit;
                Debug.DrawRay(_ray.origin, _ray.direction, Color.blue, 3f);
                if (Physics.Raycast(_ray, out _hit, 10f))
                {

                    Debug.Log(_hit.distance);
                    if (_hit.transform.gameObject.CompareTag("enemy"))
                    {
                        EnemyController.killEnemy(_hit.transform.gameObject);
                    }
                }
                currentWeapon.Fired();
            }
        }
    }

    private void FlipLever_performed(UnityEngine.InputSystem.InputAction.CallbackContext ctx)
    {
        if (!inConversation)
        {
            Ray _ray = _viewPort.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));
            RaycastHit _hit;
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward), Color.yellow, 10f);
            if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out _hit))
            {
                Debug.Log(_hit.transform.tag);
                Debug.DrawLine(transform.position, _hit.point, Color.yellow, 10f);
                if (_hit.transform.gameObject.CompareTag("lever"))
                {
                    Debug.Log(_hit.transform.gameObject.name);
                    _leverFlip = _hit.transform.gameObject;
                    LeverController.flipLever(_leverFlip);
                } else if (_hit.transform.gameObject.CompareTag("luther"))
                {
                    inConversation = true;
                    nc.StartConvo();
                    if (SceneManager.GetActiveScene().name == "StageZero")
                    {
                        foreach (MeshRenderer t in ghostGate)
                        {
                            t.enabled = false;
                        }
                    }
                } else if (_hit.transform.gameObject.CompareTag("chest"))
                {
                    GameObject temp = _hit.transform.gameObject;
                    ChestController tempChest = temp.GetComponent<ChestController>();
                    tempChest.opening = true;
                }
            }
            else
            {
            }
        } else
        {

        }
        
    }

    private void Quit_performed(UnityEngine.InputSystem.InputAction.CallbackContext ctx)
    {
        Cursor.visible = true;
        SceneManager.LoadScene("Start", LoadSceneMode.Single);
    }

    private void StopWalk_performed(UnityEngine.InputSystem.InputAction.CallbackContext ctx)
    {
        Vector2 _tempMove = ctx.ReadValue<Vector2>();
        _moveInput = new Vector3(ctx.ReadValue<Vector2>().x, 0, ctx.ReadValue<Vector2>().y);
    }

    private void Jump_performed(UnityEngine.InputSystem.InputAction.CallbackContext ctx)
    {
        if (!inConversation && _theRB.velocity.y < 0.05 && _theRB.velocity.y > -0.02)
        {
            _theRB.AddForce(new Vector3(0, 20, 0), ForceMode.Impulse);
        } else if (inConversation)
        {
            nc.ContinueConvo();
        } else
        {

        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("enemy"))
        {
            if (_currHealth > 1)
            {
                //_currHealth--;
            } else
            {
                //SceneManager.LoadScene("Start", LoadSceneMode.Single);
            }
        }
    }

    private void Look_performed(UnityEngine.InputSystem.InputAction.CallbackContext ctx)
    {
        if (!inConversation)
        {
            Vector2 _tempLook = ctx.ReadValue<Vector2>() / 10 * _mouseSens;
            transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles.x, transform.rotation.eulerAngles.y + _tempLook.x, transform.rotation.eulerAngles.z);

            _viewPort.transform.localRotation = Quaternion.Euler(_viewPort.transform.localRotation.eulerAngles + new Vector3(-_tempLook.y, 0f, 0f));
        }
    }

    private void Walk_performed(UnityEngine.InputSystem.InputAction.CallbackContext ctx)
    {
        if (!inConversation)
        {
            Vector2 _tempMove = ctx.ReadValue<Vector2>();
            _moveInput = new Vector3(ctx.ReadValue<Vector2>().x, 0, ctx.ReadValue<Vector2>().y);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        _currHealth = _maxHealth;
        //weapons = new List<Weapon>();
        //weapons.Add(_defaultWeap);
        currentWeapon = _defaultWeap;
        currentWeapon._weaponName = _defaultWeap._weaponName;

        Cursor.visible = false;
        if (instance == null)
        {
            instance = new PlayerController();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (SceneManager.GetActiveScene().name == "StageFourPointTwoLibrary" && !stage4Convo)
        {
            bool temp = true;
            foreach (DoorTrigger t in cages)
            {
                if (!t.manualOpen)
                {
                    temp = false;
                }
            }
            if (temp)
            {
                nc.StartConvo("afterPuzzleSolved");
                stage4Convo = true;
            }
        }

        if (SceneManager.GetActiveScene().name == "StageFive")
        {
            if(boss.dead == true)
            {
                SceneManager.LoadScene("Choice Scene", LoadSceneMode.Single);
                Cursor.visible = true;
            }
        }

        if (transform.position.y < -5)
        {
            LeverController.changedScene();
            EnemyController.ChangedScene();
            SceneManager.LoadScene(this.gameObject.scene.name, LoadSceneMode.Single);
        }

        Vector3 _moveHorizontal = transform.right * _moveInput.x;

        Vector3 _moveVertical = transform.forward * _moveInput.z;
        _theRB.AddForce(_moveHorizontal * _moveSpeed * Time.deltaTime, ForceMode.Impulse);
        _theRB.AddForce(_moveVertical * _moveSpeed * Time.deltaTime, ForceMode.Impulse);
        if (_theRB.velocity.z > _speed)
        {
            float temp = _theRB.velocity.z;
            temp = _speed;
            _theRB.velocity = new Vector3(_theRB.velocity.x, _theRB.velocity.y, temp);
        } else if (_theRB.velocity.z < -_speed)
        {
            float temp = _theRB.velocity.z;
            temp = -_speed;
            _theRB.velocity = new Vector3(_theRB.velocity.x, _theRB.velocity.y, temp);
        } else if (_theRB.velocity.x > _speed)
        {
            float temp = _theRB.velocity.x;
            temp = _speed;
            _theRB.velocity = new Vector3(temp, _theRB.velocity.y, _theRB.velocity.z);
        } else if (_theRB.velocity.x < -_speed)
        {
            float temp = _theRB.velocity.x;
            temp = -_speed;
            _theRB.velocity = new Vector3(temp, _theRB.velocity.y, _theRB.velocity.z);
        }
    }

    public void addWeapon(Weapon t)
    {
        if (weapons.Contains(t) == false)
        {
            weapons.Add(t);
        }

    }

    public void convoFinished ()
    {
        inConversation = false;
    }

    public void convoStarted()
    {
        inConversation = true;
    }
}
