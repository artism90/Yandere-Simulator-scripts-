using System;
using UnityEngine;
using UnityScript.Lang;

// Token: 0x0200008C RID: 140
[Serializable]
public class EventManagerScript : MonoBehaviour
{
	// Token: 0x06000349 RID: 841 RVA: 0x0004570C File Offset: 0x0004390C
	public virtual void Start()
	{
		this.EventSubtitle.transform.localScale = new Vector3((float)0, (float)0, (float)0);
		this.InterruptZone.active = false;
		if (PlayerPrefs.GetInt("Weekday") == 1)
		{
			this.EventCheck = true;
		}
		this.NoteLocker.Prompt.enabled = true;
		this.NoteLocker.CanLeaveNote = true;
	}

	// Token: 0x0600034A RID: 842 RVA: 0x00045774 File Offset: 0x00043974
	public virtual void Update()
	{
		if (!this.Clock.StopTime && this.EventCheck)
		{
			if (this.EventStudent[1] == null)
			{
				this.EventStudent[1] = this.StudentManager.Students[6];
			}
			else if (this.EventStudent[1].Dead)
			{
				this.EventCheck = false;
				this.enabled = false;
			}
			if (this.EventStudent[2] == null)
			{
				this.EventStudent[2] = this.StudentManager.Students[7];
			}
			else if (this.EventStudent[2].Dead)
			{
				this.EventCheck = false;
				this.enabled = false;
			}
			if (this.Clock.HourTime > 13.01f && this.EventStudent[1] != null && this.EventStudent[2] != null && this.EventStudent[1].Pathfinding.canMove && this.EventStudent[1].Pathfinding.canMove)
			{
				this.EventStudent[1].CurrentDestination = this.EventLocation[1];
				this.EventStudent[1].Pathfinding.target = this.EventLocation[1];
				this.EventStudent[1].EventManager = this;
				this.EventStudent[1].InEvent = true;
				this.EventStudent[2].CurrentDestination = this.EventLocation[2];
				this.EventStudent[2].Pathfinding.target = this.EventLocation[2];
				this.EventStudent[2].EventManager = this;
				this.EventStudent[2].InEvent = true;
				this.EventCheck = false;
				this.EventOn = true;
			}
		}
		if (this.EventOn)
		{
			float num = Vector3.Distance(this.Yandere.transform.position, this.EventStudent[this.EventSpeaker[this.EventPhase]].transform.position);
			if (this.Clock.HourTime > 13.5f || this.EventStudent[1].WitnessedCorpse || this.EventStudent[2].WitnessedCorpse || this.EventStudent[1].Dying || this.EventStudent[2].Dying || this.EventStudent[2].Splashed)
			{
				this.EndEvent();
			}
			else
			{
				if (!this.EventStudent[1].Pathfinding.canMove && !this.EventStudent[1].Private)
				{
					this.EventStudent[1].Character.animation.CrossFade(this.EventStudent[1].IdleAnim);
					this.EventStudent[1].Private = true;
					this.StudentManager.UpdateStudents();
				}
				if (!this.EventStudent[2].Pathfinding.canMove && !this.EventStudent[2].Private)
				{
					this.EventStudent[2].Character.animation.CrossFade(this.EventStudent[2].IdleAnim);
					this.EventStudent[2].Private = true;
					this.StudentManager.UpdateStudents();
				}
				if (!this.EventStudent[1].Pathfinding.canMove && !this.EventStudent[2].Pathfinding.canMove)
				{
					if (!this.InterruptZone.active)
					{
						this.InterruptZone.active = true;
					}
					if (!this.Spoken)
					{
						this.EventStudent[this.EventSpeaker[this.EventPhase]].Character.animation.CrossFade(this.EventAnim[this.EventPhase]);
						if (num < (float)10)
						{
							this.EventSubtitle.text = this.EventSpeech[this.EventPhase];
						}
						this.PlayClip(this.EventClip[this.EventPhase], this.EventStudent[this.EventSpeaker[this.EventPhase]].transform.position + Vector3.up * 1.5f);
						this.Spoken = true;
					}
					else
					{
						if (this.Yandere.transform.position.z > (float)0)
						{
							this.Timer += Time.deltaTime;
							if (this.Timer > this.EventClip[this.EventPhase].length)
							{
								this.EventSubtitle.text = string.Empty;
							}
							if (this.Yandere.transform.position.y < this.EventStudent[1].transform.position.y - (float)1)
							{
								this.EventSubtitle.transform.localScale = new Vector3((float)0, (float)0, (float)0);
							}
							else if (num < (float)10)
							{
								this.Scale = Mathf.Abs((num - (float)10) * 0.2f);
								if (this.Scale < (float)0)
								{
									this.Scale = (float)0;
								}
								if (this.Scale > (float)1)
								{
									this.Scale = (float)1;
								}
								this.EventSubtitle.transform.localScale = new Vector3(this.Scale, this.Scale, this.Scale);
							}
							else
							{
								this.EventSubtitle.transform.localScale = new Vector3((float)0, (float)0, (float)0);
							}
							if (this.EventStudent[this.EventSpeaker[this.EventPhase]].Character.animation[this.EventAnim[this.EventPhase]].time >= this.EventStudent[this.EventSpeaker[this.EventPhase]].Character.animation[this.EventAnim[this.EventPhase]].length)
							{
								this.EventStudent[this.EventSpeaker[this.EventPhase]].Character.animation.CrossFade(this.EventStudent[this.EventSpeaker[this.EventPhase]].IdleAnim);
							}
							if (this.Timer > this.EventClip[this.EventPhase].length + (float)1)
							{
								this.Spoken = false;
								this.EventPhase++;
								this.Timer = (float)0;
								if (this.EventPhase == 4)
								{
									if (PlayerPrefs.GetInt("Topic_22_Discovered") == 0)
									{
										this.Yandere.NotificationManager.DisplayNotification("Topic");
										PlayerPrefs.SetInt("Topic_22_Discovered", 1);
									}
									if (PlayerPrefs.GetInt("Topic_22_Student_7_Learned") == 0)
									{
										this.Yandere.NotificationManager.DisplayNotification("Opinion");
										PlayerPrefs.SetInt("Topic_22_Student_7_Learned", 1);
									}
								}
								if (this.EventPhase == Extensions.get_length(this.EventSpeech))
								{
									this.EndEvent();
								}
							}
						}
						if (this.Yandere.transform.position.y > this.EventStudent[1].transform.position.y - (float)1 && this.EventPhase == 7 && num < (float)5 && PlayerPrefs.GetInt("Event1") == 0)
						{
							this.Yandere.NotificationManager.DisplayNotification("Info");
							PlayerPrefs.SetInt("Event1", 1);
						}
					}
				}
			}
		}
	}

	// Token: 0x0600034B RID: 843 RVA: 0x00045F00 File Offset: 0x00044100
	public virtual void PlayClip(AudioClip clip, Vector3 pos)
	{
		GameObject gameObject = new GameObject("TempAudio");
		gameObject.transform.position = pos;
		AudioSource audioSource = (AudioSource)gameObject.AddComponent(typeof(AudioSource));
		audioSource.clip = clip;
		audioSource.Play();
		UnityEngine.Object.Destroy(gameObject, clip.length);
		audioSource.rolloffMode = AudioRolloffMode.Linear;
		audioSource.minDistance = (float)5;
		audioSource.maxDistance = (float)10;
		this.VoiceClip = gameObject;
		if (this.Yandere.transform.position.y < gameObject.transform.position.y - (float)2)
		{
			audioSource.volume = (float)0;
		}
		else
		{
			audioSource.volume = (float)1;
		}
	}

	// Token: 0x0600034C RID: 844 RVA: 0x00045FBC File Offset: 0x000441BC
	public virtual void EndEvent()
	{
		if (this.VoiceClip != null)
		{
			UnityEngine.Object.Destroy(this.VoiceClip);
		}
		this.EventStudent[1].CurrentDestination = this.EventStudent[1].Destinations[this.EventStudent[1].Phase];
		this.EventStudent[1].Pathfinding.target = this.EventStudent[1].Destinations[this.EventStudent[1].Phase];
		this.EventStudent[1].EventManager = null;
		this.EventStudent[1].InEvent = false;
		this.EventStudent[1].Private = false;
		this.EventStudent[2].CurrentDestination = this.EventStudent[2].Destinations[this.EventStudent[2].Phase];
		this.EventStudent[2].Pathfinding.target = this.EventStudent[2].Destinations[this.EventStudent[2].Phase];
		this.EventStudent[2].EventManager = null;
		this.EventStudent[2].InEvent = false;
		this.EventStudent[2].Private = false;
		if (!this.StudentManager.Stop)
		{
			this.StudentManager.UpdateStudents();
		}
		this.InterruptZone.active = false;
		this.Yandere.Trespassing = false;
		this.EventSubtitle.text = string.Empty;
		this.EventCheck = false;
		this.EventOn = false;
	}

	// Token: 0x0600034D RID: 845 RVA: 0x00046134 File Offset: 0x00044334
	public virtual void Main()
	{
	}

	// Token: 0x0400084D RID: 2125
	public StudentManagerScript StudentManager;

	// Token: 0x0400084E RID: 2126
	public NoteLockerScript NoteLocker;

	// Token: 0x0400084F RID: 2127
	public UILabel EventSubtitle;

	// Token: 0x04000850 RID: 2128
	public YandereScript Yandere;

	// Token: 0x04000851 RID: 2129
	public ClockScript Clock;

	// Token: 0x04000852 RID: 2130
	public StudentScript[] EventStudent;

	// Token: 0x04000853 RID: 2131
	public Transform[] EventLocation;

	// Token: 0x04000854 RID: 2132
	public AudioClip[] EventClip;

	// Token: 0x04000855 RID: 2133
	public string[] EventSpeech;

	// Token: 0x04000856 RID: 2134
	public string[] EventAnim;

	// Token: 0x04000857 RID: 2135
	public int[] EventSpeaker;

	// Token: 0x04000858 RID: 2136
	public GameObject InterruptZone;

	// Token: 0x04000859 RID: 2137
	public GameObject VoiceClip;

	// Token: 0x0400085A RID: 2138
	public bool EventCheck;

	// Token: 0x0400085B RID: 2139
	public bool EventOn;

	// Token: 0x0400085C RID: 2140
	public bool Spoken;

	// Token: 0x0400085D RID: 2141
	public int EventPhase;

	// Token: 0x0400085E RID: 2142
	public float Timer;

	// Token: 0x0400085F RID: 2143
	public float Scale;
}
