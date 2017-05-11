using UnityEngine;
using Vuforia;


public class MarkerDetectionScript : MonoBehaviour,	ITrackableEventHandler {
		
	private TrackableBehaviour mTrackableBehaviour;
	bool markerFound = false;
		
	void Start()
	{
		mTrackableBehaviour = GetComponent<TrackableBehaviour>();
		if (mTrackableBehaviour)
		{
			mTrackableBehaviour.RegisterTrackableEventHandler(this);
		}
	}


	public void OnTrackableStateChanged( TrackableBehaviour.Status previousStatus,
										 TrackableBehaviour.Status newStatus)
	{
		if (newStatus == TrackableBehaviour.Status.DETECTED ||
			newStatus == TrackableBehaviour.Status.TRACKED ||
			newStatus == TrackableBehaviour.Status.EXTENDED_TRACKED)
		{
			OnTrackingFound();
		}
		else
		{
			OnTrackingLost();
		}
	}


	private void OnTrackingFound()
	{
		//Debug.Log("Marker found!!!");
		markerFound = true;	
	}


	private void OnTrackingLost()
	{
		//Debug.Log("Marker lost!!!");
		markerFound = false;
	}

	public bool markerDetected()
	{
		return markerFound;
	}

}
