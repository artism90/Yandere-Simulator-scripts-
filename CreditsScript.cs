using System;
using UnityEngine;
using UnityScript.Lang;

// Token: 0x02000072 RID: 114
[Serializable]
public class CreditsScript : MonoBehaviour
{
	// Token: 0x060002C6 RID: 710 RVA: 0x00035EE8 File Offset: 0x000340E8
	public virtual void Start()
	{
		this.ID = 1;
		while (this.ID < Extensions.get_length(this.Lines))
		{
			this.Lines[this.ID] = this.JSON.CreditsNames[this.ID];
			this.ID++;
		}
		this.ID = 1;
		while (this.ID < Extensions.get_length(this.Sizes))
		{
			this.Sizes[this.ID] = this.JSON.CreditsSizes[this.ID];
			this.ID++;
		}
		this.ID = 1;
	}

	// Token: 0x060002C7 RID: 711 RVA: 0x00035F9C File Offset: 0x0003419C
	public virtual void Update()
	{
		if (!this.audio.isPlaying)
		{
			this.Timer += Time.deltaTime;
			if (this.Timer > (float)1)
			{
				this.audio.Play();
				this.Timer = (float)0;
			}
		}
		if (this.audio.time > 1.5f && !this.FadeAudio)
		{
			if (this.Timer == (float)0)
			{
				if (this.Sizes[this.ID] == 1)
				{
					this.NewCreditsLabel = (GameObject)UnityEngine.Object.Instantiate(this.SmallCreditsLabel, this.SpawnPoint.position, Quaternion.identity);
					this.TimerLimit = (float)1;
				}
				else
				{
					this.NewCreditsLabel = (GameObject)UnityEngine.Object.Instantiate(this.BigCreditsLabel, this.SpawnPoint.position, Quaternion.identity);
					this.TimerLimit = (float)this.Sizes[this.ID];
				}
				this.NewCreditsLabel.transform.parent = this.Panel;
				this.NewCreditsLabel.transform.localScale = new Vector3((float)1, (float)1, (float)1);
				((UILabel)this.NewCreditsLabel.GetComponent(typeof(UILabel))).text = this.Lines[this.ID];
				this.ID++;
				if (this.ID > Extensions.get_length(this.Sizes) - 1)
				{
					this.FadeAudio = true;
				}
			}
			this.Timer = Mathf.MoveTowards(this.Timer, this.TimerLimit, Time.deltaTime);
			if (this.Timer >= this.TimerLimit)
			{
				this.Timer = (float)0;
			}
		}
		if (this.FadeAudio)
		{
			this.FadeTimer += Time.deltaTime;
			if (this.FadeTimer > (float)14)
			{
				this.audio.volume = this.audio.volume - Time.deltaTime;
			}
		}
		if (Input.GetButtonDown("B") || this.audio.volume == (float)0)
		{
			this.FadeOut = true;
		}
		if (this.FadeOut)
		{
			float a = Mathf.MoveTowards(this.Darkness.color.a, (float)1, Time.deltaTime);
			Color color = this.Darkness.color;
			float num = color.a = a;
			Color color2 = this.Darkness.color = color;
			this.audio.volume = this.audio.volume - Time.deltaTime;
			if (this.Darkness.color.a == (float)1)
			{
				Application.LoadLevel("TitleScene");
			}
		}
		if (Input.GetKeyDown("-"))
		{
			Time.timeScale -= (float)1;
			this.audio.pitch = Time.timeScale;
		}
		if (Input.GetKeyDown("="))
		{
			Time.timeScale += (float)1;
			this.audio.pitch = Time.timeScale;
		}
	}

	// Token: 0x060002C8 RID: 712 RVA: 0x000362BC File Offset: 0x000344BC
	public virtual void Main()
	{
	}

	// Token: 0x04000698 RID: 1688
	public JsonScript JSON;

	// Token: 0x04000699 RID: 1689
	public Transform SpawnPoint;

	// Token: 0x0400069A RID: 1690
	public Transform Panel;

	// Token: 0x0400069B RID: 1691
	private GameObject NewCreditsLabel;

	// Token: 0x0400069C RID: 1692
	public GameObject SmallCreditsLabel;

	// Token: 0x0400069D RID: 1693
	public GameObject BigCreditsLabel;

	// Token: 0x0400069E RID: 1694
	public UISprite Darkness;

	// Token: 0x0400069F RID: 1695
	public string[] Lines;

	// Token: 0x040006A0 RID: 1696
	public int[] Sizes;

	// Token: 0x040006A1 RID: 1697
	public int ID;

	// Token: 0x040006A2 RID: 1698
	public float TimerLimit;

	// Token: 0x040006A3 RID: 1699
	public float FadeTimer;

	// Token: 0x040006A4 RID: 1700
	public float Timer;

	// Token: 0x040006A5 RID: 1701
	public bool FadeAudio;

	// Token: 0x040006A6 RID: 1702
	public bool FadeOut;

	// Token: 0x040006A7 RID: 1703
	public bool Begin;
}
