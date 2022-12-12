using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class HealthSystem : MonoBehaviour
{
    // We write to tell Unity to lose our data when we rename a variable, this was its old name
    [FormerlySerializedAs("health")] 
    public float maxHealth;
    public GameObject healthBarPrefab;

    // Private variables
    float currentHealth;

    HealthBar myHealthBar;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        // Create health panel on the canvas
        GameObject healthBarObject = Instantiate(healthBarPrefab, References.canvas.transform);
        myHealthBar = healthBarObject.GetComponent<HealthBar>();

    }

    // Update is called once per frame
    void Update()
    {
        // Make our healthbar reflect our health
        myHealthBar.ShowHealthFraction(currentHealth / maxHealth);

        // Make our healthbar follow us
        myHealthBar.transform.position = Camera.main.WorldToScreenPoint(transform.position + Vector3.up * 2);
    }
    #region Methods
    // We should be able to call the method out of the script
    public void TakeDamage(float damageAmount)
    {
        currentHealth -= damageAmount;
        if (currentHealth <= 0)
        {
            Destroy(gameObject);
        }
    }

    private void OnDestroy() 
    {
        if (myHealthBar != null) 
        {
            Destroy(myHealthBar.gameObject);    
        }
    }
    #endregion
}
