using System;
using UnityEngine;
using UnityScript.Lang;

// Token: 0x02000063 RID: 99
[Serializable]
public class ClockScript : MonoBehaviour
{
	// Token: 0x0600026E RID: 622 RVA: 0x0002C4DC File Offset: 0x0002A6DC
	public ClockScript()
	{
		this.MinuteNumber = string.Empty;
		this.HourNumber = string.Empty;
		this.TimeText = string.Empty;
	}

	// Token: 0x0600026F RID: 623 RVA: 0x0002C508 File Offset: 0x0002A708
	public virtual void Start()
	{
		this.PresentTime = this.StartHour * (float)60;
		if (PlayerPrefs.GetInt("Weekday") == 0)
		{
			PlayerPrefs.SetInt("Weekday", 1);
		}
		if (PlayerPrefs.GetFloat("SchoolAtmosphere") < (float)50)
		{
			this.BloomEffect.bloomIntensity = 0.25f;
			this.BloomEffect.bloomThreshhold = 0.5f;
			this.Police.Darkness.enabled = true;
			int num = 1;
			Color color = this.Police.Darkness.color;
			float num2 = color.a = (float)num;
			Color color2 = this.Police.Darkness.color = color;
			this.FadeIn = true;
			this.Timer = (float)5;
		}
		else
		{
			this.BloomEffect.bloomIntensity = (float)10;
			this.BloomEffect.bloomThreshhold = (float)0;
		}
		this.BloomEffect.bloomThreshhold = (float)0;
		this.UpdateWeekdayText(PlayerPrefs.GetInt("Weekday"));
		this.MainLight.color = new Color((float)1, (float)1, (float)1, (float)1);
		RenderSettings.ambientLight = new Color(0.75f, 0.75f, 0.75f, (float)1);
		RenderSettings.skybox.SetColor("_Tint", new Color(0.5f, 0.5f, 0.5f));
	}

	// Token: 0x06000270 RID: 624 RVA: 0x0002C660 File Offset: 0x0002A860
	public virtual void Update()
	{
		if (this.FadeIn && Time.deltaTime < (float)1)
		{
			float a = Mathf.MoveTowards(this.Police.Darkness.color.a, (float)0, Time.deltaTime);
			Color color = this.Police.Darkness.color;
			float num = color.a = a;
			Color color2 = this.Police.Darkness.color = color;
			if (this.Police.Darkness.color.a == (float)0)
			{
				this.Police.Darkness.enabled = false;
				this.FadeIn = false;
			}
		}
		if (this.PresentTime < (float)1080)
		{
			if (this.Timer < (float)5)
			{
				this.Timer += Time.deltaTime;
				this.BloomEffect.bloomIntensity = this.BloomEffect.bloomIntensity - Time.deltaTime * 9.75f;
				this.BloomEffect.bloomThreshhold = this.BloomEffect.bloomThreshhold + Time.deltaTime * 0.5f;
				if (this.BloomEffect.bloomThreshhold > 0.5f)
				{
					this.BloomEffect.bloomIntensity = 0.25f;
					this.BloomEffect.bloomThreshhold = 0.5f;
				}
			}
		}
		else if (!this.Police.FadeOut && !this.Yandere.Attacking && !this.Yandere.Struggling)
		{
			this.Yandere.StudentManager.StopMoving();
			this.Police.Darkness.enabled = true;
			this.Police.FadeOut = true;
			this.StopTime = true;
		}
		if (!this.StopTime)
		{
			this.PresentTime += Time.deltaTime * 0.01666667f * this.TimeSpeed;
		}
		if (this.PresentTime > (float)1440)
		{
			this.PresentTime -= (float)1440;
		}
		this.HourTime = this.PresentTime / (float)60;
		this.Hour = Mathf.Floor(this.PresentTime / (float)60);
		this.Minute = Mathf.Floor((this.PresentTime / (float)60 - this.Hour) * (float)60);
		if (this.Hour == (float)0 || this.Hour == (float)12)
		{
			this.HourNumber = "12";
		}
		else if (this.Hour < (float)12)
		{
			this.HourNumber = string.Empty + this.Hour;
		}
		else
		{
			this.HourNumber = string.Empty + (this.Hour - (float)12);
		}
		if (this.Minute < (float)10)
		{
			this.MinuteNumber = "0" + this.Minute;
		}
		else
		{
			this.MinuteNumber = string.Empty + this.Minute;
		}
		if (this.Hour < (float)12)
		{
			this.TimeText = this.HourNumber + ":" + this.MinuteNumber + " AM";
		}
		else
		{
			this.TimeText = this.HourNumber + ":" + this.MinuteNumber + " PM";
		}
		this.TimeLabel.text = this.TimeText;
		float z = this.Minute * (float)6;
		Vector3 localEulerAngles = this.MinuteHand.localEulerAngles;
		float num2 = localEulerAngles.z = z;
		Vector3 vector = this.MinuteHand.localEulerAngles = localEulerAngles;
		float z2 = this.Hour * (float)30;
		Vector3 localEulerAngles2 = this.HourHand.localEulerAngles;
		float num3 = localEulerAngles2.z = z2;
		Vector3 vector2 = this.HourHand.localEulerAngles = localEulerAngles2;
		if (this.HourTime < 8.5f)
		{
			this.PeriodLabel.text = "BEFORE CLASS";
			if (this.Period < 1)
			{
				this.DeactivateTrespassZones();
				this.Period++;
			}
		}
		else if (this.HourTime < (float)13)
		{
			this.PeriodLabel.text = "CLASSTIME";
			if (this.Period < 2)
			{
				this.ActivateTrespassZones();
				this.Period++;
			}
		}
		else if (this.HourTime < 13.5f)
		{
			this.PeriodLabel.text = "LUNCHTIME";
			if (this.Period < 3)
			{
				this.DeactivateTrespassZones();
				this.Period++;
			}
		}
		else if (this.HourTime < 15.5f)
		{
			this.PeriodLabel.text = "CLASSTIME";
			if (this.Period < 4)
			{
				this.ActivateTrespassZones();
				this.Period++;
			}
		}
		else
		{
			this.PeriodLabel.text = "AFTER SCHOOL";
			if (this.Period < 5)
			{
				this.DeactivateTrespassZones();
				this.Period++;
			}
		}
		float z3 = (float)-45 + (float)90 * (this.PresentTime - (float)420) / (float)660;
		Vector3 eulerAngles = this.Sun.eulerAngles;
		float num4 = eulerAngles.z = z3;
		Vector3 vector3 = this.Sun.eulerAngles = eulerAngles;
		if ((this.Yandere.transform.position.y < (float)11 && this.Yandere.transform.position.x > (float)-30 && this.Yandere.transform.position.z > (float)-38 && this.Yandere.transform.position.x < (float)-22 && this.Yandere.transform.position.z < (float)-26) || (this.Yandere.transform.position.y < (float)11 && this.Yandere.transform.position.x > (float)22 && this.Yandere.transform.position.z > (float)-38 && this.Yandere.transform.position.x < (float)30 && this.Yandere.transform.position.z < (float)-26))
		{
			this.AmbientLightDim -= Time.deltaTime;
			if (this.AmbientLightDim < 0.1f)
			{
				this.AmbientLightDim = 0.1f;
			}
		}
		else
		{
			this.AmbientLightDim += Time.deltaTime;
			if (this.AmbientLightDim > 0.75f)
			{
				this.AmbientLightDim = 0.75f;
			}
		}
		if (this.PresentTime > (float)930)
		{
			this.DayProgress = (this.PresentTime - (float)930) / (float)150;
			float r = (float)1 - 0.149019614f * this.DayProgress;
			Color color3 = this.MainLight.color;
			float num5 = color3.r = r;
			Color color4 = this.MainLight.color = color3;
			float g = (float)1 - 0.403921574f * this.DayProgress;
			Color color5 = this.MainLight.color;
			float num6 = color5.g = g;
			Color color6 = this.MainLight.color = color5;
			float b = (float)1 - 0.709803939f * this.DayProgress;
			Color color7 = this.MainLight.color;
			float num7 = color7.b = b;
			Color color8 = this.MainLight.color = color7;
			float r2 = (float)1 - 0.149019614f * this.DayProgress - ((float)1 - this.AmbientLightDim) * ((float)1 - this.DayProgress);
			Color ambientLight = RenderSettings.ambientLight;
			float num8 = ambientLight.r = r2;
			Color color9 = RenderSettings.ambientLight = ambientLight;
			float g2 = (float)1 - 0.403921574f * this.DayProgress - ((float)1 - this.AmbientLightDim) * ((float)1 - this.DayProgress);
			Color ambientLight2 = RenderSettings.ambientLight;
			float num9 = ambientLight2.g = g2;
			Color color10 = RenderSettings.ambientLight = ambientLight2;
			float b2 = (float)1 - 0.709803939f * this.DayProgress - ((float)1 - this.AmbientLightDim) * ((float)1 - this.DayProgress);
			Color ambientLight3 = RenderSettings.ambientLight;
			float num10 = ambientLight3.b = b2;
			Color color11 = RenderSettings.ambientLight = ambientLight3;
			this.SkyboxColor.r = (float)1 - 0.149019614f * this.DayProgress - 0.5f * ((float)1 - this.DayProgress);
			this.SkyboxColor.g = (float)1 - 0.403921574f * this.DayProgress - 0.5f * ((float)1 - this.DayProgress);
			this.SkyboxColor.b = (float)1 - 0.709803939f * this.DayProgress - 0.5f * ((float)1 - this.DayProgress);
			RenderSettings.skybox.SetColor("_Tint", new Color(this.SkyboxColor.r, this.SkyboxColor.g, this.SkyboxColor.b));
		}
		else
		{
			float ambientLightDim = this.AmbientLightDim;
			Color ambientLight4 = RenderSettings.ambientLight;
			float num11 = ambientLight4.r = ambientLightDim;
			Color color12 = RenderSettings.ambientLight = ambientLight4;
			float ambientLightDim2 = this.AmbientLightDim;
			Color ambientLight5 = RenderSettings.ambientLight;
			float num12 = ambientLight5.g = ambientLightDim2;
			Color color13 = RenderSettings.ambientLight = ambientLight5;
			float ambientLightDim3 = this.AmbientLightDim;
			Color ambientLight6 = RenderSettings.ambientLight;
			float num13 = ambientLight6.b = ambientLightDim3;
			Color color14 = RenderSettings.ambientLight = ambientLight6;
		}
		if (this.TimeSkip)
		{
			if (this.HalfwayTime == (float)0)
			{
				this.HalfwayTime = this.PresentTime + (this.TargetTime - this.PresentTime) * 0.5f;
				this.Yandere.TimeSkipHeight = this.Yandere.transform.position.y;
				this.Yandere.Phone.active = true;
				this.Yandere.TimeSkipping = true;
				this.Yandere.CanMove = false;
				this.Blur.enabled = true;
				if (this.Yandere.Armed)
				{
					this.Yandere.Unequip();
				}
			}
			if (Time.timeScale < (float)25)
			{
				Time.timeScale += (float)1;
			}
			this.Yandere.Character.animation["f02_timeSkip_00"].speed = (float)1 / Time.timeScale;
			this.Blur.blurAmount = 0.92f * (Time.timeScale / (float)100);
			if (this.PresentTime > this.TargetTime)
			{
				this.EndTimeSkip();
			}
			if (this.Yandere.CameraEffects.Streaks.color.a > (float)0 || this.Yandere.CameraEffects.MurderStreaks.color.a > (float)0 || this.Yandere.NearSenpai || Input.GetButtonDown("Start"))
			{
				this.EndTimeSkip();
			}
		}
	}

	// Token: 0x06000271 RID: 625 RVA: 0x0002D264 File Offset: 0x0002B464
	public virtual void EndTimeSkip()
	{
		this.PromptParent.localScale = new Vector3((float)1, (float)1, (float)1);
		this.Yandere.Phone.active = false;
		this.Yandere.TimeSkipping = false;
		this.Blur.enabled = false;
		Time.timeScale = (float)1;
		this.TimeSkip = false;
		this.HalfwayTime = (float)0;
		if (!this.Yandere.Noticed && !this.Police.FadeOut)
		{
			this.Yandere.CanMove = true;
		}
	}

	// Token: 0x06000272 RID: 626 RVA: 0x0002D2F4 File Offset: 0x0002B4F4
	public virtual void UpdateWeekdayText(int Weekday)
	{
		if (Weekday == 1)
		{
			this.DayLabel.text = "MONDAY";
		}
		if (Weekday == 2)
		{
			this.DayLabel.text = "TUESDAY";
		}
		if (Weekday == 3)
		{
			this.DayLabel.text = "WEDNESDAY";
		}
		if (Weekday == 4)
		{
			this.DayLabel.text = "THURSDAY";
		}
		if (Weekday == 5)
		{
			this.DayLabel.text = "FRIDAY";
		}
	}

	// Token: 0x06000273 RID: 627 RVA: 0x0002D374 File Offset: 0x0002B574
	public virtual void ActivateTrespassZones()
	{
		this.SchoolBell.Play();
		this.ID = 0;
		while (this.ID < Extensions.get_length(this.TrespassZones))
		{
			this.TrespassZones[this.ID].enabled = true;
			this.ID++;
		}
	}

	// Token: 0x06000274 RID: 628 RVA: 0x0002D3D0 File Offset: 0x0002B5D0
	public virtual void DeactivateTrespassZones()
	{
		this.Yandere.Trespassing = false;
		this.SchoolBell.Play();
		this.ID = 0;
		while (this.ID < Extensions.get_length(this.TrespassZones))
		{
			this.TrespassZones[this.ID].enabled = false;
			this.ID++;
		}
	}

	// Token: 0x06000275 RID: 629 RVA: 0x0002D438 File Offset: 0x0002B638
	public virtual void Main()
	{
	}

	// Token: 0x0400053B RID: 1339
	private string MinuteNumber;

	// Token: 0x0400053C RID: 1340
	private string HourNumber;

	// Token: 0x0400053D RID: 1341
	public Collider[] TrespassZones;

	// Token: 0x0400053E RID: 1342
	public StudentManagerScript StudentManager;

	// Token: 0x0400053F RID: 1343
	public YandereScript Yandere;

	// Token: 0x04000540 RID: 1344
	public PoliceScript Police;

	// Token: 0x04000541 RID: 1345
	public ClockScript Clock;

	// Token: 0x04000542 RID: 1346
	public Bloom BloomEffect;

	// Token: 0x04000543 RID: 1347
	public MotionBlur Blur;

	// Token: 0x04000544 RID: 1348
	public Transform PromptParent;

	// Token: 0x04000545 RID: 1349
	public Transform MinuteHand;

	// Token: 0x04000546 RID: 1350
	public Transform HourHand;

	// Token: 0x04000547 RID: 1351
	public Transform Sun;

	// Token: 0x04000548 RID: 1352
	public UILabel PeriodLabel;

	// Token: 0x04000549 RID: 1353
	public UILabel TimeLabel;

	// Token: 0x0400054A RID: 1354
	public UILabel DayLabel;

	// Token: 0x0400054B RID: 1355
	public Light MainLight;

	// Token: 0x0400054C RID: 1356
	public float HalfwayTime;

	// Token: 0x0400054D RID: 1357
	public float PresentTime;

	// Token: 0x0400054E RID: 1358
	public float TargetTime;

	// Token: 0x0400054F RID: 1359
	public float StartTime;

	// Token: 0x04000550 RID: 1360
	public float HourTime;

	// Token: 0x04000551 RID: 1361
	public float AmbientLightDim;

	// Token: 0x04000552 RID: 1362
	public float DayProgress;

	// Token: 0x04000553 RID: 1363
	public float StartHour;

	// Token: 0x04000554 RID: 1364
	public float TimeSpeed;

	// Token: 0x04000555 RID: 1365
	public float Minute;

	// Token: 0x04000556 RID: 1366
	public float Timer;

	// Token: 0x04000557 RID: 1367
	public float Hour;

	// Token: 0x04000558 RID: 1368
	public int Period;

	// Token: 0x04000559 RID: 1369
	public int ID;

	// Token: 0x0400055A RID: 1370
	public string TimeText;

	// Token: 0x0400055B RID: 1371
	public bool StopTime;

	// Token: 0x0400055C RID: 1372
	public bool TimeSkip;

	// Token: 0x0400055D RID: 1373
	public bool FadeIn;

	// Token: 0x0400055E RID: 1374
	public AudioSource SchoolBell;

	// Token: 0x0400055F RID: 1375
	public Color SkyboxColor;
}
