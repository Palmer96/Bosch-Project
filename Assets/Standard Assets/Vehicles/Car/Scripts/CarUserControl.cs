using System;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


namespace UnityStandardAssets.Vehicles.Car
{
    [RequireComponent(typeof(CarController))]
    public class CarUserControl : MonoBehaviour
    {
        private CarController m_Car; // the car controller we want to use

        bool techOn;

        public bool disabled;
        public GameObject text;

        public GameObject cart;

        public Text textScore;
        public Text textHighScore;

        int score;

        Rigidbody rb;



        private void Awake()
        {
            // get the car controller
            m_Car = GetComponent<CarController>();
            rb = GetComponent<Rigidbody>();

            textScore.text = "Score: " + 0.ToString();
            textHighScore.text = "Highscore: " + PlayerPrefs.GetInt("Highscore").ToString();


        }


        private void FixedUpdate()
        {
            if (Input.GetKeyDown(KeyCode.Alpha0))
            {
                PlayerPrefs.SetInt("Highscore", 0);
            }


            textScore.text = "Score: " + score.ToString();


            if (transform.position.z > PlayerPrefs.GetInt("Highscore"))
                textHighScore.text = "Highscore: " + score.ToString();
            else
                textHighScore.text = "Highscore: " + PlayerPrefs.GetInt("Highscore").ToString();

            if (disabled)
            {
                if (Input.GetKeyDown(KeyCode.R))
                    Enable();
            }
            else
                score = (int)transform.position.z;


            if (disabled)
                return;

            // if (!    (transform.eulerAngles.z > -1 && transform.eulerAngles.z < 1)   )
            if (transform.up.y <= 0)
            {
                // Debug.Log("Hit: " + transform.eulerAngles.z);
                Disable();
            }


            // pass the input to the car!
            float h = CrossPlatformInputManager.GetAxis("Horizontal");
            float v = CrossPlatformInputManager.GetAxis("Vertical");
#if !MOBILE_INPUT
            float handbrake = CrossPlatformInputManager.GetAxis("Jump");
            m_Car.Move(h, v, v, handbrake);
#else
            m_Car.Move(h, v, v, 0f);
#endif
        }


        void OnCollisionEnter(Collision col)
        {
            if (col.transform.CompareTag("Wall"))
            {

                foreach (ContactPoint contact in col.contacts)
                {
                    if (!disabled)
                    {
                        Debug.DrawRay(contact.point, contact.normal, Color.white);
                        Disable(contact.point);
                    }
                }
            }
        }

        void Disable()
        {

            disabled = true;
            text.SetActive(true);

            Destroy(transform.GetChild(0).gameObject);

            m_Car.Move(0, 0, 0, 0);

            if (transform.position.z > PlayerPrefs.GetInt("Highscore"))
                PlayerPrefs.SetInt("Highscore", (int)transform.position.z);
        }

        void Disable(Vector3 col)
        {

            disabled = true;
            text.SetActive(true);

            Destroy(transform.GetChild(0).gameObject);
            //Destroy(cart.GetComponent<Rigidbody>());
            //Destroy(cart.GetComponent<Rigidbody>());
            m_Car.Move(0, 0, 0, 0);
            // Destroy(cart.GetComponent<Rigidbody>());
            if (transform.position.z > PlayerPrefs.GetInt("Highscore"))
                PlayerPrefs.SetInt("Highscore", (int)transform.position.z);
            GetComponent<Rigidbody>().AddForce((col - transform.position) * 5000, ForceMode.Impulse);


        }

        void Enable()
        {
            disabled = false;
            text.SetActive(false);


       //     if (transform.position.z > PlayerPrefs.GetInt("Highscore"))
       //         PlayerPrefs.SetInt("Highscore", (int)transform.position.z);

            SceneManager.LoadScene(0);
        }

        public void UseTech()
        {
            techOn = techOn ? false : true;
            float mass = techOn ? 0 : 1;

            m_Car.m_CentreOfMassOffset = new Vector3(0, mass, 0);


        }
    }
}
