using UnityEngine;

public class SaiBehaviour : MonoBehaviour
{
    protected virtual void Reset()
    {
        this.LoadComponents();
    }

    protected virtual void Awake()
    {
        this.LoadComponents();
    }

    protected virtual void Start()
    {
        //For overide
    }

    protected virtual void LoadComponents()
    {
        //For overide
    }

    public virtual void SetActive(bool status)
    {
        gameObject.SetActive(status);
    }
}
