using System;
using UnityEngine;

// Token: 0x02000075 RID: 117
[Serializable]
public class CutsceneManagerScript : MonoBehaviour
{
	// Token: 0x060002D8 RID: 728 RVA: 0x00038518 File Offset: 0x00036718
	public CutsceneManagerScript()
	{
		this.Phase = 1;
		this.Line = 1;
	}

	// Token: 0x060002D9 RID: 729 RVA: 0x00038530 File Offset: 0x00036730
	public virtual void Update()
	{
		if (this.Phase == 1)
		{
			float a = Mathf.MoveTowards(this.Darkness.color.a, (float)1, Time.deltaTime);
			Color color = this.Darkness.color;
			float num = color.a = a;
			Color color2 = this.Darkness.color = color;
			if (this.Darkness.color.a == (float)1)
			{
				this.Phase++;
			}
		}
		else if (this.Phase == 2)
		{
			this.Subtitle.text = this.Text[this.Line];
			this.audio.clip = this.Voice[this.Line];
			this.audio.Play();
			this.Phase++;
		}
		else if (this.Phase == 3)
		{
			if (!this.audio.isPlaying || Input.GetButtonDown("A"))
			{
				if (this.Line < 2)
				{
					this.Phase--;
					this.Line++;
				}
				else
				{
					this.Subtitle.text = string.Empty;
					this.Phase++;
				}
			}
		}
		else if (this.Phase == 4)
		{
			this.EndOfDay.gameObject.active = true;
			this.EndOfDay.Phase = 10;
			this.Counselor.LecturePhase = 5;
			this.Phase++;
		}
		else if (this.Phase == 6)
		{
			float a2 = Mathf.MoveTowards(this.Darkness.color.a, (float)0, Time.deltaTime);
			Color color3 = this.Darkness.color;
			float num2 = color3.a = a2;
			Color color4 = this.Darkness.color = color3;
			if (this.Darkness.color.a == (float)0)
			{
				this.Phase++;
			}
		}
		else if (this.Phase == 7)
		{
			if (this.StudentManager.Students[7] != null)
			{
				UnityEngine.Object.Destroy(this.StudentManager.Students[7].gameObject);
			}
			this.PromptBar.ClearButtons();
			this.PromptBar.Show = false;
			this.Portal.Proceed = true;
			this.active = false;
		}
	}

	// Token: 0x060002DA RID: 730 RVA: 0x000387D8 File Offset: 0x000369D8
	public virtual void Main()
	{
	}

	// Token: 0x040006DE RID: 1758
	public StudentManagerScript StudentManager;

	// Token: 0x040006DF RID: 1759
	public CounselorScript Counselor;

	// Token: 0x040006E0 RID: 1760
	public PromptBarScript PromptBar;

	// Token: 0x040006E1 RID: 1761
	public EndOfDayScript EndOfDay;

	// Token: 0x040006E2 RID: 1762
	public PortalScript Portal;

	// Token: 0x040006E3 RID: 1763
	public UISprite Darkness;

	// Token: 0x040006E4 RID: 1764
	public UILabel Subtitle;

	// Token: 0x040006E5 RID: 1765
	public AudioClip[] Voice;

	// Token: 0x040006E6 RID: 1766
	public string[] Text;

	// Token: 0x040006E7 RID: 1767
	public int Phase;

	// Token: 0x040006E8 RID: 1768
	public int Line;
}
