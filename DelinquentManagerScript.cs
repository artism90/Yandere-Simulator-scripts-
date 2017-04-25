using System;
using UnityEngine;
using UnityScript.Lang;

// Token: 0x02000078 RID: 120
[Serializable]
public class DelinquentManagerScript : MonoBehaviour
{
	// Token: 0x060002EF RID: 751 RVA: 0x0003C654 File Offset: 0x0003A854
	public DelinquentManagerScript()
	{
		this.Phase = 1;
	}

	// Token: 0x060002F0 RID: 752 RVA: 0x0003C664 File Offset: 0x0003A864
	public virtual void Start()
	{
		this.Delinquents.active = false;
		this.TimerMax = (float)15;
		this.Timer = (float)15;
		this.Phase++;
	}

	// Token: 0x060002F1 RID: 753 RVA: 0x0003C6A0 File Offset: 0x0003A8A0
	public virtual void Update()
	{
		this.SpeechTimer = Mathf.MoveTowards(this.SpeechTimer, (float)0, Time.deltaTime);
		if (this.Attacker != null && !this.Attacker.Attacking && this.Attacker.ExpressedSurprise && this.Attacker.Run && !this.Aggro)
		{
			this.audio.clip = this.Attacker.AggroClips[UnityEngine.Random.Range(0, Extensions.get_length(this.Attacker.AggroClips))];
			this.audio.Play();
			this.Aggro = true;
		}
		if (this.Panel.active && this.Clock.HourTime > this.NextTime[this.Phase])
		{
			if (this.Phase == 3 && this.Clock.HourTime > 7.25f)
			{
				this.TimerMax = (float)75;
				this.Timer = (float)75;
				this.Phase++;
			}
			else if (this.Phase == 5 && this.Clock.HourTime > 8.5f)
			{
				this.TimerMax = (float)285;
				this.Timer = (float)285;
				this.Phase++;
			}
			else if (this.Phase == 7 && this.Clock.HourTime > 13.25f)
			{
				this.TimerMax = (float)15;
				this.Timer = (float)15;
				this.Phase++;
			}
			else if (this.Phase == 9 && this.Clock.HourTime > 13.5f)
			{
				this.TimerMax = (float)135;
				this.Timer = (float)135;
				this.Phase++;
			}
			this.Timer -= Time.deltaTime * (this.Clock.TimeSpeed / (float)60);
			this.Circle.fillAmount = (float)1 - this.Timer / this.TimerMax;
			if (this.Timer <= (float)0)
			{
				if (this.Delinquents.active)
				{
					this.Delinquents.active = false;
				}
				else
				{
					this.Delinquents.active = true;
				}
				if (this.Phase < 8)
				{
					this.Phase++;
				}
				else
				{
					this.Delinquents.active = false;
					this.Panel.active = false;
				}
			}
		}
	}

	// Token: 0x060002F2 RID: 754 RVA: 0x0003C950 File Offset: 0x0003AB50
	public virtual void CheckTime()
	{
		if (this.Clock.HourTime < (float)13)
		{
			this.Delinquents.active = false;
			this.TimerMax = (float)15;
			this.Timer = (float)15;
			this.Phase = 6;
		}
		else if (this.Clock.HourTime < 15.5f)
		{
			this.Delinquents.active = false;
			this.TimerMax = (float)15;
			this.Timer = (float)15;
			this.Phase = 8;
		}
	}

	// Token: 0x060002F3 RID: 755 RVA: 0x0003C9D4 File Offset: 0x0003ABD4
	public virtual void Main()
	{
	}

	// Token: 0x0400074C RID: 1868
	public GameObject Delinquents;

	// Token: 0x0400074D RID: 1869
	public GameObject Panel;

	// Token: 0x0400074E RID: 1870
	public float[] NextTime;

	// Token: 0x0400074F RID: 1871
	public DelinquentScript Attacker;

	// Token: 0x04000750 RID: 1872
	public UILabel TimeLabel;

	// Token: 0x04000751 RID: 1873
	public ClockScript Clock;

	// Token: 0x04000752 RID: 1874
	public UISprite Circle;

	// Token: 0x04000753 RID: 1875
	public float SpeechTimer;

	// Token: 0x04000754 RID: 1876
	public float TimerMax;

	// Token: 0x04000755 RID: 1877
	public float Timer;

	// Token: 0x04000756 RID: 1878
	public bool Aggro;

	// Token: 0x04000757 RID: 1879
	public int Phase;
}
