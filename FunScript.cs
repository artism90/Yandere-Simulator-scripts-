using System;
using UnityEngine;
using UnityScript.Lang;

// Token: 0x02000099 RID: 153
[Serializable]
public class FunScript : MonoBehaviour
{
	// Token: 0x0600037C RID: 892 RVA: 0x00047A20 File Offset: 0x00045C20
	public virtual void Start()
	{
		this.Controls.active = false;
		int num = 0;
		Color color = this.Girl.color;
		float num2 = color.a = (float)num;
		Color color2 = this.Girl.color = color;
		this.Label.text = this.Lines[this.ID];
		this.Label.gameObject.active = false;
	}

	// Token: 0x0600037D RID: 893 RVA: 0x00047A94 File Offset: 0x00045C94
	public virtual void Update()
	{
		this.Timer += Time.deltaTime;
		if (this.Timer > (float)3)
		{
			if (!this.Typewriter.mActive)
			{
				this.Controls.active = true;
			}
		}
		else if (this.Timer > (float)2)
		{
			this.Label.gameObject.active = true;
		}
		else if (this.Timer > (float)1)
		{
			float a = Mathf.MoveTowards(this.Girl.color.a, (float)1, Time.deltaTime);
			Color color = this.Girl.color;
			float num = color.a = a;
			Color color2 = this.Girl.color = color;
		}
		if (this.Controls.active)
		{
			if (Input.GetButtonDown("B"))
			{
				if (this.Skip.active)
				{
					this.ID = 19;
					this.Skip.active = false;
					this.Girl.mainTexture = this.Portraits[this.ID];
					this.Typewriter.ResetToBeginning();
					this.Typewriter.mLabel.text = this.Lines[this.ID];
				}
			}
			else if (Input.GetButtonDown("A"))
			{
				if (this.ID < Extensions.get_length(this.Lines) - 1)
				{
					if (this.Typewriter.mCurrentOffset < this.Typewriter.mFullText.Length)
					{
						this.Typewriter.Finish();
					}
					else
					{
						this.ID++;
						if (this.ID == 19)
						{
							this.Skip.active = false;
						}
						this.Girl.mainTexture = this.Portraits[this.ID];
						this.Typewriter.ResetToBeginning();
						this.Typewriter.mLabel.text = this.Lines[this.ID];
					}
				}
				else
				{
					Application.Quit();
				}
			}
		}
	}

	// Token: 0x0600037E RID: 894 RVA: 0x00047CB4 File Offset: 0x00045EB4
	public virtual void Main()
	{
	}

	// Token: 0x040008B3 RID: 2227
	public TypewriterEffect Typewriter;

	// Token: 0x040008B4 RID: 2228
	public GameObject Controls;

	// Token: 0x040008B5 RID: 2229
	public GameObject Skip;

	// Token: 0x040008B6 RID: 2230
	public Texture[] Portraits;

	// Token: 0x040008B7 RID: 2231
	public string[] Lines;

	// Token: 0x040008B8 RID: 2232
	public UITexture Girl;

	// Token: 0x040008B9 RID: 2233
	public UILabel Label;

	// Token: 0x040008BA RID: 2234
	public float OutroTimer;

	// Token: 0x040008BB RID: 2235
	public float Timer;

	// Token: 0x040008BC RID: 2236
	public int ID;
}
