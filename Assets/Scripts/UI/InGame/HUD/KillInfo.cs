using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.UI.InGame.HUD
{
    public class KillInfo : MonoBehaviour
    {
        private float alpha = 1f;
        private int col;
        public Text KillerLabel;
        public Text DamageLabel;
        public Text VictimLabel;
        private float lifeTime = 8f;
        private float maxScale = 1.5f;
        private int offset = 24;
        private bool start;
        private float timeElapsed;

        public void Destroy()
        {
            timeElapsed = lifeTime;
        }

        public void MoveOn()
        {
            col++;
            if (col > 4)
            {
                timeElapsed = lifeTime;
            }
        }

        public void Show(bool isTitan1, string name1, bool isTitan2, string name2, int dmg = 0)
        {

            //if (!isTitan1)
            //{
            //    Transform transform = KillerLabel.transform;
            //    transform.position += new Vector3(18f, 0f, 0f);
            //}
            //else
            //{
            //    Transform transform3 = VictimLabel.transform;
            //    transform3.position -= new Vector3(18f, 0f, 0f);
            //}

            KillerLabel.text = name1;
            VictimLabel.text = name2;

            if (dmg == 0)
            {
                DamageLabel.text = "";
            }
            else
            {
                DamageLabel.text = dmg.ToString();
                if (dmg >= 1000)
                {
                    DamageLabel.color = Color.red;
                }
            }
        }

        private void Start()
        {

            start = true;
            transform.localScale = new Vector3(0.85f, 0.85f, 0.85f);
            transform.localPosition = new Vector3(0f, -100f + (Screen.currentResolution.height * 0.5f), 0f);
        }

        private void Update()
        {
            if (start)
            {
                timeElapsed += Time.deltaTime;
                if (timeElapsed < 0.2f)
                {
                    transform.localScale = Vector3.Lerp(transform.localScale, Vector3.one * maxScale, Time.deltaTime * 10f);
                }
                else if (timeElapsed < 1f)
                {
                    transform.localScale = Vector3.Lerp(transform.localScale, Vector3.one, Time.deltaTime * 10f);
                }
                if (timeElapsed > lifeTime)
                {
                    transform.position += new Vector3(0f, Time.deltaTime * 0.15f, 0f);
                    alpha = ((1f - (Time.deltaTime * 45f)) + lifeTime) - timeElapsed;
                }
                else
                {
                    float num = ((int)(100f - (Screen.currentResolution.height * 0.5f))) + (col * offset);
                    transform.localPosition = Vector3.Lerp(transform.localPosition, new Vector3(0f, -num, 0f), Time.deltaTime * 10f);
                }
                if (timeElapsed > (lifeTime + 0.5f))
                {
                    Destroy(gameObject);
                }
            }
        }
    }


}
