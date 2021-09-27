using UnityEngine;

namespace FM.Legacy{
	public class LerpResult{
		public Vector3 result;
		public float timeThisFrame;
		public LerpResult(Vector3 _result, float _timeThisFrame){
			result = _result;
			timeThisFrame = _timeThisFrame;
		}

		public Vector3 Result(){
			return result;
		}

		public float TimeThisFrame(){
			return timeThisFrame;
		}

	}

	public class Utils {
		public static LerpResult ConstantLerp(Vector3 origin, Vector3 destination, float duration, float totalTimeElapsed){
			float xDuration = duration - totalTimeElapsed;
			float yDuration = duration - totalTimeElapsed;
			float zDuration = duration - totalTimeElapsed;
			float xDistance = origin.x - destination.x;
			float yDistance = origin.y - destination.y;
			float zDistance = origin.z - destination.z;

			float timeThisFrame = Time.deltaTime;
			float xThisFrame = xDistance * (1/xDuration) * timeThisFrame;
			float yThisFrame = yDistance * (1/yDuration) * timeThisFrame;
			float zThisFrame = zDistance * (1/zDuration) * timeThisFrame;

			Vector3 result = new Vector3(origin.x - xThisFrame, origin.y - yThisFrame, origin.z - zThisFrame);
			return new LerpResult(result, timeThisFrame);
		}

	}
}