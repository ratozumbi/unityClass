
    using System;
    using UnityEngine;
[RequireComponent(typeof(SpriteRenderer))]
    public class ArmaBase: MonoBehaviour
    {
        private SpriteRenderer myRender;
        public ScriptableGun attribs;

        private void Start()
        {
            myRender = GetComponent<SpriteRenderer>();
            myRender.sprite = attribs.imgArma;
        }

        private void Update()
        {
            float flip = transform.parent.localScale.x;

            Vector3 diff = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
            diff.Normalize();

            if (flip == -1)
            {
                diff.x = -diff.x;
                diff.y = -diff.y;
            }

            float rot_z = Mathf.Atan2(diff.y, diff.x) * Mathf.Rad2Deg;

            print(rot_z);

            if (rot_z <= attribs.angulo && rot_z >= -attribs.angulo)
            {
                transform.rotation = Quaternion.Euler(0f, 0f, rot_z);
            }
        }
    }
