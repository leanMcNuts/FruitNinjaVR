using System;
using UnityEngine;
namespace SpawningObjects
{
    public class CircularSpawner : MonoBehaviour
    {
        private float nextSpawnTime;
        private float radius = 10.0f;
        private float LaunchVelocity = 700f;
        //public float z;

        //this could throw a compiler error as readonly can only be set
        //once during the construction of the object?
        
        private float initlX;
        private float initlY;
        private float initlZ;

        [SerializeField]
        private GameObject itemToSpawn;
        [SerializeField]
        private float spawnDelay1 = 5;
            
        private void Update()
        {
            //z = UnityEngine.Random.Range(0, radius);

            if (ShouldSpawn())
            {
                Spawn();
            }

        }

        private float RandomizeZ()
        {
            return UnityEngine.Random.Range(0, radius);
        }

        private float RandomizeX(float z)
        {
            double a = System.Math.Sqrt(Math.Pow(radius, 2) - Math.Pow(z, 2));
            float x;
            x = (float)a;

            int negative = UnityEngine.Random.Range(-1, 1);

            if (negative == 0)
            {
                negative = 1;
            }

            x = x * negative;

            return x;
        }

        private float RandomizeY()
        {
            return UnityEngine.Random.Range(0, radius);
        }

        void Awake()
        {

            initlX = transform.position.x;
            initlY = transform.position.y;
            initlZ = transform.position.z;
        }

        private void Spawn()
        {
            
            nextSpawnTime = Time.time + spawnDelay1;

            float z = RandomizeZ();
            Vector3 positionVector = new Vector3(transform.position.x + RandomizeX(z), transform.position.y, transform.position.z + z);

            z = RandomizeZ();
            Vector3 positionVector2 = new Vector3(transform.position.x + RandomizeX(z), transform.position.y, transform.position.z + z);

            z = RandomizeZ();
            Vector3 positionVector3 = new Vector3(transform.position.x + RandomizeX(z), transform.position.y, transform.position.z + z);

            Rigidbody temp = object1.GetComponent<Rigidbody>();

            temp.velocity = new Vector3(0f, LaunchVelocity, 0f);

            positionVector.x += UnityEngine.Random.Range(-1f, 1f);
            temp.transform.position = positionVector;

            GameObject object1 = Instantiate(itemToSpawn, positionVector, transform.rotation);
            
             
            

            //object1.GetComponent<Rigidbody>().AddForce(positionVector, ForceMode.Impulse);
            //object1.GetComponent<Rigidbody>().AddRelativeForce(new Vector3(0, LaunchVelocity, 0));
            //GameObject object2 = Instantiate(itemToSpawn, positionVector2, transform.rotation);
            //GameObject object3 = Instantiate(itemToSpawn, positionVector3, transform.rotation);
        }

        private bool ShouldSpawn()
        {
            Debug.Log("Time: " + Time.time + " Next spawn time: " + nextSpawnTime);
            return Time.time >= nextSpawnTime;
        }



    }
}
