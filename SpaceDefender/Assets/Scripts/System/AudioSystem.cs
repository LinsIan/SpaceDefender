//*******************************************
// Class Sample
//*******************************************
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//*******************************************
// Class
//*******************************************
public class AudioSystem : Singleton<AudioSystem>
{
	//------------------------------------------------------
	// Constants
	//------------------------------------------------------
	private const float DEFAULT_SESOURCEQUEUE_COUNT = 10;

	//------------------------------------------------------
	// Variables
	//------------------------------------------------------
	private AudioSource        mBGMSource;
	private Queue<AudioSource> mUnusedSESourceQueue;
	private List<AudioSource>  mSESourceList;
	private bool               mIsBGMEnabled;
	private bool               mIsSEEnabled;


	//------------------------------------------------------
	// Override Functions
	//------------------------------------------------------
	public override void Initialize()
	{
		mBGMSource           = gameObject.AddComponent<AudioSource>();
		mUnusedSESourceQueue = new Queue<AudioSource>();
		mSESourceList        = new List<AudioSource>();
		for(int i=0; i<DEFAULT_SESOURCEQUEUE_COUNT; ++i)
		{
			AudioSource aNewSource = gameObject.AddComponent<AudioSource>();
			mUnusedSESourceQueue.Enqueue(aNewSource);
			mSESourceList .Add(aNewSource);
		}
	}

	//------------------------------------------------------
	// Main Functions
	//------------------------------------------------------
	public void PlayBGM(AudioClip iBGM)
	{
		if(!mIsBGMEnabled) { return; }
		mBGMSource.clip = iBGM;
		mBGMSource.loop = true;
		mBGMSource.Play();
	}

	public void StopBGM()
	{
		mBGMSource.Stop();
	}

	public void PlaySE(AudioClip iSE)
	{
		if(!mIsSEEnabled) { return; }
		AudioSource aNewSE;
		if(mUnusedSESourceQueue.Count == 0)
		{
			aNewSE = gameObject.AddComponent<AudioSource>();
			mSESourceList.Add(aNewSE);
		}
		else
		{
			aNewSE = mUnusedSESourceQueue.Dequeue();
		}
		aNewSE.clip = iSE;
		aNewSE.loop = false;
		StartCoroutine(BackToQueue(aNewSE));
		aNewSE.Play();
	}
	
	public void SetBGMIsEnabled(bool iEnabled)
	{
		mIsBGMEnabled = iEnabled;
		if(!iEnabled)
		{
			mBGMSource.volume = 0;
		}
		else
		{
			mBGMSource.volume = 1;
		}
	}

	public void SetSEIsEnabled(bool iEnabled)
	{
		mIsSEEnabled = iEnabled;
		float aVolume;
		if(!iEnabled)
		{
			aVolume = 0;
		}
		else
		{
			aVolume = 1;
		}
		
		for(int i=0; i<mSESourceList.Count; ++i)
		{
			mSESourceList[i].volume = aVolume;
		}
	}
	
	private IEnumerator BackToQueue(AudioSource iSESource)
	{
		if(iSESource)
		{
			yield return new WaitForSeconds(iSESource.clip.length);
			mUnusedSESourceQueue.Enqueue(iSESource);
		}
	}

}