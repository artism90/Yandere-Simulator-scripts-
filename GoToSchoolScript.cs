using System;
using UnityEngine;

// Token: 0x02000004 RID: 4
[Serializable]
public class GoToSchoolScript : MonoBehaviour
{
	// Token: 0x0600000C RID: 12 RVA: 0x00002BB8 File Offset: 0x00000DB8
	public virtual void Start()
	{
		this.ControlsWindow.active = false;
		this.Bloom.bloomIntensity = (float)10;
	}

	// Token: 0x0600000D RID: 13 RVA: 0x00002BD4 File Offset: 0x00000DD4
	public virtual void Update()
	{
		this.ButtonParent.transform.LookAt(Camera.main.transform.position);
		if (Input.GetKeyDown("c"))
		{
			if (this.ControlsWindow.active)
			{
				this.ControlsWindow.active = false;
			}
			else
			{
				this.ControlsWindow.active = true;
			}
		}
		if (Vector3.Distance(this.Yandere.position, this.transform.position) < (float)1)
		{
			this.Button.color = new Color((float)1, (float)1, (float)1, (float)1);
			if (Input.GetButtonDown("A"))
			{
				this.FadeOut = true;
				this.TimerLabel.color = new Color((float)1, (float)0, (float)0, (float)1);
			}
		}
		else if (Vector3.Distance(this.Yandere.position, this.transform.position) < (float)5)
		{
			this.Button.color = new Color(0.5f, 0.5f, 0.5f, (float)1);
		}
		else
		{
			int num = 0;
			Color color = this.Button.color;
			float num2 = color.a = (float)num;
			Color color2 = this.Button.color = color;
		}
		if (!this.FadeOut)
		{
			this.Bloom.bloomIntensity = Mathf.MoveTowards(this.Bloom.bloomIntensity, 0.1f, Time.deltaTime * (float)10);
			this.Timer += Time.deltaTime;
			this.TimerLabel.text = "Time taken to get to school: " + this.Timer.ToString("F2");
		}
		else
		{
			this.Bloom.bloomIntensity = Mathf.MoveTowards(this.Bloom.bloomIntensity, (float)10, Time.deltaTime * (float)10);
			if (this.Bloom.bloomIntensity == (float)10)
			{
				Application.LoadLevel("SchoolScene");
			}
		}
	}

	// Token: 0x0600000E RID: 14 RVA: 0x00002DD8 File Offset: 0x00000FD8
	public virtual void Main()
	{
	}

	// Token: 0x04000027 RID: 39
	public GameObject ControlsWindow;

	// Token: 0x04000028 RID: 40
	public Transform ButtonParent;

	// Token: 0x04000029 RID: 41
	public Transform Yandere;

	// Token: 0x0400002A RID: 42
	public UILabel TimerLabel;

	// Token: 0x0400002B RID: 43
	public UISprite Button;

	// Token: 0x0400002C RID: 44
	public Bloom Bloom;

	// Token: 0x0400002D RID: 45
	public bool FadeOut;

	// Token: 0x0400002E RID: 46
	public float Timer;
}
