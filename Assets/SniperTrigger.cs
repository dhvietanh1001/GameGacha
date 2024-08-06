using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class SniperTrigger : MonoBehaviour
{
    [SerializeField] protected Transform sniper;
    [SerializeField] protected float speed = 0f;
    [SerializeField] protected float speedmax = 855;
    [SerializeField] protected float speeddown = 10f;
    [SerializeField] protected string stopAt = "10";
    [SerializeField] protected bool stop = false;
    [SerializeField] protected bool spinning = true;
    private Quaternion initialRotation; 

    // Start is called before the first frame update
    void Start()
    {
        initialRotation = sniper.rotation; 
    }


    // Update is called once per frame
    void Update()
    {
        switch (stopAt)
        {
            case "1":
                speedmax = 854;
                break;
            case "2":
                speedmax = 856;
                break;
            case "3":
                speedmax = 858;
                break;
            case "4":
                speedmax = 859;
                break;
            case "5":
                speedmax = 860;
                break;
            case "6":
                speedmax = 859.1f;
                break;
            case "7":
                speedmax = 862;
                break;
            case "8":
                speedmax = 835;
                break;
            case "9":
                speedmax = 851;
                break;
            case "10":
                speedmax = 855;
                break;
            default:
                Debug.LogWarning("Invalid value for stopAt");
                break;
        }
    }
    private void FixedUpdate()
    {
        this.Spinning();
    }

    protected IEnumerator OnMouseDown()
    {
        sniper.rotation = initialRotation;
        yield return new WaitForSeconds(1);
        this.StartSpin();

    }

    protected virtual void StartSpin() 
    {
        this.speed = this.speedmax;
        this.spinning = true;
        this.stop = false;
    }

    protected void Spinning()
    {
        this.sniper.Rotate(0, Time.deltaTime * this.speed, 0);
        this.Stopping();
    }

    protected void Stopping()
    {
        if (!this.stop) return;
        if (this.stopAt == SpinnerMarker._instance.number.ToString()) this.spinning = false;
        if (this.spinning) return;
        
        this.speed -= this.speeddown;
        if (this.speed < 0) { 
            this.speed = 0;
        }
    }

}
