using System;
using UnityEngine;
using UnityScript.Lang;

// Token: 0x02000070 RID: 112
[Serializable]
public class CounselorScript : MonoBehaviour
{
	// Token: 0x060002BA RID: 698 RVA: 0x00034D4C File Offset: 0x00032F4C
	public CounselorScript()
	{
		this.Selected = 1;
		this.LecturePhase = 1;
		this.LectureID = 5;
	}

	// Token: 0x060002BB RID: 699 RVA: 0x00034D6C File Offset: 0x00032F6C
	public virtual void Start()
	{
		this.CounselorWindow.localScale = new Vector3((float)0, (float)0, (float)0);
		this.CounselorWindow.gameObject.active = false;
		int num = 0;
		Color color = this.ExpelProgress.color;
		float num2 = color.a = (float)num;
		Color color2 = this.ExpelProgress.color = color;
	}

	// Token: 0x060002BC RID: 700 RVA: 0x00034DD0 File Offset: 0x00032FD0
	public virtual void Update()
	{
		if (this.Yandere.transform.position.x < this.transform.position.x)
		{
			this.Prompt.Hide();
			this.Prompt.enabled = false;
		}
		else
		{
			this.Prompt.enabled = true;
		}
		if (this.Prompt.Circle[0].fillAmount <= (float)0)
		{
			this.Prompt.Circle[0].fillAmount = (float)1;
			if (!this.Busy)
			{
				this.animation.CrossFade("CounselorComputerAttention", (float)1);
				this.ChinTimer = (float)0;
				this.Yandere.TargetStudent = this.Student;
				int num = UnityEngine.Random.Range(1, 3);
				this.CounselorSubtitle.text = this.CounselorGreetingText[num];
				this.audio.clip = this.CounselorGreetingClips[num];
				this.audio.Play();
				this.StudentManager.DisablePrompts();
				this.CounselorWindow.gameObject.active = true;
				this.LookAtPlayer = true;
				this.ShowWindow = true;
				this.Yandere.ShoulderCamera.OverShoulder = true;
				this.Yandere.WeaponMenu.KeyboardShow = false;
				this.Yandere.Obscurance.enabled = false;
				this.Yandere.WeaponMenu.Show = false;
				this.Yandere.YandereVision = false;
				this.Yandere.CanMove = false;
				this.Yandere.Talking = true;
				this.PromptBar.ClearButtons();
				this.PromptBar.Label[0].text = "Accept";
				this.PromptBar.Label[4].text = "Choose";
				this.PromptBar.UpdateButtons();
				this.PromptBar.Show = true;
				this.UpdateList();
			}
			else
			{
				this.CounselorSubtitle.text = this.CounselorBusyText;
				this.audio.clip = this.CounselorBusyClip;
				this.audio.Play();
			}
		}
		if (this.LookAtPlayer)
		{
			if (this.InputManager.TappedUp)
			{
				this.Selected--;
				if (this.Selected == 6)
				{
					this.Selected = 5;
				}
				this.UpdateHighlight();
			}
			if (this.InputManager.TappedDown)
			{
				this.Selected++;
				if (this.Selected == 6)
				{
					this.Selected = 7;
				}
				this.UpdateHighlight();
			}
			if (this.ShowWindow)
			{
				if (Input.GetButtonDown("A"))
				{
					if (this.Selected == 7)
					{
						this.animation.CrossFade("CounselorComputerLoop", (float)1);
						this.Yandere.ShoulderCamera.OverShoulder = false;
						this.StudentManager.EnablePrompts();
						this.Yandere.TargetStudent = null;
						this.LookAtPlayer = false;
						this.ShowWindow = false;
						this.CounselorSubtitle.text = this.CounselorFarewellText;
						this.audio.clip = this.CounselorFarewellClip;
						this.audio.Play();
						this.PromptBar.ClearButtons();
						this.PromptBar.Show = false;
					}
					else if (this.Labels[this.Selected].color.a == (float)1)
					{
						if (this.Selected == 1)
						{
							PlayerPrefs.SetInt("Scheme_1_Stage", 100);
							this.Schemes.UpdateInstructions();
						}
						else if (this.Selected == 2)
						{
							PlayerPrefs.SetInt("Scheme_2_Stage", 100);
							this.Schemes.UpdateInstructions();
						}
						else if (this.Selected == 3)
						{
							PlayerPrefs.SetInt("Scheme_3_Stage", 100);
							this.Schemes.UpdateInstructions();
						}
						else if (this.Selected == 4)
						{
							PlayerPrefs.SetInt("Scheme_4_Stage", 100);
							this.Schemes.UpdateInstructions();
						}
						else if (this.Selected == 5)
						{
							PlayerPrefs.SetInt("Scheme_5_Stage", 7);
							this.Schemes.UpdateInstructions();
						}
						this.CounselorSubtitle.text = this.CounselorReportText[this.Selected];
						this.audio.clip = this.CounselorReportClips[this.Selected];
						this.audio.Play();
						this.ShowWindow = false;
						this.Angry = true;
						this.LectureID = this.Selected;
						this.PromptBar.ClearButtons();
						this.PromptBar.Show = false;
						this.Busy = true;
					}
				}
			}
			else
			{
				if (Input.GetButtonDown("A"))
				{
					this.audio.Stop();
				}
				if (!this.audio.isPlaying)
				{
					this.Timer += Time.deltaTime;
					if (this.Timer > 0.5f)
					{
						this.animation.CrossFade("CounselorComputerLoop", (float)1);
						this.Yandere.ShoulderCamera.OverShoulder = false;
						this.StudentManager.EnablePrompts();
						this.Yandere.TargetStudent = null;
						this.LookAtPlayer = false;
						this.Angry = false;
						this.UpdateList();
					}
				}
			}
		}
		else
		{
			this.ChinTimer += Time.deltaTime;
			if (this.ChinTimer > (float)10)
			{
				this.animation.CrossFade("CounselorComputerChin");
				if (this.animation["CounselorComputerChin"].time > this.animation["CounselorComputerChin"].length)
				{
					this.animation.CrossFade("CounselorComputerLoop");
					this.ChinTimer = (float)0;
				}
			}
		}
		if (this.ShowWindow)
		{
			this.CounselorWindow.localScale = Vector3.Lerp(this.CounselorWindow.localScale, new Vector3((float)1, (float)1, (float)1), Time.deltaTime * (float)10);
		}
		else if (this.CounselorWindow.localScale.x > 0.1f)
		{
			this.CounselorWindow.localScale = Vector3.Lerp(this.CounselorWindow.localScale, new Vector3((float)0, (float)0, (float)0), Time.deltaTime * (float)10);
		}
		else
		{
			this.CounselorWindow.localScale = new Vector3((float)0, (float)0, (float)0);
			this.CounselorWindow.gameObject.active = false;
		}
		if (this.Lecturing)
		{
			float y = Mathf.Lerp(this.Chibi.localPosition.y, (float)(250 + PlayerPrefs.GetInt("ExpelProgress") * -100), Time.deltaTime * (float)2);
			Vector3 localPosition = this.Chibi.localPosition;
			float num2 = localPosition.y = y;
			Vector3 vector = this.Chibi.localPosition = localPosition;
			if (this.LecturePhase == 1)
			{
				this.LectureLabel.text = this.LectureIntro[this.LectureID];
				float a = Mathf.MoveTowards(this.EndOfDayDarkness.color.a, (float)0, Time.deltaTime);
				Color color = this.EndOfDayDarkness.color;
				float num3 = color.a = a;
				Color color2 = this.EndOfDayDarkness.color = color;
				if (this.EndOfDayDarkness.color.a == (float)0)
				{
					this.PromptBar.ClearButtons();
					this.PromptBar.Label[0].text = "Continue";
					this.PromptBar.UpdateButtons();
					this.PromptBar.Show = true;
					if (Input.GetButtonDown("A"))
					{
						this.LecturePhase++;
						this.PromptBar.ClearButtons();
						this.PromptBar.Show = false;
					}
				}
			}
			else if (this.LecturePhase == 2)
			{
				float a2 = Mathf.MoveTowards(this.LectureLabel.color.a, (float)0, Time.deltaTime);
				Color color3 = this.LectureLabel.color;
				float num4 = color3.a = a2;
				Color color4 = this.LectureLabel.color = color3;
				if (this.LectureLabel.color.a == (float)0)
				{
					this.LectureSubtitle.text = this.CounselorLectureText[this.LectureID];
					this.audio.clip = this.CounselorLectureClips[this.LectureID];
					this.audio.Play();
					this.LecturePhase++;
				}
			}
			else if (this.LecturePhase == 3)
			{
				if (!this.audio.isPlaying || Input.GetButtonDown("A"))
				{
					this.LectureSubtitle.text = this.RivalText[this.LectureID];
					this.audio.clip = this.RivalClips[this.LectureID];
					this.audio.Play();
					this.LecturePhase++;
				}
			}
			else if (this.LecturePhase == 4)
			{
				if (!this.audio.isPlaying || Input.GetButtonDown("A"))
				{
					this.LectureSubtitle.text = string.Empty;
					if (PlayerPrefs.GetInt("ExpelProgress") < 5)
					{
						this.LecturePhase++;
					}
					else
					{
						this.LecturePhase = 7;
						this.ExpelTimer = (float)11;
					}
				}
			}
			else if (this.LecturePhase == 5)
			{
				float a3 = Mathf.MoveTowards(this.ExpelProgress.color.a, (float)1, Time.deltaTime);
				Color color5 = this.ExpelProgress.color;
				float num5 = color5.a = a3;
				Color color6 = this.ExpelProgress.color = color5;
				this.ExpelTimer += Time.deltaTime;
				if (this.ExpelTimer > (float)2)
				{
					PlayerPrefs.SetInt("ExpelProgress", PlayerPrefs.GetInt("ExpelProgress") + 1);
					this.LecturePhase++;
				}
			}
			else if (this.LecturePhase == 6)
			{
				this.ExpelTimer += Time.deltaTime;
				if (this.ExpelTimer > (float)4)
				{
					this.LecturePhase++;
				}
			}
			else if (this.LecturePhase == 7)
			{
				float a4 = Mathf.MoveTowards(this.ExpelProgress.color.a, (float)0, Time.deltaTime);
				Color color7 = this.ExpelProgress.color;
				float num6 = color7.a = a4;
				Color color8 = this.ExpelProgress.color = color7;
				this.ExpelTimer += Time.deltaTime;
				if (this.ExpelTimer > (float)6)
				{
					if (PlayerPrefs.GetInt("ExpelProgress") == 5 && PlayerPrefs.GetInt("Student_7_Expelled") == 0)
					{
						PlayerPrefs.SetInt("Student_7_Expelled", 1);
						int num7 = 0;
						Color color9 = this.EndOfDayDarkness.color;
						float num8 = color9.a = (float)num7;
						Color color10 = this.EndOfDayDarkness.color = color9;
						int num9 = 0;
						Color color11 = this.LectureLabel.color;
						float num10 = color11.a = (float)num9;
						Color color12 = this.LectureLabel.color = color11;
						this.LecturePhase = 2;
						this.ExpelTimer = (float)0;
						this.LectureID = 6;
					}
					else if (this.LectureID < 6)
					{
						this.EndOfDay.enabled = true;
						this.EndOfDay.Phase = this.EndOfDay.Phase + 1;
						this.EndOfDay.UpdateScene();
						this.enabled = false;
					}
					else
					{
						this.EndOfDay.active = false;
						this.EndOfDay.Phase = 1;
						this.CutsceneManager.Phase = this.CutsceneManager.Phase + 1;
						this.Lecturing = false;
						this.LectureID = 0;
					}
				}
			}
		}
		if (!this.audio.isPlaying)
		{
			this.CounselorSubtitle.text = string.Empty;
		}
	}

	// Token: 0x060002BD RID: 701 RVA: 0x00035A38 File Offset: 0x00033C38
	public virtual void UpdateList()
	{
		for (int i = 1; i < Extensions.get_length(this.Labels); i++)
		{
			float a = 0.5f;
			Color color = this.Labels[i].color;
			float num = color.a = a;
			Color color2 = this.Labels[i].color = color;
		}
		if (PlayerPrefs.GetInt("Scheme_1_Stage") == 2)
		{
			int num2 = 1;
			Color color3 = this.Labels[1].color;
			float num3 = color3.a = (float)num2;
			Color color4 = this.Labels[1].color = color3;
		}
		if (PlayerPrefs.GetInt("Scheme_2_Stage") == 3)
		{
			int num4 = 1;
			Color color5 = this.Labels[2].color;
			float num5 = color5.a = (float)num4;
			Color color6 = this.Labels[2].color = color5;
		}
		if (PlayerPrefs.GetInt("Scheme_3_Stage") == 4)
		{
			int num6 = 1;
			Color color7 = this.Labels[3].color;
			float num7 = color7.a = (float)num6;
			Color color8 = this.Labels[3].color = color7;
		}
		if (PlayerPrefs.GetInt("Scheme_4_Stage") == 5)
		{
			int num8 = 1;
			Color color9 = this.Labels[4].color;
			float num9 = color9.a = (float)num8;
			Color color10 = this.Labels[4].color = color9;
		}
		if (PlayerPrefs.GetInt("Scheme_5_Stage") == 6)
		{
			int num10 = 1;
			Color color11 = this.Labels[5].color;
			float num11 = color11.a = (float)num10;
			Color color12 = this.Labels[5].color = color11;
		}
	}

	// Token: 0x060002BE RID: 702 RVA: 0x00035C10 File Offset: 0x00033E10
	public virtual void UpdateHighlight()
	{
		if (this.Selected < 1)
		{
			this.Selected = 7;
		}
		else if (this.Selected > 7)
		{
			this.Selected = 1;
		}
		int num = 200 - 50 * this.Selected;
		Vector3 localPosition = this.Highlight.transform.localPosition;
		float num2 = localPosition.y = (float)num;
		Vector3 vector = this.Highlight.transform.localPosition = localPosition;
	}

	// Token: 0x060002BF RID: 703 RVA: 0x00035C90 File Offset: 0x00033E90
	public virtual void LateUpdate()
	{
		if (this.Angry)
		{
			this.Anger = Mathf.Lerp(this.Anger, (float)100, Time.deltaTime);
			this.Face.SetBlendShapeWeight(1, this.Anger);
			this.Face.SetBlendShapeWeight(5, this.Anger);
			this.Face.SetBlendShapeWeight(9, this.Anger);
		}
		else
		{
			this.Anger = Mathf.Lerp(this.Anger, (float)0, Time.deltaTime);
			this.Face.SetBlendShapeWeight(1, this.Anger);
			this.Face.SetBlendShapeWeight(5, this.Anger);
			this.Face.SetBlendShapeWeight(9, this.Anger);
		}
		if (!this.LookAtPlayer)
		{
			this.LookAtTarget = Vector3.Lerp(this.LookAtTarget, this.Default.position, Time.deltaTime * (float)2);
		}
		else
		{
			this.LookAtTarget = Vector3.Lerp(this.LookAtTarget, this.Yandere.Head.position, Time.deltaTime * (float)2);
		}
		this.Head.LookAt(this.LookAtTarget);
	}

	// Token: 0x060002C0 RID: 704 RVA: 0x00035DBC File Offset: 0x00033FBC
	public virtual void Main()
	{
	}

	// Token: 0x04000665 RID: 1637
	public CutsceneManagerScript CutsceneManager;

	// Token: 0x04000666 RID: 1638
	public StudentManagerScript StudentManager;

	// Token: 0x04000667 RID: 1639
	public InputManagerScript InputManager;

	// Token: 0x04000668 RID: 1640
	public PromptBarScript PromptBar;

	// Token: 0x04000669 RID: 1641
	public EndOfDayScript EndOfDay;

	// Token: 0x0400066A RID: 1642
	public SubtitleScript Subtitle;

	// Token: 0x0400066B RID: 1643
	public SchemesScript Schemes;

	// Token: 0x0400066C RID: 1644
	public StudentScript Student;

	// Token: 0x0400066D RID: 1645
	public YandereScript Yandere;

	// Token: 0x0400066E RID: 1646
	public PromptScript Prompt;

	// Token: 0x0400066F RID: 1647
	public AudioClip[] CounselorGreetingClips;

	// Token: 0x04000670 RID: 1648
	public AudioClip[] CounselorLectureClips;

	// Token: 0x04000671 RID: 1649
	public AudioClip[] CounselorReportClips;

	// Token: 0x04000672 RID: 1650
	public AudioClip[] RivalClips;

	// Token: 0x04000673 RID: 1651
	public AudioClip CounselorFarewellClip;

	// Token: 0x04000674 RID: 1652
	public string CounselorFarewellText;

	// Token: 0x04000675 RID: 1653
	public AudioClip CounselorBusyClip;

	// Token: 0x04000676 RID: 1654
	public string CounselorBusyText;

	// Token: 0x04000677 RID: 1655
	public string[] CounselorGreetingText;

	// Token: 0x04000678 RID: 1656
	public string[] CounselorLectureText;

	// Token: 0x04000679 RID: 1657
	public string[] CounselorReportText;

	// Token: 0x0400067A RID: 1658
	public string[] LectureIntro;

	// Token: 0x0400067B RID: 1659
	public string[] RivalText;

	// Token: 0x0400067C RID: 1660
	public UILabel[] Labels;

	// Token: 0x0400067D RID: 1661
	public Transform CounselorWindow;

	// Token: 0x0400067E RID: 1662
	public Transform Highlight;

	// Token: 0x0400067F RID: 1663
	public Transform Chibi;

	// Token: 0x04000680 RID: 1664
	public SkinnedMeshRenderer Face;

	// Token: 0x04000681 RID: 1665
	public UILabel CounselorSubtitle;

	// Token: 0x04000682 RID: 1666
	public UISprite EndOfDayDarkness;

	// Token: 0x04000683 RID: 1667
	public UILabel LectureSubtitle;

	// Token: 0x04000684 RID: 1668
	public UISprite ExpelProgress;

	// Token: 0x04000685 RID: 1669
	public UILabel LectureLabel;

	// Token: 0x04000686 RID: 1670
	public bool ShowWindow;

	// Token: 0x04000687 RID: 1671
	public bool Lecturing;

	// Token: 0x04000688 RID: 1672
	public bool Angry;

	// Token: 0x04000689 RID: 1673
	public bool Busy;

	// Token: 0x0400068A RID: 1674
	public int Selected;

	// Token: 0x0400068B RID: 1675
	public int LecturePhase;

	// Token: 0x0400068C RID: 1676
	public int LectureID;

	// Token: 0x0400068D RID: 1677
	public float Anger;

	// Token: 0x0400068E RID: 1678
	public float ExpelTimer;

	// Token: 0x0400068F RID: 1679
	public float ChinTimer;

	// Token: 0x04000690 RID: 1680
	public float Timer;

	// Token: 0x04000691 RID: 1681
	public Vector3 LookAtTarget;

	// Token: 0x04000692 RID: 1682
	public bool LookAtPlayer;

	// Token: 0x04000693 RID: 1683
	public Transform Default;

	// Token: 0x04000694 RID: 1684
	public Transform Head;
}
