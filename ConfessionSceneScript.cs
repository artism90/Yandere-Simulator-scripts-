using System;
using UnityEngine;

// Token: 0x0200006A RID: 106
[Serializable]
public class ConfessionSceneScript : MonoBehaviour
{
	// Token: 0x0600029D RID: 669 RVA: 0x0002FCEC File Offset: 0x0002DEEC
	public ConfessionSceneScript()
	{
		this.TextPhase = 1;
		this.Phase = 1;
	}

	// Token: 0x0600029E RID: 670 RVA: 0x0002FD04 File Offset: 0x0002DF04
	public virtual void Update()
	{
		if (this.Phase == 1)
		{
			float a = Mathf.MoveTowards(this.Darkness.color.a, (float)1, Time.deltaTime);
			Color color = this.Darkness.color;
			float num = color.a = a;
			Color color2 = this.Darkness.color = color;
			this.Panel.alpha = Mathf.MoveTowards(this.Panel.alpha, (float)0, Time.deltaTime);
			this.Jukebox.Volume = Mathf.MoveTowards(this.Jukebox.Volume, (float)0, Time.deltaTime);
			if (this.Darkness.color.a == (float)1)
			{
				this.Timer += Time.deltaTime;
				if (this.Timer > (float)1)
				{
					this.BloomEffect.bloomIntensity = (float)1;
					this.BloomEffect.bloomThreshhold = (float)0;
					this.BloomEffect.bloomBlurIterations = 1;
					this.Suitor = this.StudentManager.Students[13];
					this.Rival = this.StudentManager.Students[7];
					this.Rival.transform.position = this.RivalSpot.position;
					this.Rival.transform.eulerAngles = this.RivalSpot.eulerAngles;
					this.Suitor.Cosmetic.MyRenderer.materials[this.Suitor.Cosmetic.FaceID].SetFloat("_BlendAmount", (float)1);
					this.Suitor.transform.eulerAngles = this.StudentManager.SuitorConfessionSpot.eulerAngles;
					this.Suitor.transform.position = this.StudentManager.SuitorConfessionSpot.position;
					this.Suitor.Character.animation.Play(this.Suitor.IdleAnim);
					this.MythBlossoms.emissionRate = (float)100;
					this.HeartBeatCamera.active = false;
					this.ConfessionBG.active = true;
					this.audio.Play();
					this.MainCamera.position = this.CameraDestinations[1].position;
					this.MainCamera.eulerAngles = this.CameraDestinations[1].eulerAngles;
					this.Timer = (float)0;
					this.Phase++;
				}
			}
		}
		else if (this.Phase == 2)
		{
			float a2 = Mathf.MoveTowards(this.Darkness.color.a, (float)0, Time.deltaTime);
			Color color3 = this.Darkness.color;
			float num2 = color3.a = a2;
			Color color4 = this.Darkness.color = color3;
			if (this.Darkness.color.a == (float)0)
			{
				if (!this.ShowLabel)
				{
					float a3 = Mathf.MoveTowards(this.Label.color.a, (float)0, Time.deltaTime);
					Color color5 = this.Label.color;
					float num3 = color5.a = a3;
					Color color6 = this.Label.color = color5;
					if (this.Label.color.a == (float)0)
					{
						if (this.TextPhase < 5)
						{
							this.MainCamera.position = this.CameraDestinations[this.TextPhase].position;
							this.MainCamera.eulerAngles = this.CameraDestinations[this.TextPhase].eulerAngles;
							if (this.TextPhase == 4 && !this.Kissing)
							{
								this.Suitor.Hearts.enableEmission = true;
								this.Suitor.Hearts.emissionRate = (float)10;
								this.Suitor.Hearts.Play();
								this.Rival.Hearts.enableEmission = true;
								this.Rival.Hearts.emissionRate = (float)10;
								this.Rival.Hearts.Play();
								this.Suitor.Character.transform.localScale = new Vector3((float)1, (float)1, (float)1);
								this.Suitor.Character.animation.Play("kiss_00");
								this.Suitor.transform.position = this.KissSpot.position;
								this.Rival.Character.animation[this.Rival.ShyAnim].weight = (float)0;
								this.Rival.Character.animation.Play("f02_kiss_00");
								this.Kissing = true;
							}
							this.Label.text = this.Text[this.TextPhase];
							this.ShowLabel = true;
						}
						else
						{
							this.Phase++;
						}
					}
				}
				else
				{
					float a4 = Mathf.MoveTowards(this.Label.color.a, (float)1, Time.deltaTime);
					Color color7 = this.Label.color;
					float num4 = color7.a = a4;
					Color color8 = this.Label.color = color7;
					if (this.Label.color.a == (float)1)
					{
						if (!this.PromptBar.Show)
						{
							this.PromptBar.ClearButtons();
							this.PromptBar.Label[0].text = "Continue";
							this.PromptBar.UpdateButtons();
							this.PromptBar.Show = true;
						}
						if (Input.GetButtonDown("A"))
						{
							this.TextPhase++;
							this.ShowLabel = false;
						}
					}
				}
			}
		}
		else if (this.Phase == 3)
		{
			float a5 = Mathf.MoveTowards(this.Darkness.color.a, (float)1, Time.deltaTime);
			Color color9 = this.Darkness.color;
			float num5 = color9.a = a5;
			Color color10 = this.Darkness.color = color9;
			if (this.Darkness.color.a == (float)1)
			{
				this.Timer += Time.deltaTime;
				if (this.Timer > (float)1)
				{
					PlayerPrefs.SetInt("SuitorProgress", 2);
					this.Suitor.Character.transform.localScale = new Vector3(0.94f, 0.94f, 0.94f);
					this.PromptBar.ClearButtons();
					this.PromptBar.UpdateButtons();
					this.PromptBar.Show = false;
					this.ConfessionBG.active = false;
					this.Yandere.FixCamera();
					this.Phase++;
				}
			}
		}
		else
		{
			float a6 = Mathf.MoveTowards(this.Darkness.color.a, (float)0, Time.deltaTime);
			Color color11 = this.Darkness.color;
			float num6 = color11.a = a6;
			Color color12 = this.Darkness.color = color11;
			this.Panel.alpha = Mathf.MoveTowards(this.Panel.alpha, (float)1, Time.deltaTime);
			if (this.Darkness.color.a == (float)0)
			{
				this.Yandere.RPGCamera.enabled = true;
				this.Yandere.CanMove = true;
				this.HeartBeatCamera.active = true;
				this.MythBlossoms.emissionRate = (float)20;
				this.Clock.StopTime = false;
				this.enabled = false;
				this.Suitor.CoupleID = 7;
				this.Suitor.Couple = true;
				this.Rival.CoupleID = 13;
				this.Rival.Couple = true;
			}
		}
		if (this.Kissing && this.Suitor.Character.animation["kiss_00"].time >= this.Suitor.Character.animation["kiss_00"].length)
		{
			this.Suitor.Character.animation.CrossFade(this.Suitor.IdleAnim);
			this.Rival.Character.animation.CrossFade(this.Rival.IdleAnim);
			this.Kissing = false;
		}
	}

	// Token: 0x0600029F RID: 671 RVA: 0x000305AC File Offset: 0x0002E7AC
	public virtual void Main()
	{
	}

	// Token: 0x040005BE RID: 1470
	public Transform[] CameraDestinations;

	// Token: 0x040005BF RID: 1471
	public StudentManagerScript StudentManager;

	// Token: 0x040005C0 RID: 1472
	public PromptBarScript PromptBar;

	// Token: 0x040005C1 RID: 1473
	public JukeboxScript Jukebox;

	// Token: 0x040005C2 RID: 1474
	public YandereScript Yandere;

	// Token: 0x040005C3 RID: 1475
	public ClockScript Clock;

	// Token: 0x040005C4 RID: 1476
	public Bloom BloomEffect;

	// Token: 0x040005C5 RID: 1477
	public StudentScript Suitor;

	// Token: 0x040005C6 RID: 1478
	public StudentScript Rival;

	// Token: 0x040005C7 RID: 1479
	public ParticleSystem MythBlossoms;

	// Token: 0x040005C8 RID: 1480
	public GameObject HeartBeatCamera;

	// Token: 0x040005C9 RID: 1481
	public GameObject ConfessionBG;

	// Token: 0x040005CA RID: 1482
	public Transform MainCamera;

	// Token: 0x040005CB RID: 1483
	public Transform RivalSpot;

	// Token: 0x040005CC RID: 1484
	public Transform KissSpot;

	// Token: 0x040005CD RID: 1485
	public string[] Text;

	// Token: 0x040005CE RID: 1486
	public UISprite Darkness;

	// Token: 0x040005CF RID: 1487
	public UILabel Label;

	// Token: 0x040005D0 RID: 1488
	public UIPanel Panel;

	// Token: 0x040005D1 RID: 1489
	public bool ShowLabel;

	// Token: 0x040005D2 RID: 1490
	public bool Kissing;

	// Token: 0x040005D3 RID: 1491
	public int TextPhase;

	// Token: 0x040005D4 RID: 1492
	public int Phase;

	// Token: 0x040005D5 RID: 1493
	public float Timer;
}
