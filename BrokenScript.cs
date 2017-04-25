using System;
using UnityEngine;
using UnityScript.Lang;

// Token: 0x02000053 RID: 83
[Serializable]
public class BrokenScript : MonoBehaviour
{
	// Token: 0x06000227 RID: 551 RVA: 0x00027180 File Offset: 0x00025380
	public BrokenScript()
	{
		this.ID = 1;
	}

	// Token: 0x06000228 RID: 552 RVA: 0x00027190 File Offset: 0x00025390
	public virtual void Start()
	{
		this.HairPhysics[0].enabled = false;
		this.HairPhysics[1].enabled = false;
		this.PermanentAngleR = this.TwintailR.eulerAngles;
		this.PermanentAngleL = this.TwintailL.eulerAngles;
		this.Subtitle = (UILabel)GameObject.Find("EventSubtitle").GetComponent(typeof(UILabel));
		this.Yandere = GameObject.Find("YandereChan");
	}

	// Token: 0x06000229 RID: 553 RVA: 0x00027210 File Offset: 0x00025410
	public virtual void Update()
	{
		if (!this.Done)
		{
			float num = Vector3.Distance(this.Yandere.transform.position, this.transform.root.position);
			if (num < (float)5)
			{
				if (!this.Hunting)
				{
					this.Timer += Time.deltaTime;
					if (this.VoiceClip == null)
					{
						this.Subtitle.text = string.Empty;
					}
					if (this.Timer > (float)5)
					{
						this.Timer = (float)0;
						this.Subtitle.text = this.MutterTexts[this.ID];
						this.PlayClip(this.Mutters[this.ID], this.transform.position);
						this.ID++;
						if (this.ID == Extensions.get_length(this.Mutters))
						{
							this.ID = 1;
						}
					}
				}
				else if (!this.Began)
				{
					if (this.VoiceClip != null)
					{
						UnityEngine.Object.Destroy(this.VoiceClip);
					}
					this.Subtitle.text = "Do it.";
					this.PlayClip(this.DoIt, this.transform.position);
					this.Began = true;
				}
				else if (this.VoiceClip == null)
				{
					this.Subtitle.text = "...kill...kill...kill...";
					this.PlayClip(this.KillKillKill, this.transform.position);
				}
				float num2 = Mathf.Abs((num - (float)5) * 0.2f);
				if (num2 < (float)0)
				{
					num2 = (float)0;
				}
				if (num2 > (float)1)
				{
					num2 = (float)1;
				}
				this.Subtitle.transform.localScale = new Vector3(num2, num2, num2);
			}
			else
			{
				this.Subtitle.transform.localScale = new Vector3((float)0, (float)0, (float)0);
			}
		}
		float x = this.PermanentAngleR.x;
		Vector3 eulerAngles = this.TwintailR.eulerAngles;
		float num3 = eulerAngles.x = x;
		Vector3 vector = this.TwintailR.eulerAngles = eulerAngles;
		float x2 = this.PermanentAngleL.x;
		Vector3 eulerAngles2 = this.TwintailL.eulerAngles;
		float num4 = eulerAngles2.x = x2;
		Vector3 vector2 = this.TwintailL.eulerAngles = eulerAngles2;
		float z = this.PermanentAngleR.z;
		Vector3 eulerAngles3 = this.TwintailR.eulerAngles;
		float num5 = eulerAngles3.z = z;
		Vector3 vector3 = this.TwintailR.eulerAngles = eulerAngles3;
		float z2 = this.PermanentAngleL.z;
		Vector3 eulerAngles4 = this.TwintailL.eulerAngles;
		float num6 = eulerAngles4.z = z2;
		Vector3 vector4 = this.TwintailL.eulerAngles = eulerAngles4;
	}

	// Token: 0x0600022A RID: 554 RVA: 0x000274FC File Offset: 0x000256FC
	public virtual void PlayClip(AudioClip clip, Vector3 pos)
	{
		GameObject gameObject = new GameObject("TempAudio");
		gameObject.transform.position = pos;
		gameObject.transform.parent = this.transform;
		AudioSource audioSource = (AudioSource)gameObject.AddComponent(typeof(AudioSource));
		audioSource.clip = clip;
		audioSource.Play();
		UnityEngine.Object.Destroy(gameObject, clip.length);
		audioSource.rolloffMode = AudioRolloffMode.Linear;
		audioSource.minDistance = (float)1;
		audioSource.maxDistance = (float)5;
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

	// Token: 0x0600022B RID: 555 RVA: 0x000275C8 File Offset: 0x000257C8
	public virtual void Main()
	{
	}

	// Token: 0x04000489 RID: 1161
	public DynamicBone[] HairPhysics;

	// Token: 0x0400048A RID: 1162
	public string[] MutterTexts;

	// Token: 0x0400048B RID: 1163
	public AudioClip[] Mutters;

	// Token: 0x0400048C RID: 1164
	public Vector3 PermanentAngleR;

	// Token: 0x0400048D RID: 1165
	public Vector3 PermanentAngleL;

	// Token: 0x0400048E RID: 1166
	public Transform TwintailR;

	// Token: 0x0400048F RID: 1167
	public Transform TwintailL;

	// Token: 0x04000490 RID: 1168
	public AudioClip KillKillKill;

	// Token: 0x04000491 RID: 1169
	public AudioClip Stab;

	// Token: 0x04000492 RID: 1170
	public AudioClip DoIt;

	// Token: 0x04000493 RID: 1171
	public GameObject VoiceClip;

	// Token: 0x04000494 RID: 1172
	public GameObject Yandere;

	// Token: 0x04000495 RID: 1173
	public UILabel Subtitle;

	// Token: 0x04000496 RID: 1174
	public bool Hunting;

	// Token: 0x04000497 RID: 1175
	public bool Stabbed;

	// Token: 0x04000498 RID: 1176
	public bool Began;

	// Token: 0x04000499 RID: 1177
	public bool Done;

	// Token: 0x0400049A RID: 1178
	public float SuicideTimer;

	// Token: 0x0400049B RID: 1179
	public float Timer;

	// Token: 0x0400049C RID: 1180
	public int ID;
}
