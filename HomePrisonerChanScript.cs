using System;
using UnityEngine;

// Token: 0x020000B7 RID: 183
[Serializable]
public class HomePrisonerChanScript : MonoBehaviour
{
	// Token: 0x060003F8 RID: 1016 RVA: 0x0004FB50 File Offset: 0x0004DD50
	public virtual void Start()
	{
		if (PlayerPrefs.GetInt("KidnapVictim") > 0)
		{
			this.PermanentAngleR = this.TwintailR.eulerAngles;
			this.PermanentAngleL = this.TwintailL.eulerAngles;
			this.StudentID = PlayerPrefs.GetInt("KidnapVictim");
			if (PlayerPrefs.GetInt("Student_" + this.StudentID + "_Arrested") == 0 && PlayerPrefs.GetInt("Student_" + this.StudentID + "_Dead") == 0)
			{
				this.Cosmetic.StudentID = this.StudentID;
				this.Cosmetic.enabled = true;
				this.BreastSize = this.JSON.StudentBreasts[this.StudentID];
				this.RightEyeRotOrigin = this.RightEye.localEulerAngles;
				this.LeftEyeRotOrigin = this.LeftEye.localEulerAngles;
				this.RightEyeOrigin = this.RightEye.localPosition;
				this.LeftEyeOrigin = this.LeftEye.localPosition;
				this.UpdateSanity();
				this.TwintailR.transform.localEulerAngles = new Vector3((float)0, (float)180, (float)-90);
				this.TwintailL.transform.localEulerAngles = new Vector3((float)0, (float)0, (float)-90);
				this.Blindfold.active = false;
				this.Tripod.active = false;
				if (this.StudentID == 32 && PlayerPrefs.GetInt("Scheme_6_Stage") > 4)
				{
					this.Blindfold.active = true;
					this.Tripod.active = true;
				}
			}
			else
			{
				PlayerPrefs.SetInt("KidnapVictim", 0);
				this.active = false;
			}
		}
		else
		{
			this.active = false;
		}
	}

	// Token: 0x060003F9 RID: 1017 RVA: 0x0004FD1C File Offset: 0x0004DF1C
	public virtual void LateUpdate()
	{
		this.Skirt.transform.localPosition = new Vector3((float)0, -0.135f, 0.01f);
		float y = 1.2f;
		Vector3 localScale = this.Skirt.transform.localScale;
		float num = localScale.y = y;
		Vector3 vector = this.Skirt.transform.localScale = localScale;
		if (!this.Tortured)
		{
			if (this.Sanity > (float)0)
			{
				if (this.LookAhead)
				{
					float x = this.Neck.localEulerAngles.x - (float)45;
					Vector3 localEulerAngles = this.Neck.localEulerAngles;
					float num2 = localEulerAngles.x = x;
					Vector3 vector2 = this.Neck.localEulerAngles = localEulerAngles;
				}
				else if (this.YandereDetector.YandereDetected && Vector3.Distance(this.transform.position, this.HomeYandere.position) < (float)2)
				{
					Quaternion to;
					if (this.HomeCamera.Target == this.HomeCamera.Targets[10])
					{
						to = Quaternion.LookRotation(this.HomeCamera.transform.position + Vector3.down * 1.5f * ((float)100 - this.Sanity) / (float)100 - this.Neck.position);
						this.HairRotation = Mathf.Lerp(this.HairRotation, (float)0, Time.deltaTime * (float)2);
					}
					else
					{
						to = Quaternion.LookRotation(this.HomeYandere.position + Vector3.up * 1.5f - this.Neck.position);
						this.HairRotation = Mathf.Lerp(this.HairRotation, (float)45, Time.deltaTime * (float)2);
					}
					this.Neck.rotation = Quaternion.Slerp(this.LastRotation, to, Time.deltaTime * (float)2);
					this.TwintailR.transform.localEulerAngles = new Vector3((float)0, (float)180, (float)-90 - this.HairRotation);
					this.TwintailL.transform.localEulerAngles = new Vector3((float)0, (float)0, (float)-90 - this.HairRotation);
				}
				else
				{
					if (this.HomeCamera.Target == this.HomeCamera.Targets[10])
					{
						Quaternion to = Quaternion.LookRotation(this.HomeCamera.transform.position + Vector3.down * 1.5f * ((float)100 - this.Sanity) / (float)100 - this.Neck.position);
						this.HairRotation = Mathf.Lerp(this.HairRotation, (float)0, Time.deltaTime * (float)2);
					}
					else
					{
						Quaternion to = Quaternion.LookRotation(this.transform.position + this.transform.forward - this.Neck.position);
						this.Neck.rotation = Quaternion.Slerp(this.LastRotation, to, Time.deltaTime * (float)2);
					}
					this.HairRotation = Mathf.Lerp(this.HairRotation, (float)0, Time.deltaTime * (float)2);
					this.TwintailR.transform.localEulerAngles = new Vector3((float)0, (float)180, (float)-90 - this.HairRotation);
					this.TwintailL.transform.localEulerAngles = new Vector3((float)0, (float)0, (float)-90 - this.HairRotation);
				}
			}
			else
			{
				float x2 = this.Neck.localEulerAngles.x - (float)45;
				Vector3 localEulerAngles2 = this.Neck.localEulerAngles;
				float num3 = localEulerAngles2.x = x2;
				Vector3 vector3 = this.Neck.localEulerAngles = localEulerAngles2;
			}
		}
		this.LastRotation = this.Neck.rotation;
		if (!this.Tortured && this.Sanity < (float)100 && this.Sanity > (float)0)
		{
			this.TwitchTimer += Time.deltaTime;
			if (this.TwitchTimer > this.NextTwitch)
			{
				this.Twitch.x = ((float)1 - this.Sanity / (float)100) * UnityEngine.Random.Range(-10f, 10f);
				this.Twitch.y = ((float)1 - this.Sanity / (float)100) * UnityEngine.Random.Range(-10f, 10f);
				this.Twitch.z = ((float)1 - this.Sanity / (float)100) * UnityEngine.Random.Range(-10f, 10f);
				this.NextTwitch = UnityEngine.Random.Range((float)0, 1f);
				this.TwitchTimer = (float)0;
			}
			this.Twitch = Vector3.Lerp(this.Twitch, new Vector3((float)0, (float)0, (float)0), Time.deltaTime * (float)10);
			this.Neck.localEulerAngles = this.Neck.localEulerAngles + this.Twitch;
		}
		if (this.Tortured)
		{
			this.HairRotation = Mathf.Lerp(this.HairRotation, (float)45, Time.deltaTime * (float)2);
			this.TwintailR.transform.localEulerAngles = new Vector3((float)0, (float)180, (float)-90 - this.HairRotation);
			this.TwintailL.transform.localEulerAngles = new Vector3((float)0, (float)0, (float)-90 - this.HairRotation);
		}
	}

	// Token: 0x060003FA RID: 1018 RVA: 0x000502C8 File Offset: 0x0004E4C8
	public virtual void UpdateSanity()
	{
		this.Sanity = PlayerPrefs.GetFloat("Student_" + this.StudentID + "_Sanity");
		if (this.Sanity == (float)0)
		{
			this.RightMindbrokenEye.active = true;
			this.LeftMindbrokenEye.active = true;
		}
		else
		{
			this.RightMindbrokenEye.active = false;
			this.LeftMindbrokenEye.active = false;
		}
	}

	// Token: 0x060003FB RID: 1019 RVA: 0x00050344 File Offset: 0x0004E544
	public virtual void Main()
	{
	}

	// Token: 0x040009F7 RID: 2551
	public HomeYandereDetectorScript YandereDetector;

	// Token: 0x040009F8 RID: 2552
	public HomeCameraScript HomeCamera;

	// Token: 0x040009F9 RID: 2553
	public CosmeticScript Cosmetic;

	// Token: 0x040009FA RID: 2554
	public JsonScript JSON;

	// Token: 0x040009FB RID: 2555
	public Vector3 RightEyeRotOrigin;

	// Token: 0x040009FC RID: 2556
	public Vector3 LeftEyeRotOrigin;

	// Token: 0x040009FD RID: 2557
	public Vector3 PermanentAngleR;

	// Token: 0x040009FE RID: 2558
	public Vector3 PermanentAngleL;

	// Token: 0x040009FF RID: 2559
	public Vector3 RightEyeOrigin;

	// Token: 0x04000A00 RID: 2560
	public Vector3 LeftEyeOrigin;

	// Token: 0x04000A01 RID: 2561
	public Vector3 Twitch;

	// Token: 0x04000A02 RID: 2562
	public Quaternion LastRotation;

	// Token: 0x04000A03 RID: 2563
	public Transform HomeYandere;

	// Token: 0x04000A04 RID: 2564
	public Transform RightBreast;

	// Token: 0x04000A05 RID: 2565
	public Transform LeftBreast;

	// Token: 0x04000A06 RID: 2566
	public Transform TwintailR;

	// Token: 0x04000A07 RID: 2567
	public Transform TwintailL;

	// Token: 0x04000A08 RID: 2568
	public Transform RightEye;

	// Token: 0x04000A09 RID: 2569
	public Transform LeftEye;

	// Token: 0x04000A0A RID: 2570
	public Transform Skirt;

	// Token: 0x04000A0B RID: 2571
	public Transform Neck;

	// Token: 0x04000A0C RID: 2572
	public GameObject RightMindbrokenEye;

	// Token: 0x04000A0D RID: 2573
	public GameObject LeftMindbrokenEye;

	// Token: 0x04000A0E RID: 2574
	public GameObject Blindfold;

	// Token: 0x04000A0F RID: 2575
	public GameObject Character;

	// Token: 0x04000A10 RID: 2576
	public GameObject Tripod;

	// Token: 0x04000A11 RID: 2577
	public float HairRotation;

	// Token: 0x04000A12 RID: 2578
	public float TwitchTimer;

	// Token: 0x04000A13 RID: 2579
	public float NextTwitch;

	// Token: 0x04000A14 RID: 2580
	public float BreastSize;

	// Token: 0x04000A15 RID: 2581
	public float EyeShrink;

	// Token: 0x04000A16 RID: 2582
	public float Sanity;

	// Token: 0x04000A17 RID: 2583
	public bool LookAhead;

	// Token: 0x04000A18 RID: 2584
	public bool Tortured;

	// Token: 0x04000A19 RID: 2585
	public bool Male;

	// Token: 0x04000A1A RID: 2586
	public int StudentID;
}
