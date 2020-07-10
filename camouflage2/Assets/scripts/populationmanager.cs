using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class populationmanager : MonoBehaviour
{
    public GameObject personprefab;
    public int populationsize = 10;
    public float trialtime = 5f;
    List<GameObject> population = new List<GameObject>();
    public static  float elapsed = 0;
    int generation = 0;
    GUIStyle guistyle = new GUIStyle();

    // Start is called before the first frame update
    void Start()
    {
        for(int i=0;i<populationsize;i++)
        {
            Vector3 pos = new Vector3(Random.Range(-7.65f,3.08f), Random.Range(-3.19f,5.25f), 0f);
            GameObject newp = Instantiate(personprefab, pos, Quaternion.identity);
            newp.GetComponent<DNA>().r = Random.Range(0f, 1f);
            newp.GetComponent<DNA>().g = Random.Range(0f, 1f);
            newp.GetComponent<DNA>().b = Random.Range(0f, 1f);
            population.Add(newp);

        }
        
    }
    
    void breednewpopultion()
    {
        List<GameObject> newpopulation = new List<GameObject>();
        List<GameObject> sortedList = population.OrderBy(n => n.GetComponent<DNA>().timetodie).ToList();//ARRANGED THE POPULTION IN ORDER OF CLICKING
        population.Clear();
        print("heief" + sortedList.Count/2.0f);
        for (int i = (int)(sortedList.Count / 2.0f)-1; i < (sortedList.Count)-1;i++)
        {
            population.Add(breed(sortedList[i],sortedList[i+1]));
            population.Add(breed(sortedList[i],sortedList[i+1]));
        }

        for(int i=0;i<sortedList.Count;i++)
        {
            Destroy(sortedList[i]);
        }
        generation++;
    }

    GameObject breed(GameObject parent1,GameObject parent2)
    {

        Vector3 position= new Vector3(Random.Range(-7.65f, 3.08f), Random.Range(-3.19f, 5.25f), 0f);
        GameObject newp = Instantiate(personprefab, position, Quaternion.identity);
        if (Random.Range(0, 300) > 5)
        {
            newp.GetComponent<DNA>().r = Random.Range(0, 10) > 5 ? parent1.GetComponent<DNA>().r : parent2.GetComponent<DNA>().r;
            newp.GetComponent<DNA>().g = Random.Range(0, 10) > 5 ? parent1.GetComponent<DNA>().g : parent2.GetComponent<DNA>().g;
            newp.GetComponent<DNA>().b = Random.Range(0, 10) > 5 ? parent1.GetComponent<DNA>().b : parent2.GetComponent<DNA>().b;
        }

        else

        {
            newp.GetComponent<DNA>().r = Random.Range(0.0f, 1.0f);
            newp.GetComponent<DNA>().g = Random.Range(0.0f, 1.0f);
            newp.GetComponent<DNA>().b = Random.Range(0.0f, 1.0f);
        }


        return newp;
    }

    // Update is called once per frame
    void Update()
    {
        elapsed += Time.deltaTime;
        
        if(elapsed>=trialtime)
        {
            breednewpopultion();
            elapsed = 0;
            
        }
    }

    private void OnGUI()
    {
        guistyle.fontSize = 50;
        guistyle.normal.textColor = Color.red;
        GUI.Label(new Rect(10, 10, 100, 20), "Generation:" + generation, guistyle);
        GUI.Label(new Rect(10, 65, 100, 20), "trialtime:" + elapsed, guistyle);

    }
}
