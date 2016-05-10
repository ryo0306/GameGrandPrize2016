using UnityEngine;
using System.Collections;


    public class StagePhotoEasing : MonoBehaviour
    {
    [SerializeField, Tooltip("StagePhotoの状態")]
    private GameObject _stagePhotoStatus = null;
        [SerializeField, Tooltip("左端の最大")]
        public float _leftMax;
        [SerializeField, Tooltip("右端の最大")]
        public float _rightMax;
        [SerializeField, Tooltip("ステージセレクトの情報")]
        private GameObject _selectStage = null;

        //Easing処理用の時間
        
        //スライドする距離
        public float _range;
        
        //スライド時の最初の位置
        private float _startPos;

        void Start()
        {
            _startPos = transform.localPosition.x;
        }

        void Update()
        {

        if (_stagePhotoStatus.GetComponent<StagePhotoStatus>().Slide)
        {

            transform.localPosition = new Vector3(EasingCircInOut(_stagePhotoStatus.GetComponent<StagePhotoStatus>().EaseTime,
                                                                  _startPos, _startPos + _range * _stagePhotoStatus.GetComponent<StagePhotoStatus>().Direction),
                                                                  transform.localPosition.y, transform.localPosition.z);

        }
             if (_stagePhotoStatus.GetComponent<StagePhotoStatus>().EaseTime < 1.0f) return;
                 
             MoveLimit();
             _startPos = transform.localPosition.x;
             _stagePhotoStatus.GetComponent<StagePhotoStatus>().Slide = false;
                
            

        }

        //Easing関数
        private float EasingCircInOut(float t, float b, float e)
        {
            if ((t /= 0.5f) < 1) return -(e - b) / 2 * (Mathf.Sqrt(1 - t * t) - 1) + b;
            t -= 2;
            return (e - b) / 2 * (Mathf.Sqrt(1 - t * t) + 1) + b;
        }

        private void MoveLimit()
        {
            if (transform.localPosition.x > _rightMax)
            transform.localPosition = new Vector3(_leftMax,transform.localPosition.y, transform.localPosition.z);

            if (transform.localPosition.x < _leftMax)
            transform.localPosition = new Vector3(_rightMax, transform.localPosition.y, transform.localPosition.z);
        }
    }
