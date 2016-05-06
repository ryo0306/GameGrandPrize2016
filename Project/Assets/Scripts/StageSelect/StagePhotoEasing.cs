using UnityEngine;
using System.Collections;


    public class StagePhotoEasing : MonoBehaviour
    {

        [SerializeField, Tooltip("左端の最大")]
        public float _leftMax;
        [SerializeField, Tooltip("右端の最大")]
        public float _rightMax;


        //Easing処理用の時間
        float _animationTime;
        //スライドする距離
        public float _range;
        //現在slideしているかどうか
        public bool _slide;
        //スライドする方向
        private float _direction;
        
        //スライド時の最初の位置
        private float _startPos;

        void Start()
        {
            _animationTime = 0.0f;
            _startPos = transform.localPosition.x;
        }

        void Update()
        {

            if (_slide)
            {
                _animationTime += 0.01f * Time.deltaTime * 100;

                transform.localPosition = new Vector3(EasingCircInOut(_animationTime, _startPos, _startPos + _range * _direction), transform.localPosition.y, transform.localPosition.z);

                if (_animationTime >= 1.0f)
                {
                    _animationTime = 0.0f;
                    MoveLimit();
                    _startPos = transform.localPosition.x;
                    _slide = false;
                }
            }

        }

        //Easing関数
        private float EasingCircInOut(float t, float b, float e)
        {
            if ((t /= 0.5f) < 1) return -(e - b) / 2 * (Mathf.Sqrt(1 - t * t) - 1) + b;
            t -= 2;
            return (e - b) / 2 * (Mathf.Sqrt(1 - t * t) + 1) + b;
        }

        public void RightSlideOn()
        {
            _slide = true;
            _direction = 1.0f;
        }

        public void LeftSlideOn()
        {
            _slide = true;
            _direction = -1.0f;
        }

        private void MoveLimit()
        {
            if (transform.localPosition.x > _rightMax)
            transform.localPosition = new Vector3(_leftMax,transform.localPosition.y, transform.localPosition.z);

            if (transform.localPosition.x < _leftMax)
            transform.localPosition = new Vector3(_rightMax, transform.localPosition.y, transform.localPosition.z);
        }
    }
