using TMPro;
using UnityEngine;

public class SpinnerMarker : MonoBehaviour
{
    public int number; 

    public static SpinnerMarker _instance;

    public static SpinnerMarker Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = FindObjectOfType<SpinnerMarker>();

                if (_instance == null)
                {
                    GameObject singletonObject = new GameObject();
                    _instance = singletonObject.AddComponent<SpinnerMarker>();
                    singletonObject.name = typeof(SpinnerMarker).ToString() + " (Singleton)";

                    DontDestroyOnLoad(singletonObject);
                }
            }
            return _instance;
        }
    }

    private void Awake()
    {     
        if (_instance == null)
        {
            _instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else if (_instance != this)
        {
            Destroy(gameObject);
        }
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        TextMeshPro textMeshPro = other.gameObject.GetComponent<TextMeshPro>();
        if (textMeshPro != null)
        {
            string text = textMeshPro.text;
            number = int.Parse(text);
            Debug.Log("Collided with: " + other.gameObject.name + " with text: " + text);
        }
        else
        {
            Debug.Log("Collided with: " + other.gameObject.name + " but no TextMeshPro component found.");
        }
    }


    // Update is called once per frame
    void Update()
    {

    }
}