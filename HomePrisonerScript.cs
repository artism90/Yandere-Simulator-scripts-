using System;
using UnityEngine;
using UnityScript.Lang;

// Token: 0x020000B8 RID: 184
[Serializable]
public class HomePrisonerScript : MonoBehaviour
{
	// Token: 0x060003FC RID: 1020 RVA: 0x00050348 File Offset: 0x0004E548
	public HomePrisonerScript()
	{
		this.Sanity = 100f;
		this.ID = 1;
	}

	// Token: 0x060003FD RID: 1021 RVA: 0x00050364 File Offset: 0x0004E564
	public virtual void Start()
	{
		this.Sanity = PlayerPrefs.GetFloat("Student_" + PlayerPrefs.GetInt("KidnapVictim") + "_Sanity");
		this.SanityLabel.text = "Sanity: " + this.Sanity + "%";
		this.Prisoner.Sanity = this.Sanity;
		this.Subtitle.text = string.Empty;
		if (this.Sanity == (float)100)
		{
			this.BanterText = this.FullSanityBanterText;
			this.Banter = this.FullSanityBanter;
		}
		else if (this.Sanity >= (float)50)
		{
			this.BanterText = this.HighSanityBanterText;
			this.Banter = this.HighSanityBanter;
		}
		else if (this.Sanity == (float)0)
		{
			this.BanterText = this.NoSanityBanterText;
			this.Banter = this.NoSanityBanter;
		}
		else
		{
			this.BanterText = this.LowSanityBanterText;
			this.Banter = this.LowSanityBanter;
		}
		if (PlayerPrefs.GetInt("Night") == 0)
		{
			float a = 0.5f;
			Color color = this.OptionLabels[2].color;
			float num = color.a = a;
			Color color2 = this.OptionLabels[2].color = color;
			if (PlayerPrefs.GetInt("Late") == 1)
			{
				float a2 = 0.5f;
				Color color3 = this.OptionLabels[1].color;
				float num2 = color3.a = a2;
				Color color4 = this.OptionLabels[1].color = color3;
			}
			if (PlayerPrefs.GetInt("Weekday") == 5)
			{
				float a3 = 0.5f;
				Color color5 = this.OptionLabels[3].color;
				float num3 = color5.a = a3;
				Color color6 = this.OptionLabels[3].color = color5;
				float a4 = 0.5f;
				Color color7 = this.OptionLabels[4].color;
				float num4 = color7.a = a4;
				Color color8 = this.OptionLabels[4].color = color7;
			}
		}
		else
		{
			float a5 = 0.5f;
			Color color9 = this.OptionLabels[1].color;
			float num5 = color9.a = a5;
			Color color10 = this.OptionLabels[1].color = color9;
			float a6 = 0.5f;
			Color color11 = this.OptionLabels[3].color;
			float num6 = color11.a = a6;
			Color color12 = this.OptionLabels[3].color = color11;
			float a7 = 0.5f;
			Color color13 = this.OptionLabels[4].color;
			float num7 = color13.a = a7;
			Color color14 = this.OptionLabels[4].color = color13;
		}
		if (this.Sanity > (float)0)
		{
			this.OptionLabels[5].text = "?????";
			float a8 = 0.5f;
			Color color15 = this.OptionLabels[5].color;
			float num8 = color15.a = a8;
			Color color16 = this.OptionLabels[5].color = color15;
		}
		else
		{
			this.OptionLabels[5].text = "Bring to School";
			float a9 = 0.5f;
			Color color17 = this.OptionLabels[1].color;
			float num9 = color17.a = a9;
			Color color18 = this.OptionLabels[1].color = color17;
			float a10 = 0.5f;
			Color color19 = this.OptionLabels[2].color;
			float num10 = color19.a = a10;
			Color color20 = this.OptionLabels[2].color = color19;
			float a11 = 0.5f;
			Color color21 = this.OptionLabels[3].color;
			float num11 = color21.a = a11;
			Color color22 = this.OptionLabels[3].color = color21;
			float a12 = 0.5f;
			Color color23 = this.OptionLabels[4].color;
			float num12 = color23.a = a12;
			Color color24 = this.OptionLabels[4].color = color23;
			int num13 = 1;
			Color color25 = this.OptionLabels[5].color;
			float num14 = color25.a = (float)num13;
			Color color26 = this.OptionLabels[5].color = color25;
			if (PlayerPrefs.GetInt("Night") == 1)
			{
				float a13 = 0.5f;
				Color color27 = this.OptionLabels[5].color;
				float num15 = color27.a = a13;
				Color color28 = this.OptionLabels[5].color = color27;
			}
		}
		this.UpdateDesc();
		if (PlayerPrefs.GetInt("KidnapVictim") == 0)
		{
			this.enabled = false;
		}
	}

	// Token: 0x060003FE RID: 1022 RVA: 0x00050874 File Offset: 0x0004EA74
	public virtual void Update()
	{
		if (Vector3.Distance(this.HomeYandere.transform.position, this.Prisoner.transform.position) < (float)2 && this.HomeYandere.CanMove)
		{
			this.BanterTimer += Time.deltaTime;
			if (this.BanterTimer > (float)5 && !this.Bantering)
			{
				this.Bantering = true;
				if (this.BanterID < Extensions.get_length(this.Banter) - 1)
				{
					this.BanterID++;
					this.Subtitle.text = this.BanterText[this.BanterID];
					this.audio.clip = this.Banter[this.BanterID];
					this.audio.Play();
				}
			}
		}
		if (this.Bantering && !this.audio.isPlaying)
		{
			this.Subtitle.text = string.Empty;
			this.Bantering = false;
			this.BanterTimer = (float)0;
		}
		if (!this.HomeYandere.CanMove && (this.HomeCamera.Destination == this.HomeCamera.Destinations[10] || this.HomeCamera.Destination == this.TortureDestination))
		{
			if (this.InputManager.TappedDown)
			{
				this.ID++;
				if (this.ID > 5)
				{
					this.ID = 1;
				}
				int num = 465 - this.ID * 40;
				Vector3 localPosition = this.Highlight.localPosition;
				float num2 = localPosition.y = (float)num;
				Vector3 vector = this.Highlight.localPosition = localPosition;
				this.UpdateDesc();
			}
			if (this.InputManager.TappedUp)
			{
				this.ID--;
				if (this.ID < 1)
				{
					this.ID = 5;
				}
				int num3 = 465 - this.ID * 40;
				Vector3 localPosition2 = this.Highlight.localPosition;
				float num4 = localPosition2.y = (float)num3;
				Vector3 vector2 = this.Highlight.localPosition = localPosition2;
				this.UpdateDesc();
			}
			if (Input.GetKeyDown("x"))
			{
				this.Sanity -= (float)10;
				if (this.Sanity < (float)0)
				{
					this.Sanity = (float)100;
				}
				PlayerPrefs.SetFloat("Student_" + PlayerPrefs.GetInt("KidnapVictim") + "_Sanity", this.Sanity);
				this.SanityLabel.text = "Sanity: " + this.Sanity + "%";
				this.Prisoner.UpdateSanity();
			}
			if (!this.ZoomIn)
			{
				if (Input.GetButtonDown("A") && this.OptionLabels[this.ID].color.a == (float)1)
				{
					if (this.Sanity > (float)0)
					{
						if (this.Sanity >= (float)50)
						{
							this.Prisoner.Character.animation.CrossFade("f02_kidnapTorture_01");
						}
						else
						{
							this.Prisoner.Character.animation.CrossFade("f02_kidnapSurrender_00");
							int num5 = 1;
							Vector3 localPosition3 = this.TortureDestination.localPosition;
							float num6 = localPosition3.z = (float)num5;
							Vector3 vector3 = this.TortureDestination.localPosition = localPosition3;
							int num7 = 0;
							Vector3 localPosition4 = this.TortureDestination.localPosition;
							float num8 = localPosition4.y = (float)num7;
							Vector3 vector4 = this.TortureDestination.localPosition = localPosition4;
							float y = 1.1f;
							Vector3 localPosition5 = this.TortureTarget.localPosition;
							float num9 = localPosition5.y = y;
							Vector3 vector5 = this.TortureTarget.localPosition = localPosition5;
						}
						this.HomeCamera.Destination = this.TortureDestination;
						this.HomeCamera.Target = this.TortureTarget;
						this.HomeCamera.Torturing = true;
						this.Prisoner.Tortured = true;
						this.Prisoner.RightEyeRotOrigin.x = (float)-6;
						this.Prisoner.LeftEyeRotOrigin.x = (float)6;
						this.ZoomIn = true;
					}
					else
					{
						this.Darkness.FadeOut = true;
					}
					this.HomeWindow.Show = false;
					this.HomeCamera.PromptBar.ClearButtons();
					this.HomeCamera.PromptBar.Show = false;
					this.Jukebox.volume = this.Jukebox.volume - 0.5f;
				}
				if (Input.GetButtonDown("B"))
				{
					this.HomeCamera.Destination = this.HomeCamera.Destinations[0];
					this.HomeCamera.Target = this.HomeCamera.Targets[0];
					this.HomeCamera.PromptBar.ClearButtons();
					this.HomeCamera.PromptBar.Show = false;
					this.HomeYandere.CanMove = true;
					this.HomeYandere.active = true;
					this.HomeWindow.Show = false;
				}
			}
			else
			{
				this.TortureDestination.Translate(Vector3.forward * Time.deltaTime * 0.02f);
				this.Jukebox.volume = this.Jukebox.volume - Time.deltaTime * 0.05f;
				this.Timer += Time.deltaTime;
				if (this.Sanity >= (float)50)
				{
					float y2 = this.TortureDestination.localPosition.y + Time.deltaTime * 0.05f;
					Vector3 localPosition6 = this.TortureDestination.localPosition;
					float num10 = localPosition6.y = y2;
					Vector3 vector6 = this.TortureDestination.localPosition = localPosition6;
					if (this.Sanity == (float)100)
					{
						if (this.Timer > (float)2 && !this.PlayedAudio)
						{
							this.audio.clip = this.FirstTorture;
							this.PlayedAudio = true;
							this.audio.Play();
						}
					}
					else if (this.Timer > 1.5f && !this.PlayedAudio)
					{
						this.audio.clip = this.Over50Torture;
						this.PlayedAudio = true;
						this.audio.Play();
					}
				}
				else if (this.Timer > (float)5 && !this.PlayedAudio)
				{
					this.audio.clip = this.Under50Torture;
					this.PlayedAudio = true;
					this.audio.Play();
				}
				if (this.Timer > (float)10 && this.Darkness.Sprite.color.a != (float)1)
				{
					this.Darkness.enabled = false;
					int num11 = 1;
					Color color = this.Darkness.Sprite.color;
					float num12 = color.a = (float)num11;
					Color color2 = this.Darkness.Sprite.color = color;
					this.audio.clip = this.TortureHit;
					this.audio.Play();
				}
				if (this.Timer > (float)15)
				{
					if (this.ID == 1)
					{
						Time.timeScale = (float)1;
						this.NowLoading.active = true;
						PlayerPrefs.SetInt("Late", 1);
						Application.LoadLevel("SchoolScene");
						PlayerPrefs.SetFloat("Student_" + PlayerPrefs.GetInt("KidnapVictim") + "_Sanity", this.Sanity - 2.5f);
					}
					else if (this.ID == 2)
					{
						Application.LoadLevel("CalendarScene");
						PlayerPrefs.SetFloat("Student_" + PlayerPrefs.GetInt("KidnapVictim") + "_Sanity", this.Sanity - (float)10);
						PlayerPrefs.SetFloat("Reputation", PlayerPrefs.GetFloat("Reputation") - (float)20);
					}
					else if (this.ID == 3)
					{
						PlayerPrefs.SetInt("Night", 1);
						Application.LoadLevel("HomeScene");
						PlayerPrefs.SetFloat("Student_" + PlayerPrefs.GetInt("KidnapVictim") + "_Sanity", this.Sanity - (float)30);
						PlayerPrefs.SetFloat("Reputation", PlayerPrefs.GetFloat("Reputation") - (float)20);
					}
					else if (this.ID == 4)
					{
						Application.LoadLevel("CalendarScene");
						PlayerPrefs.SetFloat("Student_" + PlayerPrefs.GetInt("KidnapVictim") + "_Sanity", this.Sanity - (float)45);
						PlayerPrefs.SetFloat("Reputation", PlayerPrefs.GetFloat("Reputation") - (float)20);
					}
					if (PlayerPrefs.GetFloat("Student_" + PlayerPrefs.GetInt("KidnapVictim") + "_Sanity") < (float)0)
					{
						PlayerPrefs.SetFloat("Student_" + PlayerPrefs.GetInt("KidnapVictim") + "_Sanity", (float)0);
					}
				}
			}
		}
	}

	// Token: 0x060003FF RID: 1023 RVA: 0x0005120C File Offset: 0x0004F40C
	public virtual void UpdateDesc()
	{
		this.HomeCamera.PromptBar.Label[0].text = "Accept";
		this.DescLabel.text = string.Empty + this.Descriptions[this.ID];
		if (PlayerPrefs.GetInt("Night") == 0)
		{
			if (PlayerPrefs.GetInt("Late") == 1 && this.ID == 1)
			{
				this.DescLabel.text = "This option is unavailable if you are late for school.";
				this.HomeCamera.PromptBar.Label[0].text = string.Empty;
			}
			if (this.ID == 2)
			{
				this.DescLabel.text = "This option is unavailable in the daytime.";
				this.HomeCamera.PromptBar.Label[0].text = string.Empty;
			}
			if (PlayerPrefs.GetInt("Weekday") == 5 && (this.ID == 3 || this.ID == 4))
			{
				this.DescLabel.text = "This option is unavailable on Friday.";
				this.HomeCamera.PromptBar.Label[0].text = string.Empty;
			}
		}
		else if (this.ID != 2)
		{
			this.DescLabel.text = "This option is unavailable at nighttime.";
			this.HomeCamera.PromptBar.Label[0].text = string.Empty;
		}
		if (this.ID == 5)
		{
			if (this.Sanity > (float)0)
			{
				this.DescLabel.text = "This option is unavailable until your prisoner's Sanity has reached zero.";
			}
			if (PlayerPrefs.GetInt("Night") == 1)
			{
				this.DescLabel.text = "This option is unavailable at nighttime.";
				this.HomeCamera.PromptBar.Label[0].text = string.Empty;
			}
		}
		this.HomeCamera.PromptBar.UpdateButtons();
	}

	// Token: 0x06000400 RID: 1024 RVA: 0x000513EC File Offset: 0x0004F5EC
	public virtual void Main()
	{
	}

	// Token: 0x04000A1B RID: 2587
	public InputManagerScript InputManager;

	// Token: 0x04000A1C RID: 2588
	public HomePrisonerChanScript Prisoner;

	// Token: 0x04000A1D RID: 2589
	public HomeYandereScript HomeYandere;

	// Token: 0x04000A1E RID: 2590
	public HomeCameraScript HomeCamera;

	// Token: 0x04000A1F RID: 2591
	public HomeWindowScript HomeWindow;

	// Token: 0x04000A20 RID: 2592
	public HomeDarknessScript Darkness;

	// Token: 0x04000A21 RID: 2593
	public UILabel[] OptionLabels;

	// Token: 0x04000A22 RID: 2594
	public string[] Descriptions;

	// Token: 0x04000A23 RID: 2595
	public Transform TortureDestination;

	// Token: 0x04000A24 RID: 2596
	public Transform TortureTarget;

	// Token: 0x04000A25 RID: 2597
	public GameObject NowLoading;

	// Token: 0x04000A26 RID: 2598
	public Transform Highlight;

	// Token: 0x04000A27 RID: 2599
	public AudioSource Jukebox;

	// Token: 0x04000A28 RID: 2600
	public UILabel SanityLabel;

	// Token: 0x04000A29 RID: 2601
	public UILabel DescLabel;

	// Token: 0x04000A2A RID: 2602
	public UILabel Subtitle;

	// Token: 0x04000A2B RID: 2603
	public bool PlayedAudio;

	// Token: 0x04000A2C RID: 2604
	public bool ZoomIn;

	// Token: 0x04000A2D RID: 2605
	public float Sanity;

	// Token: 0x04000A2E RID: 2606
	public float Timer;

	// Token: 0x04000A2F RID: 2607
	public int ID;

	// Token: 0x04000A30 RID: 2608
	public AudioClip FirstTorture;

	// Token: 0x04000A31 RID: 2609
	public AudioClip Under50Torture;

	// Token: 0x04000A32 RID: 2610
	public AudioClip Over50Torture;

	// Token: 0x04000A33 RID: 2611
	public AudioClip TortureHit;

	// Token: 0x04000A34 RID: 2612
	public string[] FullSanityBanterText;

	// Token: 0x04000A35 RID: 2613
	public string[] HighSanityBanterText;

	// Token: 0x04000A36 RID: 2614
	public string[] LowSanityBanterText;

	// Token: 0x04000A37 RID: 2615
	public string[] NoSanityBanterText;

	// Token: 0x04000A38 RID: 2616
	public string[] BanterText;

	// Token: 0x04000A39 RID: 2617
	public AudioClip[] FullSanityBanter;

	// Token: 0x04000A3A RID: 2618
	public AudioClip[] HighSanityBanter;

	// Token: 0x04000A3B RID: 2619
	public AudioClip[] LowSanityBanter;

	// Token: 0x04000A3C RID: 2620
	public AudioClip[] NoSanityBanter;

	// Token: 0x04000A3D RID: 2621
	public AudioClip[] Banter;

	// Token: 0x04000A3E RID: 2622
	public float BanterTimer;

	// Token: 0x04000A3F RID: 2623
	public bool Bantering;

	// Token: 0x04000A40 RID: 2624
	public int BanterID;
}
