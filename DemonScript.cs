using System;
using UnityEngine;

// Token: 0x0200007C RID: 124
[Serializable]
public class DemonScript : MonoBehaviour
{
	// Token: 0x06000301 RID: 769 RVA: 0x0003DF8C File Offset: 0x0003C18C
	public DemonScript()
	{
		this.Intensity = 1f;
		this.Phase = 1;
	}

	// Token: 0x06000302 RID: 770 RVA: 0x0003DFA8 File Offset: 0x0003C1A8
	public virtual void Update()
	{
		if (this.Prompt.Circle[0].fillAmount <= (float)0)
		{
			this.Yandere.Character.animation.CrossFade(this.Yandere.IdleAnim);
			this.Yandere.CanMove = false;
			this.Communing = true;
		}
		if (this.Communing)
		{
			if (this.Phase == 1)
			{
				float a = Mathf.MoveTowards(this.Darkness.color.a, (float)1, Time.deltaTime);
				Color color = this.Darkness.color;
				float num = color.a = a;
				Color color2 = this.Darkness.color = color;
				if (this.Darkness.color.a == (float)1)
				{
					this.DemonSubtitle.transform.localPosition = new Vector3((float)0, (float)0, (float)0);
					this.DemonSubtitle.text = this.Lines[this.ID];
					this.DemonSubtitle.color = this.MyColor;
					int num2 = 0;
					Color color3 = this.DemonSubtitle.color;
					float num3 = color3.a = (float)num2;
					Color color4 = this.DemonSubtitle.color = color3;
					this.Phase++;
					if (this.Clips[this.ID] != null)
					{
						this.audio.clip = this.Clips[this.ID];
						this.audio.Play();
					}
				}
			}
			else if (this.Phase == 2)
			{
				this.DemonSubtitle.transform.localPosition = new Vector3(UnityEngine.Random.Range(-1f * this.Intensity, this.Intensity), UnityEngine.Random.Range(-1f * this.Intensity, this.Intensity), UnityEngine.Random.Range(-1f * this.Intensity, this.Intensity));
				float a2 = Mathf.MoveTowards(this.DemonSubtitle.color.a, (float)1, Time.deltaTime);
				Color color5 = this.DemonSubtitle.color;
				float num4 = color5.a = a2;
				Color color6 = this.DemonSubtitle.color = color5;
				float a3 = Mathf.MoveTowards(this.Button.color.a, (float)1, Time.deltaTime);
				Color color7 = this.Button.color;
				float num5 = color7.a = a3;
				Color color8 = this.Button.color = color7;
				if (this.DemonSubtitle.color.a == (float)1 && Input.GetButtonDown("A"))
				{
					this.Phase++;
				}
			}
			else if (this.Phase == 3)
			{
				this.DemonSubtitle.transform.localPosition = new Vector3(UnityEngine.Random.Range(-1f * this.Intensity, this.Intensity), UnityEngine.Random.Range(-1f * this.Intensity, this.Intensity), UnityEngine.Random.Range(-1f * this.Intensity, this.Intensity));
				float a4 = Mathf.MoveTowards(this.DemonSubtitle.color.a, (float)0, Time.deltaTime);
				Color color9 = this.DemonSubtitle.color;
				float num6 = color9.a = a4;
				Color color10 = this.DemonSubtitle.color = color9;
				if (this.DemonSubtitle.color.a == (float)0)
				{
					this.ID++;
					if (this.ID < this.Lines.Length)
					{
						this.Phase--;
						this.DemonSubtitle.text = this.Lines[this.ID];
						if (this.Clips[this.ID] != null)
						{
							this.audio.clip = this.Clips[this.ID];
							this.audio.Play();
						}
					}
					else
					{
						this.Phase++;
					}
				}
			}
			else
			{
				float a5 = Mathf.MoveTowards(this.Darkness.color.a, (float)0, Time.deltaTime);
				Color color11 = this.Darkness.color;
				float num7 = color11.a = a5;
				Color color12 = this.Darkness.color = color11;
				float a6 = Mathf.MoveTowards(this.Button.color.a, (float)0, Time.deltaTime);
				Color color13 = this.Button.color;
				float num8 = color13.a = a6;
				Color color14 = this.Button.color = color13;
				if (this.Darkness.color.a == (float)0)
				{
					this.Yandere.CanMove = true;
					this.Communing = false;
					this.Phase = 1;
					this.ID = 0;
					PlayerPrefs.SetInt("Demon_" + this.DemonID + "_Active", 1);
					PlayerPrefs.SetInt("Paranormal", 1);
				}
			}
		}
	}

	// Token: 0x06000303 RID: 771 RVA: 0x0003E520 File Offset: 0x0003C720
	public virtual void Main()
	{
	}

	// Token: 0x0400079B RID: 1947
	public YandereScript Yandere;

	// Token: 0x0400079C RID: 1948
	public PromptScript Prompt;

	// Token: 0x0400079D RID: 1949
	public UILabel DemonSubtitle;

	// Token: 0x0400079E RID: 1950
	public UISprite Darkness;

	// Token: 0x0400079F RID: 1951
	public UISprite Button;

	// Token: 0x040007A0 RID: 1952
	public AudioClip[] Clips;

	// Token: 0x040007A1 RID: 1953
	public string[] Lines;

	// Token: 0x040007A2 RID: 1954
	public bool Communing;

	// Token: 0x040007A3 RID: 1955
	public float Intensity;

	// Token: 0x040007A4 RID: 1956
	public Color MyColor;

	// Token: 0x040007A5 RID: 1957
	public int DemonID;

	// Token: 0x040007A6 RID: 1958
	public int Phase;

	// Token: 0x040007A7 RID: 1959
	public int ID;
}
